using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TMS.Model;
using TMS.Repository.IRepository;
namespace TMS.Repository.Basics
{
   public class GasolineManageRepostiory:IBase<GasolineManage>,IGaso
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<GasolineManage> GetInfo()
        {
            string sql = "select * from GasolineManage a join UserTable b on b.UserId=a.UserId";
            return Gets(sql);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int GasolineManageAdd(GasolineManage gaso)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("gaso", gaso);
            string sql = "insert into GasolineManage values(null,@GasoLicense,@GasoPrice,@GasoMass,@GasoStart,@GasoPay,@GasoAgent,@GasoRemark,@GasoTime,@UserId)";
            return CUD(sql, dynamic);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
        public int GasolineManageDelete(int GasoId)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("GasoId", GasoId);
            string sql = "delete from GasolineManage where @GasoId=GasoId";
            return CUD(sql, dynamic);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public int GasolineManageUpdate(GasolineManage gaso)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("GasoId     ", gaso.GasoId     );
            dynamic.Add("GasoLicense", gaso.GasoLicense);
            dynamic.Add("GasoPrice  ", gaso.GasoPrice  );
            dynamic.Add("GasoMass   ", gaso.GasoMass   );
            dynamic.Add("GasoStart  ", gaso.GasoStart  );
            dynamic.Add("GasoPay    ", gaso.GasoPay    );
            dynamic.Add("GasoAgent  ", gaso.GasoAgent  );
            dynamic.Add("GasoRemark ", gaso.GasoRemark );
            dynamic.Add("GasoTime   ", gaso.GasoTime   );
            dynamic.Add("UserId     ", gaso.UserId);
            string sql = "update GasolineManage set GasoLicense=@GasoLicense,GasoPrice=@GasoPrice,GasoMass=@GasoMass,GasoStart=@GasoStart,GasoPay=@GasoPay,GasoAgent=@GasoAgent,GasoRemark=@GasoRemark,GasoTime=@GasoTime,UserId=@UserId where GasoId = @GasoId";
            return CUD(sql, dynamic);
        }
    }
}

