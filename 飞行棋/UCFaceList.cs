using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 飞行棋
{
    public partial class UCFaceList : UserControl
    {
        public string picid = string.Empty;
        private static UCFaceList list;
        public static UCFaceList GetObject(Size size)
        {
            if (list==null||list.IsDisposed)
            {
                list = new UCFaceList(size);
            }
            return list;
        }
        private UCFaceList(Size size)
        {
            InitializeComponent();
            this.Size = size;
            InitialFaceList();
        }

        private void InitialFaceList()
        {
            ImageList il = new ImageList();
            il.ImageSize = new Size(40, 40);
            for (int i = 1; i <= 100; i++)
            {
                object o=Properties.Resources.ResourceManager.GetObject(i.ToString());
                ListViewItem listViewItem=new ListViewItem(i.ToString(), i - 1);
                lvFaces.Items.Add(listViewItem);
                il.Images.Add(((Image)o));
            }
            lvFaces.LargeImageList = il;
        }

        private void lvFaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lvFaces_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lvFaces.SelectedItems.Count != 1)
            {
                return;
            }
            picid = this.lvFaces.SelectedItems[0].Text;
            this.Visible = false;
        }
    }
}
