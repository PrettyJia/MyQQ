using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 飞行棋
{
    public static class ControlUtils
    {
        /// <summary>
        /// 将控件变成圆形
        /// </summary>
        /// <param name="control"></param>
        public static void ChangeToCircle(Control control)
        {
            //绘制圆形图片框
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(control.ClientRectangle);
            Region region = new Region(gp);
            control.Region = region;
        }
        /// <summary>
        /// 将控件变成方形
        /// </summary>
        /// <param name="control"></param>
        public static void ChangeToRect(Control control)
        {
            //绘制圆形图片框
            GraphicsPath gp = new GraphicsPath();
            gp.AddRectangle(control.ClientRectangle);
            Region region = new Region(gp);
            control.Region = region;
        }
    }
}
