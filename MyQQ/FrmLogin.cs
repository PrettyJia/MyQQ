using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyQQ
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 登录按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnButton_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (CheckLogin())
                {
                    FrmMain frmMain = new FrmMain();
                    frmMain.Show();
                    UserHelper.userId = txtId.Text.Trim();
                    this.Visible = false;
                }else
                {
                    toolTip1.Show("账号或密码错误", txtLoginPwd, 0, txtLoginPwd.Height, 700);
                }
            }
        }
        /// <summary>
        /// 检查用户是否登录成功
        /// </summary>
        /// <returns></returns>
        private bool CheckLogin()
        {
            string sql = string.Format(@"select COUNT(*) from Users 
where id = '{0}' and LoginPwd = '{1}'",txtId.Text.Trim(),txtLoginPwd.Text.Trim());
            try
            {
                DBHelper.connection.Open();
                SqlCommand command = new SqlCommand(sql,DBHelper.connection);
                int result=Convert.ToInt32(command.ExecuteScalar());
                if (result==1)
                {
                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBHelper.connection.Close();
            }
            return false;
        }

        /// <summary>
        /// 检查用户输入
        /// </summary>
        /// <returns></returns>
        public bool CheckInput()
        {
            if (txtId.Text.Trim().Length == 0)
            {
                toolTip1.Show("请输入账号", txtId, 0, txtId.Height, 700);
                return false;
            } else if (txtId.Text.Trim().Length<5)
            {
                toolTip1.Show("账号至少5位", txtId, 0, txtId.Height, 700);
                return false;
            } else if (txtLoginPwd.Text.Trim().Length == 0)
            {
                toolTip1.Show("请输入密码", txtLoginPwd, 0, txtLoginPwd.Height, 700);
                return false;
            }else if (txtLoginPwd.Text.Trim().Length <6|| txtLoginPwd.Text.Trim().Length>16)
            {
                toolTip1.Show("密码只能是6位~16位", txtLoginPwd, 0, txtLoginPwd.Height, 700);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 取消按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 申请账号链接点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkLblRegist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegister frmRegister = FrmRegister.CreateFrmRegister();
            frmRegister.Show();
        }
        /// <summary>
        /// 忘记密码链接点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkLblForgetPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
