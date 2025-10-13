using Domain.Model;
using Data;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class UsuarioService
    {
        public UsuarioDTO? Validar(string email, string contrasena)
        {
            var usuarioRepository = new UsuarioRepository();
            var usuario = usuarioRepository.Login(email, contrasena);

            if (usuario == null)
                return null;

            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Contrasena = usuario.Contrasena,
                FechaAlta = usuario.FechaAlta,
                EsAdmin = usuario.EsAdmin
            };
        }

        public List<UsuarioDTO> GetAll()
        {
            var usuarioRepository = new UsuarioRepository();
            var usuarios = usuarioRepository.GetAll();

            return usuarios.Select(u => new UsuarioDTO
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Email = u.Email,
                Contrasena = u.Contrasena,
                FechaAlta = u.FechaAlta,
                EsAdmin = u.EsAdmin
            }).ToList();
        }
        public UsuarioDTO? Get(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            var usuario = usuarioRepository.Get(id); 

            if (usuario == null)
                return null;

            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Contrasena = usuario.Contrasena,
                FechaAlta = usuario.FechaAlta,
                EsAdmin = usuario.EsAdmin
            };
        }
        public UsuarioDTO Add(UsuarioDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();

            // Validar email duplicado
            if (usuarioRepository.EmailExists(dto.Email))
            {
                throw new ArgumentException($"Ya existe un usuario con el Email '{dto.Email}'.");
            }

            var fechaAlta = DateTime.Now;
            var usuario = new Usuario(0, dto.Nombre, dto.Apellido, dto.Email, dto.Contrasena, fechaAlta, dto.EsAdmin);

            usuarioRepository.Add(usuario);

            dto.Id = usuario.Id;
            dto.FechaAlta = usuario.FechaAlta;

            return dto;
        }

        public bool Delete(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            return usuarioRepository.Delete(id);
        }

        public bool Update(UsuarioDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();

            // Validar email duplicado
            if (usuarioRepository.EmailExists(dto.Email, dto.Id))
            {
                throw new ArgumentException($"Ya existe otro usuario con el Email '{dto.Email}'.");
            }

            var usuario = new Usuario(dto.Id, dto.Nombre, dto.Apellido, dto.Email, dto.Contrasena, dto.FechaAlta, dto.EsAdmin);

            return usuarioRepository.Update(usuario);
        }
    }
}
