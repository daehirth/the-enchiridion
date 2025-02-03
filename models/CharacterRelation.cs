using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnchiridion.models
{
    public class CharacterRelation
    {
        [Key]
        public int Id { get; set; }
        public required int FromCharacterId { get; set; }
        [ForeignKey("FromCharacterId")]
        public Character? FromCharacter { get; set; }
        public required int ToCharacterId { get; set; }
        [ForeignKey("ToCharacterId")]
        public Character? ToCharacter { get; set; }
        public string? Relation { get; set; }
        public required int CampaignId { get; set; }
        [ForeignKey("CampaignId")]
        public Campaign? Campaign { get; set; }
    }
}
