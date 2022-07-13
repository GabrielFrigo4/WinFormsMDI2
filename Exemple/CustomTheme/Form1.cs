namespace CustomTheme;
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void bCreateWin_Click(object sender, EventArgs e)
    {
        mdiControl.CreateMdiWin<MdiWinThemeCustom>();
    }
}