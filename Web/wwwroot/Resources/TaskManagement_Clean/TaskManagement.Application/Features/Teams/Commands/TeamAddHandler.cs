using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Features.Teams.Commands
{
    public class TeamAddHandler : IRequestHandler<TeamAddCommand, TeamDto>
    {
        private readonly IGenericRepository<Team> _repository;
        private readonly IMapper _mapper;

        public TeamAddHandler(IGenericRepository<Team> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<TeamDto> Handle(TeamAddCommand request, CancellationToken cancellationToken)
        {
            var teamDomainModel= _mapper.Map<Team>(request);
            await _repository.AddAsync(teamDomainModel);
            await _repository.SaveChangesAsync();
            return _mapper.Map<TeamDto>(teamDomainModel);
        }
    }
}
