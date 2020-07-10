using LoggerApplication.Contract;
using System.Collections.Generic;

namespace LoggerApplication.Service.Logging
{
    public interface ILogService
    {
        List<LogListItemDto> GetLogList();
        LogDto GetLogInfoById(int id);
        List<LogListItemDto> GetLogListBySearchTerm(string term);
        void InsertLog(LogDto logDto);
        void UpdateLog(LogDto logDto);
        void DeleteLog(int logId);
    }
}
