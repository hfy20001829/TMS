using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
namespace TMS.Repository
{
   public class ShipperManageRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<ShipperManage> GetInfo()
        {
            string sql = "select * from ShipperManage a join UserTable b on b.UserId=a.UserId";
            List<ShipperManage> shipp = DapperHelper<ShipperManage>.Gets(sql);
            return shipp;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int ShippAdd(ShipperManage shop)
        {
            string sql = "insert into ShipperManage values(null,@ShipperName,@ShipperPhone,@UnitName,@ContactAddress,@DrivingTime,@DrivingPicture,@ShipperRemark,@ShipperTime,@UserId)";
            return DapperHelper<ShipperManage>.Execute(sql, new
            {
                @ShipperName=shop.ShipperName,
                @ShipperPhone=shop.ShipperPhone,
                @UnitName=shop.UnitName,
                @ContactAddress=shop.ContactAddress,
                @DrivingTime=shop.DrivingTime,
                @DrivingPicture=shop.DrivingPicture,
                @ShipperRemark=shop.ShipperRemark,
                @ShipperTime=shop.ShipperTime,
                @UserId=shop.UserId
            });
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
        public int ShippDelete(int ShipperId)
        {
            string sql = "delete from ShipperManage where @ShipperId=ShipperId";
            return DapperHelper<CarManage>.Execute(sql, new { @ShipperId = ShipperId });
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public int ShippUpdate(ShipperManage shop)
        {
            string sql = "update ShipperManage set ShipperName=@ShipperName,ShipperPhone=@ShipperPhone,UnitName=@UnitName,ContactAddress=@ContactAddress,DrivingTime=@DrivingTime,DrivingPicture=@DrivingPicture,ShipperRemark=@ShipperRemark,ShipperTime=@ShipperTime,UserId=@UserId where ShipperId=@ShipperId";
            return DapperHelper<CarManage>.Execute(sql, new
            {
                @ShipperId=shop.ShipperId,
                @ShipperName = shop.ShipperName,
                @ShipperPhone = shop.ShipperPhone,
                @UnitName = shop.UnitName,
                @ContactAddress = shop.ContactAddress,
                @DrivingTime = shop.DrivingTime,
                @DrivingPicture = shop.DrivingPicture,
                @ShipperRemark = shop.ShipperRemark,
                @ShipperTime = shop.ShipperTime,
                @UserId = shop.UserId
            });
        }
    }
}
