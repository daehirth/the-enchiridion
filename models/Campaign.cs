﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnchiridion.models
{
    [Table("campaign")]
    public class Campaign
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public required string Name { get; set; }
    }
}
