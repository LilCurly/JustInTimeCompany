using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Airports.Queries
{
    public class GetAirportQuery: IRequest<Airport>
    {
        public GetAirportQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
