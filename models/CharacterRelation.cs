using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnchiridion.models
{
    [Table("character_relation")]
    public class CharacterRelation
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("from_character")]
        public required int FromCharacter { get; set; }
        [Column("to_character")]
        public required int ToCharacter { get; set; }
        [Column("relation")]
        public string? Relation { get; set; }
        [Column("campaignid")]
        public required int CampaignId { get; set; }
    }
}
