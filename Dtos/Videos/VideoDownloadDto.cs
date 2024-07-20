using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Dtos.Videos
{
    public class VideoDownloadDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string videoPath { get; set; } = String.Empty;
        public DateTime Published { get; set; } 
    }
}