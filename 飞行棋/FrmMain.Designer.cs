namespace 飞行棋
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.plTransforBox = new System.Windows.Forms.Panel();
            this.plTransfor = new System.Windows.Forms.Panel();
            this.plShade = new System.Windows.Forms.Panel();
            this.pbFace = new System.Windows.Forms.PictureBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.plLoginBox = new System.Windows.Forms.Panel();
            this.pbLoginBtn = new System.Windows.Forms.PictureBox();
            this.pbPwdBg = new System.Windows.Forms.PictureBox();
            this.pbUserNameBg = new System.Windows.Forms.PictureBox();
            this.plTransforBox.SuspendLayout();
            this.plTransfor.SuspendLayout();
            this.plShade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFace)).BeginInit();
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
            this.plTransforBox.Location = new System.Drawing.Point(259, 63);
            this.plTransforBox.Name = "plTransforBox";
            this.plTransforBox.Size = new System.Drawing.Size(298, 392);
            this.plTransforBox.TabIndex = 19;
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
            this.plShade.Controls.Add(this.pbFace);
            this.plShade.Controls.Add(this.pbLogo);
            this.plShade.Controls.Add(this.plLoginBox);
            this.plShade.Controls.Add(this.pbPwdBg);
            this.plShade.Controls.Add(this.pbUserNameBg);
            this.plShade.Location = new System.Drawing.Point(0, 392);
            this.plShade.Name = "plShade";
            this.plShade.Size = new System.Drawing.Size(298, 392);
            this.plShade.TabIndex = 20;
            // 
            // pbFace
            // 
            this.pbFace.BackgroundImage = global::飞行棋.Properties.Resources._1_100;
            this.pbFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbFace.Location = new System.Drawing.Point(120, 104);
            this.pbFace.Name = "pbFace";
            this.pbFace.Size = new System.Drawing.Size(70, 70);
            this.pbFace.TabIndex = 22;
            this.pbFace.TabStop = false;
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
            this.plLoginBox.Controls.Add(this.pbLoginBtn);
            this.plLoginBox.Location = new System.Drawing.Point(46, 271);
            this.plLoginBox.Name = "plLoginBox";
            this.plLoginBox.Size = new System.Drawing.Size(207, 83);
            this.plLoginBox.TabIndex = 20;
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
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 770);
            this.Controls.Add(this.plTransforBox);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.plTransforBox.ResumeLayout(false);
            this.plTransfor.ResumeLayout(false);
            this.plShade.ResumeLayout(false);
            this.plShade.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFace)).EndInit();
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
        private System.Windows.Forms.PictureBox pbFace;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel plLoginBox;
        private System.Windows.Forms.PictureBox pbLoginBtn;
        private System.Windows.Forms.PictureBox pbPwdBg;
        private System.Windows.Forms.PictureBox pbUserNameBg;
    }
}