using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
namespace TMS.Repository
{
    public class CarManageRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<CarManage> GetInfo()
        {
            string sql = "select * from CarManage a join UserTable b on b.UserId=a.UserId";
            List<CarManage> car = DapperHelper<CarManage>.Gets(sql);
            return car;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int CarAdd(CarManage car)
        {
            string sql = "insert into CarManage values(null,@Factory,@CarLicense,@CarName,@Company,@Motorcycle,@CarColor,@PurchaseTime,@Operation,@InsuranceTime,@AsTime,@Maintain,@CarPicture,@InsurancePicture,@UserId)";
            return DapperHelper<CarManage>.Execute(sql, new
            {
                @Factory = car.Factory,
                @CarLicense = car.CarLicense,
                @CarName = car.CarName,
                @Company = car.Company,
                @Motorcycle = car.Motorcycle,
                @CarColor = car.CarColor,
                @PurchaseTime = car.PurchaseTime,
                @Operation = car.Operation,
                @InsuranceTime = car.InsuranceTime,
                @AsTime = car.AsTime,
                @Maintain = car.Maintain,
                @CarPicture = car.CarPicture,
                @InsurancePicture = car.InsurancePicture,
                @UserId=car.UserId
            });
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
        public int CarDelete(int CarId)
        {
            string sql = "delete from CarManage where @CarId=CarId";
            return DapperHelper<CarManage>.Execute(sql,new { CarId = CarId });
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public int CarUpdate(CarManage car)
        {
            string sql = "update CarManage set @Factory=Factory,@CarLicense=CarLicense,@CarName=CarName,@Company=CarName,@Motorcycle=Motorcycle,@CarColor=CarColor,@PurchaseTime=PurchaseTime,@Operation=Operation,@InsuranceTime=InsuranceTime,@AsTime=AsTime,@Maintain=Maintain,@CarPicture=CarPicture,@InsurancePicture=InsurancePicture where @CarId=CarId";
            return DapperHelper<CarManage>.Execute(sql, new {
                @CarId=car.CarId,
                @Factory = car.Factory,
                @CarLicense = car.CarLicense,
                @CarName = car.CarName,
                @Company = car.Company,
                @Motorcycle = car.Motorcycle,
                @CarColor = car.CarColor,
                @PurchaseTime = car.PurchaseTime,
                @Operation = car.Operation,
                @InsuranceTime = car.InsuranceTime,
                @AsTime = car.AsTime,
                @Maintain = car.Maintain,
                @CarPicture = car.CarPicture,
                @InsurancePicture = car.InsurancePicture,
                @UserId = car.UserId
            });
        }
    }
}
