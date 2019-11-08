using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Commands.CreateFlight
{
    public class CreateFlightEveryWeekCommand : IRequest<bool>
    {
        public CreateFlightEveryWeekCommand(DateTime departureTime, DateTime arrivalTime, int planeId, int pilotId, int departureAirportId, int arrivalAirportId, int seats, int number)
        {
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            PlaneId = planeId;
            PilotId = pilotId;
            DepartureAirportId = departureAirportId;
            ArrivalAirportId = arrivalAirportId;
            Seats = seats;
            Number = number;
        }

        public DateTime DepartureTime { get; }
        public DateTime ArrivalTime { get; }
        public int PlaneId { get; }
        public int PilotId { get; }
        public int DepartureAirportId { get; }
        public int ArrivalAirportId { get; }
        public int Seats { get; }
        public int Number { get; }
    }
}
