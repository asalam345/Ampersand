using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Features.Teams.Commands.UpdateTeam
{
    public record UpdateTeamCommand(Guid Id, string Name,string? Description):IRequest<TeamDto>;

    
}
