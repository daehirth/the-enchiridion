namespace TheEnchiridion.models.requests
{
    public class ChangeCharacterCampaignRequest
    {
        public required string UserId { get; set; }
        public required int CharacterId { get; set; }
        public required int NewCampaignId { get; set; }
    }
}
