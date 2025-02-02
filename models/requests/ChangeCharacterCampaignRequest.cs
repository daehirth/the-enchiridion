namespace TheEnchiridion.models.requests
{
    public class ChangeCharacterCampaignRequest
    {
        public LoginRequest User { get; set; }
        public int CharacterId { get; set; }
        public int NewCampaignId { get; set; }
    }
}
