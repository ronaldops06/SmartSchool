using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SmartSchool.API.Models;
using System.Linq;
using SmartSchool.API.Data;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Dtos;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public readonly IRepository _repository;
        public readonly IMapper _mapper;
        public AlunoController(IRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repository.GetAllAlunos(true);
            
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var aluno = _repository.GetAllAlunoById(id, false);
            if (aluno == null)
            {
                return BadRequest("O aluno não foi encontrado.");
            }

            var alunoDto = _mapper.Map<AlunoDto>(aluno);

            return Ok(alunoDto);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public IActionResult Post(AlunoRegistrarDto alunoDto)
        {
            var aluno = _mapper.Map<Aluno>(alunoDto);

            _repository.Add(aluno);
            if (_repository.SaveChanges())
            {

                return Created($"/api/aluno/{alunoDto.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não cadastrado.");
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistrarDto alunoDto)
        {
            var aluno = _repository.GetAllAlunoById(id, false);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado.");
            }

            _mapper.Map(alunoDto, aluno);

            _repository.Update(aluno);
            if (_repository.SaveChanges())
            {
                return Created($"/api/aluno/{alunoDto.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não atualizado.");
        }

        // PATCH api/<AlunoController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegistrarDto alunoDto)
        {
            var aluno = _repository.GetAllAlunoById(id, false);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado.");
            }

            _mapper.Map(alunoDto, aluno);

            _repository.Update(aluno);
            if (_repository.SaveChanges())
            {
                return Created($"/api/aluno/{alunoDto.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não atualizado.");
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repository.GetAllAlunoById(id, false);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado.");
            }

            _repository.Delete(aluno);
            if (_repository.SaveChanges())
            {
                return Ok("Aluno deletado");
            }

            return BadRequest("Aluno não deletado.");
        }
    }
}
