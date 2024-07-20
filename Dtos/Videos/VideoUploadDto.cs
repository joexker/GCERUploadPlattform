using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Videos
{
    public class VideoUploadDto
    {
        [Required]
        public required IFormFile Video { get; set; }
        [Required]
        public string Title { get; set; } = String.Empty;
    }
}