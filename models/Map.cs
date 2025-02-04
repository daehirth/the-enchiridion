﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnchiridion.models
{
    public class Map
    {
        [Key]
        public int Id { get; set; }
        public string ImageLocation { get; set; }
        public required int CampaignId { get; set; }
        [ForeignKey("CampaignId")]
        public Campaign? Campaign { get; set;}
        public required string Name { get; set; }
    }
}
