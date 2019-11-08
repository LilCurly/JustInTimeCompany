using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.EntityFramework.Configurations
{
    class BookingConfigurations : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasOne(u => u.User).WithMany(b => b.Bookings);
            builder.HasOne(f => f.Flight);
            
            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.Count).IsRequired();
        }
    }
}
