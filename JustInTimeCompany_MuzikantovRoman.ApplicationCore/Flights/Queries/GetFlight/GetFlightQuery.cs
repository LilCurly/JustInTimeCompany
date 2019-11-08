using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Queries.GetFlight
{
    public class GetFlightQuery : IRequest<Flight>
    {
        public GetFlightQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
