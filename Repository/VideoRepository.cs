using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Videos;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace api.Repository
{
    public class VideoRepository(ApplicationDBContext context) : IVideoRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Video?> DeleteAsync(int id)
        {
            var videoModel = await _context.Video.FirstOrDefaultAsync(v => v.Id == id);

            if(videoModel == null)
            {
                return null;
            }

            _context.Video.Remove(videoModel);
            await _context.SaveChangesAsync();

            return videoModel;
        }

        public async Task<List<Video>> GetAllAsync()
        {
            return await _context.Video.ToListAsync();
        }

        public async Task<List<Video>> GetAllFromTeamAsync(int id)
        {
            var videomodel = _context.Video.AsQueryable();

            videomodel.Where(v => v.TeamId == id);

            return await videomodel.ToListAsync();
        }

        public async Task<Video?> GetByIdAsync(int id)
        {
            return await _context.Video.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Video?> UpdateAsync(int id, VideoUpdateDto updateDto)
        {
            var existingVideo = await _context.Video.FirstOrDefaultAsync(v => v.Id == id);

            if(existingVideo == null)
            {
                return null;
            }

            if(!updateDto.Title.IsNullOrEmpty())
                existingVideo.Title = updateDto.Title;
            
            existingVideo.TeamId = updateDto.TeamId;  
            existingVideo.VideoDirectoryId = updateDto.VideoDirectoryId;

            await _context.SaveChangesAsync();

            return existingVideo;
        }

        public async Task<Video?> UploadAsync(Video videoModel)
        {

            if(
                videoModel.VideoDirectoryId != null && 
                await _context.Directories.FirstOrDefaultAsync(d => d.Id == videoModel.VideoDirectoryId) == null
            )
            {
                return null;
            }

            if(
                videoModel.TeamId != null && 
                await _context.Directories.FirstOrDefaultAsync(d => d.Id == videoModel.TeamId) == null
            )
            {
                return null;
            }
                
            await _context.Video.AddAsync(videoModel);
            await _context.SaveChangesAsync();

            return videoModel;
        }
    }
}