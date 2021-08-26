using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Repository
{
    public class IPers<T> : IRepository.IPersRepostiory<T> where T : class, new()
    {
        public int CUD(string sql, object exec)
        {
            return DapperHelper<T>.Execute(sql, exec);
        }

        public List<T> Gets(string sql, object exec=null)
        {
            return DapperHelper<T>.Gets(sql, exec);
        }
    }
}
