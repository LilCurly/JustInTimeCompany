using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Users.Queries.GetLogs
{
    public class GetUserLogsQuery : IRequest<List<string>>
    {
        public GetUserLogsQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; }
    }
}
