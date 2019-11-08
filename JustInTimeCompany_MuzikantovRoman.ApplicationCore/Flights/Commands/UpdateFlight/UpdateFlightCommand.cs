using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Commands.UpdateFlight
{
    public class UpdateFlightCommand : IRequest<bool>
    {
        public UpdateFlightCommand(int flightId, DateTime departureTime, DateTime arrivalTime, Plane plane, User pilot, Airport departureAirport, Airport arrivalAirport, int seats)
        {
            FlightId = flightId;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Plane = plane;
            Pilot = pilot;
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
            Seats = seats;
        }

        public int FlightId { get; }
        public DateTime DepartureTime { get; }
        public DateTime ArrivalTime { get; }
        public Plane Plane { get; }
        public User Pilot { get; }
        public Airport DepartureAirport { get; }
        public Airport ArrivalAirport { get; }
        public int Seats { get; }
    }
}
