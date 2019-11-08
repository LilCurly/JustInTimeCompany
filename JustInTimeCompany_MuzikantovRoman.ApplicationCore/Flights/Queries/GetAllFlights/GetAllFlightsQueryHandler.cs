using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Queries.GetAllFlights
{
    public class GetAllFlightsQueryHandler : IRequestHandler<GetAllFlightsQuery, List<Flight>>
    {
        private readonly IFlightRepository _repo;
        public GetAllFlightsQueryHandler(IFlightRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Flight>> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAll();
        }
    }
}
