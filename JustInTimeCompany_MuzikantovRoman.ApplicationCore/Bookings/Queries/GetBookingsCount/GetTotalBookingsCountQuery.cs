using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Bookings.Queries.GetBookingsCount
{
    public class GetTotalBookingsCountQuery : IRequest<int>
    {
        public GetTotalBookingsCountQuery(string user)
        {
            User = user;
        }

        public string User { get; }
    }
}
