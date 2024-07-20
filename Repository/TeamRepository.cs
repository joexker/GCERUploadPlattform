using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Team;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace api.Repository
{
    public class TeamRepository : ITeamRepository
    {

        private readonly ApplicationDBContext _context;

        public TeamRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Team> CreateAsync(Team teamModel)
        {
            await _context.Team.AddAsync(teamModel);
            await _context.SaveChangesAsync();

            return teamModel;
        }

        public async Task<Team?> DeleteAsync(int id)
        {
           var teamModel = await _context.Team.FirstOrDefaultAsync(x => x.Id == id);

           if(teamModel == null)
           {
                return null;
           }

           _context.Team.Remove(teamModel);
           await _context.SaveChangesAsync();

           return teamModel;
        }

        public async Task<List<Team>> GetAllAsync()
        {
            return await _context.Team.Include(c => c.Videos).Include(d => d.Directories).ThenInclude(c => c.Videos).ToListAsync();
        }

        public async Task<Team?> GetByIdAsync(int id)
        {
            return await _context.Team.Include(c => c.Videos).Include(d => d.Directories).ThenInclude(c => c.Videos).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Team?> UpdateAsync(int id, TeamUpdateDto updateDto)
        {
            var existingTeam = await _context.Team.FirstOrDefaultAsync(x => x.Id == id);

            if(existingTeam == null)
                return null;
            
            if(!updateDto.Name.IsNullOrEmpty())
                existingTeam.Name = updateDto.Name;
            if(!updateDto.TeamNumber.IsNullOrEmpty())
                existingTeam.TeamNumber = updateDto.TeamNumber;

            await _context.SaveChangesAsync();

            return existingTeam;

        }
    }
}