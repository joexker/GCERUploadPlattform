using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string videoPath { get; set; } = String.Empty;
        public DateTime Published { get; set; } = DateTime.Now;
        public int? TeamId { get; set; }
        public int? VideoDirectoryId { get; set; }

        public List<Comments> Comments { get; set; } = new List<Comments>();

    }
}