namespace FormUtilits.Themes;
public class FormThemeLoopArgs : EventArgs
{
    public Control MyControl { get; private set; }
    public Color Main { get; private set; }
    public Color Other { get; private set; }
    public FormThemeMode Mode { get; private set; }
    public bool IsLight { get; private set; }
    public bool IsDark { get; private set; }
    public bool IsSystem { get; private set; }
    public bool SetTheme { get; set; }
    public bool Stop { get; set; }

    public FormThemeLoopArgs(Control myControl, Color main, Color other, FormThemeMode mode, bool isLight, bool isDark, bool isSystem)
    {
        MyControl = myControl;
        Main = main;
        Other = other;
        Mode = mode;
        IsLight = isLight;
        IsDark = isDark;
        IsSystem = isSystem;
        SetTheme = false;
        Stop = false;
    }
}