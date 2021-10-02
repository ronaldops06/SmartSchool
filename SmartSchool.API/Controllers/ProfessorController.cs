using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Dtos;
using SmartSchool.API.Models;
using System.Collections.Generic;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public ProfessorController(IRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repository.GetAllProfessores(true);

            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto professorDto)
        {
            var professor = _mapper.Map<Professor>(professorDto);

            _repository.Add(professor);
            if (_repository.SaveChanges())
            {
                return Created($"/api/aluno/{professorDto.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Professor não cadastrado.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDto professorDto)
        {
            var professor = _repository.GetAllProfessoreById(id, false);
            if (professor == null)
            {
                return BadRequest("Professor não encontrado");
            }

            _mapper.Map(professorDto, professor);

            _repository.Update(professor);
            if (_repository.SaveChanges())
            {
                return Created($"/api/aluno/{professorDto.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Professor não atualizado.");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegistrarDto professorDto)
        {
            var professor = _repository.GetAllProfessoreById(id, false);
            if (professor == null)
            {
                return BadRequest("Professor não encontrado");
            }

            _mapper.Map(professorDto, professor);

            _repository.Update(professor);
            if (_repository.SaveChanges())
            {
                return Created($"/api/aluno/{professorDto.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Professor não atualizado.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repository.GetAllProfessoreById(id, false);
            if (professor == null)
            {
                return BadRequest("Professor não encontrado");
            }

            _repository.Delete(professor);
            if (_repository.SaveChanges())
            {
                return Ok("Professor deletado.");
            }

            return BadRequest("Professor não deletado.");
        }
    }
}
