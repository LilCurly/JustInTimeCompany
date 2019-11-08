using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Airports.Queries
{
    public class GetAllAirportQuery : IRequest<List<Airport>>
    {
    }
}
