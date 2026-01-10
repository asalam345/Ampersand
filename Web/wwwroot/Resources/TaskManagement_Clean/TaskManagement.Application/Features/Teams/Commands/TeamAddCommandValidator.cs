using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Features.Teams.Commands
{
    public class TeamAddCommandValidator:AbstractValidator<TeamAddCommand>
    {
        private readonly IGenericRepository<Team> _repository;

        public TeamAddCommandValidator(IGenericRepository<Team> repository)
        {
            _repository = repository;
            RuleFor(x => x.Name)
                .NotEmpty()
                .MustAsync(async (name, CancellationToken) =>
                {
                    var existingTeam = await _repository.GetAllAsync();
                    return !existingTeam.Any(t=>t.Name == name);
                })
                .WithMessage("A team with this name already exists!");
            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(4)
                .WithMessage("Describe a little about the team");
                
        }
    }
}
