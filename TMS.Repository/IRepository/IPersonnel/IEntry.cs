using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
namespace TMS.Repository.IRepository
{
    public interface IEntry : IPersRepostiory<EntryManage>
    {
        List<EntryManage> GetInfo();
        int EntryDelete(int EntryId);
        int EntryAdd(EntryManage entry);
        int EntryUpdate(EntryManage entry);
    }
}
