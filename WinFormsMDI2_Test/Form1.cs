using System;
using System.Windows.Forms;
using WinFormsMDI2;

namespace WinFormsMDI2_Test;
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        mdiControl.CreateMdiWin();
        mdiControl.CreateMdiWin().MdiTheme = MdiThemeMode.Dark;
        mdiControl.CreateMdiWin(typeof(MdiCustom));
        mdiControl.CreateMdiWin<MdiCustom>();
        mdiControl.CreateMdiWin(typeof(MdiThemeSwitch));
        mdiControl.CreateMdiWin<MdiThemeSwitch>();

        mdiControl.CreateMdiWinWithForm(new FormForMDI());
        mdiControl.CreateMdiWinWithForm(new FormForMDI()).MdiTheme = MdiThemeMode.Dark;
        mdiControl.CreateMdiWinWithForm(typeof(MdiWinThemeCustom), new FormForMDI());
        mdiControl.CreateMdiWinWithForm<MdiWinThemeCustom>(new FormForMDI());

        for (int i = 0; i < 8; i++)
        {
            MdiWin mdi = mdiControl.CreateMdiWin();
            mdi.MdiTheme = MdiThemeMode.Light;
        }
    }

    private void createMDI_Click(object sender, EventArgs e)
    {
        mdiControl.CreateMdiWinWithForm(new FormForMDI());
    }
}
