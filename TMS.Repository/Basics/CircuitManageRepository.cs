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
   public class CircuitManageRepository:IBase<CircuitManage>,ICir
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<CircuitManage> GetInfo()
        {
            string sql = "select *from CircuitManage a join ShipperManage b on b.ShipperId=a.ShipperId join UserTable c on c.UserId=a.UserId";
            return Gets(sql);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int CircuitAdd(CircuitManage c)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("c", c);
            string sql = "insert into CircuitManage value(null,@CircuitName,@CircuitStart,@CircuitTerminus,@CircuitStuta,@ShipperId,@UserId)";
            return CUD(sql,dynamic);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="CircuitId"></param>
        /// <returns></returns>
        public int CircuitDelete(int CircuitId)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("CircuitId", CircuitId);
            string sql = "delete from CircuitManage where @CircuitId=CircuitId";
            return CUD(sql, dynamic);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int CirucitUpdate(CircuitManage c)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("CircuitId", c.CircuitId);
            dynamic.Add("CircuitName", c.CircuitName);
            dynamic.Add("CircuitStart", c.CircuitStart);
            dynamic.Add("CircuitTerminus", c.CircuitTerminus);
            dynamic.Add("CircuitStuta", c.CircuitStuta);
            dynamic.Add("ShipperId", c.ShipperId);
            dynamic.Add("UserId", c.UserId);
            string sql = "update CircuitManage set CircuitName=@CircuitName,CircuitStart=@CircuitStart,CircuitTerminus=@CircuitTerminus,CircuitStuta=@CircuitStuta,@ShipperId=ShipperId,UserId=@UserId where CircuitId=@CircuitId";
            return CUD(sql, dynamic);
        }
    }
}
