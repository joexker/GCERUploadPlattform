using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Directories
{
    public class DirectoryDto
    {
        public string Title { get; set; } = string.Empty;
        public int TeamId { get; set; }
    }
}