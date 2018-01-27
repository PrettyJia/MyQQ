namespace 飞行棋
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
            this.plTransforBox = new System.Windows.Forms.Panel();
            this.plTransfor = new System.Windows.Forms.Panel();
            this.plShade = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.lblTitleBar = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.plFace = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.plLoginBox = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pbLoginBtn = new System.Windows.Forms.PictureBox();
            this.pbPwdBg = new System.Windows.Forms.PictureBox();
            this.pbUserNameBg = new System.Windows.Forms.PictureBox();
            this.plTransforBox.SuspendLayout();
            this.plTransfor.SuspendLayout();
            this.plShade.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.plLoginBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoginBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPwdBg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserNameBg)).BeginInit();
            this.SuspendLayout();
            // 
            // plTransforBox
            // 
            this.plTransforBox.BackColor = System.Drawing.Color.Black;
            this.plTransforBox.Controls.Add(this.plTransfor);
            this.plTransforBox.Location = new System.Drawing.Point(0, 0);
            this.plTransforBox.Name = "plTransforBox";
            this.plTransforBox.Size = new System.Drawing.Size(298, 392);
            this.plTransforBox.TabIndex = 20;
            // 
            // plTransfor
            // 
            this.plTransfor.BackgroundImage = global::飞行棋.Properties.Resources.star_trails;
            this.plTransfor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plTransfor.Controls.Add(this.plShade);
            this.plTransfor.Location = new System.Drawing.Point(0, -392);
            this.plTransfor.Name = "plTransfor";
            this.plTransfor.Size = new System.Drawing.Size(596, 784);
            this.plTransfor.TabIndex = 22;
            // 
            // plShade
            // 
            this.plShade.BackColor = System.Drawing.Color.Transparent;
            this.plShade.BackgroundImage = global::飞行棋.Properties.Resources.shade;
            this.plShade.Controls.Add(this.panel1);
            this.plShade.Controls.Add(this.lblTitleBar);
            this.plShade.Controls.Add(this.txtPwd);
            this.plShade.Controls.Add(this.txtUserName);
            this.plShade.Controls.Add(this.plFace);
            this.plShade.Controls.Add(this.pbLogo);
            this.plShade.Controls.Add(this.plLoginBox);
            this.plShade.Controls.Add(this.pbPwdBg);
            this.plShade.Controls.Add(this.pbUserNameBg);
            this.plShade.Location = new System.Drawing.Point(0, 392);
            this.plShade.Name = "plShade";
            this.plShade.Size = new System.Drawing.Size(298, 392);
            this.plShade.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbClose);
            this.panel1.Location = new System.Drawing.Point(264, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(34, 30);
            this.panel1.TabIndex = 29;
            // 
            // pbClose
            // 
            this.pbClose.Image = global::飞行棋.Properties.Resources.qr_panel_close;
            this.pbClose.Location = new System.Drawing.Point(-24, 2);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(116, 25);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbClose.TabIndex = 28;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // lblTitleBar
            // 
            this.lblTitleBar.Location = new System.Drawing.Point(3, 0);
            this.lblTitleBar.Name = "lblTitleBar";
            this.lblTitleBar.Size = new System.Drawing.Size(292, 36);
            this.lblTitleBar.TabIndex = 27;
            this.lblTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitleBar_MouseDown);
            // 
            // txtPwd
            // 
            this.txtPwd.BackColor = System.Drawing.Color.White;
            this.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPwd.Location = new System.Drawing.Point(66, 241);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(167, 14);
            this.txtPwd.TabIndex = 26;
            this.txtPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPwd_KeyDown);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.White;
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserName.Location = new System.Drawing.Point(66, 201);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(167, 14);
            this.txtUserName.TabIndex = 25;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // plFace
            // 
            this.plFace.BackgroundImage = global::飞行棋.Properties.Resources._1_100;
            this.plFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.plFace.Location = new System.Drawing.Point(115, 111);
            this.plFace.Name = "plFace";
            this.plFace.Size = new System.Drawing.Size(70, 70);
            this.plFace.TabIndex = 24;
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.Image = global::飞行棋.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(105, 38);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(96, 63);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbLogo.TabIndex = 21;
            this.pbLogo.TabStop = false;
            // 
            // plLoginBox
            // 
            this.plLoginBox.BackColor = System.Drawing.Color.Transparent;
            this.plLoginBox.Controls.Add(this.linkLabel1);
            this.plLoginBox.Controls.Add(this.pbLoginBtn);
            this.plLoginBox.Location = new System.Drawing.Point(46, 271);
            this.plLoginBox.Name = "plLoginBox";
            this.plLoginBox.Size = new System.Drawing.Size(207, 83);
            this.plLoginBox.TabIndex = 20;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(112, 8);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 12);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "申请内测账号";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pbLoginBtn
            // 
            this.pbLoginBtn.BackColor = System.Drawing.Color.Transparent;
            this.pbLoginBtn.Image = global::飞行棋.Properties.Resources.login_button;
            this.pbLoginBtn.Location = new System.Drawing.Point(0, 30);
            this.pbLoginBtn.Name = "pbLoginBtn";
            this.pbLoginBtn.Size = new System.Drawing.Size(624, 42);
            this.pbLoginBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbLoginBtn.TabIndex = 2;
            this.pbLoginBtn.TabStop = false;
            this.pbLoginBtn.Click += new System.EventHandler(this.pbLoginBtn_Click);
            // 
            // pbPwdBg
            // 
            this.pbPwdBg.BackColor = System.Drawing.Color.Transparent;
            this.pbPwdBg.Image = global::飞行棋.Properties.Resources.login_edit_bk;
            this.pbPwdBg.Location = new System.Drawing.Point(46, 233);
            this.pbPwdBg.Name = "pbPwdBg";
            this.pbPwdBg.Size = new System.Drawing.Size(207, 32);
            this.pbPwdBg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPwdBg.TabIndex = 19;
            this.pbPwdBg.TabStop = false;
            // 
            // pbUserNameBg
            // 
            this.pbUserNameBg.BackColor = System.Drawing.Color.Transparent;
            this.pbUserNameBg.Image = global::飞行棋.Properties.Resources.login_edit_bk;
            this.pbUserNameBg.Location = new System.Drawing.Point(46, 192);
            this.pbUserNameBg.Name = "pbUserNameBg";
            this.pbUserNameBg.Size = new System.Drawing.Size(207, 32);
            this.pbUserNameBg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbUserNameBg.TabIndex = 18;
            this.pbUserNameBg.TabStop = false;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(298, 392);
            this.Controls.Add(this.plTransforBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.plTransforBox.ResumeLayout(false);
            this.plTransfor.ResumeLayout(false);
            this.plShade.ResumeLayout(false);
            this.plShade.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.plLoginBox.ResumeLayout(false);
            this.plLoginBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoginBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPwdBg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserNameBg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plTransforBox;
        private System.Windows.Forms.Panel plTransfor;
        private System.Windows.Forms.Panel plShade;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel plLoginBox;
        private System.Windows.Forms.PictureBox pbLoginBtn;
        private System.Windows.Forms.PictureBox pbPwdBg;
        private System.Windows.Forms.PictureBox pbUserNameBg;
        private System.Windows.Forms.Panel plFace;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblTitleBar;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Panel panel1;
    }
}

