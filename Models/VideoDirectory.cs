using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class VideoDirectory
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public int? TeamId { get; set; }
        public List<Video> Videos { get; set; } = new List<Video>();
    }
}