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
            InitializeComponent();
            DIY();
        }
        private void DIY()
        {
            //绘制圆形图片框
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(plFace.ClientRectangle);
            Region region = new Region(gp);
            plFace.Region = region;
            
        }
        //登录按钮的点击事件
        private void pbLoginBtn_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {

            }
        }
        public bool CheckInput()
        {
            if (txtUserName.Text.Length==0)
            {
                MessageBox.Show("输入用户名！");
                return false;
            }else if (txtPwd.Text.Length==0)
            {
                MessageBox.Show("请输入密码！");
                return false;
            }
            return true;
        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int IParam);

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void plShade_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void lblTitleBar_Click(object sender, EventArgs e)
        {
            ReleaseCapture();
            SendMessage(base.Handle, 0x112, 0xf012, 0);
        }

        private void lblTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(base.Handle, 0x112, 0xf012, 0);
        }
    }
}
