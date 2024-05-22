﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Portfolio:BaseEntity
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Title { get; set; } = null!;
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Subtitle { get; set; } = null!;
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? PhotoFile { get; set; }
    }
}
