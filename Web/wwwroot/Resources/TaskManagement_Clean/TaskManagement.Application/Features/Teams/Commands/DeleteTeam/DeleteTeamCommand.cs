using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Teams.Commands.DeleteTeam
{
    public record DeleteTeamCommand(Guid Id):IRequest<bool>;
    
}
