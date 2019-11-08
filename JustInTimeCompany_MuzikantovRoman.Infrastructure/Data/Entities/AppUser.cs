using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public User User { get; set; }
    }
}
