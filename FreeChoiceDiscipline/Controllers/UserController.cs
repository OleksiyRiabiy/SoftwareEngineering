using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using FreeChoiceDiscipline.DAL.Entities;
using Microsoft.AspNetCore.Mvc;


namespace FreeChoiceDiscipline.Controllers
{
	[Route("User")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepository;

		public UserController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IUserRepository userRepository)
		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
			_userRepository = userRepository;
		}


		[HttpDelete]
		public IActionResult DeleteUser(int id)
		{
			_userRepository.DeleteUser(id, trackChanges: false);

			return StatusCode(201); // View 
		}


		[HttpGet]
		public IActionResult GetUser(int id)
		{
			_userRepository.FindUserById(id, trackChanges: false);

			return StatusCode(201); // View 
		}


		[HttpPut]
		public IActionResult UpdateUser(int id, User user)
		{
			_userRepository.UpdateUser(id, user);

			return StatusCode(201); // View 
		}

	}
}
