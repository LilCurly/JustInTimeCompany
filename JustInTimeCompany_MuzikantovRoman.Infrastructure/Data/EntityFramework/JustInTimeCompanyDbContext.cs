using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.Entities;
using JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.EntityFramework.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.EntityFramework
{
    public class JustInTimeCompanyDbContext : IdentityDbContext<AppUser>
    {
        public JustInTimeCompanyDbContext(DbContextOptions<JustInTimeCompanyDbContext> options) : base(options)
        {}

        public DbSet<User> MyUsers { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<LogUser> LogsUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AirportConfigurations());
            builder.ApplyConfiguration(new BookingConfigurations());
            builder.ApplyConfiguration(new FlightConfigurations());
            builder.ApplyConfiguration(new LogConfigurations());
            builder.ApplyConfiguration(new PlaneConfigurations());
            builder.ApplyConfiguration(new UserConfigurations());
            builder.ApplyConfiguration(new LogUserConfigurations());
        }

    }
}
