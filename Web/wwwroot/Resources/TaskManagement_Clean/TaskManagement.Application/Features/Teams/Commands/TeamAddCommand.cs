using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Features.Teams.Commands
{
    public class TeamAddCommand:IRequest<TeamDto>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        //public List<CreateTaskRequest>? Tasks { get; set; } = new();
    }
}
