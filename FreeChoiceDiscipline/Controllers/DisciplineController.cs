using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using FreeChoiceDiscipline.DAL.Entities;
using FreeChoiceDiscipline.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeChoiceDiscipline.Controllers
{
    [Route("Discipline")]
    [ApiController]
    public class DisciplineController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public DisciplineController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateDiscipline(DisciplineToCreate disciplineToCreate)
        {
            if (disciplineToCreate == null )
            {
                _logger.LogError($"{nameof(DisciplineToCreate)} object sent from client is null.");
                return BadRequest(); // View ?
            }

            var discipline = _mapper.Map<Discipline>(disciplineToCreate);

            _repository.Discipline.CreateDiscipline(discipline);
            _repository.Save();

            return StatusCode(201); // View 
        }

        [HttpGet]
        public IActionResult AllDisciplines()
        {
            List<Discipline> model = new List<Discipline>();
            model.Add(
                new Discipline() { Title = "Some course1", Id = 1, CurrentAmountOfStudents = 15, MaxAmountOfStudents = 100, IsOpenToRegistry = true, Users = null }
                );
            model.Add(
               new Discipline() { Title = "Some course2", Id = 2, CurrentAmountOfStudents = 5, MaxAmountOfStudents = 100, IsOpenToRegistry = true, Users = null }
               );
            model.Add(
               new Discipline() { Title = "Some course3", Id = 3, CurrentAmountOfStudents = 25, MaxAmountOfStudents = 100, IsOpenToRegistry = true, Users = null }
               );

            //var model = _repository.Discipline.GetAll(false).ToList();
            return View(model);
		}

    }
}
