using PrettyCommonControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                FrmRooms rooms = FrmRooms.GetFrmRooms();
                rooms.Show();

                this.Visible = false;
            }
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
    }
}
