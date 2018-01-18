using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyQQ
{
    public partial class FrmRegister : Form
    {
        private static FrmRegister _frmRegister = null;
        private FrmRegister()
        {
            InitializeComponent();
        }
        public static FrmRegister CreateFrmRegister()
        {
            if (_frmRegister == null)
            {
                _frmRegister = new FrmRegister();
            }
            return _frmRegister;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (Regist())
                {

                }
                else
                {
                    MessageBox.Show("注册失败，请联系管理员！");
                }
            }
        }

        public bool Regist()
        {
            return false;
        }

        public bool CheckInput()
        {
            if (txtNickName.Text.Trim().Length == 0)
            {
                toolTip1.Show("请输入昵称", txtNickName, 0, txtNickName.Height, 700);
                txtNickName.Focus();
                return false;
            }
            else if (rdoSex_Boy.Checked == false && rdoSex_Girl.Checked == false)
            {
                toolTip1.Show("性别必须选中一个", rdoSex_Boy, 0, rdoSex_Boy.Height, 700);
                return false;
            }
            else if (txtLoginPwd.Text.Trim().Length == 0)
            {
                toolTip1.Show("请输入密码", txtLoginPwd, 0, txtLoginPwd.Height, 700);
                txtLoginPwd.Focus();
                return false;
            }
            else if (txtLoginPwd2.Text.Trim().Length == 0)
            {
                toolTip1.Show("请输入确认密码", txtLoginPwd2, 0, txtLoginPwd2.Height, 700);
                txtLoginPwd2.Focus();
                return false;
            }
            else if (txtLoginPwd2.Text.Trim() != txtLoginPwd.Text.Trim())
            {
                toolTip1.Show("两次密码必须一致", txtLoginPwd2, 0, txtLoginPwd2.Height, 700);
                txtLoginPwd2.Focus();
                return false;
            }
            return true;
        }
    }
}
