using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
   public class GasolineManage
    {
        public int GasoId      { get; set; }
        public string GasoLicense { get; set; }
        public int GasoPrice   { get; set; }
        public int GasoMass    { get; set; }
        public int GasoStart   { get; set; }
        public string GasoPay     { get; set; }
        public string GasoAgent   { get; set; }
        public string GasoRemark  { get; set; }
        public DateTime GasoTime    { get; set; }
        public int UserId { get; set; }
    }
}
