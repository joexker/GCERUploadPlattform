using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Team
{
    public class TeamUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string TeamNumber { get; set; } = string.Empty;
    }
}