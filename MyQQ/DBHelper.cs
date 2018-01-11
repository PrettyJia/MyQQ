using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MyQQ
{
    /// <summary>
    /// 数据库访问工具类
    /// </summary>
    public class DBHelper
    {
        public static string connStr = "server=.;database=myqq;uid=sa;pwd=sa";
        public static SqlConnection connection = new SqlConnection(connStr);

    }
}
