using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Repository.IRepository;
using TMS.Model;
namespace TMS.Repository.IRepository
{
   public interface IGaso:IBaseRepository<GasolineManage>
    {
        List<GasolineManage> GetInfo();
        int GasolineManageUpdate(GasolineManage gaso);
        int GasolineManageDelete(int GasoId);
        int GasolineManageAdd(GasolineManage gaso);
    }
}
