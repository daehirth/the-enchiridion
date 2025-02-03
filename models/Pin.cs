using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnchiridion.models
{
    public class Pin
    {
        [Key]
        public int Id { get; set; }
        public required int MapId { get; set; }
        [ForeignKey("MapId")]
        public Map? Map { get; set; }
        public required int XPos { get; set; }
        public required int YPos { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
