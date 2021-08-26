using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
namespace TMS.Repository.IRepository
{
  public interface IStaff : IPersRepostiory<StaffManage>
    {
        List<StaffManage> GetInfo();
        int StafDelete(int StafId);
        int StafAdd(StaffManage staf);
        int StafUpdate(StaffManage staf);
    }
}
