using PrettyCommonControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace 飞行棋
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            //防止闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            InitializeComponent();
            ControlUtils.ChangeToCircle(plFace);
        }
        
        //登录按钮的点击事件
        private void pbLoginBtn_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (CheckUser())
                {
                    FrmRooms rooms = FrmRooms.GetFrmRooms(txtUserName.Text.Trim());
                    rooms.Show();
                    this.Visible = false;
                }else
                {
                    UCMessageBox.Show("账号或密码有误！",this);
                }
            }
        }
        /// <summary>
        /// 检查登录
        /// </summary>
        /// <returns></returns>
        private bool CheckUser()
        {
            string id = txtUserName.Text.Trim();
            string pwd = txtPwd.Text.Trim();
            string sql =string.Format( @"select COUNT(*) from Users
                where id={0} and pwd='{1}'",id,pwd);
            DBHelper dbHelper = new DBHelper();
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                int result =Convert.ToInt32( command.ExecuteScalar());
                if (result==1)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                UCMessageBox.Show(ex.Message, this);
                return false;
            }
            finally
            {
                dbHelper.Connection.Close();
            }
            return false;
        }

        public bool CheckInput()
        {
            if (txtUserName.Text.Length==0)
            {
                UCMessageBox.Show("输入用户名！",this);
                return false;
            }else if (txtPwd.Text.Length==0)
            {
                UCMessageBox.Show("输入用户名！", this);
                return false;
            }
            return true;
        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int IParam);
        
        private void lblTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(base.Handle, 0x112, 0xf012, 0);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegist regist = new FrmRegist();
            regist.Show();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //更更换显示的头像

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            ChangeFace();
        }

        private void ChangeFace()
        {
            string sql = string.Format("select face from Users where id={0}",txtUserName.Text.Trim());
            DBHelper dbHelper = new DBHelper();
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                string faceId=command.ExecuteScalar().ToString();
                plFace.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(faceId);
            }
            catch (Exception)
            {
                plFace.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("1-100");
                //UCMessageBox.Show("系统繁忙！",this);
            }
            finally
            {
                dbHelper.Connection.Close();
            }
        }
        /// <summary>
        /// 按下回车键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                pbLoginBtn_Click(sender, e);
            }
        }
    }
}
