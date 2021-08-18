using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
   public class ShipperManage
    {
        public int ShipperId { get; set; }
        public string ShipperName    { get; set; }
        public string ShipperPhone   { get; set; }
        public string UnitName       { get; set; }
        public string ContactAddress { get; set; }
        public DateTime DrivingTime    { get; set; }
        public string DrivingTTime { get {return DrivingTime.ToString("yyyy-MM-dd"); } }
        public string DrivingPicture { get; set; }
        public string ShipperRemark  { get; set; }
        public DateTime ShipperTime    { get; set; }
        public int UserId { get; set; }
    }                     
}
