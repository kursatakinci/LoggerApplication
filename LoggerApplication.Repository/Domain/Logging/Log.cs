using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApplication.Repository.Domain.Logging
{
    public class Log : BaseCreationDatedEntity
    {
        public int LogTypeId { get; set; }
        public string ShortDesc { get; set; }
        public string FullDesc { get; set; }
        public string RelatedObject { get; set; }
    }
}
