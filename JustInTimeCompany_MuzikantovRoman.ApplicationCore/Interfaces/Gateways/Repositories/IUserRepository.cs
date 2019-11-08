using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories
{
    public interface IUserRepository
    {
        Task<bool> Create(User user, string password);
        Task Update(User user);
        Task<User> FindByName(string email);
        Task<User> FindById(int id);
        Task<bool> CheckPassword(User user, string password);
        Task<List<User>> GetAvailablePilots(DateTime from, DateTime to, int flightId = -1);
        Task<List<string>> GetLogs(User user);
    }
}
