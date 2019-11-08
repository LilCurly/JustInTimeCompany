using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Queries.GetFlight
{
    public class GetFlightsPerPilotQuery : IRequest<List<Flight>>
    {
        public GetFlightsPerPilotQuery(string pilot, int limit = 0)
        {
            Pilot = pilot;
            Limit = limit;
        }

        public string Pilot { get; }
        public int Limit { get; }
    }
}
