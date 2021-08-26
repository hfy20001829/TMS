using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
  public  class StaffManage
    {
        public int StafId      { get; set; }
        public string StafName    { get; set; }
        public string StafSex     { get; set; }
        public int UserId      { get; set; }
        public string StafPost    { get; set; }
        public string StafPhone   { get; set; }
        public string StafAcademy { get; set; }
        public string StafMajor   { get; set; }
        public string StafHome    { get; set; }
        public DateTime StafTime    { get; set; }
        public string StafAge     { get; set; }
        public string StafSort    { get; set; }
        public string StafState { get; set; }
        public DateTime StafCTime { get; set; }
        public string UserName { get; set; }
    }              
}
