using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
   public class OutsourcingManage
    {
        public int OutId { get; set; }
        public string OutName { get; set; }
        public string OutEmail { get; set; }
        public string OutFixed { get; set; }
        public string OutPhone { get; set; }
        public string OutAddress { get; set; }
        public DateTime OutTime { get; set; }
        public string OutRemark { get; set; }
        public int UserId { get; set; }
    }
}
