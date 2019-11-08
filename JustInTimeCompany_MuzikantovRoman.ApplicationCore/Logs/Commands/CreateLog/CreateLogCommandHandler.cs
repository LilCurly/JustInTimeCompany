using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Logs.Commands.CreateLog
{
    class CreateLogCommandHandler : IRequestHandler<CreateLogCommand, bool>
    {
        private readonly ILogRepository _repo;

        public CreateLogCommandHandler(ILogRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(CreateLogCommand request, CancellationToken cancellationToken)
        {
            List<User> users = new List<User>();
            await _repo.Create(request.Log, users);

            return true;
        }
    }
}
