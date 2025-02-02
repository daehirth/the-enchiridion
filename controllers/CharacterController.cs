using TheEnchiridion.context;
using TheEnchiridion.models;
using TheEnchiridion.models.requests;
using TheEnchiridion.services;
using Microsoft.AspNetCore.Mvc;

namespace TheEnchiridion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {

        private readonly ICharacterService _characterService;
        private readonly ILogger<CharacterController> _logger;

        public CharacterController(ICharacterService characterService, ILogger<CharacterController> logger) {
            _characterService = characterService;
            _logger = logger;
        }

        [HttpPost]
        [Route("getCharactersByUser")]
        public IList<Character> getCharactersByUser(string username)
        {
            return _characterService.getCharactersByUser(username);
        }

        [HttpPut]
        [Route("createCharacter")]
        public void createCharacter(CreateCharacterRequest request)
        {
            _characterService.createCharacter(request);
        }
    }
}
