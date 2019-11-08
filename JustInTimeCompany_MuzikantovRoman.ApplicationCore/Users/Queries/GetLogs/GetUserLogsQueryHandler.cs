using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Users.Queries.GetLogs
{
    class GetUserLogsQueryHandler : IRequestHandler<GetUserLogsQuery, List<string>>
    {
        private readonly IUserRepository _userRepo;

        public GetUserLogsQueryHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<List<string>> Handle(GetUserLogsQuery request, CancellationToken cancellationToken)
        {
            List<string> result = new List<string>();
            var user = await _userRepo.FindByName(request.UserName);

            result = await _userRepo.GetLogs(user);

            return result;
        }
    }
}
