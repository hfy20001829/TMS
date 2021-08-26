using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.Repository.IRepository;
namespace TMS.Repository.IRepository
{
   public interface ICar:IBaseRepository<CarManage>
    {
        List<CarManage> GetInfo();
        int CarDelete(int CarId);
        int CarAdd(CarManage car);
        int CarUpdate(CarManage car);
    }                  
}                         
                          
                       
                         
                   
                        