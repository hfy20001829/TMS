using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Model;
using TMS.Repository;
using TMS.Repository.IRepository;
namespace TMS.Controllers
{
    [Route("CarManageAPI")]
    [ApiController]
    public class CarManageAPIController : ControllerBase
    {
        //CarManageRepository car = new CarManageRepository();
        public ICar car;
        /// <summary>
        /// 日志器
        /// </summary>
        private ILogger m_Logger;
        /// <summary>
        /// 日志器工厂
        /// </summary>
        private ILoggerFactory m_LoggerFactory;
        public CarManageAPIController(ILoggerFactory loggerFactory, ICar _car)
        {
            car = _car;
            m_LoggerFactory = loggerFactory;
            // 获取指定名字的日志器
            m_Logger = m_LoggerFactory.CreateLogger("AppLogger");
        }
        [Authorize]
        /// <summary>
        /// 显示车辆信息
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("GetCarManage")]
        public IActionResult GetCarManage(string Factory, string CarLicense, string CarName, string Company)
        {
            try
            {
                var list = car.GetInfo();
                if (!string.IsNullOrEmpty(Factory))//判断查找厂牌型号
                {
                    list = list.Where(x => x.Factory.Contains(Factory)).ToList();
                }
                if (!string.IsNullOrEmpty(CarLicense))//判断查找车牌号
                {
                    list = list.Where(x => x.CarLicense.Contains(CarLicense)).ToList();
                }
                if (!string.IsNullOrEmpty(CarName))//判断查找司机姓名
                {
                    list = list.Where(x => x.CarName.Contains(CarName)).ToList();
                }
                if (!string.IsNullOrEmpty(Company))//判断查找所属公司
                {
                    list = list.Where(x => x.Company.Contains(Company)).ToList();
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
        [HttpPost, Route("DelCarManage")]
        public IActionResult DelCarManage(int CarId)
        {
            try
            {
                int i = car.CarDelete(CarId);
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
        [HttpPost, Route("AddCarManage")]
        public IActionResult AddCarManage(CarManage c)
        {
            try
            {
                int i = car.CarAdd(c);
                return Ok(i);
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "数据异常错误");
                return Ok("数据异常");
            }
        }
        [Authorize]
        [HttpGet, Route("FanCarManage")]
        public IActionResult FanCarManage(int carId)
        {
            try
            {
                CarManage s = car.GetInfo().Where(x => x.CarId.Equals(carId)).FirstOrDefault();
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
        [HttpPost, Route("UptCarManage")]
        [Authorize]
        public IActionResult UptCarManage(CarManage c)
        {
            try
            {
                int i = car.CarUpdate(c);
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
