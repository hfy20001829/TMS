using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using MySql;
using MySqlConnector;
using System.Data;

namespace TMS.Repository
{
    public class DapperHelper<T> where T:class,new()
    {
        static string  constr = ConfigHelper.constr;
        //获取所有数据
        public static List<T> Gets(string sql)
        {
            using (IDbConnection conn = new MySqlConnection(constr))
            {
                conn.Open();
                List<T> list = conn.Query<T>(sql).ToList();
                return list;
            }
        }
        //查询数据
        public static List<T> Gets(string sql,object param)
        {
            using (IDbConnection conn = new MySqlConnection(constr))
            {
                conn.Open();
                List<T> list = conn.Query<T>(sql,param).ToList();
                return list;
            }
        }
        //增删改
        public static int Execute(string sql, object param = null)
        {
            using (IDbConnection conn = new MySqlConnection(constr))
            {
                conn.Open();
                int i = conn.Execute(sql, param);
                return i;
            }
        }
    }
}
