using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
   public class CircuitManage
    {
        public int CircuitId       { get; set; }
        public string CircuitName     { get; set; }
        public string CircuitStart    { get; set; }
        public string CircuitTerminus { get; set; }
        public string CircuitStuta { get; set; }
        public int ShipperId { get; set; }
        public string ShipperName { get; set; }
        public string ShipperPhone { get; set; }
        public string UnitName { get; set; }
        public string ShipperRemark { get; set; }
        public DateTime DrivingTime { get; set; }
        public int UserId { get; set; }
        public virtual ShipperManage ShipperManage { get; set; }
    }
}
