using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.EntityFramework.Configurations
{
    class PlaneConfigurations : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder.Property(p => p.Capacity).IsRequired();
            builder.Property(p => p.Motor).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Speed).IsRequired();
        }
    }
}
