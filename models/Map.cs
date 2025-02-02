using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnchiridion.models
{
    [Table("map")]
    public class Map
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("image_location")]
        public string ImageLocation { get; set; }
        [Column("campaignid")]
        public required int CampaignId { get; set;}
        [Column("name")]
        public required string Name { get; set; }
    }
}
