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
    [Route("LonginAPI")]
    [ApiController]
    public class LonginAPIController : ControllerBase
    {
        LonginRepository longin = new LonginRepository();
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        [HttpPost,Route("LonGin")]
        public int LonGin(Longin l)
        {
            var list = longin.GetInfo(l);
            int i = 0;
            if (list.Count == 0)
            {
                return i = 0;
            }
            foreach (var item in list)
            {
                if (item.Name == l.Name && item.Pass == l.Pass)
                {
                    if (item.UserId == 0)
                    {
                        return i = 1;
                    }
                    else if (item.UserId == 1)
                    {
                        return i = 2;
                    }
                    return i = 0;
                }
            }
            return i;
        }
    }
}
