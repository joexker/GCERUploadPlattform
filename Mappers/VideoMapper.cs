using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Videos;
using api.Models;

namespace api.Mappers
{
    public static class VideoMapper
    {
        public static Video ToVideoInTeamFromFile(this IFormFile file, int id, String title)
        {
            return new Video
            {
                videoPath = file.FileName,
                Title = title,
                TeamId = id
            };
        }

        public static Video ToVideoInDirectoryFromFile(this IFormFile file, int id, String title)
        {
            return new Video
            {
                videoPath = file.FileName,
                Title = title,
                VideoDirectoryId = id
            };
        }

        public static VideoDownloadDto ToDownloadDto(this Video videoModel)
        {
            return new VideoDownloadDto{
                Id = videoModel.Id,
                Title = videoModel.Title,
                videoPath = videoModel.videoPath,
                Published = videoModel.Published
            };
        }
    }
}