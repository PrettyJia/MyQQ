using PrettyCommonControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 飞行棋
{
    public partial class FrmRegist : Form
    {
        UCFaceList faceList;
        public FrmRegist()
        {
            
            InitializeComponent();
            faceList = UCFaceList.GetObject(this.Size);
            faceList.Visible = false;
            faceList.VisibleChanged += FaceList_VisibleChanged;
            this.Controls.Add(faceList);
        }

        private void FaceList_VisibleChanged(object sender, EventArgs e)
        {
            //获取id，更改图片
            string picid = faceList.picid;
            pbFace.Image = (Image)Properties.Resources.ResourceManager.GetObject(picid.ToString());
        }

        private void FrmRegist_Load(object sender, EventArgs e)
        {
            ControlUtils.ChangeToCircle(pbFace);
        }
        //头像选择
        private void pbFace_Click(object sender, EventArgs e)
        {
            faceList.Visible = true;
            faceList.BringToFront();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (faceList.picid.Length == 0)
            {
                UCMessageBox.Show("请选择一个头像！", this);
                return;
            } else if (txtNickName.Text.Trim().Length == 0)
            {
                UCMessageBox.Show("昵称不能为空！", this);
                return;
            } else if (txtPwd.Text.Trim().Length == 0)
            {
                UCMessageBox.Show("密码不能为空！", this);
                return;
            } else if (txtPwd.Text.Trim().Length<6|| txtPwd.Text.Trim().Length>16)
            {
                UCMessageBox.Show("密码长度为6~16位！", this);
                return;
            } else if (txtPwd2.Text.Trim().Length == 0)
            {
                UCMessageBox.Show("确认密码不能为空！", this);
                return;
            } else if (txtPwd2.Text.Trim() != txtPwd.Text.Trim())
            {
                UCMessageBox.Show("两次密码需一致！", this);
                return;
            }
            RegistUser();
        }

        private void RegistUser()
        {
            string sql =string.Format(@"insert into Users (nickName,face,pwd)
            values('{0}','{1}','{2}');
            select @@IDENTITY",txtNickName.Text.Trim(), faceList.picid,txtPwd2.Text.Trim());
            DBHelper dbHelper = new DBHelper();
            try
            {
                dbHelper.Connection.Open();
                SqlCommand command = new SqlCommand(sql, dbHelper.Connection);
                int id=Convert.ToInt32(command.ExecuteScalar());
                if (id>0)
                {
                    MessageBox.Show(string.Format("注册的QQ号码为：{0}\r\n请牢记！",id));
                }else
                {
                    UCMessageBox.Show("服务器繁忙，请稍后重试！",this);
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
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
