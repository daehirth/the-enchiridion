using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnchiridion.models
{
    [Table("user")]
    public class User
    {
        public required string username { get; set; }
        public required string password { get; set; }
        public int id { get; set; }

    }
}
