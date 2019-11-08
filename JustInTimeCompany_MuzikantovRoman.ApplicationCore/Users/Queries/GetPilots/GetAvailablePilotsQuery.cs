using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Users.Queries.GetPilots
{
    public class GetAvailablePilotsQuery : IRequest<List<User>>
    {
        public GetAvailablePilotsQuery(DateTime from, DateTime to, int flightId = -1)
        {
            From = from;
            To = to;
            FlightId = flightId;
        }

        public DateTime From { get; }
        public DateTime To { get; }
        public int FlightId { get; }
    }
}
