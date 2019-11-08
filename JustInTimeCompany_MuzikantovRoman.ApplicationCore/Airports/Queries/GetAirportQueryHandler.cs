using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Airports.Queries
{
    public class GetAirportQueryHandler : IRequestHandler<GetAirportQuery, Airport>
    {
        private readonly IAirportRepository _repo;
        public GetAirportQueryHandler(IAirportRepository repo)
        {
            _repo = repo;
        }
        public async Task<Airport> Handle(GetAirportQuery request, CancellationToken cancellationToken)
        {
            return await _repo.Get(request.Id);
        }
    }
}
