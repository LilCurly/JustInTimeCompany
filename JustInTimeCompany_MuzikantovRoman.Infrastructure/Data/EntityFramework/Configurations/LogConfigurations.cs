using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.EntityFramework.Configurations
{
    class LogConfigurations : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasOne(f => f.ConcernedFlight).WithMany(l => l.Logs);
            
            builder.Property(p => p.DateModified).IsRequired();
            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.LogMessage).IsRequired();
        }
    }
}
