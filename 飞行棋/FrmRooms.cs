using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 飞行棋
{
    public partial class FrmRooms : Form
    {
        /// <summary>
        /// 登录的用户id
        /// </summary>
        public string id=string.Empty;
        private static FrmRooms frmRooms;
        public static FrmRooms GetFrmRooms(string id)
        {
            if (frmRooms==null)
            {
                frmRooms = new FrmRooms( id);
            }
            return frmRooms;
        }
        private FrmRooms(string id)
        {
            this.id = id;
            InitializeComponent();
        }
        
        private void FrmRooms_Load(object sender, EventArgs e)
        {
            //防止闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            InitialRooms();
            LoadRooms();
        }

        private void InitialRooms()
        {
            for (int i = 0; i < 10; i++)
            {
                UCTable ucTable = new UCTable();
                ucTable.Name = "ucTable"+i;
                ucTable.id = id;
                ucTable.SetTableNum(i + 1);
                ucTable.ReferenceRoomData();
                flowLayoutPanel1.Controls.Add(ucTable);
            }
            
        }

        private void LoadRooms()
        {
            

        }
        //刷新房间
        private void tRefershen_Tick(object sender, EventArgs e)
        {
            foreach (Control control in Controls[0].Controls)
            {
                if (control is UCTable)
                {
                    (control as UCTable).ReferenceRoomData();
                }
            }
        }

        private void FrmRooms_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
