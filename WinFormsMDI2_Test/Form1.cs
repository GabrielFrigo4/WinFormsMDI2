using System;
using System.Windows.Forms;
using WinFormsMDI2;

namespace WinFormsMDI2_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            mdiControl.CreateMdiWin();
            mdiControl.CreateMdiWin().MdiTheme = Theme.Dark;
            mdiControl.CreateMdiWin(typeof(MdiCustom));
            mdiControl.CreateMdiWin<MdiCustom>();
            mdiControl.CreateMdiWin(typeof(MdiThemeSwitch));
            mdiControl.CreateMdiWin<MdiThemeSwitch>();

            mdiControl.CreateMdiWinWithForm(new FormForMDI());
            mdiControl.CreateMdiWinWithForm(new FormForMDI()).MdiTheme = Theme.Dark;
            mdiControl.CreateMdiWinWithForm(typeof(MdiWinThemeCustom), new FormForMDI());
            mdiControl.CreateMdiWinWithForm<MdiWinThemeCustom>(new FormForMDI());
        }

        private void createMDI_Click(object sender, EventArgs e)
        {
            mdiControl.CreateMdiWinWithForm(new FormForMDI());
        }
    }
}
