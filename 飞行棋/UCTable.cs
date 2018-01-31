using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using PrettyCommonControl;
using System.Collections;

namespace 飞行棋
{
    public partial class UCTable : UserControl
    {
        public string id =string.Empty;//用户编号string.Empty
        //房间编号
        public string roomId = string.Empty;
        private const string FORMAT_TABLENUM = "- {0} -";
        /// <summary>
        /// 0为可用，1为准备中，2为已经开始游戏
        /// </summary>
        private int roomState;//房间状态
        public UCTable()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 刷新房间数据
        /// </summary>
        public void ReferenceRoomData()
        {
            //获取房间数据
            GetRoomData();
            ChangeCursor();
        }

        private void ChangeCursor()
        {
            if (roomState!=2)
            {
                return;
            }
            foreach (Control item in this.Controls[0].Controls)
            {
                if (item.Tag != null)
                {
                    string[] para=(item as PictureBox).Tag.ToString().Split(',');
                    if (para[1]=="{0}")
                    {
                        item.Cursor = Cursors.No;
                    }
                }
            }
        }


        /// <summary>
        /// 获取玩家数据-头像和昵称，同时切换鼠标悬浮样式
        /// </summary>
        private void GetPlayerData(string uid,int seat)
        {
            DBHelper dbHelper = new DBHelper();
            string sql =string.Format("select nickName,face from users where id={0}", uid);
            SqlDataReader reader = null;
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    string name = reader["nickName"].ToString();
                    string face = reader["face"].ToString();
                    switch (seat)
                    {
                        case 1:
                            lblPlay1Name.Text = name;
                            lblPlay1Name.Visible = true;
                            //通过头像名字获取对应的资源
                            pbPlay1.Image = Properties.Resources.ResourceManager.GetObject(face) as Image;
                            //头像变圆
                            ControlUtils.ChangeToCircle(pbPlay1);
                            pbPlay1.Tag = string.Format(pbPlay1.Tag.ToString(), uid);
                            pbPlay1.Cursor = Cursors.Hand;
                            break;
                        case 2:
                            lblPlay2Name.Text = name;
                            lblPlay2Name.Visible = true;
                            pbPlay2.Image = Properties.Resources.ResourceManager.GetObject(face) as Image;
                            ControlUtils.ChangeToCircle(pbPlay2);
                            pbPlay2.Tag = string.Format(pbPlay2.Tag.ToString(), uid);
                            pbPlay2.Cursor = Cursors.Hand;
                            break;
                        case 3:
                            lblPlay3Name.Text = name;
                            lblPlay3Name.Visible = true;
                            pbPlay3.Image = Properties.Resources.ResourceManager.GetObject(face) as Image;
                            ControlUtils.ChangeToCircle(pbPlay3);
                            pbPlay3.Tag = string.Format(pbPlay3.Tag.ToString(), uid);
                            pbPlay3.Cursor = Cursors.Hand;
                            break;
                        case 4:
                            lblPlay4Name.Text = name;
                            lblPlay4Name.Visible = true;
                            pbPlay4.Image = Properties.Resources.ResourceManager.GetObject(face) as Image;
                            ControlUtils.ChangeToCircle(pbPlay4);
                            pbPlay4.Tag = string.Format(pbPlay4.Tag.ToString(), uid);
                            pbPlay4.Cursor = Cursors.Hand;
                            break;
                    }
                }else
                {
                    switch (seat)
                    {
                        case 1:
                            lblPlay1Name.Text = "";
                            lblPlay1Name.Visible = false;
                            //通过头像名字获取对应的资源
                            pbPlay1.Image = Properties.Resources.ResourceManager.GetObject("Seat") as Image;
                            //头像变方
                            ControlUtils.ChangeToRect(pbPlay1);
                            pbPlay1.Tag = "1,{0}";
                            if (roomState==1)
                            {
                                pbPlay1.Cursor = Cursors.No;
                            }else
                            {
                                pbPlay1.Cursor = Cursors.Hand;
                            }
                            break;
                        case 2:
                            lblPlay2Name.Text = "";
                            lblPlay2Name.Visible = false;
                            pbPlay2.Image = Properties.Resources.ResourceManager.GetObject("Seat") as Image;
                            ControlUtils.ChangeToRect(pbPlay2);
                            pbPlay2.Tag = "2,{0}";
                            if (roomState == 1)
                            {
                                pbPlay2.Cursor = Cursors.No;
                            }else
                            {
                                pbPlay2.Cursor = Cursors.Hand;

                            }
                            break;
                        case 3:
                            lblPlay3Name.Text = "";
                            lblPlay3Name.Visible = false;
                            pbPlay3.Image = Properties.Resources.ResourceManager.GetObject("Seat") as Image;
                            ControlUtils.ChangeToRect(pbPlay3);
                            pbPlay3.Tag = "3,{0}";
                            if (roomState == 1)
                            {
                                pbPlay3.Cursor = Cursors.No;
                            }else
                            {
                                pbPlay3.Cursor = Cursors.Hand;
                            }
                            break;
                        case 4:
                            lblPlay4Name.Text = "";
                            lblPlay4Name.Visible = false;
                            pbPlay4.Image = Properties.Resources.ResourceManager.GetObject("Seat") as Image;
                            ControlUtils.ChangeToRect(pbPlay4);
                            pbPlay4.Tag = "4,{0}";
                            if (roomState == 1)
                            {
                                pbPlay4.Cursor = Cursors.No;
                            }else
                            {
                                pbPlay4.Cursor = Cursors.Hand;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                UCMessageBox.Show(ex.Message, FrmRooms.GetFrmRooms(id));
            }
            finally
            {
                if (reader!=null)
                {
                    reader.Close();
                }
            }
        }

        //获取房间数据
        private void GetRoomData()
        {
            //重置座位数据，用于标记
            pbPlay1.Tag = "1,{0}";
            pbPlay2.Tag = "2,{0}";
            pbPlay3.Tag = "3,{0}";
            pbPlay4.Tag = "4,{0}";
            string sql = string.Format(@"select Rooms.state as rstate,id,seat,
            RoomPlayer.state ustate
            from Rooms
            inner join RoomPlayer on Rooms.rid=RoomPlayer.rid
            where Rooms.rid={0}", roomId);
            DBHelper dbHelper = new DBHelper();
            SqlDataReader reader = null;
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                for (int i = 1; i <= 4; i++)
                {
                    if (reader.Read())
                    {
                        //将四个头像设置信息
                        roomState = Convert.ToInt32(reader["rstate"]);
                        int id = Convert.ToInt32(reader["id"]);
                        int seat = Convert.ToInt32(reader["seat"]);
                        int ustate = Convert.ToInt32(reader["ustate"]);
                        GetPlayerData(id.ToString(), seat);
                    }
                    //GetPlayerData(0.ToString(), tempNum);
                }
                //遍历所有座位，得到没有上座的座位
                for (int i = 1; i <=4; i++)
                {
                    Control item=this.Controls.Find("pbPlay" + i, true)[0];
                    //座位信息
                    string[] info = item.Tag.ToString().Split(',');
                    if (info[1] == "{0}")
                    {
                        GetPlayerData(0.ToString(), Convert.ToInt32(info[0]));
                    }
                }

                //0为可用，1为已经开始游戏
                if (roomState == 0)
                {
                    pbRoomState.Image = Properties.Resources.tablen;
                }
                else if (roomState == 1)
                {
                    //更换图标
                    pbRoomState.Image = Properties.Resources.tables;
                }

            }
            catch (Exception ex)
            {
                UCMessageBox.Show(ex.Message,FrmRooms.GetFrmRooms(id));
            }
            finally
            {
                if (reader!=null)
                {
                    reader.Close();
                }
            }
        }

        #region 房间图片控件悬浮
        private void pbRoomState_MouseEnter(object sender, EventArgs e)
        {
            if (roomState == 1)
            {
                return;
            }
            pbRoomState.Image = Properties.Resources.tableh;
        }
        private void pbRoomState_MouseLeave(object sender, EventArgs e)
        {
            if (roomState == 1)
            {
                return;
            }
            pbRoomState.Image = Properties.Resources.tablen;
        }
        #endregion
        public void SetTableNum(int num)
        {
            this.lblTableNum.Text = string.Format(FORMAT_TABLENUM, num);
            roomId = num.ToString();
        }

        //进入房间
        private void pbRoomState_Click(object sender, EventArgs e)
        {
            if (roomState == 1)
            {
                return;
            }
            //进入房间-匹配模式
            FrmMain main = new FrmMain();
            main.roomId = roomId;
            main.id = id;
            main.Show();
        }

        //进入房间
        private void pbPlay1_Click(object sender, EventArgs e)
        {
            if (roomState == 1)
            {
                return;
            }
            //进入房间-选座模式
            FrmMain main = new FrmMain();
            main.roomId = roomId;
            main.id = id;
            main.Show(); 
        }
    }
}
