using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Commands.UpdateFlight
{
    public class UpdateFlightRealTimeCommand : IRequest<bool>
    {
        public UpdateFlightRealTimeCommand(int flightId, DateTime realDeparture, DateTime realArrival, string reason)
        {
            FlightId = flightId;
            RealDeparture = realDeparture;
            RealArrival = realArrival;
            Reason = reason;
        }

        public int FlightId { get; }
        public DateTime RealDeparture { get; }
        public DateTime RealArrival { get; }
        public string Reason { get; }
    }
}
