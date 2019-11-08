using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Commands.DeleteFlight
{
    public class DeleteFlightCommand : IRequest<bool>
    {
        public DeleteFlightCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
