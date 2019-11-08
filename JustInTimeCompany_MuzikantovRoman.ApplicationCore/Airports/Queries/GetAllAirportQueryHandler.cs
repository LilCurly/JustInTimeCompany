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
    public class GetAllAirportQueryHandler : IRequestHandler<GetAllAirportQuery, List<Airport>>
    {
        private readonly IAirportRepository _repo;
        public GetAllAirportQueryHandler(IAirportRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Airport>> Handle(GetAllAirportQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAll();
        }
    }
}
