using System;
using System.Collections.Generic;
using System.Linq;
using api.Dtos.Directories;
using api.Models;

namespace api.Interfaces
{
    public interface IDirectoryRepository
    {
        Task<List<VideoDirectory>> GetAllAsync();
        Task<VideoDirectory?> GetByIdAsync(int id);
        Task<VideoDirectory?> CreateAsync(VideoDirectory teamModel);
        Task<VideoDirectory?> UpdateAsync(int id, DirectoryUpdateDto updateDto);
        Task<VideoDirectory?> DeleteAsync(int id);
    }
}