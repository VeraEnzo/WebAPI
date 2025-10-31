using Data;
using Domain.Model;
using DTOs; // Asegúrate de tener este using
using System;
using System.Collections.Generic; // Necesario para List<T>
using System.Linq; // Necesario para .Select()

namespace Application.Services
{
    public class CategoriaService
    {
        public CategoriaDTO Add(CategoriaDTO dto)
        {
            var categoriaRepository = new CategoriaRepository();
            if (categoriaRepository.NombreExists(dto.Nombre))
            {
                throw new ArgumentException($"Ya existe una categoría con el nombre '{dto.Nombre}'.");
            }

            // --- CORREGIDO: Se pasa la descripción al constructor ---
            var categoria = new Categoria(0, dto.Nombre, dto.Descripcion);
            // El estado 'Activo' se establece en true por defecto en el constructor del Dominio

            categoriaRepository.Add(categoria);
            dto.Id = categoria.Id; // El ID es asignado por la BD
            dto.Activo = categoria.Activo; // Asignamos el estado inicial
            return dto;
        }

        public List<CategoriaDTO> GetAll()
        {
            var categoriaRepository = new CategoriaRepository();
            // El repositorio ahora debería devolver solo las activas por defecto
            var categorias = categoriaRepository.GetAll();
            // Mapeamos incluyendo las nuevas propiedades
            return categorias.Select(c => new CategoriaDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                Activo = c.Activo
            }).ToList();
        }

        public CategoriaDTO? Get(int id)
        {
            var categoriaRepository = new CategoriaRepository();
            var categoria = categoriaRepository.Get(id);
            // Mapeamos incluyendo las nuevas propiedades
            return categoria == null ? null : new CategoriaDTO
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
                Activo = categoria.Activo
            };
        }

        public bool Update(CategoriaDTO dto)
        {
            var categoriaRepository = new CategoriaRepository();
            if (categoriaRepository.NombreExists(dto.Nombre, dto.Id))
            {
                throw new ArgumentException($"Ya existe otra categoría con el nombre '{dto.Nombre}'.");
            }

            var categoria = categoriaRepository.Get(dto.Id);
            if (categoria == null) return false;

            // Actualizamos Nombre y Descripción usando los métodos del dominio
            categoria.SetNombre(dto.Nombre);
            categoria.SetDescripcion(dto.Descripcion);

            // Actualizamos el estado Activo
            if (dto.Activo && !categoria.Activo)
            {
                categoria.Activar();
            }
            else if (!dto.Activo && categoria.Activo)
            {
                categoria.Desactivar();
            }

            return categoriaRepository.Update(categoria);
        }

        // Método para borrado lógico (recomendado)
        public bool Delete(int id)
        {
            var categoriaRepository = new CategoriaRepository();
            var categoria = categoriaRepository.Get(id);
            if (categoria == null) return false;

            // En lugar de borrar, desactivamos
            categoria.Desactivar();
            return categoriaRepository.Update(categoria); // Usamos Update para guardar el cambio de estado

            // Si quisieras un borrado físico (NO RECOMENDADO si hay productos asociados):
            // return categoriaRepository.Delete(id);
        }
        public List<CategoriaDTO> Buscar(string texto)
        {
            var categoriaRepository = new CategoriaRepository();
            var categorias = categoriaRepository.GetByCriteria(texto);

            // Mapear de Dominio a DTO
            return categorias.Select(c => new CategoriaDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                Activo = c.Activo
            }).ToList();
        }
    }
}