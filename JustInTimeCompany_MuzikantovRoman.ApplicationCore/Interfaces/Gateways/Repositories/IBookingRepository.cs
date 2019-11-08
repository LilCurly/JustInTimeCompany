using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories
{
    public interface IBookingRepository
    {
        Task Create(Booking booking);
        Task Delete(Booking booking);
        Task<Booking> Get(int id);
        Task<List<Booking>> GetPerUser(User user, int limit = 0);
        Task<List<Booking>> GetPerUserIncoming(User user, int limit = 0);
        Task<int> GetTotalCount(User user);
        Task<int> GetIncomingCount(User user);
    }
}
