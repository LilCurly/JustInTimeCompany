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
    public class GetFlightsPerAirportQueryHandler : IRequestHandler<GetFlightsPerAirportQuery, List<Flight>>
    {
        private readonly IFlightRepository _flightRepo;
        private readonly IAirportRepository _airportRepo;
        public GetFlightsPerAirportQueryHandler(IFlightRepository flightRepo, IAirportRepository airportRepo)
        {
            _flightRepo = flightRepo;
            _airportRepo = airportRepo;
        }

        public async Task<List<Flight>> Handle(GetFlightsPerAirportQuery request, CancellationToken cancellationToken)
        {
            Airport departureAirport = null;
            Airport arrivalAirport = null;
            if(request.DepartureAirportId != -1)
            {
                departureAirport = _airportRepo.Get(request.DepartureAirportId).Result;
                if(departureAirport == null)
                {
                    // TODO : Exception
                }
            }
            if(request.ArrivalAirportId != -1)
            {
                arrivalAirport = _airportRepo.Get(request.ArrivalAirportId).Result;
                if(arrivalAirport == null)
                {
                    // TODO : Exception
                }
            }
            return await _flightRepo.GetPerAirport(departureAirport, arrivalAirport, request.ArrivalDateTime);
        }
    }
}
