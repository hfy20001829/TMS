using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;

namespace TMS.Repository.IRepository
{
   public interface ICir:IBaseRepository<CircuitManage>
    {
        List<CircuitManage> GetInfo();
        int CircuitDelete(int CircuitId);
        int CircuitAdd(CircuitManage c);
        int CirucitUpdate(CircuitManage c);
    }
}
