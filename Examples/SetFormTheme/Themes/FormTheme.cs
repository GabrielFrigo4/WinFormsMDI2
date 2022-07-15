using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace FormUtilits.Themes;
public class FormTheme
{
    #region System Funcs
    [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
    private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string? pszSubIdList);

    [DllImport("dwmapi.dll")]
    private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

    private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
    private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

    private bool IsWindows10OrGreater(int build = -1)
    {
        return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
    }
    #endregion

    #region My Private Funcs
    private bool SetControlBox(Form form)
    {
        if (IsWindows10OrGreater(17763))
        {
            var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
            if (IsWindows10OrGreater(18985))
            {
                attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
            }

            int useImmersiveDarkMode = IsDark ? 1 : 0;
            return DwmSetWindowAttribute(form.Handle, (int)attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
        }
        return false;
    }

    private void SetFormColor(Form form, Color main, Color other)
    {
        form.BackColor = main;
        form.ForeColor = other;

        if (IsDark)
        {
            SetWindowTheme(form.Handle, "DarkMode_Explorer", null);
        }
        else if (IsLight)
        {
            SetWindowTheme(form.Handle, "Explorer", null);
        }
    }

    private string GetCurrentThemeName()
    {
        string RegistryKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes";
        string? theme;
        theme = (string?)Registry.GetValue(RegistryKey, "CurrentTheme", string.Empty);
        if (theme != null)
        {
            theme = theme.Split('\\').Last().Split('.').First().ToString();
            return theme;
        }
        else
        {
            return string.Empty;
        }
    }

    public void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
    {
        if (IsSystem == true)
        {
            SetThemeMode(FormThemeMode.System);
        }
    }
    #endregion

    #region My Public Funcs
    public Form MainForm { get; private set; }
    public bool IsLight { get; private set; }
    public bool IsDark { get; private set; }
    public bool IsSystem { get; private set; }
    public FormThemeMode CurrentMode { get; private set; }
    public bool IsInit { get; private set; }

    public readonly string[] DarkThemes = { "dark", "themeA", "themeB" };
    public readonly string[] LightThemes = { "aero", "themeC", "themeD" };

    public event EventHandler<FormThemeLoopArgs>? FormThemeLoop;
    public event EventHandler<FormThemeStartArgs>? FormThemeStart;

    public bool IsSystemModeLight()
    {
        bool isModeLight;
        string themeName = GetCurrentThemeName();
        if (LightThemes.Contains(themeName))
        {
            isModeLight = true;
        }
        else if (DarkThemes.Contains(themeName))
        {
            isModeLight = false;
        }
        else
        {
            isModeLight = false;
        }

        return isModeLight;
    }

    public bool IsSystemModeDark()
    {
        bool isModeDark;
        string themeName = GetCurrentThemeName();
        if (DarkThemes.Contains(themeName))
        {
            isModeDark = true;
        }
        else if (LightThemes.Contains(themeName))
        {
            isModeDark = false;
        }
        else
        {
            isModeDark = false;
        }

        return isModeDark;
    }

    public FormTheme(Form mainForm)
    {
        MainForm = mainForm;
        FormThemeLoop += SetTheme_Label;
        FormThemeLoop += SetTheme_MenuStrip;
        FormThemeLoop += SetTheme_IDarkMode;
        SystemEvents.UserPreferenceChanged += (s, e) => { SystemEvents_UserPreferenceChanged(s, e); };
    }

    public void Init()
    {
        if (!IsInit)
        {
            SetThemeMode(FormThemeMode.System);
        }
        IsInit = true;
    }

    public void Reset()
    {
        IsLight = false;
        IsDark = false;
        IsSystem = false;
        IsInit = false;
        CurrentMode = FormThemeMode.System;
    }

    public void SetThemeMode(FormThemeMode mode)
    {
        bool isDark = IsDark, isLight = IsLight;

        CurrentMode = mode;
        if (CurrentMode == FormThemeMode.Light)
        {
            IsLight = true;
            IsDark = false;
            IsSystem = false;
        }
        else if (CurrentMode == FormThemeMode.Dark)
        {
            IsLight = false;
            IsDark = true;
            IsSystem = false;
        }
        else if (CurrentMode == FormThemeMode.System)
        {
            IsLight = IsSystemModeLight();
            IsDark = IsSystemModeDark();
            IsSystem = true;
        }

        if (isDark != IsDark || isLight != IsLight)
        {
            SetThemeModeForm(MainForm, mode, true);
        }
    }

    public void SetThemeModeForm(Form form, FormThemeMode mode, bool setControlBox = true)
    {
        Color main, other;
        if (IsDark)
        {
            main = Color.FromArgb(23, 23, 23);
            other = Color.White;
        }
        else
        {
            main = Color.WhiteSmoke;
            other = Color.Black;
        }

        FormThemeStart?.Invoke(this, new FormThemeStartArgs(form, main, other, mode, IsLight, IsDark, IsSystem));

        void UpdateColorControls(Control myControl)
        {
            if (IsDark)
            {
                SetWindowTheme(myControl.Handle, "DarkMode_Explorer", null);
            }
            else
            {
                SetWindowTheme(myControl.Handle, "Explorer", null);
            }

            FormThemeLoopArgs args = new FormThemeLoopArgs(myControl, main, other, mode, IsLight, IsDark, IsSystem);
            FormThemeLoop?.Invoke(this, args);
            if (args.SetTheme == false)
            {
                myControl.BackColor = main;
                myControl.ForeColor = other;
            }
            if (args.Stop == true)
            {
                return;
            }

            foreach (Control subC in myControl.Controls)
            {
                UpdateColorControls(subC);
            }
        }

        foreach (Control c in form.Controls)
        {
            UpdateColorControls(c);
        }

        SetFormColor(form, main, other);
        if (setControlBox)
        {
            SetControlBox(form);
        }
    }
    #endregion

    #region My Public Async
    public void SetThemeModeAsync(FormThemeMode mode)
    {
        bool isDark = IsDark, isLight = IsLight;

        CurrentMode = mode;
        if (CurrentMode == FormThemeMode.Light)
        {
            IsLight = true;
            IsDark = false;
            IsSystem = false;
        }
        else if (CurrentMode == FormThemeMode.Dark)
        {
            IsLight = false;
            IsDark = true;
            IsSystem = false;
        }
        else if (CurrentMode == FormThemeMode.System)
        {
            IsLight = IsSystemModeLight();
            IsDark = IsSystemModeDark();
            IsSystem = true;
        }

        if (isDark != IsDark || isLight != IsLight)
        {
            SetThemeModeFormAsync(MainForm, mode, true);
        }
    }

    public async void SetThemeModeFormAsync(Form form, FormThemeMode mode, bool setControlBox = true)
    {
        Color main, other;
        if (IsDark)
        {
            main = Color.FromArgb(23, 23, 23);
            other = Color.White;
        }
        else
        {
            main = Color.WhiteSmoke;
            other = Color.Black;
        }

        await Task.Run(() => FormThemeStart?.Invoke(this, new FormThemeStartArgs(form, main, other, mode, IsLight, IsDark, IsSystem)));

        async void UpdateColorControlsAsync(Control myControl)
        {
            if (IsDark)
            {
                SetWindowTheme(myControl.Handle, "DarkMode_Explorer", null);
            }
            else
            {
                SetWindowTheme(myControl.Handle, "Explorer", null);
            }

            FormThemeLoopArgs args = new FormThemeLoopArgs(myControl, main, other, mode, IsLight, IsDark, IsSystem);
            await Task.Run(() => FormThemeLoop?.Invoke(this, args));
            if (args.SetTheme == false)
            {
                myControl.BackColor = main;
                myControl.ForeColor = other;
            }
            if (args.Stop == true)
            {
                return;
            }

            foreach (Control subC in myControl.Controls)
            {
                await Task.Run(() => UpdateColorControlsAsync(subC));
            }
        }

        foreach (Control c in form.Controls)
        {
            await Task.Run(() => UpdateColorControlsAsync(c));
        }

        SetFormColor(form, main, other);
        if (setControlBox)
        {
            SetControlBox(form);
        }
    }
    #endregion

    #region MyControlFuncs
    void SetTheme_Label(object? sender, FormThemeLoopArgs e)
    {
        if (e.MyControl is Label)
        {
            e.MyControl.BackColor = Color.Transparent;
            e.MyControl.ForeColor = e.Other;
            e.SetTheme = true;
        }
    }

    void SetTheme_MenuStrip(object? sender, FormThemeLoopArgs e)
    {
        void SetForeColorItem(ref ToolStripMenuItem item)
        {
            item.ForeColor = e.Other;
            foreach (object subItem in item.DropDownItems)
            {
                if (subItem is ToolStripMenuItem thisSubItem)
                {
                    SetForeColorItem(ref thisSubItem);
                }
            }
        }
    }

    void SetTheme_IDarkMode(object? sender, FormThemeLoopArgs e)
    {
        if (e.MyControl is IFormTheme mode)
        {
            mode.SetMode(sender, e);
            e.SetTheme = true;
        }
    }
    #endregion
}