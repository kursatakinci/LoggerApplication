using System;

namespace LoggerApplication.Contract
{
    public class LogListItemDto
    {
        public int LogId { get; set; }
        public LogType LogType { get; set; }
        public string ShortDesc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
