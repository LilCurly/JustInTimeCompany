using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
    {
        private readonly IUserRepository _repo;
        public LoginUserCommandHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            if(!string.IsNullOrEmpty(request.Mail) && !string.IsNullOrEmpty(request.Password))
            {
                var user = await _repo.FindByName(request.Mail);
                if(user != null)
                {
                    if(await _repo.CheckPassword(user, request.Password))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
