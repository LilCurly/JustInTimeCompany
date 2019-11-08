using Microsoft.EntityFrameworkCore;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.EntityFramework.Configurations
{
    class LogUserConfigurations : IEntityTypeConfiguration<LogUser>
    {
        public void Configure(EntityTypeBuilder<LogUser> builder)
        {
            builder.HasKey(bc => new { bc.LogId , bc.UserId });
            builder
                .HasOne(bc => bc.Log)
                .WithMany(b => b.ConcernedUsers)
                .HasForeignKey(bc => bc.LogId);  
            builder
                .HasOne(bc => bc.User)
                .WithMany(c => c.Logs)
                .HasForeignKey(bc => bc.UserId);
        }
    }
}
