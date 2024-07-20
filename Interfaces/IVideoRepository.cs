using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Videos;
using api.Models;

namespace api.Interfaces
{
    public interface IVideoRepository
    {
        
        Task<Video?> UploadAsync(Video uploadDto);
        Task<List<Video>> GetAllFromTeamAsync(int id);
        Task<List<Video>> GetAllAsync();
        Task<Video?> GetByIdAsync(int id);
        Task<Video?> UpdateAsync(int id, VideoUpdateDto updateDto);
        Task<Video?> DeleteAsync(int id);
    }
}