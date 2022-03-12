using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;

namespace WinFormsMDI2;
public partial class MdiWin : UserControl, IMdiWin
{
    public MdiControl mdiControl;
    private bool isMinNotMove = false, notMove = true, mdiFocus = true;
    private int minInd;

    private bool resizable = true, maximizeBox = true, minimizeBox = true;
    private Image max = Properties.Resources.Maximize, min = Properties.Resources.Minimize, normal = Properties.Resources.Normalize, close = Properties.Resources.Close;
    private Color minEnterColor = Color.LightGray, minDownColor = Color.Gray, minLeaveColor = SystemColors.ControlLightLight;
    private Color maxEnterColor = Color.LightGray, maxDownColor = Color.Gray, maxLeaveColor = SystemColors.ControlLightLight;
    private Color closeEnterColor = Color.FromArgb(255, 90, 90), closeDownColor = Color.FromArgb(255, 20, 20), closeLeaveColor = SystemColors.ControlLightLight;
    private Color borderColor;
    private MdiThemeMode theme = MdiThemeMode.Light;

    bool isMove = false, isMin = false, isResize = false;
    int mx, my, rx, ry;
    Point lastLocation, minPos, maxPos;
    Size lastSize, lastMinSize, lastMaxSize;
    string lastTitle;

    public MdiWin()
    {
        BackColor = Color.FromArgb(240, 240, 240);
        InitializeComponent();
        //labelTitle
        labelTitle.MouseDown += panelMain_MouseDown;
        labelTitle.MouseUp += panelMain_MouseUp;
        labelTitle.MouseMove += panelMain_MouseMove;
        labelTitle.DoubleClick += panelMain_DoubleClick;
        //pictureBoxIco
        pictureBoxIco.MouseDown += panelMain_MouseDown;
        pictureBoxIco.MouseUp += panelMain_MouseUp;
        pictureBoxIco.MouseMove += panelMain_MouseMove;
        pictureBoxIco.DoubleClick += panelMain_DoubleClick;
    }

    private void MdiWin_MouseDown()
    {
        mdiControl.FocusMdiWin(this);
    }

