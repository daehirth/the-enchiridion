using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnchiridion.models
{
    public class CampaignCharacter
    {
        [Key]
        public int Id { get; set; }
        public required int CharacterId { get; set; }
        [ForeignKey("CharacterId")]
        public Character? Character { get; set; }
        public required int CampaignId { get; set; }
        [ForeignKey("CampaignId")]
        public Campaign? Campaign { get; set; }
    }
}
