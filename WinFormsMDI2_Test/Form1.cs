using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsMDI2_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            mdiControl.CreateMdiWin();
            mdiControl.CreateMdiWin();
            mdiControl.CreateMdiWinWithForm(new FormForMDI());
            mdiControl.CreateMdiWinWithForm<MdiStyle>(new FormForMDI());
        }

        private void createMDI_Click(object sender, EventArgs e)
        {
            mdiControl.CreateMdiWin<MdiCustom>();
        }
    }
}
