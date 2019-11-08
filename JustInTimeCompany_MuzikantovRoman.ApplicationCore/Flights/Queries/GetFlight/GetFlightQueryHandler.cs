using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Queries.GetFlight
{
    class GetFlightQueryHandler : IRequestHandler<GetFlightQuery, Flight>
    {
        private readonly IFlightRepository _repo;

        public GetFlightQueryHandler(IFlightRepository repo)
        {
            _repo = repo;
        }

        public async Task<Flight> Handle(GetFlightQuery request, CancellationToken cancellationToken)
        {
            return await _repo.Get(request.Id);
        }
    }
}
