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
using System.Threading;

namespace 飞行棋
{
    public partial class FrmMain : Form
    {
        //为保证安全性，使用触发器
        //规则一、房间所有玩家准备完毕，房间的状态改为开始
        //规则二、当所有玩家进入终点，房间的状态为准备
        public string roomId = string.Empty;//房间编号
        public string seatId = string.Empty;//座位号
        public string id = string.Empty;//用户编号

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //防止闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.Text = "房间：" + roomId;
            //更新房间状态及信息
            UpdateRoomInfo();
            InitialRandShowNum();
        }
        #region 初始化动画效果中的文字
        /// <summary>
        /// 加载40个数
        /// </summary>
        private void InitialRandShowNum()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 39; i++)
            {
                int step = random.Next(1, 7);
                randShowNum[i] = step;
            }
        }
        #endregion
        /// <summary>
        /// 更新房间状态及信息
        /// </summary>
        private void UpdateRoomInfo()
        {
            //为了安全，先检查后更新数据
            if (CheckRoomState() && GetRoomPlayerCount() < 4)
            {
                //占座
                if (IsNowRoom())
                {
                    if (SaveSeat())
                    {
                        UCMessageBox.Show("占座成功！", this);
                    }
                }
                else
                {
                    UCMessageBox.Show("占座失败！别处游戏中", this);
                    // this.Close();
                }
            }
            else
            {
                UCMessageBox.Show("人数已满或已经开始，不能加入房间！", this);
                //this.Close();
            }
        }
        /// <summary>
        /// 判断是否是当前房间
        /// </summary>
        /// <returns></returns>
        private bool IsNowRoom()
        {
            string sql = "select rid from RoomPlayer where id="+id;
            DBHelper dbHelper = new DBHelper();
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                int rid=Convert.ToInt32(command.ExecuteScalar());
                if (rid.ToString()==roomId)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                dbHelper.Connection.Close();
            }
            return false;
        }

        /// <summary>
        /// 占座
        /// </summary>
        /// <returns></returns>
        public bool SaveSeat()
        {
            int[] seats = new int[4];
            //是选中号码还是随机号码
            if (seatId.Length == 0)
            {
                GetSeats(seats);
                int length = 0;
                for (int i = 0; i < seats.Length; i++)
                {
                    if (seats[i] != 0)
                    {
                        length++;
                    }
                }
                switch (length)
                {
                    case 0:
                    case 1:
                        if (seats[0] == 4)
                        {
                            seatId = "1";
                        }
                        else if (seats[0] == 1)
                        {
                            seatId = "2";
                        }
                        else
                        {
                            seatId = (seats[0] + 1) + "";
                        }
                        break;
                    case 2:
                        //如果有两位，求和除以2 强转剩余的那两个座位
                        seatId = (seats.Sum() / 2).ToString();
                        break;
                    case 3:
                        //如果还有一个座位
                        seatId = (10 - seats.Sum()).ToString();
                        break;
                    default:
                        break;
                }
            }
            DBHelper dbHelper = new DBHelper();
            string sql = string.Format(@"insert into RoomPlayer (rid,id,seat,state)
                values({0},{1},{2},0)", roomId, id, seatId);
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                int result = command.ExecuteNonQuery();
                if (result == 1)
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
        /// <summary>
        /// 获取所有座位,没有人坐的座位号为0
        /// </summary>
        /// <param name="seats"></param>
        private void GetSeats(int[] seats)
        {
            string sql = "select seat from RoomPlayer where rid=" + roomId;
            DBHelper dbHelper = new DBHelper();
            SqlDataReader reader = null;
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                int i = 0;
                while (reader.Read())
                {
                    seats[i] = Convert.ToInt32(reader["seat"]);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        /// <summary>
        /// 获取房间中玩家人数
        /// </summary>
        /// <returns></returns>
        public int GetRoomPlayerCount()
        {
            string sql = "select COUNT(*) from RoomPlayer where rid=" + roomId;
            DBHelper dbHelper = new DBHelper();
            int count = -1;
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                count = Convert.ToInt32(command.ExecuteScalar());
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
            string sql = string.Format("select state from Rooms where rid={0}", roomId);
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                int state = Convert.ToInt32(command.ExecuteScalar());
                if (state == 2)
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
        private int[] playerPosition = new int[4];//4个玩家的位置
        private void btnGo_Click(object sender, EventArgs e)
        {
            btnGo.Enabled = false;
            Random random = new Random();
            int step = random.Next(1, 7);
            //如果等于6增加一次机会 


        }
        private Control willMoveControl = null;//即将移动的控件
        private void Go(int step)
        {
            tRefreshRoom.Stop();//动画开始的时候停止刷新数据
            randShowNum[randShowNum.Length - 1] = step;
            tShowRandNum.Start();
            tTime20.Start();

        }
        /// <summary>
        /// 移动飞机
        /// </summary>
        /// <param name="start">开始的位置,从1开始</param>
        /// <param name="end">结束的位置</param>
        /// <param name="moveControl">要移动的控件</param>
        private void MoveFly(int start, int end)
        {
            for (int i = start; i <= end;)
            {

                Control[] controls = this.Controls.Find("lbl" + i, true);
                if (controls.Length == 0)
                {
                    return;
                }
                Control startControl = controls[0];//获取开始的控件
                int ltarget = (startControl.Left + startControl.Width / 2) - willMoveControl.Width / 2;
                int ttarget = (startControl.Top + startControl.Height / 2) - willMoveControl.Height / 2;

                //先走y    向下且向右 或 向上且向左
                if ((willMoveControl.Top < ttarget && willMoveControl.Left < ltarget) || (willMoveControl.Top > ttarget && willMoveControl.Left > ltarget))
                {
                    while (willMoveControl.Top != ttarget)
                    {

                        if (willMoveControl.Top > ttarget)
                        {
                            willMoveControl.Top -= 1;
                        }
                        else
                        {
                            willMoveControl.Top += 1;
                        }
                        Thread.Sleep(10);
                        this.Update();
                    }
                    while (willMoveControl.Left != ltarget)
                    {

                        if (willMoveControl.Left > ltarget)
                        {
                            willMoveControl.Left -= 1;
                        }
                        else
                        {
                            willMoveControl.Left += 1;
                        }
                        Thread.Sleep(10);
                        this.Update();
                    }
                }
                else
                {
                    while (willMoveControl.Left != ltarget)
                    {

                        if (willMoveControl.Left > ltarget)
                        {
                            willMoveControl.Left -= 1;
                        }
                        else
                        {
                            willMoveControl.Left += 1;
                        }
                        Thread.Sleep(10);
                        this.Update();
                    }
                    while (willMoveControl.Top != ttarget)
                    {

                        if (willMoveControl.Top > ttarget)
                        {
                            willMoveControl.Top -= 1;
                        }
                        else
                        {
                            willMoveControl.Top += 1;
                        }
                        Thread.Sleep(10);
                        this.Update();
                    }

                }
                //直行规则
                //绿色 11->17 !player2
                //蓝色 29->35 !player3
                //红色 47->53 !player4
                //橙色 65->71 !player1
                //终点****************
                //17   p2
                //35   p3
                //53   p4
                //71   p1

                switch (i)
                {
                    case 11:
                        if (willMoveControl.Name != "lblPlayer2")
                        {
                            i += 6;
                            end += 6;
                        }
                        else
                        {
                            i++;
                        }
                        break;
                    case 29:
                        if (willMoveControl.Name != "lblPlayer3")
                        {
                            i += 6;
                            end += 6;
                        }
                        else
                        {
                            i++;
                        }
                        break;
                    case 47:
                        if (willMoveControl.Name != "lblPlayer4")
                        {
                            i += 6;
                            end += 6;
                        }
                        else
                        {
                            i++;
                        }
                        break;
                    case 65:
                        if (willMoveControl.Name != "lblPlayer1")
                        {
                            i += 6;
                            end += 6;
                        }
                        else
                        {
                            i++;
                        }
                        break;
                    default:
                        i++;
                        break;
                }
                playerPosition[0] = end;
            }
        }

        private void tMoveFly_Tick(object sender, EventArgs e)
        {

        }
        private int[] randShowNum = new int[40];
        private int showIndex = 0;
        /// <summary>
        /// 用来展示随机数的时钟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tShowRandNum_Tick(object sender, EventArgs e)
        {
            lblRandNum.Text = randShowNum[showIndex].ToString();
            ++showIndex;
            if (showIndex == 40)
            {
                showIndex = 0;
                tShowRandNum.Stop();
                //开始移动飞机
                MoveFly(playerPosition[0] + 1, playerPosition[0] + randShowNum[39]);
                //动画结束才开始刷新数据
                tRefreshRoom.Start();
            }
        }

        private void tTime20_Tick(object sender, EventArgs e)
        {
            int time = Convert.ToInt32(lblTime20.Text);
            time -= 1;
            lblTime20.Text = time.ToString();
            if (time == 0)
            {
                lblTime20.Text = "20";
                tTime20.Stop();
            }
        }
        /// <summary>
        /// 刷新房间里的走步数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRefreshRoom_Tick(object sender, EventArgs e)
        {
            //房间信息刷新逻辑
            //1.获取上次走步
            string sql = "select top 1 std,num,seat from RoomState order by cdate desc";

            int std = -1;//状态序号
            int num = -1;//骰子点数
            int seat = -1;//座位号
            DBHelper dbHelper = new DBHelper();
            SqlDataReader reader = null;
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    std = Convert.ToInt32(reader["std"]);
                    num = Convert.ToInt32(reader["num"]);
                    seat = Convert.ToInt32(reader["seat"]);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            //判断是哪个玩家掷骰子,展示移动效果
            if (num != 6)
            {
                switch (seat)
                {
                    case 1:
                        willMoveControl = lblPlayer1;
                        break;
                    case 2:
                        willMoveControl = lblPlayer1;
                        break;
                    case 3:
                        willMoveControl = lblPlayer1;
                        break;
                    case 4:
                        willMoveControl = lblPlayer1;
                        break;
                }
                Go(num);
            }
            else
            {
                //如果点数为6，玩家是否是当前玩家
            }
            //2.判断是否是当前玩家走步，是则该玩家走步，否则刷新其他玩家走步
        }
    }
}
