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
    public class StaffManageRepository : IPers<StaffManage>,IStaff
    {
        public List<StaffManage> GetInfo()
        {
            string sql = "select * from StaffManage a join UserTable b on b.UserId=a.UserId";
            return Gets(sql);
        }

        public int StafAdd(StaffManage staf)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("staf", staf);
            string sql = "insert into StaffManage values(null,@StafName,@UserId,@StafPost,@StafPhone,@StafAcademy,@StafMajor,@StafHome,@StafTime,@StafAge,@StafSort,@StafState,@StafCTime)";
            return CUD(sql, dynamic);
        }

        public int StafDelete(int StafId)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("CarId", StafId);
            string sql = "delete from StaffManage where StafId=@StafId";
            return CUD(sql, dynamic);
        }

        public int StafUpdate(StaffManage staf)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("StafId     ", staf.StafId     );
            dynamic.Add("StafName   ", staf.StafName   );
            dynamic.Add("StafSex    ", staf.StafSex    );
            dynamic.Add("UserId     ", staf.UserId     );
            dynamic.Add("StafPost   ", staf.StafPost   );
            dynamic.Add("StafPhone  ", staf.StafPhone  );
            dynamic.Add("StafAcademy", staf.StafAcademy);
            dynamic.Add("StafMajor  ", staf.StafMajor  );
            dynamic.Add("StafHome   ", staf.StafHome   );
            dynamic.Add("StafTime   ", staf.StafTime   );
            dynamic.Add("StafAge    ", staf.StafAge    );
            dynamic.Add("StafSort   ", staf.StafSort   );
            dynamic.Add("StafState  ", staf.StafState);
            dynamic.Add("StafCTime  ", staf.StafCTime);
            string sql = "insert into  StaffManage values(null,StafName=@StafName,UserId=@UserId,StafPost=@StafPost,StafPhone=@StafPhone,StafAcademy=@StafAcademy,StafMajor=@StafMajor,StafHome=@StafHome,StafTime=@StafTime,StafAge=@StafAge,StafSort=@StafSort,StafState=@StafState,StafCTime=@StafCTime where StafId=@StafId)";
            return CUD(sql, dynamic);
        }
    }
}
