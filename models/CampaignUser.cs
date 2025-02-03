using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnchiridion.models
{
    public class CampaignUser
    {
        [Key]
        public int Id { get; set; }
        public required string UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public required int CampaignId { get; set; }
        [ForeignKey("CampaignId")]
        public Campaign? Campaign { get; set; }
        public required bool IsOwner { get; set; }
    }
}
