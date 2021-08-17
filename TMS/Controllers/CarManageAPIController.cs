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
    [Route("CarManageAPI")]
    [ApiController]
    public class CarManageAPIController : ControllerBase
    {
        CarManageRepository car = new CarManageRepository();
        /// <summary>
        /// 显示车辆信息
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("GetCarManage")]
        public IActionResult GetCarManage(string Factory, string CarLicense, string CarName, string Company)
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
        /// <summary>
        /// 删除车辆信息
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
        [HttpPost, Route("DelCarManage")]
        public int DelCarManage(int CarId) 
        {
            int i = car.CarDelete(CarId);
            return i;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpPost, Route("AddCarManage")]
        public int AddCarManage(CarManage c)
        {
            int i = car.CarAdd(c);
            return i;
        }
        //public IActionResult Fan(int carId)
        //{
        //    CarManage s = car.GetInfo().Where(x => x.CarId.Equals(carId)).FirstOrDefault();
        //    return ;
        //}
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpPost, Route("UptCarManage")]

        public int UptCarManage(CarManage c,int carId)
        {
            CarManage s = car.GetInfo().Where(x => x.CarId.Equals(carId)).FirstOrDefault();
            int i = car.CarUpdate(c);
            return i;
        }

    }
}
