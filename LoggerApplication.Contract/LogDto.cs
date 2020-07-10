using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApplication.Contract
{
    public class LogDto
    {
        public int LogId { get; set; }
        public LogType LogType { get; set; }
        public string ShortDesc { get; set; }
        public string FullDesc { get; set; }
        public string RelatedObject { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
