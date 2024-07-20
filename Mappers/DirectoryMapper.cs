using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Directories;
using api.Models;

namespace api.Mappers
{
    public static class DirectoryMapper
    {
        
        public static DirectoryDto ToDirectoryDto(this VideoDirectory dirmodel)
        {
            return new DirectoryDto
            {
                Title = dirmodel.Title
            };
        }

        public static VideoDirectory ToDirectoryFromDirectoryDto(this DirectoryDto directoryDto)
        {
            return new VideoDirectory
            {
                Title = directoryDto.Title,
                TeamId = directoryDto.TeamId
            };
        }
    }
}