namespace TheEnchiridion.models.requests
{
    public class CreateCharacterRequest
    {
        public required LoginRequest User { get; set; }
        public required string Name { get; set; }
        public required string Race { get; set; }
        public required int CampaignId { get; set; }
    }
}
