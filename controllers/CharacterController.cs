using TheEnchiridion.context;
using TheEnchiridion.models;
using TheEnchiridion.models.requests;
using TheEnchiridion.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace TheEnchiridion.Controllers
{
    [ApiController]
    [Authorize]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCharactersByUser([FromBody] string username)
        {
            var charaList = await _characterService.getCharactersByUser(username);
            if (charaList.Any())
                return Ok(charaList);
            else
                return NotFound("No characters found for user!");
        }

        [HttpPut]
        [Route("createCharacter")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCharacter([FromBody] CreateCharacterRequest request)
        {
            _characterService.createCharacter(request);
            return Ok("Character has been created!");
        }
    }
}
