using LoggerApplication.Repository.Domain.Logging;

namespace LoggerApplication.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Log> Logs { get; }
        void Commit();
    }
}
