namespace FormUtilits.Themes;
public class FormThemeStartArgs : EventArgs
{
    public Form Form { get; private set; }
    public Color Main { get; private set; }
    public Color Other { get; private set; }
    public FormThemeMode Mode { get; private set; }
    public bool IsLight { get; private set; }
    public bool IsDark { get; private set; }
    public bool IsSystem { get; private set; }

    public FormThemeStartArgs(Form form, Color main, Color other, FormThemeMode mode, bool isLight, bool isDark, bool isSystem)
    {
        Form = form;
        Main = main;
        Other = other;
        Mode = mode;
        IsLight = isLight;
        IsDark = isDark;
        IsSystem = isSystem;
    }
}