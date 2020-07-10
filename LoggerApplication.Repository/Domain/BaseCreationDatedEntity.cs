using System;

namespace LoggerApplication.Repository.Domain
{
    public abstract class BaseCreationDatedEntity : BaseWithIdEntity
    {
        public DateTime CreatedOnUtc { get; set; }
    }
}
