using TheEnchiridion.context;
using TheEnchiridion.models;
using TheEnchiridion.models.requests;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace TheEnchiridion.services
{
    public interface ICharacterService
    {
        IList<Character> getCharactersByUser(string username);
        Character? getCharacter(int id);
        IList<Character> getCharactersByCampaignId(int id);
        IList<Character> getCharactersByNameAndCampaignId(string name, int campaignId);
        void createCharacter(CreateCharacterRequest request);
        void setCampaignId(ChangeCharacterCampaignRequest request);
    }

    public class CharacterService: ICharacterService
    {

        private readonly IUserService _userService;

        public CharacterService(IUserService userService) 
        {
            _userService = userService;
        }

        public IList<Character> getCharactersByUser(string username)
        {
            using (var context = new DataContext())
            {
                var characters = context.Characters.Where(x => x.UserId == username).ToList();
                return characters;
            }
        }

        public Character? getCharacter(int id)
        {
            using (var context = new DataContext())
            {
                var character = context.Characters.FirstOrDefault(x => x.Id == id);
                return character;
            }
        }

        public IList<Character> getCharactersByCampaignId(int id)
        {
            using (var context = new DataContext())
            {
                var characters = context.Characters.Where(x => x.CampaignId == id).ToList();
                return characters;
            }
        }

        public IList<Character> getCharactersByNameAndCampaignId(string name, int campaignId)
        {
            using (var context = new DataContext())
            {
                var characters = context.Characters.Where(x => x.Name == name && x.CampaignId == campaignId).ToList();
                return characters;
            }
        }

        public void createCharacter(CreateCharacterRequest request)
        {
            using (var context = new DataContext())
            {
                var user = new Character()
                {
                    Name = request.Name,
                    CampaignId = request.CampaignId,
                    Race = request.Race,
                    UserId = request.User.Username
                };

                context.Characters.Add(user);
                context.SaveChanges();
            }

            //TODO: Throw exception for why it failed.
        }

        public void setCampaignId(ChangeCharacterCampaignRequest request)
        {
            using (var context = new DataContext())
            {
                var dbChara = context.Characters.FirstOrDefault(x => x.Id == request.CharacterId);
                if (dbChara != null)
                {
                    if (request.NewCampaignId <= 0)
                        dbChara.CampaignId = null;
                    else
                        dbChara.CampaignId = request.NewCampaignId;

                    context.Characters.Update(dbChara);
                    context.SaveChanges();
                }
            }

            //TODO: Throw exception for why it failed.
        }
    }
}
