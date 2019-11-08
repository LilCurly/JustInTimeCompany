using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.EntityFramework.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly JustInTimeCompanyDbContext _dbContext;

        public LogRepository(JustInTimeCompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Log log, List<User> users)
        {
            if(users.Count > 0)
            {
                foreach(var user in users)
                {
                    user.Logs.Add(new LogUser
                    {
                        Log = log,
                        User = user 
                    });

                    _dbContext.MyUsers.Update(user);
                }
            }
            await _dbContext.Logs.AddAsync(log);
            _dbContext.SaveChanges();
        }

        public async Task<Log> Get(int id)
        {
            return await _dbContext.Logs.Where(l => l.LogId == id).SingleOrDefaultAsync();
        }
    }
}
