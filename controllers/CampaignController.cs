using TheEnchiridion.models;
using TheEnchiridion.context;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using TheEnchiridion.services;
using Microsoft.AspNetCore.Authorization;
using TheEnchiridion.models.requests;

namespace TheEnchiridion.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _campaignService;
        private readonly ILogger<CampaignController> _logger;

        public CampaignController(ICampaignService campaignService, 
            ILogger<CampaignController> logger)
        {
            _campaignService = campaignService;
            _logger = logger;
        }

        [HttpPost]
        [Route("getCampaignsByUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCampaignsByUser([FromBody] string userId)
        {
            var campaigns = await _campaignService.getCampaignsByUser(userId);
            if (campaigns.Any())
                return Ok(campaigns);
            else
                return NotFound("No campaigns found for user!");
        }

        [HttpPut]
        [Route("createCampaign")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCampaign([FromBody] CreateCampaignRequest request)
        {
            
            return Ok(await _campaignService.createCampaign(request.Name, request.UserId));
        }

        [HttpPut]
        [Route("addUserToCampaign")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> addUserToCampaign(UpdateCampaignRequest request)
        {
            return Ok(await _campaignService.addUserToCampaign(request.CampaignId, request.UserId));
        }
    }
}
