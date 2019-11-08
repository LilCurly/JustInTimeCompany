using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Queries.GetFlightCount
{
    public class GetTotalFlightsCountQuery : IRequest<int>
    {
        public GetTotalFlightsCountQuery(string pilot = null)
        {
            Pilot = pilot;
        }

        public string Pilot { get; }
    }
}
