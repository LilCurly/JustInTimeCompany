using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.Domain.Entities
{
    public class LogUser
    {
        public int LogId { get; set; }
        public Log Log { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
