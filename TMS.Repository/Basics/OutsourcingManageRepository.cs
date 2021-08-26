using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.Repository.IRepository;
using Dapper;
namespace TMS.Repository
{
    public class OutsourcingManageRepository:IBase<OutsourcingManage>,IOut
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<OutsourcingManage> GetInfo()
        {
            string sql = "select * from OutsourcingManage a join UserTable b on b.UserId=a.UserId";
            List<OutsourcingManage> outsour = DapperHelper<OutsourcingManage>.Gets(sql);
            return Gets(sql);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int OutsourAdd(OutsourcingManage u)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("u", u);
            string sql = "insert into OutsourcingManage values(null,@OutName,@OutEmail,@OutFixed,@OutPhone,@OutAddress,@OutTime,@OutRemark,@UserId)";
            return CUD(sql, dynamic);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
        public int OutsourDelete(int OutId)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("OutId", OutId);
            string sql = "delete from OutsourcingManage where @OutId=OutId";
            return CUD(sql, dynamic);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public int OutsourUpdate(OutsourcingManage u)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("OutId", u.OutId);
            dynamic.Add("OutName", u.OutName);
            dynamic.Add("OutEmail", u.OutEmail);
            dynamic.Add("OutFixed", u.OutFixed);
            dynamic.Add("OutPhone", u.OutPhone);
            dynamic.Add("OutAddress", u.OutAddress);
            dynamic.Add("OutTime", u.OutTime);
            dynamic.Add("OutRemark", u.OutRemark);
            dynamic.Add("UserId", u.UserId);
            string sql = "update OutsourcingManage set OutName=@OutName,OutEmail=@OutEmail,OutFixed=@OutFixed,OutPhone=@OutPhone,OutAddress=@OutAddress,OutTime=@OutTime,OutRemark=@OutRemark,UserId=@UserId where OutId=@OutId";
            return CUD(sql, dynamic);
        }
    }
}
