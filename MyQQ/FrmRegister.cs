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
    }
}
