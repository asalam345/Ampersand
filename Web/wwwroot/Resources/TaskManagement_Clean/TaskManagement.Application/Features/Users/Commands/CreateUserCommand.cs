using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs.Users;

namespace TaskManagement.Application.Features.Users.Commands
{
    public sealed record CreateUserCommand(CreateUserDto user):IRequest<Guid>;
    
}
