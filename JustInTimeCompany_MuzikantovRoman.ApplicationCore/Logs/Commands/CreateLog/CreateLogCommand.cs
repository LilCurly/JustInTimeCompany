using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Logs.Commands.CreateLog
{
    public class CreateLogCommand : IRequest<bool>
    {
        public CreateLogCommand(Log log)
        {
            Log = log;
        }

        public Log Log { get; }
    }
}
