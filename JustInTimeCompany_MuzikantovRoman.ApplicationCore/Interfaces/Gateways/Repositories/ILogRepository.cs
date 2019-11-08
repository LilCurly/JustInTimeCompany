using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories
{
    public interface ILogRepository
    {
        Task Create(Log log, List<User> users);
        Task<Log> Get(int id);
    }
}
