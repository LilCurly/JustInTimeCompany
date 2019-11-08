using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<User>
    {
        public GetUserQuery(string email)
        {
            Email = email;
        }

        public string Email { get; }
    }
}
