using TheEnchiridion.context;
using TheEnchiridion.models;
using System.Reflection.Metadata.Ecma335;

namespace TheEnchiridion.services
{

    public interface ICampaignService
    {
        void createCampaign(string campaignName, string username);
        IList<Campaign> getCampaignsByUser(string username);
        void addUserToCampaign(int campaignId, string username);
    }

    public class CampaignService: ICampaignService
    {
        public CampaignService() { }

        public void addUserToCampaign(int campaignId, string username)
        {
            using (var context = new DataContext())
            {
                var campaignUser = new CampaignUser()
                {
                    IsOwner = false,
                    UserId = username,
                    CampaignId = campaignId
                };

                context.CampaignUsers.Add(campaignUser);
                context.SaveChanges();
            }
        }

        public void createCampaign(string campaignName, string username)
        {
            using (var context = new DataContext())
            {
                var campaign = new Campaign()
                {
                    Name = campaignName
                };

                context.Campaigns.Add(campaign);
                context.SaveChanges();

                var campaignUser = new CampaignUser()
                {
                    CampaignId = campaign.Id,
                    UserId = username,
                    IsOwner = true
                };
                context.CampaignUsers.Add(campaignUser);
                context.SaveChanges();
            }
            //TODO: Throw exception for reason why it failed.
        }

        public IList<Campaign> getCampaignsByUser(string username)
        {
            using (var context = new DataContext())
            {
                var campaignIds = context.CampaignUsers
                    .Where(x => x.UserId == username)
                    .Select(x => x.CampaignId)
                    .ToList();

                var campaigns = context.Campaigns
                    .Where(x => campaignIds.Contains(x.Id))
                    .ToList();

                return campaigns;
            }
        }
    }
}
