using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    //[Table("Team")]
    public class Team
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string TeamNumber { get; set; } = string.Empty;

        public List<Video> Videos { get; set; } = new List<Video>();
        public List<VideoDirectory> Directories { get; set; } = new List<VideoDirectory>();

    }
}