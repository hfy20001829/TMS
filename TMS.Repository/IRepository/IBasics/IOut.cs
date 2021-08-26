using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.Repository.IRepository;
namespace TMS.Repository.IRepository
{
   public interface IOut:IBaseRepository<OutsourcingManage>
    {
        List<OutsourcingManage> GetInfo();
        int OutsourDelete(int OutId);
        int OutsourAdd(OutsourcingManage u);
        int OutsourUpdate(OutsourcingManage u);
    }
}
