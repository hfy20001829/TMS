using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Model;
using TMS.Repository;
namespace TMS.Controllers.Basics
{
    [Route("OutSourManage")]
    [ApiController]
    [Authorize]
    public class OutsourcingManageAPIController : ControllerBase
    {
        OutsourcingManageRepository outsour = new OutsourcingManageRepository();
        [HttpGet, Route("GetOutSour")]
        public IActionResult GetOutSour(string OutName, string OutPhone)
        {
            var list = outsour.GetInfo();
            if (!string.IsNullOrEmpty(OutName))//判断查找名字
            {
                list = list.Where(x => x.OutName.Contains(OutName)).ToList();

            }
            if (!string.IsNullOrEmpty(OutPhone))//判断查找手机号
            {
                list = list.Where(x => x.OutPhone.Contains(OutPhone)).ToList();
            }
            return Ok(new { date = list });
        }
        [Authorize]
        /// <summary>
        /// 删除车辆信息
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
        [HttpPost, Route("DelOutSour")]
        public int DelOutSour(int OutId)
        {
            int i = outsour.OutsourDelete(OutId);
            return i;
        }
        [Authorize]
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpPost, Route("AddOutSour")]
        public int AddOutSour(OutsourcingManage o)
        {
            int i = outsour.OutsourAdd(o);
            return i;
        }
        [Authorize]
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="ShipperId"></param>
        /// <returns></returns>
        [HttpGet, Route("FanOutSour")]
        public IActionResult FanOutSour(int OutId)
        {
            OutsourcingManage o = outsour.GetInfo().Where(x => x.OutId.Equals(OutId)).FirstOrDefault();
            return Ok(o);
        }
        [Authorize]
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpPost, Route("UptOutSour")]
        public int UptOutSour(OutsourcingManage o)
        {
            int i = outsour.OutsourUpdate(o);
            return i;
        }
    }
}
