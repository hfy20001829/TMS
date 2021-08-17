using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
    public class UserTable
    {
        public int UserId { get; set; }//菜单表Id
        public string UserName { get; set; }//菜单表名称
        public int PId { get; set; }//菜单表父级Id
    }
}
