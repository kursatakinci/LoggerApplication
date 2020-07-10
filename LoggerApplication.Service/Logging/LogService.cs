using LoggerApplication.Contract;
using LoggerApplication.Repository;
using LoggerApplication.Repository.Domain.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggerApplication.Service.Logging
{
    public class LogService : ILogService
    {
        protected readonly IUnitOfWork _unitOfWork;

        public LogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteLog(int logId)
        {
            var log = _unitOfWork.Logs.GetById(logId);

            if (log != null)
            {
                _unitOfWork.Logs.Delete(log);
                _unitOfWork.Commit();
            }
        }

        public LogDto GetLogInfoById(int id)
        {
            var log = _unitOfWork.Logs.GetById(id);

            if (log == null)
            {
                return null;
            }
            else
            {
                return new LogDto { LogId = log.Id, LogType = (LogType)log.LogTypeId, ShortDesc = log.ShortDesc, FullDesc = log.FullDesc, CreatedOnUtc = log.CreatedOnUtc, RelatedObject = log.RelatedObject };
            }
        }

        public List<LogListItemDto> GetLogList()
        {
            var logList = _unitOfWork.Logs.Get();

            //TODO: add automapper in project
            return logList.Select(l => new LogListItemDto() { LogId = l.Id, LogType = (LogType)l.LogTypeId, CreatedOnUtc = l.CreatedOnUtc, ShortDesc = l.ShortDesc }).ToList();
        }

        public List<LogListItemDto> GetLogListBySearchTerm(string term)
        {
            var logList = _unitOfWork.Logs.Get(b => b.ShortDesc.Contains(term) || b.FullDesc.Contains(term));

            //TODO: add automapper in project
            return logList.Select(l => new LogListItemDto() { LogId = l.Id, LogType = (LogType)l.LogTypeId, ShortDesc = l.ShortDesc, CreatedOnUtc = l.CreatedOnUtc }).ToList();
        }

        public void InsertLog(LogDto logDto)
        {
            var log = new Log() { LogTypeId = (int)logDto.LogType, ShortDesc = logDto.ShortDesc, FullDesc = logDto.FullDesc, RelatedObject = logDto.RelatedObject, CreatedOnUtc = DateTime.UtcNow };
            _unitOfWork.Logs.Insert(log);
            _unitOfWork.Commit();
        }

        public void UpdateLog(LogDto logDto)
        {
            var log = _unitOfWork.Logs.GetById(logDto.LogId);

            if (log != null)
            {
                log.ShortDesc = logDto.ShortDesc;
                log.FullDesc = logDto.FullDesc;
                log.RelatedObject = logDto.RelatedObject;
                log.LogTypeId = (int)logDto.LogType;

                _unitOfWork.Logs.Update(log);
                _unitOfWork.Commit();
            }
        }
    }
}
