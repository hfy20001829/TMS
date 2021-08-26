using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.Repository.IRepository;
namespace TMS.Repository
{
    public class EntryManageRepository : IPers<EntryManage>, IEntry
    {
        public int EntryAdd(EntryManage entry)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("entry", entry);
            string sql = "insert into EntryManage values(null,@EntrtName,@UserId,@EntryPost,@EntryUP,@EntryTime,@EntryCTime,@EntryState,@EntryAppr)";
            return CUD(sql, dynamic);
        }

        public int EntryDelete(int EntryId)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("EntryId", EntryId);
            string sql = "delete from EntryDelete where EntryId=@EntryId";
            return CUD(sql, dynamic);
        }

        public int EntryUpdate(EntryManage entry)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("EntryId   ", entry.EntryId   );
            dynamic.Add("EntrtName ", entry.EntrtName );
            dynamic.Add("UserId    ", entry.UserId    );
            dynamic.Add("EntryPost ", entry.EntryPost );
            dynamic.Add("EntryUP   ", entry.EntryUP   );
            dynamic.Add("EntryTime ", entry.EntryTime );
            dynamic.Add("EntryCTime", entry.EntryCTime);
            dynamic.Add("EntryState", entry.EntryState);
            dynamic.Add("EntryAppr ", entry.EntryAppr );
            string sql = "insert into  StaffManage values(null,EntrtName=@EntrtName,UserId=@UserId,EntryPost=@EntryPost,EntryUP=@EntryUP,EntryTime=@EntryTime,EntryCTime=@EntryCTime,EntryState=@EntryState,EntryAppr=@EntryAppr where EntryId=@EntryId)";
            return CUD(sql, dynamic);
        }

        public List<EntryManage> GetInfo()
        {
            string sql = "select * from EntryManage a join UserTable b on b.UserId=a.UserId";
            return Gets(sql);
        }
    }
}
