using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Commands.CreateFlight
{
    public class CreateFlightCommand : IRequest<bool>
    {
        public CreateFlightCommand(Flight flight)
        {
            Flight = flight;
        }
        
        public Flight Flight { get; }
    }
}
