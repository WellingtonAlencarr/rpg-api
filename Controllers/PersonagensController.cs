using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagensController : ControllerBase
    {
        private readonly DataContext _context; // context é usado para visualizar uma variável global

        public PersonagensController(DataContext context)
        {
            //Inicialização desta base de dados personagens a partir do contexto da program.cs
            _context = context;
        }

        [HttpGet("{id}")] //Buscar pelo ID
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {

                Personagem p = await _context.TB_PERSONAGENS
                    .Include(ar => ar.Arma) // Carrega a propriedade  Arma do objeto p
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

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
                 try
         {
                    List<Personagem> lista = await _context.TB_PERSONAGENS.ToListAsync();
                    return Ok(lista);
          }
        catch (System.Exception ex)
           {
                    return BadRequest(ex.Message);
                    
            }
        }
        [HttpPost]

        public async Task<IActionResult> Add(Personagem novoPersonagem)
        {
            try
            {
                if (novoPersonagem.PontosVida > 100)
                {
                    throw new Exception ("Pontos de vida não pode ser maior que 100");
                }
                await _context.TB_PERSONAGENS.AddAsync(novoPersonagem);
                await _context.SaveChangesAsync();

                return Ok(novoPersonagem.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]

        public async Task<IActionResult> Update(Personagem novoPersonagem)
        {
            try
            {
                if (novoPersonagem.PontosVida > 100)
                {
                    throw new System.Exception ("Pontos de vida não pode ser maior que 100");
                }
                _context.TB_PERSONAGENS.Update(novoPersonagem);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       [HttpDelete("id")]

       public async Task<IActionResult> Delete(int id)
       {
        try
        {
            Personagem pRemover = await _context.TB_PERSONAGENS.FirstOrDefaultAsync(p => p.Id == id);

            _context.TB_PERSONAGENS.Remove(pRemover);
            int linhasAfetadas = await _context.SaveChangesAsync();
            return Ok(linhasAfetadas);

        }

        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
       }


        [HttpPost("DeletePersonagemHabilidade")]
        public async Task<IActionResult> DeleteAsync(PersonagemHabilidade ph)
        {
            try
            {
                PersonagemHabilidade? phRemover = await _context.TB_PERSONAGENS_HABILIDADES
                .FirstOrDefaultAsync(phBusca => phBusca.PersonagemId == ph.PersonagemId
                && phBusca.HabilidadeId == ph.HabilidadeId);
                if (phRemover == null)
                    throw new System.Exception("Personagem ou Habilidade não encontrados");
                _context.TB_PERSONAGENS_HABILIDADES.Remove(phRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByUser/{userId}")]
        public async Task<IActionResult> GetByUserAsync(int userId)
        {
            try
            {
                List<Personagem> lista = await _context.TB_PERSONAGENS
                .Where(u => u.Usuario.Id == userId)
                .ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByPerfil/{userId}")]
        public async Task<IActionResult> GetByPerfilAsync(int userId)
        {
            try
            {
                Usuario usuario = await _context.TB_USUARIOS
                .FirstOrDefaultAsync(x => x.Id == userId);
                List<Personagem> lista = new List<Personagem>();
                if (usuario.Perfil == "Admin")
                    lista = await _context.TB_PERSONAGENS.ToListAsync();
                else
                    lista = await _context.TB_PERSONAGENS
                    .Where(p => p.Usuario.Id == userId).ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByNomeAproximado/{nomePersonagem}")]
        public async Task<IActionResult> GetByNomeAproximado(string nomePersonagem)
        {
            try
            {
                List<Personagem> lista = await _context.TB_PERSONAGENS
                .Where(p => p.Nome.ToLower().Contains(nomePersonagem.ToLower()))
                .ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }   //Fim Controller
}