using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
namespace TMS.Repository
{
    public class OutsourcingManageRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<OutsourcingManage> GetInfo()
        {
            string sql = "select * from OutsourcingManage a join UserTable b on b.UserId=a.UserId";
            List<OutsourcingManage> outsour = DapperHelper<OutsourcingManage>.Gets(sql);
            return outsour;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int OutsourAdd(OutsourcingManage u)
        {
            string sql = "insert into OutsourcingManage values(null,@OutName,@OutEmail,@OutFixed,@OutPhone,@OutAddress,@OutTime,@OutRemark,@UserId)";
            return DapperHelper<OutsourcingManage>.Execute(sql, new
            {
                @OutName = u.OutName,
                @OutEmail = u.OutEmail,
                @OutFixed = u.OutFixed,
                @OutPhone = u.OutPhone,
                @OutAddress = u.OutAddress,
                @OutTime = u.OutTime,
                @OutRemark = u.OutRemark,
                @UserId = u.UserId
            });
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
        public int OutsourDelete(int OutId)
        {
            string sql = "delete from OutsourcingManage where @OutId=OutId";
            return DapperHelper<OutsourcingManage>.Execute(sql, new { OutId = OutId });
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public int OutsourUpdate(OutsourcingManage u)
        {
            string sql = "update OutsourcingManage set OutName=@OutName,OutEmail=@OutEmail,OutFixed=@OutFixed,OutPhone=@OutPhone,OutAddress=@OutAddress,OutTime=@OutTime,OutRemark=@OutRemark,UserId=@UserId where OutId=@OutId";
            return DapperHelper<OutsourcingManage>.Execute(sql, new
            {
                @OutId = u.OutId,
                @OutName = u.OutName,
                @OutEmail = u.OutEmail,
                @OutFixed = u.OutFixed,
                @OutPhone = u.OutPhone,
                @OutAddress = u.OutAddress,
                @OutTime = u.OutTime,
                @OutRemark = u.OutRemark,
                @UserId = u.UserId
            });
        }
    }
}
