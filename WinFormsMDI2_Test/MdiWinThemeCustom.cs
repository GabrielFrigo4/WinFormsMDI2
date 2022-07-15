using System.Drawing;
using System.Windows.Forms;
using WinFormsMDI2;

namespace WinFormsMDI2_Test;
public partial class MdiWinThemeCustom : AbstractMdiWin
{
    internal int mx, my;

    public MdiWinThemeCustom()
    {
        InitializeComponent();
    }

    private void panelMain_MouseDown(object sender, MouseEventArgs e)
    {
        IsMove = true;
        mx = MousePosition.X - Location.X;
        my = MousePosition.Y - Location.Y;
    }

    private void panelMain_MouseUp(object sender, MouseEventArgs e)
    {
        IsMove = false;
    }

    private void panelMain_MouseMove(object sender, MouseEventArgs e)
    {
        if (IsMove)
        {
            Location = new Point(MousePosition.X - mx, MousePosition.Y - my);
            if (NotMove)
            {
                NotMove = false;
            }
        }
    }

    #region AbstractMdiWin
    public override void SetIco(Image ico) { }
    public override void SetTitle(string title) { }
    public override void SetMinimizeBox(bool minimizeBox) { }
    public override void SetMaximizeBox(bool maximizeBox) { }
    public override bool MdiFocus { get; set; }
    #endregion
}
