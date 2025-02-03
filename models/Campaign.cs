using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnchiridion.models
{
    public class Campaign
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
