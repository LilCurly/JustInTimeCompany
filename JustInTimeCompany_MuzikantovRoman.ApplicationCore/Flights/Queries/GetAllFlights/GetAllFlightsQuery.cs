using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Queries.GetAllFlights
{
    public class GetAllFlightsQuery : IRequest<List<Flight>>
    {
    }
}
