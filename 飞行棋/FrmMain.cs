using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PrettyCommonControl;
using System.Data.SqlClient;

namespace 飞行棋
{
    public partial class FrmMain : Form
    {
        public string roomId = string.Empty;
        public string seatId=string.Empty;
        public string id = string.Empty;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = "房间：" + roomId;
            //更新房间状态及信息
            UpdateRoomInfo();
        }
        /// <summary>
        /// 更新房间状态及信息
        /// </summary>
        private void UpdateRoomInfo()
        {
            //为了安全，先检查后更新数据
            if (CheckRoomState())
            {
                //占座
                if (SaveSeat())
                {
                    MessageBox.Show("占座成功！");
                }
                
            }
        }
        //
        public bool SaveSeat()
        {
            DBHelper dbHelper = new DBHelper();
            string sql = string.Format(@"insert into RoomPlayer (rid,id,seat,state)
                values({0},{1},{2},0)",roomId,id,seatId);
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                int result = command.ExecuteNonQuery();
                if (result==1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                dbHelper.Connection.Close();
            }
        }
        public bool CheckRoomState()
        {
            DBHelper dbHelper = new DBHelper();
            string sql = string.Format("select state from Rooms where rid={0}",roomId);
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                int state = Convert.ToInt32(command.ExecuteScalar());
                if (state==2)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                UCMessageBox.Show(ex.Message, this);
            }
            finally
            {
                dbHelper.Connection.Close();
            }
            return true;
        }
    }
}
