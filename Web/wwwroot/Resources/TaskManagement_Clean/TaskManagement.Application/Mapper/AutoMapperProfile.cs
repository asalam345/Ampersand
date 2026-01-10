using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Features.Teams.Commands;
using TaskManagement.Application.Features.Teams.Commands.UpdateTeam;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskItem,CreateTaskCommandDto>().ReverseMap();
            CreateMap<Team,TeamDto>().ReverseMap();
            CreateMap<TeamAddCommand, Team>().ReverseMap();
            CreateMap<UpdateTeamDto,UpdateTeamCommand>().ReverseMap();
        }
    }
}
