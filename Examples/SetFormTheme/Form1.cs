using WinFormsMDI2;
using FormUtilits.Themes;

namespace SetFormTheme;
public partial class Form1 : Form
{
    FormTheme formTheme;                                                    //class that changes the theme of the form

    public Form1()
    {
        InitializeComponent();
        formTheme = new(this);                                              // select current form
        formTheme.FormThemeLoop += SetTheme_MyControlsLoop;                 // add SetTheme_MyControlsLoop in FormThemeLoop
    }

    private void bCreateWin_Click(object sender, EventArgs e)
    {
        MdiWin mdiWin = mdiControl.CreateMdiWinWithForm(new Form2());       // create a mdi window
        if (formTheme.IsDark)                                               // switch theme color
            mdiWin.MdiTheme = MdiThemeMode.Dark;
        else
            mdiWin.MdiTheme = MdiThemeMode.Light;
    }

    private void bSwitchTheme_Click(object sender, EventArgs e)
    {
        if (formTheme.CurrentMode == FormThemeMode.Light)                   // switch theme color
        {
            formTheme.SetThemeMode(FormThemeMode.Dark);
        }
        else if (formTheme.CurrentMode == FormThemeMode.Dark)
        {
            formTheme.SetThemeMode(FormThemeMode.Light);
        }
    }

    #region SetTheme
    private void SetTheme_MyControlsLoop(object? sender, FormThemeLoopArgs e)
    {
        if (e.MyControl is MdiWin)
        {
            List<Task> taks = new();
            if (e.MyControl is not MdiWin mdiWin) return;

            if (e.IsDark)
                mdiWin.MdiTheme = MdiThemeMode.Dark;
            else
                mdiWin.MdiTheme = MdiThemeMode.Light;

            foreach (Control con in mdiWin.Controls)
            {
                if (con is Form form)
                {
                    taks.Add(Task.Run(() => formTheme.SetThemeModeFormAsync(form, e.Mode)));
                    break;
                }
            }

            Task.WhenAll(taks);

            e.SetTheme = true;
            e.Stop = true;
        }
        else
        {
            e.MyControl.BackColor = e.Main;
            e.MyControl.ForeColor = e.Other;
            e.SetTheme = true;
            e.Stop = false;
        }
    }
    #endregion
}