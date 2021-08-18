using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
   public class CarManage
    {
        public int CarId         { get; set; }
        public string Factory       { get; set; }
        public string CarLicense    { get; set; }
        public string CarName       { get; set; }
        public string Company       { get; set; }
        public string Motorcycle    { get; set; }
        public string CarColor      { get; set; }
        public DateTime PurchaseTime  { get; set; }
        public string Operation     { get; set; }
        public DateTime InsuranceTime { get; set; }
        public DateTime AsTime        { get; set; }
        public string Maintain      { get; set; }
        public string CarPicture { get; set; }
        public string InsurancePicture { get; set; }
        public int UserId { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
