namespace MyQQ
{
    partial class FrmLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtLoginPwd = new System.Windows.Forms.TextBox();
            this.lnkLblRegist = new System.Windows.Forms.LinkLabel();
            this.lnkLblForgetPwd = new System.Windows.Forms.LinkLabel();
            this.btnButton = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.label1.Location = new System.Drawing.Point(24, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "MyQQ号码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.label2.Location = new System.Drawing.Point(24, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "MyQQ密码：";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(96, 76);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(133, 21);
            this.txtId.TabIndex = 2;
            // 
            // txtLoginPwd
            // 
            this.txtLoginPwd.Location = new System.Drawing.Point(95, 108);
            this.txtLoginPwd.Name = "txtLoginPwd";
            this.txtLoginPwd.PasswordChar = '*';
            this.txtLoginPwd.Size = new System.Drawing.Size(133, 21);
            this.txtLoginPwd.TabIndex = 3;
            // 
            // lnkLblRegist
            // 
            this.lnkLblRegist.AutoSize = true;
            this.lnkLblRegist.BackColor = System.Drawing.Color.Transparent;
            this.lnkLblRegist.Location = new System.Drawing.Point(235, 79);
            this.lnkLblRegist.Name = "lnkLblRegist";
            this.lnkLblRegist.Size = new System.Drawing.Size(53, 12);
            this.lnkLblRegist.TabIndex = 4;
            this.lnkLblRegist.TabStop = true;
            this.lnkLblRegist.Text = "申请号码";
            this.lnkLblRegist.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblRegist_LinkClicked);
            // 
            // lnkLblForgetPwd
            // 
            this.lnkLblForgetPwd.AutoSize = true;
            this.lnkLblForgetPwd.BackColor = System.Drawing.Color.Transparent;
            this.lnkLblForgetPwd.Location = new System.Drawing.Point(235, 111);
            this.lnkLblForgetPwd.Name = "lnkLblForgetPwd";
            this.lnkLblForgetPwd.Size = new System.Drawing.Size(53, 12);
            this.lnkLblForgetPwd.TabIndex = 5;
            this.lnkLblForgetPwd.TabStop = true;
            this.lnkLblForgetPwd.Text = "忘记密码";
            this.lnkLblForgetPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblForgetPwd_LinkClicked);
            // 
            // btnButton
            // 
            this.btnButton.BackgroundImage = global::MyQQ.Properties.Resources.button;
            this.btnButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnButton.FlatAppearance.BorderSize = 0;
            this.btnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnButton.Location = new System.Drawing.Point(137, 154);
            this.btnButton.Name = "btnButton";
            this.btnButton.Size = new System.Drawing.Size(75, 23);
            this.btnButton.TabIndex = 6;
            this.btnButton.Text = "登录";
            this.btnButton.UseVisualStyleBackColor = true;
            this.btnButton.Click += new System.EventHandler(this.btnButton_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancle.BackgroundImage = global::MyQQ.Properties.Resources.button;
            this.btnCancle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancle.FlatAppearance.BorderSize = 0;
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCancle.Location = new System.Drawing.Point(218, 154);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 7;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = false;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MyQQ.Properties.Resources.LoginFormBG;
            this.ClientSize = new System.Drawing.Size(305, 188);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnButton);
            this.Controls.Add(this.lnkLblForgetPwd);
            this.Controls.Add(this.lnkLblRegist);
            this.Controls.Add(this.txtLoginPwd);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyQQ用户登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtLoginPwd;
        private System.Windows.Forms.LinkLabel lnkLblRegist;
        private System.Windows.Forms.LinkLabel lnkLblForgetPwd;
        private System.Windows.Forms.Button btnButton;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

