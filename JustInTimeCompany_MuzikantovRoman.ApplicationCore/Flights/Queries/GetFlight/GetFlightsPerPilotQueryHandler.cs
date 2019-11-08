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
    public class GetFlightsPerPilotQueryHandler : IRequestHandler<GetFlightsPerPilotQuery, List<Flight>>
    {
        private readonly IUserRepository _userRepo;
        private readonly IFlightRepository _flightRepo;
        public GetFlightsPerPilotQueryHandler(IUserRepository userRepo, IFlightRepository flightRepo)
        {
            _userRepo = userRepo;
            _flightRepo = flightRepo;
        }
        public async Task<List<Flight>> Handle(GetFlightsPerPilotQuery request, CancellationToken cancellationToken)
        {
            var pilot = _userRepo.FindByName(request.Pilot).Result;
            if(pilot == null)
            {
                // TODO : Exception
            }
            return await _flightRepo.GetPerPilot(pilot, request.Limit);
        }
    }
}
