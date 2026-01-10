using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Features.Teams.Commands.DeleteTeam
{
    public class DeleteTeamCommandHandler(IGenericRepository<Team> repository) : IRequestHandler<DeleteTeamCommand, bool>
    {
        private readonly IGenericRepository<Team> _repository = repository;

        public async Task<bool> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _repository.GetByIdAsync(request.Id);
            if (team == null) return false;

            _repository.Delete(team);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
