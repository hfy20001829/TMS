using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Repository.IRepository;
using TMS.Model;
namespace TMS.Repository.IRepository
{
   public interface IShop:IBaseRepository<ShipperManage>
    {
        List<ShipperManage> GetInfo();
        int ShippDelete(int ShipperId);
        int ShippAdd(ShipperManage shop);
        int ShippUpdate(ShipperManage shop);
    }
}
