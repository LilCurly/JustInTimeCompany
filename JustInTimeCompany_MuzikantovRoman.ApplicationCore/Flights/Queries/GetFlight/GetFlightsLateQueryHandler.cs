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
    public class GetFlightsLateQueryHandler : IRequestHandler<GetFlightsLateQuery, List<Flight>>
    {
        private readonly IFlightRepository _repo;

        public GetFlightsLateQueryHandler(IFlightRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Flight>> Handle(GetFlightsLateQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetLate();
        }
    }
}
