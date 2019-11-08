using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Bookings.Commands.DeleteBooking
{
    public class DeleteBookingCommand : IRequest<bool>
    {
        public DeleteBookingCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
