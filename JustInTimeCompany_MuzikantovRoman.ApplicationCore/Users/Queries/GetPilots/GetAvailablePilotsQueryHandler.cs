using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Users.Queries.GetPilots
{
    public class GetAvailablePilotsQueryHandler : IRequestHandler<GetAvailablePilotsQuery, List<User>>
    {
        private readonly IUserRepository _repo;

        public GetAvailablePilotsQueryHandler(IUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<User>> Handle(GetAvailablePilotsQuery request, CancellationToken cancellationToken)
        {
            if(request.FlightId == -1)
            {
                return await _repo.GetAvailablePilots(request.From, request.To);
            }
            return await _repo.GetAvailablePilots(request.From, request.To, request.FlightId);
        }
    }
}
