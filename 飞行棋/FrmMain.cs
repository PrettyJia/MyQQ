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
            //默认掷骰子按钮禁用
            this.btnGo.Visible = false;
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
                    this.Close();
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
            string sql = "select rid,seat from RoomPlayer where id=" + id;
            DBHelper dbHelper = new DBHelper();
            SqlDataReader reader = null;
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    string rid = reader["rid"].ToString();
                    if (rid == roomId || rid == "0")
                    {
                        seatId = reader["seat"].ToString();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
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
                for (int i = 0; i < seats.Length; i++)
                {
                    if (reader.Read())
                    {
                        seats[i] = Convert.ToInt32(reader["seat"]);
                    }
                    else
                    {
                        seats[i] = 0;
                    }
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
        private int[] playerPosition = {1,19,37,55};//4个玩家的位置
        private void btnGo_Click(object sender, EventArgs e)
        {
            tRefreshRoom.Stop();//动画开始的时候停止刷新数据
            btnGo.Visible = false;
            //向数据库中插入一条数据,并移动
            int num=InsertGoInfo();
            Go(num);
            //刷新房间数据
            ///tRefreshRoom.Start();
        }

        /// <summary>
        /// 插入移动数据，获取移动量
        /// </summary>
        /// <returns></returns>
        private int InsertGoInfo()
        {
            int num = -1;
            string sql = string.Format(@"insert into RoomState (rid,seat)
values({0}, {1});select num from RoomState where std= @@identity", roomId,seatId);
            DBHelper dbHelper = new DBHelper();
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql,dbHelper.Connection);
                num=Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception)
            {
            }
            finally
            {
                dbHelper.Connection.Close();
            }
            return num;
        }

        private Control willMoveControl = null;//即将移动的控件
        private void Go(int step)
        {
            randShowNum[randShowNum.Length - 1] = step;
            tShowRandNum.Start();
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
                playerPosition[Convert.ToInt32(seatId) - 1] = end;
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
                //开始移动飞机,移动谁的飞机？
                int seat = Convert.ToInt32(seatId);
                switch (seat)
                {
                    case 1:
                        willMoveControl =lblPlayer1;
                        break;
                    case 2:
                        willMoveControl = lblPlayer2;
                        break;
                    case 3:
                        willMoveControl = lblPlayer3;
                        break;
                    case 4:
                        willMoveControl = lblPlayer4;
                        break;

                }
                MoveFly(playerPosition[seat-1], playerPosition[seat-1] + randShowNum[39]);
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
        /// 刷新房间里的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRefreshRoom_Tick(object sender, EventArgs e)
        {
            //房间信息刷新逻辑
            //无论如何刷新房间头像信息
            RefreshRoomPlayerInfo();
            //房间是否已经进入游戏状态
            //没有，判断所有玩家是否全部准备好
            //如果都准备好，将房间状态修改
            //如果进入游戏状态，开始游戏-
            if (GetRoomState() != true)
            {
                if (AllPlayerReady())
                {
                    UpdateRoomToStart();
                }
            }
            else
            {
                Gameing();
            }

        }
        /// <summary>
        /// 刷新房间内玩家头像信息
        /// </summary>
        private void RefreshRoomPlayerInfo()
        {
            pbPlay1.Tag = "1,{0}";
            pbPlay2.Tag = "2,{0}";
            pbPlay3.Tag = "3,{0}";
            pbPlay4.Tag = "4,{0}";
            //查询房间内所有玩家
            string sql = "select id,seat,state from RoomPlayer where rid=" + roomId;
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
                        int uid = Convert.ToInt32(reader["id"]);
                        int seat = Convert.ToInt32(reader["seat"]);
                        int state = Convert.ToInt32(reader["state"]);
                        GetPlayerInfo(uid, seat, state);
                        if (uid.ToString()==id)
                        {
                            seatId = seat.ToString();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            //设置没有座位的
            for (int i = 1; i <= 4; i++)
            {
                //lblPlayer1State
                Control pbcontrol = this.Controls.Find("pbPlay" + i, true)[0];
                Label lblControl = Controls.Find("lblPlayer" + i + "State", true)[0] as Label;
                Label nickName=Controls.Find("lblPlay" + i + "Name", true)[0] as Label;
                //判断没有座位
                if (pbcontrol.Tag.ToString() == (i + ",{0}"))
                {
                    ControlUtils.ChangeToRect(pbcontrol);
                    lblControl.Text = "";
                    nickName.Text = "";
                    nickName.Visible = false;
                    (pbcontrol as PictureBox).Image = Properties.Resources.Seat;
                }
                else
                {
                    ControlUtils.ChangeToCircle(pbcontrol);
                    //获取对应座位的玩家
                    int uid = Convert.ToInt32(pbcontrol.Tag.ToString().Split(',')[1]);
                    //有座位的判断准备状态
                    if (!GetUserReaday(uid))
                    {
                        lblControl.Text = "";
                        lblControl.Visible = false;
                        if (seatId == i.ToString())
                        {
                            this.btnReady.Visible = true;
                        }
                    }
                    else
                    {
                        //判断自己是否已经准备
                        if (seatId == i.ToString())
                        {
                            this.btnReady.Visible = false;
                        }
                        lblControl.Text = "已准备";
                        lblControl.Visible = true;
                    }
                }
            }
        }
        /// <summary>
        /// 获取玩家是否已经准备完毕
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        private bool GetUserReaday(int uid)
        {
            string sql = "select state from RoomPlayer where id=" + uid;
            bool isReady = false;
            DBHelper dbHelper = new DBHelper();
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                int result = Convert.ToInt32(command.ExecuteScalar());
                if (result == 1)
                {
                    isReady = true;
                }
            }
            catch (Exception ex)
            { }
            finally
            {
                dbHelper.Connection.Close();
            }
            return isReady;
        }

        /// <summary>
        /// 获取具体的玩家信息
        /// </summary>
        /// <param name="id">玩家id</param>
        /// <param name="seat">玩家座位号</param>
        /// <param name="state">玩家状态</param>
        private void GetPlayerInfo(int id, int seat, int state)
        {
            //获取头像编号
            string sql = "select face,nickName from Users where id=" + id;
            DBHelper dbHelper = new DBHelper();
            SqlDataReader reader = null;
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string face = reader["face"].ToString();
                    string nickName = reader["nickName"].ToString();
                    switch (seat)
                    {
                        case 1:
                            pbPlay1.Tag = string.Format(pbPlay1.Tag.ToString(), id);
                            pbPlay1.Image = Properties.Resources.ResourceManager.GetObject(face) as Image;
                            lblPlay1Name.Text = nickName;
                            lblPlay1Name.Visible = true;
                            break;
                        case 2:
                            pbPlay2.Tag = string.Format(pbPlay2.Tag.ToString(), id);
                            pbPlay2.Image = Properties.Resources.ResourceManager.GetObject(face) as Image;
                            lblPlay2Name.Text = nickName;
                            lblPlay2Name.Visible = true;
                            break;
                        case 3:
                            pbPlay3.Tag = string.Format(pbPlay3.Tag.ToString(), id);
                            pbPlay3.Image = Properties.Resources.ResourceManager.GetObject(face) as Image;
                            lblPlay3Name.Text = nickName;
                            lblPlay3Name.Visible = true;
                            break;
                        case 4:
                            pbPlay4.Tag = string.Format(pbPlay4.Tag.ToString(), id);
                            pbPlay4.Image = Properties.Resources.ResourceManager.GetObject(face) as Image;
                            lblPlay4Name.Text = nickName;
                            lblPlay4Name.Visible = true;
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                dbHelper.Connection.Close();
            }



        }
        /// <summary>
        /// 更改房间状态为游戏中
        /// </summary>
        private void UpdateRoomToStart()
        {
            string sql = "update Rooms set state=1 where rid=" + roomId;
            DBHelper dbHelper = new DBHelper();
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dbHelper.Connection.Close();
            }
        }

        /// <summary>
        /// 获取房间状态是否开始
        /// </summary>
        /// <returns></returns>
        private bool GetRoomState()
        {
            string sql = "select state from Rooms where rid=" + roomId;
            DBHelper dbHelper = new DBHelper();
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                int state = Convert.ToInt32(command.ExecuteScalar());
                if (state == 1)
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
        /// 开始游戏
        /// </summary>
        private void Gameing()
        {
            if (GetPlayCount() == 0)
            {
                //判断是否是第一次掷骰子，如果是从第一个开始投
                //获取第一个座位
                int seat = GetFirstSeat(roomId);
                //各自判断是否是第一个位
                if (seat.ToString()==seatId)
                {
                    tRefreshRoom.Stop();
                    //倒计时
                    tTime20.Start();
                    btnGo.Visible = true;
                    //更新位置
                }
            }
            else
            {
                return;
                //如果不是第一次掷骰子，获取上次走步数据
                //如果是当前用户，进入掷骰子流程
                //不是当前用户，则刷新走步数据
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
                //if (num != 6)
                //{

                //}
                //else
                //{
                //    //如果点数为6，玩家是否是当前玩家
                //}
                //判断是否是当前玩家走步，是则该玩家走步，否则刷新其他玩家走步
                //开始倒计时
                tShowRandNum.Start();
                if (seat.ToString() == seatId)
                {
                    btnGo.Enabled = true;
                    tRefreshRoom.Stop();//暂停刷新数据
                }
                else
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
            }
        }

        private int GetFirstSeat(string roomId)
        {
            string sql = "select top 1 seat from RoomPlayer where rid="+roomId;
            DBHelper dbHelper = new DBHelper();
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql,dbHelper.Connection);
                int seat=Convert.ToInt32(command.ExecuteScalar());
                return seat;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dbHelper.Connection.Close();
            }
            return -1;
        }

        /// <summary>
        /// 获取房间掷骰子的次数
        /// </summary>
        /// <returns></returns>
        private int GetPlayCount()
        {
            string sql = "select count(*) from RoomState where rid=" + roomId;
            DBHelper dbHelper = new DBHelper();
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                dbHelper.Connection.Close();
            }
        }
        /// <summary>
        /// 所有玩家是否都准备
        /// </summary>
        /// <returns></returns>
        private bool AllPlayerReady()
        {
            bool ready = true;
            //查询准备好的人数
            string sql = string.Format("select seat,state from RoomPlayer where rid={0}", roomId);
            DBHelper dbHelper = new DBHelper();
            SqlDataReader reader = null;
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    int seat = Convert.ToInt32(reader["seat"]);
                    int state = Convert.ToInt32(reader["state"]);
                    if (state == 0)
                    {
                        ready = false;
                    }
                    else
                    {
                        switch (seat)
                        {
                            case 1:
                                lblPlayer1State.Text = "已准备";
                                break;
                            case 2:
                                lblPlayer2State.Text = "已准备";
                                break;
                            case 3:
                                lblPlayer3State.Text = "已准备";
                                break;
                            case 4:
                                lblPlayer4State.Text = "已准备";
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return ready;
        }

        /// <summary>
        /// 确定准备好了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReady_Click(object sender, EventArgs e)
        {
            string sql = "update RoomPlayer set state=1 where id=" + id;
            DBHelper dbHelper = new DBHelper();
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                int result = command.ExecuteNonQuery();
                if (result == 1)
                {
                    this.btnReady.Visible = false;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                dbHelper.Connection.Close();
            }

        }
    }
}
