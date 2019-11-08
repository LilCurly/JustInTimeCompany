using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Users.Queries.GetUser
{
    class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly IUserRepository _repo;

        public GetUserQueryHandler(IUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _repo.FindByName(request.Email);
        }
    }
}
