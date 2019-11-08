using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Commands.CreateFlight
{
    class CreateFlightEveryWeekCommandHandler : IRequestHandler<CreateFlightEveryWeekCommand, bool>
    {
        private readonly IAirportRepository _airportRepo;
        private readonly IFlightRepository _flightRepo;
        private readonly IPlaneRepository _planeRepo;
        private readonly IUserRepository _userRepo;

        public CreateFlightEveryWeekCommandHandler(IFlightRepository flightRepo, IPlaneRepository planeRepo, IUserRepository userRepo, IAirportRepository airportRepo)
        {
            _userRepo = userRepo;
            _airportRepo = airportRepo;
            _flightRepo = flightRepo;
            _planeRepo = planeRepo;
        }

        public async Task<bool> Handle(CreateFlightEveryWeekCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var plane = await _planeRepo.Get(request.PlaneId);
                var pilot = await _userRepo.FindById(request.PilotId);
                var departureAirport = await _airportRepo.Get(request.DepartureAirportId);
                var arrivalAirport = await _airportRepo.Get(request.ArrivalAirportId);

                if(plane == null || pilot == null || departureAirport == null || arrivalAirport == null)
                {
                    // TRHOW EXCEPTION
                }

                var flights = GenerateFlights(request, plane, pilot, departureAirport, arrivalAirport);

                foreach(var flight in flights)
                {
                    await _flightRepo.Create(flight);
                }
                //pilot.PilotFlights.Add(flight);
                //await _userRepo.Update(pilot);
                
                return true;
            }
            catch(Exception ex)
            {
            }
            return false;
        }

        public List<Flight> GenerateFlights(CreateFlightEveryWeekCommand request, Plane plane, User pilot, Airport departureAirport, Airport arrivalAirport)
        {
            List<Flight> flights = new List<Flight>();

            DateTime departureTime = request.DepartureTime;
            DateTime arrivalTime = request.ArrivalTime;
            
            for(int i = 0; i < request.Number; i++)
            {
                flights.Add(new Flight() 
                {
                    DepartureTime = departureTime,
                    ArrivalTime = arrivalTime,
                    Plane = plane,
                    Pilot = pilot,
                    DepartureAirport = departureAirport,
                    ArrivalAirport = arrivalAirport,
                    Seats = request.Seats,
                    IsConfirmed = false
                });

                departureTime =  departureTime.AddDays(7);
                arrivalTime = arrivalTime.AddDays(7);
            }

            return flights;
        }
    }
}
