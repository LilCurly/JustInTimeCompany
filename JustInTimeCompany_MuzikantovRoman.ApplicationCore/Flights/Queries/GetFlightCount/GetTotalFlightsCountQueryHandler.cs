using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Queries.GetFlightCount
{
    public class GetTotalFlightsCountQueryHandler : IRequestHandler<GetTotalFlightsCountQuery, int>
    {
        private readonly IFlightRepository _flightRepo;
        private readonly IUserRepository _userRepo;

        public GetTotalFlightsCountQueryHandler(IFlightRepository flightRepo, IUserRepository userRepo)
        {
            _flightRepo = flightRepo;
            _userRepo = userRepo;
        }

        public async Task<int> Handle(GetTotalFlightsCountQuery request, CancellationToken cancellationToken)
        {
            if(request.Pilot != null)
            {
                var pilot = _userRepo.FindByName(request.Pilot).Result;
                if(pilot == null)
                {
                    // THROW EXCEPTION
                }
                return await _flightRepo.GetFlightsCount(pilot);
            }
            return await _flightRepo.GetFlightsCount();
        }
    }
}
