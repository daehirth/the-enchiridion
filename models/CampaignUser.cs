using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnchiridion.models
{
    [Table("campaign_user")]
    public class CampaignUser
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("userid")]
        public required string UserId { get; set; }
        [Column("campaignid")]
        public required int CampaignId { get; set; }
        [Column("isowner")]
        public required bool IsOwner { get; set; }
    }
}
