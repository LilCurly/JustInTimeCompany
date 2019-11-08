using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Queries.GetFlightCount
{
    public class GetIncomingFlightsCountQuery : IRequest<int>
    {
        public GetIncomingFlightsCountQuery(string pilot = null)
        {
            Pilot = pilot;
        }

        public string Pilot { get; }
    }
}
