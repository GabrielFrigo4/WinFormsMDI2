using System.Security.Permissions;
using WinFormsMDI2;

namespace CustomTheme;
public partial class MdiWinThemeCustom : AbstractMdiWin
{
    private bool isMax = false;

    internal int mx, my;

    public MdiWinThemeCustom()
    {
        InitializeComponent();
        panelMain.Select();
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
            DrawBounds();
        }
    }

    private void bClose_Click(object sender, EventArgs e)
    {
        MdiControl.Controls.Remove(this);
        MdiControl.MdiWins.Remove(this);
        panelMain.Select();
        Dispose();
    }

    private void bNormalMax_Click(object sender, EventArgs e)
    {
        isMax = !isMax;
        if (isMax)
        {
            bNormalMax.BackColor = Color.Green;
            Dock = DockStyle.Fill;
        }
        else
        {
            bNormalMax.BackColor = Color.Orange;
            Dock = DockStyle.None;
        }
        panelMain.Select();
        DrawBounds();
    }

    private void MdiWinThemeCustom_Paint(object sender, PaintEventArgs e)
    {
        int left = 0, right = Right - Left, top = Bottom - Top, botton = Height;
        Graphics g = e.Graphics;
        g.Clear(BackColor);
        g.DrawLine(Pens.Black, left, top, left, 0);
        g.DrawLine(Pens.Black, left, botton - 1, right, botton - 1);
        g.DrawLine(Pens.Black, right - 1, top, right - 1, 0);
    }

    private void MdiWinThemeCustom_Resize(object sender, EventArgs e)
    {
        DrawBounds();
    }

    private void DrawBounds()
    {
        InvokePaint(this, new PaintEventArgs(CreateGraphics(), DisplayRectangle));
    }

    #region AbstractMdiWin
    public override void SetIco(Image ico) { }
    public override void SetTitle(string title) { }
    public override void SetMinimizeBox(bool minimizeBox) { }
    public override void SetMaximizeBox(bool maximizeBox) { }
    public override bool MdiFocus { get; set; }
    #endregion
}
