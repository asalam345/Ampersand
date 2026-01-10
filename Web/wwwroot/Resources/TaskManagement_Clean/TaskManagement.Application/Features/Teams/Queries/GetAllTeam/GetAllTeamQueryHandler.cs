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

namespace TaskManagement.Application.Features.Teams.Queries.GetAllTeam
{
    public class GetAllTeamQueryHandler : IRequestHandler<GetAllTeamQuery, IEnumerable<TeamDto>>
    {
        private readonly IGenericRepository<Team> _repository;
        private readonly IMapper _mapper;

        public GetAllTeamQueryHandler(IGenericRepository<Team> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TeamDto>> Handle(GetAllTeamQuery request, CancellationToken cancellationToken)
        {
            var teamList = await _repository.GetAllAsync();
            return  _mapper.Map<IEnumerable<TeamDto>>(teamList);
            
        }
    }
}
