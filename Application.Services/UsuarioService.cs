using Data;
using Domain.Model;
using DTOs;
using Microsoft.Extensions.Configuration; // <-- Añadido
using Microsoft.IdentityModel.Tokens;   // <-- Añadido
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;  // <-- Añadido
using System.Linq;
using System.Security.Claims;           // <-- Añadido
using System.Text;                      // <-- Añadido

namespace Application.Services
{
    public class UsuarioService
    {
        // --- MÉTODO NUEVO PARA LOGIN Y GENERACIÓN DE TOKEN ---
        public string? ValidarYGenerarToken(string email, string contrasena, IConfiguration configuration)
        {
            var usuarioRepository = new UsuarioRepository();
            var usuario = usuarioRepository.Login(email, contrasena);

            if (usuario == null)
            {
                return null; // Si el login falla, devuelve null
            }

            // Si el login es exitoso, generamos el token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(ClaimTypes.Name, $"{usuario.Nombre} {usuario.Apellido}"), // Nombre completo del usuario
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, usuario.EsAdmin ? "Admin" : "User") // Rol para autorización
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(configuration["JwtSettings:ExpirationMinutes"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JwtSettings:Issuer"],
                audience: configuration["JwtSettings:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // --- MÉTODOS CRUD (se mantienen como estaban) ---

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
                Contrasena = "", // Por seguridad, no devolvemos la contraseña
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
                Contrasena = "", // Por seguridad, no devolvemos la contraseña
                FechaAlta = usuario.FechaAlta,
                EsAdmin = usuario.EsAdmin
            };
        }

        public UsuarioDTO Add(UsuarioDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();

            if (usuarioRepository.EmailExists(dto.Email))
            {
                throw new ArgumentException($"Ya existe un usuario con el Email '{dto.Email}'.");
            }

            var fechaAlta = DateTime.Now;
            var usuario = new Usuario(0, dto.Nombre, dto.Apellido, dto.Email, dto.Contrasena, fechaAlta, dto.EsAdmin);

            usuarioRepository.Add(usuario);

            dto.Id = usuario.Id;
            dto.FechaAlta = usuario.FechaAlta;
            dto.Contrasena = ""; // No devolvemos la contraseña

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
            var usuario = usuarioRepository.Get(dto.Id);

            if (usuario == null) return false;

            if (usuarioRepository.EmailExists(dto.Email, dto.Id))
            {
                throw new ArgumentException($"Ya existe otro usuario con el Email '{dto.Email}'.");
            }

            usuario.SetNombre(dto.Nombre);
            usuario.SetApellido(dto.Apellido);
            usuario.SetEmail(dto.Email);

            // Solo actualizamos la contraseña si se provee una nueva
            if (!string.IsNullOrWhiteSpace(dto.Contrasena))
            {
                usuario.SetContrasena(dto.Contrasena);
            }

            // Asumimos que la fecha de alta y el rol de admin se pueden cambiar
            usuario.SetFechaAlta(dto.FechaAlta);
            usuario.SetEsAdmin(dto.EsAdmin);

            return usuarioRepository.Update(usuario);
        }
    }
}