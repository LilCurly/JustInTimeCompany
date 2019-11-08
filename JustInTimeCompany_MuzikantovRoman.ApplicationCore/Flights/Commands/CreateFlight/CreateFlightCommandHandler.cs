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
    public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, bool>
    {
        private readonly IAirportRepository _airportRepo;
        private readonly IFlightRepository _flightRepo;
        private readonly IPlaneRepository _planeRepo;
        private readonly IUserRepository _userRepo;

        public CreateFlightCommandHandler(IFlightRepository flightRepo, IPlaneRepository planeRepo, IUserRepository userRepo, IAirportRepository airportRepo)
        {
            _userRepo = userRepo;
            _airportRepo = airportRepo;
            _flightRepo = flightRepo;
            _planeRepo = planeRepo;
        }

        public async Task<bool> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var flight = request.Flight;
                flight.IsConfirmed = false;
                await _flightRepo.Create(flight);
                
                return true;
            }
            catch(Exception ex)
            {
            }
            return false;
        }
    }
}
