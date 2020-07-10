using System;
using System.Collections.Generic;
using System.Text.Json;
using LoggerApplication.Contract;
using LoggerApplication.Core.Helper;
using LoggerApplication.Framework.Controllers;
using LoggerApplication.Service.Logging;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LoggerApplication.Controllers
{
    [Route("api/logs/[action]")]
    [ApiController]
    public class LoggerController : BasicApiController
    {
        protected readonly ILogService _logService;

        public LoggerController(ILogService logService) : base()
        {
            _logService = logService;
        }

        //log listesi
        [HttpGet]
        public ActionResult<List<LogListItemDto>> GetAll()
        {
            return _logService.GetLogList();
        }

        //tek log
        [HttpGet("{id}")]
        public ActionResult<LogDto> Get(int id)
        {
            return _logService.GetLogInfoById(id);
        }

        //loglarda arama yapma
        [HttpPost]
        public ActionResult<List<LogListItemDto>> Search([FromBody] JsonElement jsonValue)
        {
            var value = JsonElementHelper.GetString(jsonValue);
            return _logService.GetLogListBySearchTerm(value);
        }

        //bir logun kaydedilmesi
        [HttpPost]
        public ActionResult<bool> Insert([FromBody] JsonElement jsonValue)
        {
            try
            {
                var value = JsonElementHelper.GetString(jsonValue);
                var blogDto = JsonConvert.DeserializeObject<LogDto>(value);
                _logService.InsertLog(blogDto);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //bir logun update edilmesi
        [HttpPut]
        public ActionResult<bool> Put([FromBody] JsonElement jsonValue)
        {
            try
            {
                var value = JsonElementHelper.GetString(jsonValue);

                var blogInfo = JsonConvert.DeserializeObject<LogDto>(value);

                _logService.UpdateLog(blogInfo);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //logun silinmesi
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                _logService.DeleteLog(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}