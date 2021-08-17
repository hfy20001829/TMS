using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Repository.IRepository
{
    interface IBaseRepository<T> where T:class,new()
    {
        List<T> Gets();
        int CUD();
    }
}
