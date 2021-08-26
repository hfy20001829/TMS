using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Model;
using TMS.Repository.IRepository;
namespace TMS.Controllers.Personnel
{
    [Route("EntryManageAPI")]
    [ApiController]
    public class EntryManageAPIController : ControllerBase
    {
        public IEntry entry;
        /// <summary>
        /// 日志器
        /// </summary>
        private ILogger m_Logger;
        /// <summary>
        /// 日志器工厂
        /// </summary>
        private ILoggerFactory m_LoggerFactory;
        public EntryManageAPIController(ILoggerFactory loggerFactory, IEntry _entry)
        {
            entry = _entry;
            m_LoggerFactory = loggerFactory;
            // 获取指定名字的日志器
            m_Logger = m_LoggerFactory.CreateLogger("AppLogger");
        }
        [Authorize]
        /// <summary>
        /// 显示车辆信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetEntry")]
        public IActionResult GetEntry(string EntrtName, int UserId, string EntryPost, string EntryUP)
        {
            try
            {
                var list = entry.GetInfo();
                if (!string.IsNullOrEmpty(EntrtName))//判断查找厂牌型号
                {
                    list = list.Where(x => x.EntrtName.Contains(EntrtName)).ToList();
                }
                if (UserId != 0)//判断查找车牌号
                {
                    list = list.Where(x => x.UserId == UserId).ToList();
                }
                if (!string.IsNullOrEmpty(EntryPost))//判断查找司机姓名
                {
                    list = list.Where(x => x.EntryPost.Contains(EntryPost)).ToList();
                }
                if (!string.IsNullOrEmpty(EntryUP))//判断查找所属公司
                {
                    list = list.Where(x => x.EntryUP.Contains(EntryUP)).ToList();
                }
                return Ok(new { date = list });
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "数据异常错误");
                return Ok("数据异常");
            }

        }
        [Authorize]
        /// <summary>
        /// 删除车辆信息
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
        [HttpPost, Route("DelEntry")]
        public IActionResult DelEntry(int EntryId)
        {
            try
            {
                int i = entry.EntryDelete(EntryId);
                return Ok(i);
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "数据异常错误");
                return Ok("数据异常");
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost, Route("AddEntry")]
        public IActionResult AddEntry(EntryManage e)
        {
            try
            {
                int i = entry.EntryAdd(e);
                return Ok(e);
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "数据异常错误");
                return Ok("数据异常");
            }
        }
        [Authorize]
        [HttpGet, Route("FanEntry")]
        public IActionResult FanEntry(int EntryId)
        {
            try
            {
                EntryManage s = entry.GetInfo().Where(x => x.EntryId.Equals(EntryId)).FirstOrDefault();
                return Ok(s);
            }
            catch (Exception ex)
            {

                m_Logger.LogError(ex, "数据异常错误");
                return Ok("数据异常");
            }
        }
        ///// <summary>
        ///// 修改
        ///// </summary>
        ///// <param name="c"></param>
        /// <returns></returns>
        [HttpPost, Route("UptEntry")]
        [Authorize]
        public IActionResult UptEntry(EntryManage e)
        {
            try
            {
                int i = entry.EntryUpdate(e);
                return Ok(i);
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "数据异常错误");
                return Ok("数据异常");
            }
        }
    }
}
