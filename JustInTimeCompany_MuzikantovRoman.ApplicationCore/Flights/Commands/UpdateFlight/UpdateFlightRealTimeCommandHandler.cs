using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Commands.UpdateFlight
{
    public class UpdateFlightRealTimeCommandHandler : IRequestHandler<UpdateFlightRealTimeCommand, bool>
    {
        private readonly IFlightRepository _flightRepo;
        private readonly IPlaneRepository _planeRepo;

        public UpdateFlightRealTimeCommandHandler(IFlightRepository flightRepo, IPlaneRepository planeRepo)
        {
            _flightRepo = flightRepo;
            _planeRepo = planeRepo;
        }
        public async Task<bool> Handle(UpdateFlightRealTimeCommand request, CancellationToken cancellationToken)
        {
            var flight = await _flightRepo.Get(request.FlightId);
            if(flight == null)
            {
                // TRHOW EXCEPTION
            }
            flight.RealArrivalTime = request.RealArrival;
            flight.RealDepartureTime = request.RealDeparture;
            flight.IsConfirmed = true;
            if(request.Reason != null)
            {
                flight.LateReason = request.Reason;
            }
            var plane = flight.Plane;
            plane.TimesUsed++;
            if(plane.TimesUsed == 6)
            {
                plane.State = State.Garage;
            }
            await _planeRepo.UpdateStatus(plane);
            await _flightRepo.Update(flight);
            return true;
        }
    }
}
