namespace TheEnchiridion.models.requests
{
    public class CreateCharacterRequest
    {
        public required string UserId { get; set; }
        public required string Name { get; set; }
        public required string Race { get; set; }
        public int? CampaignId { get; set; }
    }
}
