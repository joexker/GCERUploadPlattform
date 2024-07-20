using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Team;
using api.Models;

namespace api.Interfaces
{
    public interface ITeamRepository
    {
        
        Task<List<Team>> GetAllAsync();
        Task<Team?> GetByIdAsync(int id);
        Task<Team> CreateAsync(Team teamModel);
        Task<Team?> UpdateAsync(int id, TeamUpdateDto updateDto);
        Task<Team?> DeleteAsync(int id);
    }
}