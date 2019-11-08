using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.EntityFramework.Configurations
{
    class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(b => b.Bookings).WithOne(u => u.User);
            builder.HasMany(f => f.PilotFlights).WithOne(u => u.Pilot);
        }
    }
}
