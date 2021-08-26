using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Repository;
using TMS.Model;
using Microsoft.Extensions.Logging;
using TMS.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;

namespace TMS.Controllers
{
    [Route("GasolineManageRepostioryAPI")]
    [ApiController]
    public class GasolineManageRepostioryAPIController : ControllerBase
    {
        [Route("CarManageAPI")]
        [ApiController]
        public class CarManageAPIController : ControllerBase
        {
            //CarManageRepository car = new CarManageRepository();
            public IGaso gaso;
            /// <summary>
            /// 日志器
            /// </summary>
            private ILogger m_Logger;
            /// <summary>
            /// 日志器工厂
            /// </summary>
            private ILoggerFactory m_LoggerFactory;
            public CarManageAPIController(ILoggerFactory loggerFactory, IGaso _gaso)
            {
                gaso = _gaso;
                m_LoggerFactory = loggerFactory;
                // 获取指定名字的日志器
                m_Logger = m_LoggerFactory.CreateLogger("AppLogger");
            }
            //[Authorize]
            /// <summary>
            /// 显示车辆信息
            /// </summary>
            /// <returns></returns>
            [HttpGet, Route("GetGasolineManage")]
            [Authorize]
            public IActionResult GetGasolineManage(string GasoLicense, string GasoAgent)
            {
                try
                {
                    var list = gaso.GetInfo();
                    if (!string.IsNullOrEmpty(GasoLicense))//判断查找厂牌型号
                    {
                        list = list.Where(x => x.GasoLicense.Contains(GasoLicense)).ToList();
                    }
                    if (!string.IsNullOrEmpty(GasoAgent))//判断查找车牌号
                    {
                        list = list.Where(x => x.GasoAgent.Contains(GasoAgent)).ToList();
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
            [HttpPost, Route("DelGasolineManage")]
            public IActionResult DelGasolineManage(int GasoId)
            {
                try
                {
                    int i = gaso.GasolineManageDelete(GasoId);
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
            [HttpPost, Route("AddCarManageGasolineManage")]
            public IActionResult AddCarManageGasolineManage(GasolineManage g)
            {
                try
                {
                    int i = gaso.GasolineManageAdd(g);
                    return Ok(i);
                }
                catch (Exception ex)
                {
                    m_Logger.LogError(ex, "数据异常错误");
                    return Ok("数据异常");
                }
            }
            [Authorize]
            [HttpGet, Route("FanGasolineManage")]
            public IActionResult FanGasolineManage(int GasoId)
            {
                try
                {
                    GasolineManage s = gaso.GetInfo().Where(x => x.GasoId.Equals(GasoId)).FirstOrDefault();
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
            [HttpPost, Route("UptGasolineManage")]
            [Authorize]
            public IActionResult UptGasolineManage(GasolineManage g)
            {
                try
                {
                    int i = gaso.GasolineManageUpdate(g);
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
}
