using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SmartSchool.API.Models;
using System.Linq;
using SmartSchool.API.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;
        public AlunoController(SmartContext context) 
        {
            _context = context;
        }

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return BadRequest("O aluno não foi encontrado.");
            }

            return Ok(aluno);
        }

        // GET api/<AlunoController>/João
        [HttpGet("{ByName}")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null)
            {
                return BadRequest("O aluno não foi encontrado.");
            }

            return Ok(aluno);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var al = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (al == null)
            {
                return BadRequest("Aluno não encontrado.");
            }

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        // PATCH api/<AlunoController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var al = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (al == null)
            {
                return BadRequest("Aluno não encontrado.");
            }

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado.");
            }

            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok();
        }
    }
}
