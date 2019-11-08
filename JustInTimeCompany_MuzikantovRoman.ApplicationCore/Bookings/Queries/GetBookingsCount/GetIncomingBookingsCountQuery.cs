using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Bookings.Queries.GetBookingsCount
{
    public class GetIncomingBookingsCountQuery : IRequest<int>
    {
        public GetIncomingBookingsCountQuery(string user)
        {
            User = user;
        }

        public string User { get; }
    }
}
