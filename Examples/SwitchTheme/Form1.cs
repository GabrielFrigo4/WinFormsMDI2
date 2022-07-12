using WinFormsMDI2;

namespace SwitchTheme;
public partial class Form1 : Form
{
    MdiThemeMode themeMode = MdiThemeMode.Light;                //it's the color theme of the mdi window

    public Form1()
    {
        InitializeComponent();
    }

    private void bCreateWin_Click(object sender, EventArgs e)
    {
        MdiWin mdiWin = mdiControl.CreateMdiWin();              //create a mdi window
        mdiWin.MdiTheme = themeMode;                            //set mdi window theme
    }

    private void bSwitchTheme_Click(object sender, EventArgs e)
    {
        if (themeMode == MdiThemeMode.Light)                    // switch theme color
            themeMode = MdiThemeMode.Dark;
        else if (themeMode == MdiThemeMode.Dark)
            themeMode = MdiThemeMode.Light;

        foreach (IMdiWin win in mdiControl.MdiWins)             // get all IMdiWin in mdiControl
        {
            if (win is MdiWin mdiWin)                           // if IMdiWin is MdiWin
                mdiWin.MdiTheme = themeMode;                    // set mdiWin theme
        }
    }
}