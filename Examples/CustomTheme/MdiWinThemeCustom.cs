using System.Security.Permissions;
using WinFormsMDI2;

namespace CustomTheme;
public partial class MdiWinThemeCustom : UserControl, IMdiWin
{
    private bool isMax = false;

    internal bool notMove = true, isMove = false;
    internal int mx, my;

    private MdiControl? mdiControl;
    public MdiControl MdiControl
    {
        get
        {
            if (mdiControl is not null)
                return mdiControl;
            else
                throw new Exception("MdiControl is null");
        }

        set
        {
            mdiControl = value;
        }
    }

    public MdiWinThemeCustom()
    {
        InitializeComponent();
        panelMain.Select();
    }

    private void MdiWin_MouseDown()
    {
        MdiControl.FocusMdiWin(this);
        panelMain.Select();
    }

    private void MdiWin_MouseDown(object sender, MouseEventArgs e)
    {
        MdiWin_MouseDown();
        panelMain.Select();
    }

    private void panelMain_MouseDown(object sender, MouseEventArgs e)
    {
        isMove = true;
        mx = MousePosition.X - Location.X;
        my = MousePosition.Y - Location.Y;
    }

    private void panelMain_MouseUp(object sender, MouseEventArgs e)
    {
        isMove = false;
    }

    private void panelMain_MouseMove(object sender, MouseEventArgs e)
    {
        if (isMove)
        {
            Location = new Point(MousePosition.X - mx, MousePosition.Y - my);
            if (notMove)
            {
                notMove = false;
            }
            DrawBounds();
        }
    }

    private void bClose_Click(object sender, EventArgs e)
    {
        MdiControl.Controls.Remove(this);
        MdiControl.MdiWins.Remove(this);
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

    #region behaviors
#pragma warning disable SYSLIB0003 // O tipo ou membro é obsoleto
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
#pragma warning restore SYSLIB0003 // O tipo ou membro é obsoleto
    protected override void WndProc(ref Message m)
    {
        // 0x210 is WM_PARENTNOTIFY
        // 513 is WM_LBUTTONCLICK
        if (m.Msg == 0x210 && m.WParam.ToInt32() == 513)
        {
            // get the clicked position
            var x = (int)(m.LParam.ToInt32() & 0xFFFF);
            var y = (int)(m.LParam.ToInt32() >> 16);

            // get the clicked control
            var childControl = this.GetChildAtPoint(new Point(x, y));

            // call onClick (which fires Click event)
            MdiWin_MouseDown();

            // do something else...
        }
        base.WndProc(ref m);
    }
    #endregion

    #region IMdiWin
    bool IMdiWin.NotMove()
    {
        return notMove;
    }
    bool IMdiWin.IsMinNotMove() { return false; }
    int IMdiWin.MinInd() { return 0; }
    void IMdiWin.SetIco(Image ico) { }
    void IMdiWin.SetTitle(string title) { }
    void IMdiWin.SetMinimizeBox(bool minimizeBox) { }
    void IMdiWin.SetMaximizeBox(bool maximizeBox) { }
    bool IMdiWin.MdiFocus { get; set; }
    #endregion
}
