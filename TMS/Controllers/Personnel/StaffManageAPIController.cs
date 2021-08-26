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
namespace TMS.Controllers
{
    [Route("StaffManageAPI")]
    [ApiController]
    public class StaffManageAPIController : ControllerBase
    {
        public IStaff staf;
        /// <summary>
        /// 日志器
        /// </summary>
        private ILogger m_Logger;
        /// <summary>
        /// 日志器工厂
        /// </summary>
        private ILoggerFactory m_LoggerFactory;
        public StaffManageAPIController(ILoggerFactory loggerFactory, IStaff _staf)
        {
            staf = _staf;
            m_LoggerFactory = loggerFactory;
            // 获取指定名字的日志器
            m_Logger = m_LoggerFactory.CreateLogger("AppLogger");
        }
        [Authorize]
        /// <summary>
        /// 显示车辆信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetStaf")]
        public IActionResult GetStaf(string StafName, int UserId, string StafPost, string StafPhone)
        {
            try
            {
                var list = staf.GetInfo();
                if (!string.IsNullOrEmpty(StafName))//判断查找厂牌型号
                {
                    list = list.Where(x => x.StafName.Contains(StafName)).ToList();
                }
                if (UserId!=0)//判断查找车牌号
                {
                    list = list.Where(x => x.UserId==UserId).ToList();
                }
                if (!string.IsNullOrEmpty(StafPost))//判断查找司机姓名
                {
                    list = list.Where(x => x.StafPost.Contains(StafPost)).ToList();
                }
                if (!string.IsNullOrEmpty(StafPhone))//判断查找所属公司
                {
                    list = list.Where(x => x.StafPhone.Contains(StafPhone)).ToList();
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
        [HttpPost, Route("DelStaf")]
        public IActionResult DelStaf(int StafId)
        {
            try
            {
                int i = staf.StafDelete(StafId);
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
        [HttpPost, Route("AddStaf")]
        public IActionResult AddStaf(StaffManage s)
        {
            try
            {
                int i = staf.StafAdd(s);
                return Ok(i);
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "数据异常错误");
                return Ok("数据异常");
            }
        }
        [Authorize]
        [HttpGet, Route("FanStaf")]
        public IActionResult FanStaf(int StafId)
        {
            try
            {
                StaffManage s = staf.GetInfo().Where(x => x.StafId.Equals(StafId)).FirstOrDefault();
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
        [HttpPost, Route("UptStaf")]
        [Authorize]
        public IActionResult UptStaf(StaffManage s)
        {
            try
            {
                int i = staf.StafUpdate(s);
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
