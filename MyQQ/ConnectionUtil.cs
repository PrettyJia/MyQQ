using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MyQQ
{
    /// <summary>
    /// 数据库连接工具类,可以连接MySQL或SQLServer
    /// </summary>
    public class ConnectionUtil
    {
        private string connStr = "server=.;database=myqq;uid=sa;pwd=sa"; 

        public int ExecuteNoneQuery(string sql)
        {
            SqlConnection connection = null;
            int result = -1;
            try
            {
                connection = new SqlConnection(connStr);
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static int ExecuteScalar(string sql) { }
    }
}
