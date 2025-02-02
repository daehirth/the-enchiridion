using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnchiridion.models
{
    [Table("character")]
    public class Character
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string UserId { get; set; }
        public int? CampaignId { get; set; }
        public required string Race { get; set; }
    }
}
