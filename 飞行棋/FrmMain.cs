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
        //为保证安全性，使用触发器
        //规则一、房间所有玩家准备完毕，房间的状态改为开始
        //规则二、当所有玩家进入终点，房间的状态为准备
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
            if (CheckRoomState()&&GetRoomPlayerCount()<4)
            {
                //占座
                if (SaveSeat())
                {
                    UCMessageBox.Show("占座成功！",this);
                }else
                {
                    UCMessageBox.Show("占座失败！别处游戏中", this);
                }

            }else {
                UCMessageBox.Show("人数已满或已经开始不能加入房间！",this);
                this.Close();
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
            catch (Exception)
            {
                return false;
            }
            finally
            {
                dbHelper.Connection.Close();
            }
        }
        /// <summary>
        /// 获取房间中玩家人数
        /// </summary>
        /// <returns></returns>
        public int GetRoomPlayerCount()
        {
            string sql = "select COUNT(*) from RoomPlayer where rid="+roomId;
            DBHelper dbHelper = new DBHelper();
            int count = -1;
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                count=Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception)
            {

            }
            finally
            {
                dbHelper.Connection.Close();
            }
            return count;
        }
        /// <summary>
        /// 检查房间的状态为未开始
        /// </summary>
        /// <returns></returns>
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
