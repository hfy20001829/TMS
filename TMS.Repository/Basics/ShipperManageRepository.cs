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
   public class ShipperManageRepository:IBase<ShipperManage>,IShop
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<ShipperManage> GetInfo()
        {
            string sql = "select * from ShipperManage a join UserTable b on b.UserId=a.UserId";
            return Gets(sql);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int ShippAdd(ShipperManage shop)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("shop", shop);
            string sql = "insert into ShipperManage values(null,@ShipperName,@ShipperPhone,@UnitName,@ContactAddress,@DrivingTime,@DrivingPicture,@ShipperRemark,@ShipperTime,@UserId)";
            return CUD(sql, dynamic);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
        public int ShippDelete(int ShipperId)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("ShipperId", ShipperId);
            string sql = "delete from ShipperManage where @ShipperId=ShipperId";
            return CUD(sql,dynamic);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public int ShippUpdate(ShipperManage shop)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("ShipperId",shop.ShipperId);
            dynamic.Add("ShipperName",shop.ShipperName);
            dynamic.Add("ShipperPhone",shop.ShipperPhone);
            dynamic.Add("UnitName",shop.UnitName);
            dynamic.Add("ContactAddress",shop.ContactAddress);
            dynamic.Add("DrivingTime",shop.DrivingTime);
            dynamic.Add("DrivingPicture",shop.DrivingPicture);
            dynamic.Add("ShipperRemark",shop.ShipperRemark);
            dynamic.Add("ShipperTime",shop.ShipperTime);
            dynamic.Add("UserId", shop.UserId);
            string sql = "update ShipperManage set ShipperName=@ShipperName,ShipperPhone=@ShipperPhone,UnitName=@UnitName,ContactAddress=@ContactAddress,DrivingTime=@DrivingTime,DrivingPicture=@DrivingPicture,ShipperRemark=@ShipperRemark,ShipperTime=@ShipperTime,UserId=@UserId where ShipperId=@ShipperId";
            return CUD(sql, dynamic);
        }
    }
}
