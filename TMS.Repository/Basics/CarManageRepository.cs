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
    public class CarManageRepository:IBase<CarManage>,ICar
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<CarManage> GetInfo()
        {
            string sql = "select * from CarManage a join UserTable b on b.UserId=a.UserId";
            return Gets(sql);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int CarAdd(CarManage car)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("car", car);
            string sql = "insert into CarManage values(null,@Factory,@CarLicense,@CarName,@Company,@Motorcycle,@CarColor,@PurchaseTime,@Operation,@InsuranceTime,@AsTime,@Maintain,@CarPicture,@InsurancePicture,@UserId)";
            return CUD(sql, car);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
        public int CarDelete(int CarId)
        {
            DynamicParameters dynamic =new DynamicParameters();
            dynamic.Add("CarId", CarId);
            string sql = "delete from CarManage where CarId=@CarId";
            return CUD(sql, dynamic);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public int CarUpdate(CarManage car)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("CarId", car.CarId);
            dynamic.Add("Factory", car.Factory);
            dynamic.Add("CarLicense", car.CarLicense);
            dynamic.Add("CarName", car.CarName);
            dynamic.Add("Company", car.Company);
            dynamic.Add("Motorcycle", car.Motorcycle);
            dynamic.Add("CarColor", car.CarColor);
            dynamic.Add("PurchaseTime", car.PurchaseTime);
            dynamic.Add("Operation", car.Operation);
            dynamic.Add("InsuranceTime", car.InsuranceTime);
            dynamic.Add("AsTime", car.AsTime);
            dynamic.Add("Maintain", car.Maintain);
            dynamic.Add("CarPicture", car.CarPicture);
            dynamic.Add("InsurancePicture", car.InsurancePicture);
            dynamic.Add("UserId", car.UserId);
            string sql = "update CarManage set Factory=@Factory,CarLicense=@CarLicense,CarName=@CarName,Company=@CarName,Motorcycle=@Motorcycle,CarColor=@CarColor,PurchaseTime=@PurchaseTime,Operation=@Operation,InsuranceTime=@InsuranceTime,AsTime=@AsTime,Maintain=@Maintain,CarPicture=@CarPicture,InsurancePicture=@InsurancePicture where CarId=@CarId";
            return CUD(sql, dynamic);
        }
    }
}
