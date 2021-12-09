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
    public partial class MdiThemeSwitch : WinFormsMDI2.MdiWin
    {
        public MdiThemeSwitch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MdiTheme == WinFormsMDI2.Theme.Dark)
            {
                MdiTheme = WinFormsMDI2.Theme.Light;
            }
            else if (MdiTheme == WinFormsMDI2.Theme.Light)
            {
                MdiTheme = WinFormsMDI2.Theme.Dark;
            }
        }
    }
}
