using TheEnchiridion.context;
using TheEnchiridion.models;
using TheEnchiridion.models.requests;
using TheEnchiridion.services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TheEnchiridion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IUserService userService, ILogger<LoginController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        [Route("userExists")]
        public bool userExists(string username)
        {
            return _userService.userExists(username);
        }

        [HttpPut]
        [Route("createUser")]
        public void createUser(LoginRequest request)
        {
            _userService.createUser(request);
        }
    }
}
