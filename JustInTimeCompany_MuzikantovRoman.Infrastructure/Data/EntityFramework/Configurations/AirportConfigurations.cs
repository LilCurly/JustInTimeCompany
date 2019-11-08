using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.EntityFramework.Configurations
{
    class AirportConfigurations : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
