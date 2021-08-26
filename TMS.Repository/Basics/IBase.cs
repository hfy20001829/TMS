using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Repository;
using TMS.Repository.IRepository;

namespace TMS.Repository
{
    public class IBase<T> : IRepository.IBaseRepository<T> where T : class, new()
    {
      

        public List<T> Gets(string sql, object exec=null)
        {
            return DapperHelper<T>.Gets(sql, exec);
        }

       public int CUD(string sql,object exec=null)
        {
            return DapperHelper<T>.Execute(sql,exec);
        }
    }
}
