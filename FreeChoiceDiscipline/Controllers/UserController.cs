using System;
namespace FreeChoiceDiscipline.Controllers
{
	[Route("api/user")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;
		private readonly UserManager<User> _userManager;
		private readonly IAuthenticationManager _authManager;

		public UserController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IAuthenticationManager authManager)

		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
			_userManager = userManager;
			_authManager = authManager;


		}
	}

}