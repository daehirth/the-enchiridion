using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnchiridion.models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public required string Race { get; set; }
    }
}
