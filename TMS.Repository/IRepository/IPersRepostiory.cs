using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Repository.IRepository
{
    public interface IPersRepostiory<T> where T : class, new()
    {
        List<T> Gets(string sql, object exec);
        int CUD(string sql, object exec);
    }
}
