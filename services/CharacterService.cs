using TheEnchiridion.context;
using TheEnchiridion.models;
using TheEnchiridion.models.requests;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace TheEnchiridion.services
{
    public interface ICharacterService
    {
        Task<IList<Character>> getCharactersByUser(string userId);
        Task<Character?> getCharacter(int characterId);
        Task<Character> createCharacter(CreateCharacterRequest request);
    }

    public class CharacterService: ICharacterService
    {

        private readonly EnchiridionDbContext _context;
        private readonly ICampaignService _campaignService;

        public CharacterService(EnchiridionDbContext context, ICampaignService campaignService) 
        {
            _context = context;
            _campaignService = campaignService;
        }

        public async Task<IList<Character>> getCharactersByUser(string userId)
        {
            var characters = await _context.Characters.Where(x => x.UserId == userId).ToListAsync();
            return characters;
        }

        public async Task<Character> getCharacter(int id)
        {
            var character = await _context.Characters.FirstOrDefaultAsync(x => x.Id == id);
            return character;
        }

        public async Task<Character> createCharacter(CreateCharacterRequest request)
        {
            var chara = new Character()
            {
                Name = request.Name,
                Race = request.Race,
                UserId = request.UserId
            };

            Campaign? dbCampaign = null;

            if(request.CampaignId != null)
            {
                dbCampaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == request.CampaignId);
                if (dbCampaign == null)
                    throw new NullReferenceException("Campaign does not exist!");
            }

            await _context.Characters.AddAsync(chara);
            await _context.SaveChangesAsync();

            if(dbCampaign != null)
            {
                var campaignChara = new CampaignCharacter() 
                { 
                    CampaignId = dbCampaign.Id,
                    CharacterId = chara.Id,
                };
                await _context.CampaignCharacters.AddAsync(campaignChara);
                await _context.SaveChangesAsync();
            }

            return chara;
        }
    }
}
