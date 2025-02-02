using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnchiridion.models
{
    [Table("pin")]
    public class Pin
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("mapid")]
        public required int MapId { get; set; }
        [Column("xpos")]
        public required int XPos { get; set; }
        [Column("ypos")]
        public required int YPos { get; set; }
        [Column("name")]
        public required string Name { get; set; }
        [Column("description")]
        public string? Description { get; set; }
    }
}
