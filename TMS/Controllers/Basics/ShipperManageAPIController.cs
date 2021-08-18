using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Model;
using TMS.Repository;
namespace TMS.Controllers
{
    [Route("ShipperManageAPI")]
    [ApiController]
    public class ShipperManageAPIController : ControllerBase
    {
        ShipperManageRepository shipp = new ShipperManageRepository();
        [HttpGet, Route("GetShipperManage")]
        public IActionResult GetShipperManage(string ShipperName, string ShipperPhone, string DrivingTTime)
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
        /// <summary>
        /// 删除车辆信息
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
        [HttpPost, Route("DelShipperManage")]
        public int DelShipperManage(int ShipperId)
        {
            int i = shipp.ShippDelete(ShipperId);
            return i;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpPost, Route("AddShipperManage")]
        public int AddShipperManage(ShipperManage s)
        {
            int i = shipp.ShippAdd(s);
            return i;
        }
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="ShipperId"></param>
        /// <returns></returns>
        [HttpGet,Route("FanShipperManage")]
        public IActionResult FanShipperManage(int ShipperId)
        {
            ShipperManage s = shipp.GetInfo().Where(x => x.ShipperId.Equals(ShipperId)).FirstOrDefault();
            return Ok(s);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpPost, Route("UptShipperManage")]
        public int UptShipperManage(ShipperManage s) 
        {
            int i = shipp.ShippUpdate(s);
            return i;
        }

    }
}
