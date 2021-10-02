using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.V1.Dtos;
using SmartSchool.API.Models;
using System.Collections.Generic;

namespace SmartSchool.API.V1.Controllers
{   
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public ProfessorController(IRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Método responsável por retornar todos os professores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repository.GetAllProfessores(true);

            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

        /// <summary>
        /// Método responsável por criar um novo professor
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável por atualizar um professor já existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="professorDto"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável por atualizar parcialmente um professor já existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="professorDto"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável por deletar um aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
