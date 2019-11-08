using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository _repo;
        public CreateUserCommandHandler(IUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Create(
                new User(){ FirstName = request.FirstName, LastName = request.LastName, Mail = request.Mail, Password = request.Password, IsPilot = false }, 
                request.Password);
        }
    }
}
