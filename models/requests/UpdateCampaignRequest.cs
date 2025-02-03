namespace TheEnchiridion.models.requests
{
    public class UpdateCampaignRequest
    {
        public required int CampaignId { get; set; }
        public required string UserId { get; set; }
        public bool RemoveUser { get; set; }
    }
}
