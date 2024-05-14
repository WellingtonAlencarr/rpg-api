using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RpgApi.Models;
using RpgApi.Models.Enuns;


namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagensExerciciosController : Controller
    {
       private static List<Personagem> personagens = new List<Personagem>()
        {
            //Colar os objetos da lista do chat aqui
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=110, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=115, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=200, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=245, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=300, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=110, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=150, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };      

        // Exercicio A
        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetbyNome(string nome)
        {
            List<Personagem> listaBusca = personagens.FindAll(p => p.Nome == nome);
            if (listaBusca.Count == 0) 
            return BadRequest("Nome não localizado, procurar novamente!");

            return Ok(listaBusca);
           
        }


    // Exercicio B
       [HttpPost("PostValidacao")]

       public IActionResult PostValidacao(Personagem novoPersonagem)
       {
        if (novoPersonagem.Defesa < 10 || novoPersonagem.Inteligencia > 30)
        return BadRequest("Inteligencia não pode ser maior que 30 OU defesa não pode ser menor que 10!");
        personagens.Add(novoPersonagem);

        return Ok(personagens);
       }


    // Exercicio C
       [HttpPost("PostValidacaoMago")]
       public IActionResult PostValidacaoMago(Personagem novoPersonagem)
       {
        
        if (novoPersonagem.Inteligencia < 35)
        return BadRequest("Magos não podem ter menos de 30 de inteligência");
        personagens.Add(novoPersonagem);
        return Ok(novoPersonagem);
       }

       // Exercicio D

       [HttpGet("GetClerigoMago")]
       public IActionResult GetClerigoMago()
       {
        Personagem pRemoveCavaleiro = personagens.Find(p => p.Classe == ClasseEnum.Cavaleiro );
        personagens.Remove(pRemoveCavaleiro);

        List<Personagem> listaFinal = personagens.OrderByDescending(p => p.PontosVida).ToList();
        return Ok(listaFinal);
       }

    // Exercicio E
        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
            return Ok("Quantidade de personagens: " + personagens.Count + "  Soma de inteligencia: " + personagens.Sum(p => p.Inteligencia));
        }

       


        // Exercicio F
         [HttpGet("GetByClasse/{enumId}")]
        public IActionResult GetByClasse(int enumId)
        {
            ClasseEnum enumDigitado = (ClasseEnum)enumId;

            List<Personagem> listaBusca = personagens.FindAll (p => p.Classe == enumDigitado);

            return Ok(listaBusca);
        }
    }
}