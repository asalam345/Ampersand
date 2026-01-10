using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskManagement.Application.Features.Users.Commands
{
    public sealed class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        public CreateUserHandler()
        {
            
        }
        public Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
