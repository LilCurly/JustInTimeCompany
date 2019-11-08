using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.Domain.Entities
{
    public class Log
    {
        public int LogId { get; set; }
        public string LogMessage { get; set; }
        public string UserMessage { get; set; }
        public DateTime Date { get; set; }
        public bool DateModified { get; set; }
        public Flight ConcernedFlight { get; set; }
        public ICollection<LogUser> ConcernedUsers { get; set; }
    }
}
