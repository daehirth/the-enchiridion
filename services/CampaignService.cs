using TheEnchiridion.context;
using TheEnchiridion.models;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using TheEnchiridion.models.responses;

namespace TheEnchiridion.services
{

    public interface ICampaignService
    {
        Task<Campaign> createCampaign(string campaignName, string username);
        Task<IList<Campaign>> getCampaignsByUser(string username);
        Task<AddUserToCampaignResponse> addUserToCampaign(int campaignId, string username);

        Task<IList<Character>> getCharactersByCampaignId(int campaignId);
    }

    public class CampaignService: ICampaignService
    {

        private readonly EnchiridionDbContext _context;
        public CampaignService(EnchiridionDbContext context) 
        {
            _context = context;
        }

        public async Task<AddUserToCampaignResponse> addUserToCampaign(int campaignId, string username)
        {
            var dbCampaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == campaignId);

            if (dbCampaign == null)
                return new AddUserToCampaignResponse()
                {
                    Message = "Unable to find campaign!",
                    Success = false
                };

            var campaignUser = new CampaignUser()
            {
                IsOwner = false,
                UserId = username,
                CampaignId = campaignId
            };

            await _context.CampaignUsers.AddAsync(campaignUser);
            await _context.SaveChangesAsync();

            return new AddUserToCampaignResponse()
            {
                Message = $"User was added to the {dbCampaign.Name} campaign!",
                Success = true
            };
        }

        public async Task<Campaign> createCampaign(string campaignName, string userId)
        {
            var campaign = new Campaign()
            {
                Name = campaignName
            };

            await _context.Campaigns.AddAsync(campaign);
            await _context.SaveChangesAsync();

            var campaignUser = new CampaignUser()
            {
                CampaignId = campaign.Id,
                UserId = userId,
                IsOwner = true
            };

            await _context.CampaignUsers.AddAsync(campaignUser);
            await _context.SaveChangesAsync();
            return campaign;
        }

        public async Task<IList<Campaign>> getCampaignsByUser(string userId)
        {
            var campaigns = await _context.CampaignUsers
                .Where(x => x.UserId == userId)
                .Select(x => x.Campaign)
                .Distinct()
                .ToListAsync();

            return campaigns;
        }

        public async Task<IList<Character>> getCharactersByCampaignId(int campaignId)
        {
            var characters = await _context.CampaignCharacters
                .Where(x => x.CampaignId == campaignId)
                .Select(x => x.Character)
                .ToListAsync();
            return characters;
        }
    }
}
