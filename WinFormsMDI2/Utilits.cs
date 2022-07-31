using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsMDI2;
static public class Utilits
{
    static public Tuple<bool, bool> SetTheme_WinFormsMDI2(Control myControl, Color main, Color other, bool isLight, bool isDark,
        Action<Form, bool, bool, bool> setThemeModeForm, Action<Form, bool, bool, bool> setThemeModeFormAsync)
    {
        if (myControl is MdiWin mdiWin)
        {
            List<Task> taks = new();

            if (isDark)
                mdiWin.MdiTheme = MdiThemeMode.Dark;
            else
                mdiWin.MdiTheme = MdiThemeMode.Light;

            foreach (Control con in mdiWin.Controls)
            {
                if (con is Form form)
                {
                    taks.Add(Task.Run(() => setThemeModeFormAsync(form, isLight, isDark, true)));
                    break;
                }
            }

            Task.WhenAll(taks);

            return new(true, true);
        }
        return new(false, false);
    }
}