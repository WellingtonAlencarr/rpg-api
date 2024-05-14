using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RpgApi.Data;
using Microsoft.EntityFrameworkCore;
using RpgApi.Models;
using RpgApi.Utils;

namespace RpgApi.Controllers
{
    [Route("[controller]")]
    public class UsuariosController : Controller
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        private async Task<bool> UsuarioExistente(string username)
        {
            if (await _context.TB_USUARIOS.AnyAsync(x => x.UserName.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        [HttpPost("Registrar")]

        public async Task<IActionResult> RegistrarUsuario(Usuario user)
        {
            try
            {
                if (await UsuarioExistente(user.UserName))
                    throw new System.Exception("Nome de Usuario já existente");

                Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                user.PasswordString = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                await _context.TB_USUARIOS.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario? usuario = await _context.TB_USUARIOS
                        .FirstOrDefaultAsync(x => x.UserName.ToLower().Equals(credenciais.UserName.ToLower()));
                if (usuario == null)
                {
                    throw new System.Exception("Usuario não encontrado");
                }
                else if (!Criptografia
                        .VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta");
                }
                else
                {
                    usuario.DataAcesso = System.DateTime.Now;
                    _context.TB_USUARIOS.Update(usuario);
                    await _context.SaveChangesAsync();

                    return Ok(usuario);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Usuario> lista = await _context.TB_USUARIOS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> AlterarSenha(Usuario s)
        {

            Criptografia.CriarPasswordHash(s.PasswordString, out byte[] hash, out byte[] salt);
            s.PasswordString = string.Empty;
            s.PasswordHash = hash;
            s.PasswordSalt = salt;

            _context.TB_USUARIOS.Update(s);
            int linhasAfetadas = await _context.SaveChangesAsync();

            return Ok(linhasAfetadas);
        }


        [HttpGet("{id}")] //Buscar pelo ID
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {

                Personagem p = await _context.TB_PERSONAGENS
                .Include(ar => ar.Arma) // Carrega a propriedade  Arma do objeto p
                .Include(us => us.Usuario)
                .Include(ph => ph.PersonagemHabilidades)
                .ThenInclude(h => h.Habilidade) //Carrega a lista de personagemHabilidade de  p
                .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(p);

            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}