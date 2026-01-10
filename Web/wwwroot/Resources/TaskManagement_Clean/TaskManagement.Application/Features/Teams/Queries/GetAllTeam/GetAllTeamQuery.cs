using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Features.Teams.Queries.GetAllTeam
{
    public class GetAllTeamQuery:IRequest<IEnumerable<TeamDto>>
    {
    }
}
