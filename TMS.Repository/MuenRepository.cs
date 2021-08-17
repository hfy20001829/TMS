using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
namespace TMS.Repository
{
   public class MuenRepository
    {
        /// <summary>
        /// 部门表显示
        /// </summary>
        /// <returns></returns>
        public List<UserTable> GetInfo()
        {
            string sql = "select *from UserTable";
            List<UserTable> users = DapperHelper<UserTable>.Gets(sql);
            return users;
        }
    }
}