    private void MdiWin_MouseDown(object sender, MouseEventArgs e)
    {
        MdiWin_MouseDown();
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

    [DefaultValue("MdiWin")]
    [Description("Is MdiWin Title")]
    public string Title { get { return labelTitle.Text; } set { labelTitle.Text = value; } }

    [DefaultValue(true)]
    [Description("Is Resizable MdiWin")]
    public bool Resizable { 
        get { return resizable; } 
        set { 
            if(value != resizable)
            {
                if (value)
                {
                    panelTop.Size = new Size(panelTop.Size.Width, 6);
                    panelFloor.Size = new Size(panelFloor.Size.Width, 6);
                    panelLeft.Size = new Size(6, panelLeft.Size.Height);
                    panelRight.Size = new Size(6, panelRight.Size.Height);
                }
                else
                {
                    panelTop.Size = new Size(panelTop.Size.Width, 3);
                    panelFloor.Size = new Size(panelFloor.Size.Width, 3);
                    panelLeft.Size = new Size(3, panelLeft.Size.Height);
                    panelRight.Size = new Size(3, panelRight.Size.Height);
                }
                resizable = value;
            }
        } 
    }

    [DefaultValue(true)]
    [Description("Is Maximize Box MdiWin")]
    public bool MaximizeBox { 
        get { return maximizeBox; } 
        set { 
            maximizeBox = value; 
            if(!maximizeBox && !minimizeBox)
            {
                bMax.Visible = false;
                bMin.Visible = false;
            }
            else if(!bMax.Visible || bMin.Visible)
            {
                bMax.Visible = true;
                bMin.Visible = true;
            }
        } 
    }

    [DefaultValue(true)]
    [Description("Is Minimize Box MdiWin")]
    public bool MinimizeBox { 
        get { return minimizeBox; }
        set { 
            minimizeBox = value;
            if (!maximizeBox && !minimizeBox)
            {
                bMax.Visible = false;
                bMin.Visible = false;
            }
            else if (!bMax.Visible || bMin.Visible)
            {
                bMax.Visible = true;
                bMin.Visible = true;
            }
        } 
    }

    [Description("Is MdiWin Ico")]
    public Image Ico { get { return pictureBoxIco.Image; } set { pictureBoxIco.Image = value; } }

    [Description("Is Close Image")]
    public Image CloseImage { get { return close; } set { close = bClose.Image = value; } }

    [Description("Is Normalize Image")]
    public Image NormalizeImage { get { return normal; } set { normal = value; } }

    [Description("Is Minimize Image")]
    public Image MinimizeImage { get { return min; } set { min = bMin.Image = value; } }

    [Description("Is Maximize Image")]
    public Image MaximizeImage { get { return max; } set { max = bMax.Image = value; } }

    [Description("Is Minimize Enter Color")]
    public Color MinimizeEnterColor { get { return minEnterColor; } set { minEnterColor = value; } }

    [Description("Is Minimize Down Color")]
    public Color MinimizeDownColor { get { return minDownColor; } set { minDownColor = value; } }

    [DefaultValue(typeof(Color), "White")]
    [Description("Is Minimize Leave Color")]
    public Color MinimizeLeaveColor { get { return minLeaveColor; } set { minLeaveColor = value; } }

    [Description("Is Maximize Enter Color")]
    public Color MaximizeEnterColor { get { return maxEnterColor; } set { maxEnterColor = value; } }

    [Description("Is Maximize Down Color")]
    public Color MaximizeDownColor { get { return maxDownColor; } set { maxDownColor = value; } }

    [DefaultValue(typeof(Color), "White")]
    [Description("Is Maximize Leave Color")]
    public Color MaximizeLeaveColor { get { return maxLeaveColor; } set { maxLeaveColor = value; } }

    [Description("Is Close Enter Color")]
    public Color CloseEnterColor { get { return closeEnterColor; } set { closeEnterColor = value; } }

    [Description("Is Close Down Color")]
    public Color CloseDownColor { get { return closeDownColor; } set { closeDownColor = value; } }

    [DefaultValue(typeof(Color), "White")]
    [Description("Is Close Leave Color")]
    public Color CloseLeaveColor { get { return closeLeaveColor; } set { closeLeaveColor = value; } }

    [DefaultValue(typeof(Color), "LightGray")]
    [Description("Is MdiWin Title")]
    public Color BorderColor { get { return borderColor; } set { borderColor = panelTop.BackColor = panelFloor.BackColor = panelLeft.BackColor = panelRight.BackColor = panelLeftTop.BackColor = panelRightTop.BackColor = panelLeftFloor.BackColor = panelRightFloor.BackColor = value; } }

    [DefaultValue(typeof(Color), "White")]
    [Description("Is MdiWin Title")]
    public Color ControlBarColor { get { return panelMain.BackColor; } set { panelMain.BackColor = value; } }

    [DefaultValue(typeof(Color), "Black")]
    [Description("Is MdiWin Title")]
    public Color TitleColor { get { return labelTitle.ForeColor; } set { labelTitle.ForeColor = value; } }

    [DefaultValue(typeof(MdiThemeMode), "Light")]
    [Description("Is MdiWin Theme")]
    public MdiThemeMode MdiTheme
    {
        get
        {
            return theme;
        }
        set
        {
            theme = value;
            switch (theme)
            {
                case MdiThemeMode.Light:
                    BackColor = SystemColors.Control;
                    TitleColor = SystemColors.ControlText;
                    ControlBarColor = SystemColors.ControlLightLight;
                    MinimizeEnterColor = Color.LightGray;
                    MinimizeDownColor = Color.Gray;
                    MinimizeLeaveColor = SystemColors.ControlLightLight;
                    MaximizeEnterColor = Color.LightGray;
                    MaximizeDownColor = Color.Gray;
                    MaximizeLeaveColor = SystemColors.ControlLightLight;
                    CloseEnterColor = Color.FromArgb(255, 90, 90);
                    CloseDownColor = Color.FromArgb(255, 20, 20);
                    CloseLeaveColor = SystemColors.ControlLightLight;
                    BorderColor = Color.DarkGray;
                    CloseImage = Properties.Resources.Close;
                    NormalizeImage = Properties.Resources.Normalize;
                    MinimizeImage = Properties.Resources.Minimize;
                    MaximizeImage = Properties.Resources.Maximize;
                    bMin.BackColor = MinimizeLeaveColor;
                    bMax.BackColor = MaximizeLeaveColor;
                    bClose.BackColor = closeLeaveColor;
                    break;
                case MdiThemeMode.Dark:
                    BackColor = Color.FromArgb(60, 60, 60);
                    TitleColor = Color.White;
                    ControlBarColor = Color.FromArgb(35, 35, 35);
                    MinimizeEnterColor = Color.FromArgb(80, 80, 80);
                    MinimizeDownColor = Color.FromArgb(120, 120, 120);
                    MinimizeLeaveColor = Color.FromArgb(35, 35, 35);
                    MaximizeEnterColor = Color.FromArgb(80, 80, 80);
                    MaximizeDownColor = Color.FromArgb(120, 120, 120);
                    MaximizeLeaveColor = Color.FromArgb(35, 35, 35);
                    CloseEnterColor = Color.FromArgb(180, 0, 0);
                    CloseDownColor = Color.FromArgb(255, 40, 40);
                    CloseLeaveColor = Color.FromArgb(35, 35, 35);
                    BorderColor = Color.FromArgb(14, 14, 14);
                    CloseImage = Properties.Resources.CloseWhite;
                    NormalizeImage = Properties.Resources.NormalizeWhite;
                    MinimizeImage = Properties.Resources.MinimizeWhite;
                    MaximizeImage = Properties.Resources.MaximizeWhite;
                    bMin.BackColor = MinimizeLeaveColor;
                    bMax.BackColor = MaximizeLeaveColor;
                    bClose.BackColor = CloseLeaveColor;
                    break;
            }
        }
    }
    #endregion

    #region panelMain
    private void panelMain_MouseDown(object sender, MouseEventArgs e)
    {
        if (Dock != DockStyle.Fill)
        {
            isMove = true;
            isMinNotMove = false;
            mx = MousePosition.X - Location.X;
            my = MousePosition.Y - Location.Y;
        }
    }

    private void panelMain_MouseUp(object sender, MouseEventArgs e)
    {
        isMove = false;
    }

    private void panelMain_MouseMove(object sender, MouseEventArgs e)
    {
        if (isMove)
        {
            Point newMousePosition = new Point(MousePosition.X - mx, MousePosition.Y - my), newPosition = newMousePosition;

            if (Width < mdiControl.Width)
            {
                if (newMousePosition.X < 0)
                {
                    newPosition.X = 0;
                }
                else if (newMousePosition.X + Width > mdiControl.Width)
                {
                    newPosition.X = mdiControl.Width - Width;
                }
            }

            if (Height < mdiControl.Height)
            {
                if (newMousePosition.Y < 0)
                {
                    newPosition.Y = 0;
                }
                else if (newMousePosition.Y + Height > mdiControl.Height)
                {
                    newPosition.Y = mdiControl.Height - Height;
                }
            }

            Location = newPosition;

            if (notMove)
            {
                notMove = false;
            }
        }
    }

    private void panelMain_DoubleClick(object sender, EventArgs e)
    {
        if (maximizeBox)
        {
            if (Dock == DockStyle.Fill)
            {
                Dock = DockStyle.None;
                bMax.Image = max;

                MaximumSize = lastMaxSize;
                panelTop.Visible = true;
                panelFloor.Visible = true;
                panelLeft.Visible = true;
                panelLeftFloor.Visible = true;
                panelRight.Visible = true;
                panelRightFloor.Visible = true;
            }
            else
            {
                if (isMin)
                {
                    Title = lastTitle;
                    MinimumSize = lastMinSize;
                    Bounds = new Rectangle(lastLocation, lastSize);
                    bMin.Image = min;
                    isMin = false;
                    isMinNotMove = false;
                }
                else
                {
                    panelTop.Visible = false;
                    panelFloor.Visible = false;
                    panelLeft.Visible = false;
                    panelLeftFloor.Visible = false;
                    panelRight.Visible = false;
                    panelRightFloor.Visible = false;
                }

                lastMaxSize = MaximumSize;
                if (MaximumSize.Width > MinimumSize.Width && MaximumSize.Height > MinimumSize.Height)
                    MaximumSize = new Size(MaximumSize.Width - 12, MaximumSize.Height - 44);
                Dock = DockStyle.Fill;
                bMax.Image = normal;
            }
        }
    }
    #endregion

    #region panelTop
    private void panelTop_MouseDown(object sender, MouseEventArgs e)
    {
        if (Dock != DockStyle.Fill)
        {
            if(resizable)
                isResize = true;
            else
                isResize = false;

            ry = -MousePosition.Y - Size.Height;
            my = MousePosition.Y - Location.Y;

            minPos = new Point(Location.X + Size.Width - MinimumSize.Width, Location.Y + Size.Height - MinimumSize.Height);
            maxPos = new Point(Location.X + Size.Width - MaximumSize.Width, Location.Y + Size.Height - MaximumSize.Height);
        }
    }

    private void panelTop_MouseUp(object sender, MouseEventArgs e)
    {
        isResize = false;
    }

    private void panelTop_MouseMove(object sender, MouseEventArgs e)
    {
        if (isResize)
        {
            bool minSize = minPos.Y >= MousePosition.Y - my, maxSize = maxPos.Y <= MousePosition.Y - my || !(MaximumSize.Width > MinimumSize.Width && MaximumSize.Height > MinimumSize.Height);
            if (minSize && maxSize)
            {
                Bounds = new Rectangle(Location.X, MousePosition.Y - my, Size.Width, -MousePosition.Y - ry);
            }
            else if(!minSize)
            {
                Bounds = new Rectangle(Location.X, minPos.Y, Size.Width, -MousePosition.Y - ry);
            }
            else if(!maxSize)
            {
                Bounds = new Rectangle(Location.X, maxPos.Y, Size.Width, -MousePosition.Y - ry);
            }
        }

        if (resizable)
            Cursor.Current = Cursors.SizeNS;
    }

    private void panelTop_MouseEnter(object sender, EventArgs e)
    {
        if (resizable)
            Cursor.Current = Cursors.SizeNS;
    }
    #endregion

    #region panelFloor
    private void panelFloor_MouseDown(object sender, MouseEventArgs e)
    {
        if (Dock != DockStyle.Fill)
        {
            if (resizable)
                isResize = true;
            else
                isResize = false;

            ry = MousePosition.Y - Size.Height;
        }
    }

    private void panelFloor_MouseUp(object sender, MouseEventArgs e)
    {
        isResize = false;
    }

    private void panelFloor_MouseMove(object sender, MouseEventArgs e)
    {
        if (isResize)
        {
            Size = new Size(Size.Width, MousePosition.Y - ry);
        }

        if (resizable)
            Cursor.Current = Cursors.SizeNS;
    }

    private void panelFloor_MouseEnter(object sender, EventArgs e)
    {
        if (resizable)
            Cursor.Current = Cursors.SizeNS;
    }
    #endregion

    #region panelLeft
    private void panelLeft_MouseDown(object sender, MouseEventArgs e)
    {
        if (Dock != DockStyle.Fill)
        {
            if (resizable)
                isResize = true;
            else
                isResize = false;

            rx = -MousePosition.X - Size.Width;
            mx = MousePosition.X - Location.X;

            minPos = new Point(Location.X + Size.Width - MinimumSize.Width, Location.Y + Size.Height - MinimumSize.Height);
            maxPos = new Point(Location.X + Size.Width - MaximumSize.Width, Location.Y + Size.Height - MaximumSize.Height);
        }
    }

    private void panelLeft_MouseUp(object sender, MouseEventArgs e)
    {
        isResize = false;
    }

    private void panelLeft_MouseMove(object sender, MouseEventArgs e)
    {
        if (isResize)
        {
            bool minSize = minPos.X >= MousePosition.X - mx, maxSize = maxPos.X <= MousePosition.X - mx || !(MaximumSize.Width > MinimumSize.Width && MaximumSize.Height > MinimumSize.Height); ;
            if (minSize && maxSize)
            {
                Bounds = new Rectangle(MousePosition.X - mx, Location.Y, -MousePosition.X - rx, Size.Height);
            }
            else if(!minSize)
            {
                Bounds = new Rectangle(minPos.X, Location.Y, -MousePosition.X - rx, Size.Height);
            }
            else if (!maxSize)
            {
                Bounds = new Rectangle(maxPos.X, Location.Y, -MousePosition.X - rx, Size.Height);
            }
        }

        if (resizable)
            Cursor.Current = Cursors.SizeWE;
    }

    private void panelLeft_MouseEnter(object sender, EventArgs e)
    {
        if (resizable)
            Cursor.Current = Cursors.SizeWE;
    }
    #endregion

    #region panelRight
    private void panelRight_MouseDown(object sender, MouseEventArgs e)
    {
        if (Dock != DockStyle.Fill)
        {
            if (resizable)
                isResize = true;
            else
                isResize = false;

            rx = MousePosition.X - Size.Width;
        }
    }

    private void panelRight_MouseUp(object sender, MouseEventArgs e)
    {
        isResize = false;
    }

    private void panelRight_MouseMove(object sender, MouseEventArgs e)
    {
        if (isResize)
        {
            Size = new Size(MousePosition.X - rx, Size.Height);
        }

        if (resizable)
            Cursor.Current = Cursors.SizeWE;
    }

    private void panelRight_MouseEnter(object sender, EventArgs e)
    {
        if (resizable)
            Cursor.Current = Cursors.SizeWE;
    }
    #endregion

    #region panelLeftTop
    private void panelLeftTop_MouseDown(object sender, MouseEventArgs e)
    {
        if (Dock != DockStyle.Fill)
        {
            if (resizable)
                isResize = true;
            else
                isResize = false;

            ry = -MousePosition.Y - Size.Height;
            my = MousePosition.Y - Location.Y;
            rx = -MousePosition.X - Size.Width;
            mx = MousePosition.X - Location.X;

            minPos = new Point(Location.X + Size.Width - MinimumSize.Width, Location.Y + Size.Height - MinimumSize.Height);
            maxPos = new Point(Location.X + Size.Width - MaximumSize.Width, Location.Y + Size.Height - MaximumSize.Height);
        }
    }

    private void panelLeftTop_MouseUp(object sender, MouseEventArgs e)
    {
        isResize = false;
    }

    private void panelLeftTop_MouseMove(object sender, MouseEventArgs e)
    {
        if (isResize)
        {
            bool minSizeX = minPos.X >= MousePosition.X - mx, maxSizeX = maxPos.X <= MousePosition.X - mx || !(MaximumSize.Width > MinimumSize.Width && MaximumSize.Height > MinimumSize.Height); ;
            bool minSizeY = minPos.Y >= MousePosition.Y - my, maxSizeY = maxPos.Y <= MousePosition.Y - my || !(MaximumSize.Width > MinimumSize.Width && MaximumSize.Height > MinimumSize.Height); ;
            if (minSizeY && minSizeX && maxSizeY && maxSizeX)
            {
                Bounds = new Rectangle(MousePosition.X - mx, MousePosition.Y - my, -MousePosition.X - rx, -MousePosition.Y - ry);
            }
            else if (minSizeY && maxSizeY && maxSizeX)
            {
                Bounds = new Rectangle(minPos.X, MousePosition.Y - my, -MousePosition.X - rx, -MousePosition.Y - ry);
            }
            else if (minSizeX && maxSizeY && maxSizeX)
            {
                Bounds = new Rectangle(MousePosition.X - mx, minPos.Y, -MousePosition.X - rx, -MousePosition.Y - ry);
            }
            else if (maxSizeY && maxSizeX)
            {
                Bounds = new Rectangle(minPos.X, minPos.Y, -MousePosition.X - rx, -MousePosition.Y - ry);
            }
            else if (minSizeY && minSizeX && maxSizeY)
            {
                Bounds = new Rectangle(maxPos.X, MousePosition.Y - my, -MousePosition.X - rx, -MousePosition.Y - ry);
            }
            else if (minSizeY && minSizeX && maxSizeX)
            {
                Bounds = new Rectangle(MousePosition.X - mx, maxPos.Y, -MousePosition.X - rx, -MousePosition.Y - ry);
            }
            else if (minSizeY && minSizeX)
            {
                Bounds = new Rectangle(maxPos.X, maxPos.Y, -MousePosition.X - rx, -MousePosition.Y - ry);
            }
        }

        if (resizable)
            Cursor.Current = Cursors.SizeNWSE;
    }

    private void panelLeftTop_MouseEnter(object sender, EventArgs e)
    {
        if (resizable)
            Cursor.Current = Cursors.SizeNWSE;
    }
    #endregion

    #region panelRightTop
    private void panelRightTop_MouseDown(object sender, MouseEventArgs e)
    {
        if (Dock != DockStyle.Fill)
        {
            if (resizable)
                isResize = true;
            else
                isResize = false;

            ry = -MousePosition.Y - Size.Height;
            rx = MousePosition.X - Size.Width;
            my = MousePosition.Y - Location.Y;

            minPos = new Point(Location.X + Size.Width - MinimumSize.Width, Location.Y + Size.Height - MinimumSize.Height);
        }
    }

    private void panelRightTop_MouseUp(object sender, MouseEventArgs e)
    {
        isResize = false;
    }

    private void panelRightTop_MouseMove(object sender, MouseEventArgs e)
    {
        if (isResize)
        {
            if (minPos.Y >= MousePosition.Y - my)
            {
                Bounds = new Rectangle(Location.X, MousePosition.Y - my, MousePosition.X - rx, -MousePosition.Y - ry);
            }
            else
            {
                Bounds = new Rectangle(Location.X, minPos.Y, MousePosition.X - rx, -MousePosition.Y - ry);
            }
        }

        if (resizable)
            Cursor.Current = Cursors.SizeNESW;
    }

    private void panelRightTop_MouseEnter(object sender, EventArgs e)
    {
        if (resizable)
            Cursor.Current = Cursors.SizeNESW;
    }
    #endregion

    #region panelRightFloor
    private void panelRightFloor_MouseDown(object sender, MouseEventArgs e)
    {
        if (Dock != DockStyle.Fill)
        {
            if (resizable)
                isResize = true;
            else
                isResize = false;

            rx = MousePosition.X - Size.Width;
            ry = MousePosition.Y - Size.Height;
        }
    }

    private void panelRightFloor_MouseUp(object sender, MouseEventArgs e)
    {
        isResize = false;
    }

    private void panelRightFloor_MouseMove(object sender, MouseEventArgs e)
    {
        if (isResize)
        {
            Size = new Size(MousePosition.X - rx, MousePosition.Y - ry);
        }

        if (resizable)
            Cursor.Current = Cursors.SizeNWSE;
    }

    private void panelRightFloor_MouseEnter(object sender, EventArgs e)
    {
        if (resizable)
            Cursor.Current = Cursors.SizeNWSE;
    }
    #endregion

    #region panelLeftFloor
    private void panelLeftFloor_MouseDown(object sender, MouseEventArgs e)
    {
        if (Dock != DockStyle.Fill)
        {
            if (resizable)
                isResize = true;
            else
                isResize = false;

            rx = -MousePosition.X - Size.Width;
            ry = MousePosition.Y - Size.Height;
            mx = MousePosition.X - Location.X;

            minPos = new Point(Location.X + Size.Width - MinimumSize.Width, Location.Y + Size.Height - MinimumSize.Height);
        }
    }

    private void panelLeftFloor_MouseUp(object sender, MouseEventArgs e)
    {
        isResize = false;
    }

    private void panelLeftFloor_MouseMove(object sender, MouseEventArgs e)
    {
        if (isResize)
        {
            if (minPos.X >= MousePosition.X - mx)
            {
                Bounds = new Rectangle(MousePosition.X - mx, Location.Y, -MousePosition.X - rx, MousePosition.Y - ry);
            }
            else
            {
                Bounds = new Rectangle(minPos.X, Location.Y, -MousePosition.X - rx, MousePosition.Y - ry);
            }
        }

        if (resizable)
            Cursor.Current = Cursors.SizeNESW;
    }

    private void panelLeftFloor_MouseEnter(object sender, EventArgs e)
    {
        if (resizable)
            Cursor.Current = Cursors.SizeNESW;
    }
    #endregion

    #region panelAll
    private void panelAll_MouseLeave(object sender, EventArgs e)
    {
        Cursor.Current = Cursors.Default;
    }
    #endregion

    #region buttons
    private void bMin_Click(object sender, EventArgs e)
    {
        if (minimizeBox)
        {
            if (!isMin)
            {
                int x = 0;
                minInd = 1;

                IMdiWin[] wins = new IMdiWin[] { };
                wins = mdiControl.mdiWins.ToArray();

                Array.Sort(wins, delegate (IMdiWin mw1, IMdiWin mw2) {
                    if (((Control)mw1).Location.Y == ((Control)mw2).Location.Y)
                        return ((Control)mw1).Location.X.CompareTo(((Control)mw2).Location.X);
                    else
                        return -((Control)mw1).Location.Y.CompareTo(((Control)mw2).Location.Y);
                });

                foreach (Control cont in wins)
                {
                    if (cont.Location.X + 226 > mdiControl.Width)
                        continue;

                    if (x + 226 <= mdiControl.Width)
                    {
                        if (cont.Location.X == x && cont.Location.Y == mdiControl.Height - 32 * minInd)
                        {
                            x += 226;
                        }
                        if (cont.Location.X > x)
                        {
                            break;
                        }
                    }
                    else
                    {
                        x = 0;
                        minInd++;
                        if (cont.Location.X == x && cont.Location.Y == mdiControl.Height - 32 * minInd)
                        {
                            x += 226;
                        }
                        if (cont.Location.X > x)
                        {
                            break;
                        }
                    }
                }

                if (Dock == DockStyle.Fill)
                {
                    Dock = DockStyle.None;
                    bMax.Image = max;
                }

                lastTitle = Title;
                lastSize = Size;
                lastMinSize = MinimumSize;
                lastLocation = Location;
                MaximumSize = lastMaxSize;

                panelTop.Visible = false;
                panelFloor.Visible = false;
                panelLeft.Visible = false;
                panelLeftFloor.Visible = false;
                panelRight.Visible = false;
                panelRightFloor.Visible = false;

                Title = Title.Substring(0, 3) + "...";
                MinimumSize = new Size(0, 0);
                Bounds = new Rectangle(x, mdiControl.Height - 32 * minInd, 226, 32);
                bMin.Image = normal;
                isMin = true;
                isMinNotMove = true;

                if (notMove)
                {
                    notMove = false;
                }
            }
            else
            {
                panelTop.Visible = true;
                panelFloor.Visible = true;
                panelLeft.Visible = true;
                panelLeftFloor.Visible = true;
                panelRight.Visible = true;
                panelRightFloor.Visible = true;

                Title = lastTitle;
                MinimumSize = lastMinSize;
                Bounds = new Rectangle(lastLocation, lastSize);
                bMin.Image = min;
                isMin = false;
                isMinNotMove = false;
            }
        }
    }

    private void bMax_Click(object sender, EventArgs e)
    {
        if (maximizeBox)
        {
            if (Dock == DockStyle.Fill)
            {
                Dock = DockStyle.None;
                bMax.Image = max;

                MaximumSize = lastMaxSize;
                panelTop.Visible = true;
                panelFloor.Visible = true;
                panelLeft.Visible = true;
                panelLeftFloor.Visible = true;
                panelRight.Visible = true;
                panelRightFloor.Visible = true;
            }
            else
            {
                if (isMin)
                {
                    Title = lastTitle;
                    MinimumSize = lastMinSize;
                    Bounds = new Rectangle(lastLocation, lastSize);
                    bMin.Image = min;
                    isMin = false;
                    isMinNotMove = false;
                }
                else
                {
                    panelTop.Visible = false;
                    panelFloor.Visible = false;
                    panelLeft.Visible = false;
                    panelLeftFloor.Visible = false;
                    panelRight.Visible = false;
                    panelRightFloor.Visible = false;
                }

                lastMaxSize = MaximumSize;
                if (MaximumSize.Width > MinimumSize.Width && MaximumSize.Height > MinimumSize.Height)
                    MaximumSize = new Size(MaximumSize.Width - 12, MaximumSize.Height - 44);
                Dock = DockStyle.Fill;
                bMax.Image = normal;
            }
        }
    }

    private void bClose_Click(object sender, EventArgs e)
    {
        mdiControl.Controls.Remove(this);
        mdiControl.mdiWins.Remove(this);
        Dispose();
    }

    private void bMin_MouseLeave(object sender, EventArgs e)
    {
        if (minimizeBox)
            bMin.BackColor = minLeaveColor;
    }

    private void bMax_MouseLeave(object sender, EventArgs e)
    {
        if (maximizeBox)
            bMax.BackColor = maxLeaveColor;
    }

    private void bClose_MouseLeave(object sender, EventArgs e)
    {
        bClose.BackColor = closeLeaveColor;
    }

    private void bMin_MouseEnter(object sender, EventArgs e)
    {
        if (minimizeBox)
            bMin.BackColor = minEnterColor;
    }

    private void bMax_MouseEnter(object sender, EventArgs e)
    {
        if (maximizeBox)
            bMax.BackColor = maxEnterColor;
    }

    private void bClose_MouseEnter(object sender, EventArgs e)
    {
        bClose.BackColor = closeEnterColor;
    }

    private void bMin_MouseDown(object sender, MouseEventArgs e)
    {
        if (minimizeBox)
            bMin.BackColor = minDownColor;
    }

    private void bMax_MouseDown(object sender, MouseEventArgs e)
    {
        if (maximizeBox)
            bMax.BackColor = maxDownColor;
    }

    private void bClose_MouseDown(object sender, MouseEventArgs e)
    {
        bClose.BackColor = closeDownColor;
    }
    #endregion

    #region IMdiWin
    bool IMdiWin.NotMove()
    {
        return notMove;
    }
    void IMdiWin.SetMdiControl(MdiControl mdiControl)
    {
        this.mdiControl = mdiControl;
    }

    bool IMdiWin.IsMinNotMove()
    {
        return isMinNotMove;
    }
    int IMdiWin.MinInd()
    {
        return minInd;
    }

    void IMdiWin.SetIco(Image ico)
    {
        Ico = ico;
    }
    void IMdiWin.SetTitle(string title)
    {
        Title = title;
    }

    void IMdiWin.SetMinimizeBox(bool minimizeBox)
    {
        MinimizeBox = minimizeBox;
    }
    void IMdiWin.SetMaximizeBox(bool maximizeBox)
    {
        MaximizeBox = maximizeBox;
    }

    bool IMdiWin.MdiFocus 
    {
        get => mdiFocus;

        set
        {
            if(theme == MdiThemeMode.Light)
            {
                if (mdiFocus != value && value == true)
                {
                    BorderColor = Color.DarkGray;
                }
                else if (mdiFocus != value && value == false)
                {
                    BorderColor = Color.White;
                }
            }
            else if (theme == MdiThemeMode.Dark)
            {
                if (mdiFocus != value && value == true)
                {
                    BorderColor = Color.FromArgb(14, 14, 14);
                }
                else if (mdiFocus != value && value == false)
                {
                    BorderColor = Color.FromArgb(35, 35, 35);
                }
            }
            mdiFocus = value;
        }
    }
    #endregion
}

public enum MdiThemeMode
{
    Light,
    Dark,
}
