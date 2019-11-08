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
    public class GetIncomingFlightsQueryHandler : IRequestHandler<GetIncomingFlightsQuery, List<Flight>>
    {
        private readonly IFlightRepository _repo;

        public GetIncomingFlightsQueryHandler(IFlightRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Flight>> Handle(GetIncomingFlightsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetIncomingFlights(3);
        }
    }
}
