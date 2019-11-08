using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Commands.CreateFlight
{
    public class CreateFlightEveryDayOfWeekCommand : IRequest<bool>
    {
        public CreateFlightEveryDayOfWeekCommand(DateTime departureTime, DateTime arrivalTime, int planeId, int pilotId, int departureAirportId, int arrivalAirportId, int seats)
        {
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            PlaneId = planeId;
            PilotId = pilotId;
            DepartureAirportId = departureAirportId;
            ArrivalAirportId = arrivalAirportId;
            Seats = seats;
        }

        public DateTime DepartureTime { get; }
        public DateTime ArrivalTime { get; }
        public int PlaneId { get; }
        public int PilotId { get; }
        public int DepartureAirportId { get; }
        public int ArrivalAirportId { get; }
        public int Seats { get; }
    }
}
