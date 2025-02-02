using TheEnchiridion.models;
using TheEnchiridion.context;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using TheEnchiridion.services;

namespace TheEnchiridion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _campaignService;
        private readonly IUserService _userService;
        private readonly ILogger<CampaignController> _logger;

        public CampaignController(ICampaignService campaignService, 
            IUserService userService,
            ILogger<CampaignController> logger)
        {
            _campaignService = campaignService;
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        [Route("getCampaignsByUser")]
        public IList<Campaign> getCampaignsByUser(string username)
        {
            return _campaignService.getCampaignsByUser(username);
        }

        [HttpPut]
        [Route("createCampaign")]
        public void createCampaign(string campaignName, string username)
        {
            _campaignService.createCampaign(campaignName, username);
        }

        [HttpPut]
        [Route("addUserToCampaign")]
        public void addUserToCampaign(int campaignId, string username)
        {
            _campaignService.addUserToCampaign(campaignId, username);
        }
    }
}
