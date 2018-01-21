namespace 飞行棋
{
    partial class UCTable
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.plRoomtemp = new System.Windows.Forms.Panel();
            this.lblPlay4Name = new System.Windows.Forms.Label();
            this.lblPlay1Name = new System.Windows.Forms.Label();
            this.lblPlay2Name = new System.Windows.Forms.Label();
            this.lblPlay3Name = new System.Windows.Forms.Label();
            this.lblTableNum = new System.Windows.Forms.Label();
            this.pbPlay4 = new System.Windows.Forms.PictureBox();
            this.pbPlay2 = new System.Windows.Forms.PictureBox();
            this.pbPlay3 = new System.Windows.Forms.PictureBox();
            this.pbPlay1 = new System.Windows.Forms.PictureBox();
            this.pbRoomState = new System.Windows.Forms.PictureBox();
            this.plRoomtemp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRoomState)).BeginInit();
            this.SuspendLayout();
            // 
            // plRoomtemp
            // 
            this.plRoomtemp.Controls.Add(this.lblPlay4Name);
            this.plRoomtemp.Controls.Add(this.lblPlay1Name);
            this.plRoomtemp.Controls.Add(this.lblPlay2Name);
            this.plRoomtemp.Controls.Add(this.lblPlay3Name);
            this.plRoomtemp.Controls.Add(this.lblTableNum);
            this.plRoomtemp.Controls.Add(this.pbPlay4);
            this.plRoomtemp.Controls.Add(this.pbPlay2);
            this.plRoomtemp.Controls.Add(this.pbPlay3);
            this.plRoomtemp.Controls.Add(this.pbPlay1);
            this.plRoomtemp.Controls.Add(this.pbRoomState);
            this.plRoomtemp.Location = new System.Drawing.Point(0, 0);
            this.plRoomtemp.Name = "plRoomtemp";
            this.plRoomtemp.Size = new System.Drawing.Size(160, 160);
            this.plRoomtemp.TabIndex = 1;
            // 
            // lblPlay4Name
            // 
            this.lblPlay4Name.AutoSize = true;
            this.lblPlay4Name.ForeColor = System.Drawing.Color.White;
            this.lblPlay4Name.Location = new System.Drawing.Point(11, 102);
            this.lblPlay4Name.Name = "lblPlay4Name";
            this.lblPlay4Name.Size = new System.Drawing.Size(41, 12);
            this.lblPlay4Name.TabIndex = 10;
            this.lblPlay4Name.Text = "label1";
            this.lblPlay4Name.Visible = false;
            // 
            // lblPlay1Name
            // 
            this.lblPlay1Name.AutoSize = true;
            this.lblPlay1Name.ForeColor = System.Drawing.Color.White;
            this.lblPlay1Name.Location = new System.Drawing.Point(18, 14);
            this.lblPlay1Name.Name = "lblPlay1Name";
            this.lblPlay1Name.Size = new System.Drawing.Size(41, 12);
            this.lblPlay1Name.TabIndex = 9;
            this.lblPlay1Name.Text = "label1";
            this.lblPlay1Name.Visible = false;
            // 
            // lblPlay2Name
            // 
            this.lblPlay2Name.AutoSize = true;
            this.lblPlay2Name.ForeColor = System.Drawing.Color.White;
            this.lblPlay2Name.Location = new System.Drawing.Point(111, 43);
            this.lblPlay2Name.Name = "lblPlay2Name";
            this.lblPlay2Name.Size = new System.Drawing.Size(41, 12);
            this.lblPlay2Name.TabIndex = 8;
            this.lblPlay2Name.Text = "label1";
            this.lblPlay2Name.Visible = false;
            // 
            // lblPlay3Name
            // 
            this.lblPlay3Name.AutoSize = true;
            this.lblPlay3Name.ForeColor = System.Drawing.Color.White;
            this.lblPlay3Name.Location = new System.Drawing.Point(109, 105);
            this.lblPlay3Name.Name = "lblPlay3Name";
            this.lblPlay3Name.Size = new System.Drawing.Size(41, 12);
            this.lblPlay3Name.TabIndex = 7;
            this.lblPlay3Name.Text = "label1";
            this.lblPlay3Name.Visible = false;
            // 
            // lblTableNum
            // 
            this.lblTableNum.ForeColor = System.Drawing.Color.White;
            this.lblTableNum.Location = new System.Drawing.Point(29, 145);
            this.lblTableNum.Name = "lblTableNum";
            this.lblTableNum.Size = new System.Drawing.Size(100, 13);
            this.lblTableNum.TabIndex = 6;
            this.lblTableNum.Text = "label1";
            this.lblTableNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbPlay4
            // 
            this.pbPlay4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPlay4.Image = global::飞行棋.Properties.Resources.Seat;
            this.pbPlay4.Location = new System.Drawing.Point(14, 62);
            this.pbPlay4.Name = "pbPlay4";
            this.pbPlay4.Size = new System.Drawing.Size(32, 32);
            this.pbPlay4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPlay4.TabIndex = 4;
            this.pbPlay4.TabStop = false;
            this.pbPlay4.Tag = "4,{0}";
            this.pbPlay4.Click += new System.EventHandler(this.pbPlay1_Click);
            // 
            // pbPlay2
            // 
            this.pbPlay2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPlay2.Image = global::飞行棋.Properties.Resources.Seat;
            this.pbPlay2.Location = new System.Drawing.Point(113, 61);
            this.pbPlay2.Name = "pbPlay2";
            this.pbPlay2.Size = new System.Drawing.Size(32, 32);
            this.pbPlay2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPlay2.TabIndex = 3;
            this.pbPlay2.TabStop = false;
            this.pbPlay2.Tag = "2,{0}";
            this.pbPlay2.Click += new System.EventHandler(this.pbPlay1_Click);
            // 
            // pbPlay3
            // 
            this.pbPlay3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPlay3.Image = global::飞行棋.Properties.Resources.Seat;
            this.pbPlay3.Location = new System.Drawing.Point(64, 110);
            this.pbPlay3.Name = "pbPlay3";
            this.pbPlay3.Size = new System.Drawing.Size(32, 32);
            this.pbPlay3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPlay3.TabIndex = 2;
            this.pbPlay3.TabStop = false;
            this.pbPlay3.Tag = "3,{0}";
            this.pbPlay3.Click += new System.EventHandler(this.pbPlay1_Click);
            // 
            // pbPlay1
            // 
            this.pbPlay1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPlay1.Image = global::飞行棋.Properties.Resources.Seat;
            this.pbPlay1.Location = new System.Drawing.Point(65, 14);
            this.pbPlay1.Name = "pbPlay1";
            this.pbPlay1.Size = new System.Drawing.Size(32, 32);
            this.pbPlay1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPlay1.TabIndex = 1;
            this.pbPlay1.TabStop = false;
            this.pbPlay1.Tag = "1,{0}";
            this.pbPlay1.Click += new System.EventHandler(this.pbPlay1_Click);
            // 
            // pbRoomState
            // 
            this.pbRoomState.Image = global::飞行棋.Properties.Resources.tablen;
            this.pbRoomState.Location = new System.Drawing.Point(44, 43);
            this.pbRoomState.Name = "pbRoomState";
            this.pbRoomState.Size = new System.Drawing.Size(73, 74);
            this.pbRoomState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbRoomState.TabIndex = 0;
            this.pbRoomState.TabStop = false;
            this.pbRoomState.Click += new System.EventHandler(this.pbRoomState_Click);
            this.pbRoomState.MouseEnter += new System.EventHandler(this.pbRoomState_MouseEnter);
            this.pbRoomState.MouseLeave += new System.EventHandler(this.pbRoomState_MouseLeave);
            // 
            // UCTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plRoomtemp);
            this.Name = "UCTable";
            this.Size = new System.Drawing.Size(160, 160);
            this.plRoomtemp.ResumeLayout(false);
            this.plRoomtemp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRoomState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plRoomtemp;
        private System.Windows.Forms.PictureBox pbPlay4;
        private System.Windows.Forms.PictureBox pbPlay2;
        private System.Windows.Forms.PictureBox pbPlay3;
        private System.Windows.Forms.PictureBox pbPlay1;
        private System.Windows.Forms.PictureBox pbRoomState;
        private System.Windows.Forms.Label lblTableNum;
        private System.Windows.Forms.Label lblPlay4Name;
        private System.Windows.Forms.Label lblPlay1Name;
        private System.Windows.Forms.Label lblPlay2Name;
        private System.Windows.Forms.Label lblPlay3Name;
    }
}
