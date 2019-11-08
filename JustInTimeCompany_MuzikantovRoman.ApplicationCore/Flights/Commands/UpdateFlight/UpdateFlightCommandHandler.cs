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
    public class UpdateFlightCommandHandler : IRequestHandler<UpdateFlightCommand, bool>
    {
        private readonly IFlightRepository _flightRepo;
        private readonly ILogRepository _logRepo;
        public UpdateFlightCommandHandler(IFlightRepository flightRepo, ILogRepository logRepo)
        {
            _flightRepo = flightRepo;
            _logRepo = logRepo;
        }

        public async Task<bool> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = _flightRepo.Get(request.FlightId).Result;
            bool dateChanged = request.DepartureTime != flight.DepartureTime || request.ArrivalTime != flight.ArrivalTime;
            if(dateChanged || 
                request.Seats != flight.Seats || 
                request.Plane != flight.Plane || 
                request.Pilot != flight.Pilot || 
                request.DepartureAirport != flight.DepartureAirport || 
                request.ArrivalAirport != flight.ArrivalAirport)
            {
                var log = new Log();
                var users = new List<User>();

                if(dateChanged)
                {
                    users = _flightRepo.GetUsersInFlight(flight);
                    log.UserMessage = flight.ToUserLog(request.DepartureTime, request.ArrivalTime);
                }

                string oldLog = flight.ToLog();

                flight.DepartureTime = request.DepartureTime;
                flight.ArrivalTime = request.ArrivalTime;
                flight.ArrivalAirport = request.ArrivalAirport;
                flight.DepartureAirport = request.DepartureAirport;
                flight.Pilot = request.Pilot;
                flight.Plane = request.Plane;
                flight.Seats = request.Seats;

                string newLog = flight.ToLog();

                log.ConcernedFlight = flight;
                log.LogMessage = $"Previous : {oldLog} \n Updated : {newLog}"; 
                log.Date = DateTime.Now;
                log.DateModified = dateChanged;
                
                await _logRepo.Create(log, users);
                await _flightRepo.Update(flight);
                return true;
            }
            return false;
        }
    }
}
