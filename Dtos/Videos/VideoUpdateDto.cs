using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Videos
{
    public class VideoUpdateDto
    {
        public string Title { get; set; } = String.Empty;
        public int? TeamId { get; set; }
        public int? VideoDirectoryId { get; set; }
    }
}