using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Dtos.Team;
using api.Models;

namespace api.Mappers
{
    public static class TeamMapper
    {
        
        public static TeamDto ToTeamDto(this Team teamModel)
        {
            return new TeamDto
            {
                Id = teamModel.Id,
                Name = teamModel.Name,
                TeamNumber = teamModel.TeamNumber
            };
        }

        public static Team ToTeamFromCreateDto(this TeamCreateDto createDto)
        {
            return new Team
            {
                Name = createDto.Name,
                TeamNumber = createDto.TeamNumber
            };
        }
    }
}