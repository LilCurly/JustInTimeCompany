using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Queries.GetFlight
{
    public class GetFlightsPerAirportQuery : IRequest<List<Flight>>
    {
        public GetFlightsPerAirportQuery(int departureAirportId = -1, int arrivalAirportId = -1, DateTime? arrivalDateTime = null)
        {
            DepartureAirportId = departureAirportId;
            ArrivalAirportId = arrivalAirportId;
            ArrivalDateTime = arrivalDateTime;
        }

        public int DepartureAirportId { get; }
        public int ArrivalAirportId { get; }
        public DateTime? ArrivalDateTime { get; }
    }
}
