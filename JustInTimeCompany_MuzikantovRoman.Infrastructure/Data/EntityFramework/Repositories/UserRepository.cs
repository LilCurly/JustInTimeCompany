using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.EntityFramework.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly JustInTimeCompanyDbContext _dbContext;

        public UserRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, JustInTimeCompanyDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Mail, password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task<bool> Create(User user, string password)
        {
            var appUser = new AppUser(){ User = user, UserName = user.Mail, Email = user.Mail, PasswordHash = user.Password };
            var result = await _userManager.CreateAsync(appUser, password);

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(appUser, "Member").Wait();
            }

            return result.Succeeded;
        }

        public async Task<User> FindById(int id)
        {
            return await _dbContext.MyUsers.Where(u => u.UserId == id).SingleAsync();
        }

        public async Task<User> FindByName(string email)
        {
            var result = await _userManager.Users.Where(u => u.UserName == email).Include(u => u.User).SingleAsync();
            return result.User;
        }

        public async Task<List<User>> GetAvailablePilots(DateTime from, DateTime to, int flightId = -1)
        {
            var pilots = _dbContext.Users.Include(p => p.User).Where(p => p.User.IsPilot == true);
            var query = _dbContext.Flights.AsQueryable();
            if(flightId != -1)
            {
                query = query.Where(f => f.FlightId != flightId).AsQueryable();
            }
            var conflictPilots = await query.Where(f => from <= f.ArrivalTime && to >= f.DepartureTime).Select(f => f.Pilot).ToListAsync();
            List<User> result = new List<User>();
            foreach(AppUser pilot in pilots)
            {
                if (!conflictPilots.Contains(pilot.User))
                {
                    result.Add(pilot.User);
                }
            }

            /*foreach(AppUser pilot in pilots)
            {
                if(pilot.User.IsAvailable(from, to))
                {
                    result.Add(pilot.User);
                }
            }*/

            return result;
        }

        public async Task<List<string>> GetLogs(User user)
        {
            var result = await (from lu in _dbContext.LogsUsers
                    join l in _dbContext.Logs.Include(log => log.ConcernedFlight) on lu.LogId equals l.LogId
                    where lu.UserId == user.UserId && l.ConcernedFlight.DepartureTime > DateTime.Now 
                    orderby l.Date ascending
                    select l.UserMessage).ToListAsync();

            return result;
        }

        public async Task Update(User user)
        {
            _dbContext.MyUsers.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
