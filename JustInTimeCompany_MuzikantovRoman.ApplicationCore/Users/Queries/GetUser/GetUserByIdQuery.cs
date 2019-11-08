using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Users.Queries.GetUser
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public GetUserByIdQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}
