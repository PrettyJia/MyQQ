using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace 飞行棋
{
    public class DBHelper
    {
        private string connStr = "server=.;database=fly;uid=sa;pwd=sa";
        private SqlConnection _connection;

        public SqlConnection Connection
        {
            get
            {
                if (_connection==null)
                {
                    _connection = new SqlConnection(connStr);
                }
                return _connection;
            }
        }
    }

}
