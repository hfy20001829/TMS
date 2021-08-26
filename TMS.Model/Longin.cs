using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
   public class Longin
    {
        public int Id   { get; set; }// 登陆Id
        public string Name { get; set; }//登录名
        public string Pass { get; set; }//登陆密码
        public int UserId { get; set; }//部门表Id
    }
}
