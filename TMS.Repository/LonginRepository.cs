using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
namespace TMS.Repository
{
    public class LonginRepository
    {
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="longin"></param>
        /// <returns></returns>
        public List<Longin> GetInfo(Longin longin)
        {
            string sql = $"select *from Longin where Name='{longin.Name}' and Pass='{longin.Pass}'";
            List<Longin> longins = DapperHelper<Longin>.Gets(sql);
            return longins;
        }
    }
}
