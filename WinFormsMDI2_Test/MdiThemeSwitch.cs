using System;

namespace WinFormsMDI2_Test;
public partial class MdiThemeSwitch : WinFormsMDI2.MdiWin
{
    public MdiThemeSwitch()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (MdiTheme == WinFormsMDI2.MdiThemeMode.Dark)
        {
            MdiTheme = WinFormsMDI2.MdiThemeMode.Light;
        }
        else if (MdiTheme == WinFormsMDI2.MdiThemeMode.Light)
        {
            MdiTheme = WinFormsMDI2.MdiThemeMode.Dark;
        }
    }
}
