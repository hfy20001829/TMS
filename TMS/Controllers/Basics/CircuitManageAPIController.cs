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
namespace TMS.Controllers.Basics
{
    [Route("CircuitManageAPIController")]
    [ApiController]
    public class CircuitManageAPIController : ControllerBase
    {
        //CircuitManageRepository cir = new CircuitManageRepository();

        private ILogger m_Logger;
        /// <summary>
        /// 日志器工厂
        /// </summary>
        private ILoggerFactory m_LoggerFactory;
        public ICir cir;
        public CircuitManageAPIController (ICir _cir, ILoggerFactory loggerFactory)
        {
            cir = _cir;
            m_LoggerFactory = loggerFactory;
            // 获取指定名字的日志器
            m_Logger = m_LoggerFactory.CreateLogger("AppLogger");
        }
        [Authorize]
        /// <summary>
        /// 显示车辆信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetCircuitManage")]
        public IActionResult GetCircuitManage(string CircuitName, string CircuitStart, string CircuitTerminus, string CircuitStuta,string ShipperPhone,string UnitName)
        {
            try
            {
                var list = cir.GetInfo();
                if (!string.IsNullOrEmpty(CircuitName))//判断查找厂牌型号
                {
                    list = list.Where(x => x.CircuitName.Contains(CircuitName)).ToList();
                }
                if (!string.IsNullOrEmpty(CircuitStart))//判断查找车牌号
                {
                    list = list.Where(x => x.CircuitStart.Contains(CircuitStart)).ToList();
                }
                if (!string.IsNullOrEmpty(CircuitTerminus))//判断查找司机姓名
                {
                    list = list.Where(x => x.CircuitTerminus.Contains(CircuitTerminus)).ToList();
                }
                if (!string.IsNullOrEmpty(CircuitStuta))//判断查找所属公司
                {
                    list = list.Where(x => x.CircuitStuta.Contains(CircuitStuta)).ToList();
                }
                if (!string.IsNullOrEmpty(ShipperPhone))//判断查找所属公司
                {
                    list = list.Where(x => x.ShipperPhone.Contains(ShipperPhone)).ToList();
                }
                if (!string.IsNullOrEmpty(UnitName))//判断查找所属公司
                {
                    list = list.Where(x => x.UnitName.Contains(UnitName)).ToList();
                }
                return Ok(new { date = list });
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "捕捉到异常");
                return Ok("数据异常");
            }
        }
        [Authorize]
        /// <summary>
        /// 删除车辆信息
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
        [HttpPost, Route("DelCircuitManage")]
        public int DelCircuitManage(int CircuitId)
        {
            int i = cir.CircuitDelete(CircuitId);
            return i;
        }
        [Authorize]
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost, Route("AddCircuitManage")]
        public int AddCircuitManage(CircuitManage c)
        {
            int i = cir.CircuitAdd(c);
            return i;
        }
        [Authorize]
        [HttpGet, Route("FanCircuitManage")]
        public IActionResult FanCarManage(int CircuitId)
        {
            CircuitManage s = cir.GetInfo().Where(x => x.CircuitId.Equals(CircuitId)).FirstOrDefault();
            return Ok(s);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpPost, Route("UptCircuitManage")]
        [Authorize]
        public int UptCircuitManage(CircuitManage c)
        {
            int i = cir.CirucitUpdate(c);
            return i;
        }
    }
}
