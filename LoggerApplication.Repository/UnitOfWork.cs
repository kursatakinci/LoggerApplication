using LoggerApplication.Repository.Domain.Logging;

namespace LoggerApplication.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private LoggerApplicationDbContext _dbContext;
        private BaseRepository<Log> _logs;

        public UnitOfWork(LoggerApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Log> Logs
        {
            get
            {
                return _logs ??
                    (_logs = new BaseRepository<Log>(_dbContext));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
