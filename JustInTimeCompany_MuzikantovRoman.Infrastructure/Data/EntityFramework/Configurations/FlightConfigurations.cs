using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.EntityFramework.Configurations
{
    class FlightConfigurations : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasOne(u => u.Pilot).WithMany(f => f.PilotFlights);
            builder.HasOne(p => p.Plane);
            builder.HasOne(a => a.DepartureAirport);
            builder.HasOne(a => a.ArrivalAirport);


            builder.Property(p => p.DepartureTime).IsRequired();
            builder.Property(p => p.ArrivalTime).IsRequired();
            builder.Property(p => p.Seats).IsRequired();
        }
    }
}
