using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Core.Models
{
    public class Slider:BaseEntity
    {
        [Required]
        [StringLength(maximumLength:50)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(maximumLength:15)]
        public string ButtonText { get; set; }
        public string RedirectUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
