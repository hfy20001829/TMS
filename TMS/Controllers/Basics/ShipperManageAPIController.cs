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
    [Route("ShipperManageAPI")]
    [ApiController]
    public class ShipperManageAPIController : ControllerBase
    {
        /// <summary>
        /// 日志器
        /// </summary>
        private ILogger m_Logger;

        private IShop shipp;
        /// <summary>
        /// 日志器工厂
        /// </summary>
        private ILoggerFactory m_LoggerFactory;
        public ShipperManageAPIController(ILoggerFactory loggerFactory, IShop _shipp)
        {
            shipp = _shipp;
            m_LoggerFactory = loggerFactory;
            // 获取指定名字的日志器
            m_Logger = m_LoggerFactory.CreateLogger("AppLogger");
        }
        [HttpGet, Route("GetShipperManage")]
        [Authorize]
        public IActionResult GetShipperManage(string ShipperName, string ShipperPhone, string DrivingTTime)
        {
            try
            {
                var list = shipp.GetInfo();
                if (!string.IsNullOrEmpty(ShipperName))//判断查找厂牌型号
                {
                    list = list.Where(x => x.ShipperName.Contains(ShipperName)).ToList();
                }
                if (!string.IsNullOrEmpty(ShipperPhone))//判断查找车牌号
                {
                    list = list.Where(x => x.ShipperPhone.Contains(ShipperPhone)).ToList();
                }
                if (!string.IsNullOrEmpty(DrivingTTime))//日期判断
                {
                    list = list.Where(x => x.DrivingTTime.Contains(DrivingTTime)).ToList();
                }
                return Ok(new { date = list });
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex,"数据异常");
                return Ok("请求错误");
            }
           
        }
        [Authorize]
        /// <summary>
        /// 删除车辆信息
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
        [HttpPost, Route("DelShipperManage")]
        public IActionResult DelShipperManage(int ShipperId)
        {
            try
            {
                int i = shipp.ShippDelete(ShipperId);
                return Ok(i);
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "数据异常");
                return Ok("请求错误");
            }
            
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost, Route("AddShipperManage")]
        public IActionResult AddShipperManage(ShipperManage s)
        {
            try
            {
                int i = shipp.ShippAdd(s);
                return Ok(i);
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "数据异常");
                return Ok("请求错误");
            }
        }

        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="ShipperId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet,Route("FanShipperManage")]
        public IActionResult FanShipperManage(int ShipperId)
        {
            try
            {
                ShipperManage s = shipp.GetInfo().Where(x => x.ShipperId.Equals(ShipperId)).FirstOrDefault();
                return Ok(s);
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "数据异常");
                return Ok("请求异常");
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost, Route("UptShipperManage")]
        public IActionResult UptShipperManage(ShipperManage s) 
        {
            try
            {
                int i = shipp.ShippUpdate(s);
                return Ok(i);
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "数据异常");
                return Ok("请求异常");
                
            }
        }

    }
}
