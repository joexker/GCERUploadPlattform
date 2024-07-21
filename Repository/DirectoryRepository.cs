using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Directories;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace api.Repository
{
    public class DirectoryRepository : IDirectoryRepository
    {
        private readonly ApplicationDBContext _context;
        public DirectoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<VideoDirectory?> CreateAsync(VideoDirectory dirModel)
        {
            if(dirModel.TeamId != null && await _context.Team.FirstOrDefaultAsync(t => t.Id == dirModel.TeamId) == null)
                return null;

            await _context.Directories.AddAsync(dirModel);
            await _context.SaveChangesAsync();

            return dirModel;
        }

        public async Task<VideoDirectory?> DeleteAsync(int id)
        {
           var dirModel = await _context.Directories.FirstOrDefaultAsync(x => x.Id == id);

           if(dirModel == null)
           {
                return null;
           }

           _context.Directories.Remove(dirModel);
           await _context.SaveChangesAsync();

           return dirModel;
        }

        public async Task<List<VideoDirectory>> GetAllAsync()
        {
            return await _context.Directories.Include(c => c.Videos).ToListAsync();
        }

        public async Task<VideoDirectory?> GetByIdAsync(int id)
        {
            return await _context.Directories.Include(c => c.Videos).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<VideoDirectory>> GetAllFromTeamAsync(int id)
        {
            var dirmodel = _context.Directories.AsQueryable();

            dirmodel.Where(v => v.TeamId == id);

            return await dirmodel.ToListAsync();
        }

        public async Task<VideoDirectory?> UpdateAsync(int id, DirectoryUpdateDto updateDto)
        {
            var existingDirectory = await _context.Directories.FirstOrDefaultAsync(x => x.Id == id);

            if(existingDirectory == null)
                return null;
            
            if(!updateDto.Title.IsNullOrEmpty())
                existingDirectory.Title = updateDto.Title;

            await _context.SaveChangesAsync();

            return existingDirectory;

        }
    }
}