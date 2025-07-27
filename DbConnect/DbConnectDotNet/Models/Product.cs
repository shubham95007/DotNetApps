﻿using System.ComponentModel.DataAnnotations;

namespace FromScratch.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
