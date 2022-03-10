using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsMDI2;
public partial class MdiControl : UserControl
{
    public List<IMdiWin> mdiWins = new List<IMdiWin>();

    public MdiControl()
    {
        BackColor = Color.FromArgb(230, 230, 230);
        InitializeComponent();
    }

    public MdiWin CreateMdiWin()
    {
        var win = new MdiWin();
        win.mdiControl = this;

        IMdiWin[] wins = new IMdiWin[] { };
        wins = mdiWins.ToArray();

        Array.Sort(wins, delegate (IMdiWin mw1, IMdiWin mw2) {
            if (((Control)mw1).Location.X - ((Control)mw1).Location.Y == ((Control)mw2).Location.X - ((Control)mw2).Location.Y)
                return ((Control)mw1).Location.X.CompareTo(((Control)mw2).Location.X);
            else if (mw1.NotMove() && mw2.NotMove())
                return (((Control)mw1).Location.X - ((Control)mw1).Location.Y).CompareTo(((Control)mw2).Location.X - ((Control)mw2).Location.Y);
            else
                return -Convert.ToInt32(mw1.NotMove()).CompareTo(Convert.ToInt32(mw2.NotMove()));
        });

        int x = 0, y = 0, cil = 0;
        foreach (Control cont in wins)
        {
            if (y + win.Height + 44 > Height)
            {
                cil++;
                x = 48 * cil;
                y = 0;
            }
            else
            {
                if (cont.Location.X == x && cont.Location.Y == y)
                {
                    x += 48;
                    y += 48;
                }
                if (cont.Location.X > x || cont.Location.Y > y)
                {
                    break;
                }
            }
        }

        win.Location = new Point(x, y);

        Controls.Add(win);
        mdiWins.Add(win);

        FocusMdiWin(win);
        return win;
    }

    public IMdiWin CreateMdiWin(Type mdiWinType)
    {
        var win = Activator.CreateInstance(mdiWinType) as IMdiWin;
        win.SetMdiControl(this);

        IMdiWin[] wins = new IMdiWin[] { };
        wins = mdiWins.ToArray();

        Array.Sort(wins, delegate (IMdiWin mw1, IMdiWin mw2) {
            if (((Control)mw1).Location.X - ((Control)mw1).Location.Y == ((Control)mw2).Location.X - ((Control)mw2).Location.Y)
                return ((Control)mw1).Location.X.CompareTo(((Control)mw2).Location.X);
            else if (mw1.NotMove() && mw2.NotMove())
                return (((Control)mw1).Location.X - ((Control)mw1).Location.Y).CompareTo(((Control)mw2).Location.X - ((Control)mw2).Location.Y);
            else
                return -Convert.ToInt32(mw1.NotMove()).CompareTo(Convert.ToInt32(mw2.NotMove()));
        });

        int x = 0, y = 0, cil = 0;
        foreach (Control cont in wins)
        {
            if (y + ((Control)win).Height + 44 > Height)
            {
                cil++;
                x = 48 * cil;
                y = 0;
            }
            else
            {
                if (cont.Location.X == x && cont.Location.Y == y)
                {
                    x += 48;
                    y += 48;
                }
                if (cont.Location.X > x || cont.Location.Y > y)
                {
                    break;
                }
            }
        }

        ((Control)win).Location = new Point(x, y);

        Controls.Add((Control)win);
        mdiWins.Add(win);

        FocusMdiWin(win);
        return win;
    }

    public MdiWinType CreateMdiWin<MdiWinType>() where MdiWinType : Control, IMdiWin
    {
        var win = CreateMdiWin(typeof(MdiWinType));
        return (MdiWinType)win;
    }

    public MdiWin CreateMdiWinWithForm(Form form, bool useFormIcon = true, bool useFormText= true)
    {
        form.FormBorderStyle = FormBorderStyle.None;
        form.TopLevel = false;

        var win = new MdiWin();
        if(useFormIcon)
            win.Ico = form.Icon.ToBitmap();
        if (useFormText)
            win.Title = form.Text;
        win.MinimumSize = new Size(form.MinimumSize.Width + 12, form.MinimumSize.Height + 44);
        if (form.MaximumSize.Width > 0 && form.MaximumSize.Height > 0)
            win.MaximumSize = new Size(form.MaximumSize.Width + 12, form.MaximumSize.Height + 44);
        win.MinimizeBox = form.MinimizeBox;
        win.MaximizeBox = form.MaximizeBox;
        form.Dock = DockStyle.Fill;
        win.Controls.Add(form);
        form.BringToFront();
        form.Show();
        win.mdiControl = this;

        IMdiWin[] wins = new IMdiWin[] { };
        wins = mdiWins.ToArray();

        Array.Sort(wins, delegate (IMdiWin mw1, IMdiWin mw2) {
            if (((Control)mw1).Location.X - ((Control)mw1).Location.Y == ((Control)mw2).Location.X - ((Control)mw2).Location.Y)
                return ((Control)mw1).Location.X.CompareTo(((Control)mw2).Location.X);
            else if (mw1.NotMove() && mw2.NotMove())
                return (((Control)mw1).Location.X - ((Control)mw1).Location.Y).CompareTo(((Control)mw2).Location.X - ((Control)mw2).Location.Y);
            else
                return -Convert.ToInt32(mw1.NotMove()).CompareTo(Convert.ToInt32(mw2.NotMove()));
        });

        int x = 0, y = 0, cil = 0;
        foreach (Control cont in wins)
        {
            if (y + win.Height + 44 > Height)
            {
                cil++;
                x = 48 * cil;
                y = 0;
            }
            else
            {
                if (cont.Location.X == x && cont.Location.Y == y)
                {
                    x += 48;
                    y += 48;
                }
                if (cont.Location.X > x || cont.Location.Y > y)
                {
                    break;
                }
            }
        }

        win.Location = new Point(x, y);

        Controls.Add(win);
        mdiWins.Add(win);

        FocusMdiWin(win);
        return win;
    }

    public IMdiWin CreateMdiWinWithForm(Type mdiWinStyle, Form form, bool useFormIcon = true, bool useFormText = true)
    {
        form.FormBorderStyle = FormBorderStyle.None;
        form.TopLevel = false;

        var win = Activator.CreateInstance(mdiWinStyle) as IMdiWin;
        if (useFormIcon)
            win.SetIco(form.Icon.ToBitmap());
        if (useFormText)
            win.SetTitle(form.Text);
        ((Control)win).MinimumSize = new Size(form.MinimumSize.Width + 12, form.MinimumSize.Height + 44);
        if (form.MaximumSize.Width > 0 && form.MaximumSize.Height > 0)
            ((Control)win).MaximumSize = new Size(form.MaximumSize.Width + 12, form.MaximumSize.Height + 44);
        win.SetMinimizeBox(form.MinimizeBox);
        win.SetMaximizeBox(form.MaximizeBox);
        form.Dock = DockStyle.Fill;
        ((Control)win).Controls.Add(form);
        form.BringToFront();
        form.Show();
        win.SetMdiControl(this);

        IMdiWin[] wins = new IMdiWin[] { };
        wins = mdiWins.ToArray();

        Array.Sort(wins, delegate (IMdiWin mw1, IMdiWin mw2) {
            if (((Control)mw1).Location.X - ((Control)mw1).Location.Y == ((Control)mw2).Location.X - ((Control)mw2).Location.Y)
                return ((Control)mw1).Location.X.CompareTo(((Control)mw2).Location.X);
            else if (mw1.NotMove() && mw2.NotMove())
                return (((Control)mw1).Location.X - ((Control)mw1).Location.Y).CompareTo(((Control)mw2).Location.X - ((Control)mw2).Location.Y);
            else
                return -Convert.ToInt32(mw1.NotMove()).CompareTo(Convert.ToInt32(mw2.NotMove()));
        });

        int x = 0, y = 0, cil = 0;
        foreach (Control cont in wins)
        {
            if (y + ((Control)win).Height + 44 > Height)
            {
                cil++;
                x = 48 * cil;
                y = 0;
            }
            else
            {
                if (cont.Location.X == x && cont.Location.Y == y)
                {
                    x += 48;
                    y += 48;
                }
                if (cont.Location.X > x || cont.Location.Y > y)
                {
                    break;
                }
            }
        }

        ((Control)win).Location = new Point(x, y);

        Controls.Add((Control)win);
        mdiWins.Add(win);

        FocusMdiWin(win);
        return win;
    }

    public MdiWinStyle CreateMdiWinWithForm<MdiWinStyle>(Form form, bool useFormIcon = true, bool useFormText = true) where MdiWinStyle : Control, IMdiWin
    {
        var win = CreateMdiWinWithForm(typeof(MdiWinStyle), form, useFormIcon, useFormText);
        return (MdiWinStyle)win;
    }

    public void FocusMdiWin(IMdiWin win)
    {
        Controls.SetChildIndex((Control)win,0);
    }

    private void MdiControl_Resize(object sender, EventArgs e)
    {
        foreach (IMdiWin win in mdiWins)
        {
            if (win.IsMinNotMove())
            {
                ((Control)win).Location = new Point(((Control)win).Location.X, Height - 32 * win.MinInd());
            }
        }
    }

    private bool removeScreenFlickering = true;

    #region behaviors
    [DefaultValue(true)]
    [Description("Is Remove Screen Flickering")]
    public bool RemoveScreenFlickering { get { return removeScreenFlickering; } set { removeScreenFlickering = value; } }
    #endregion

    protected override CreateParams CreateParams
    {
        get
        {
            if (removeScreenFlickering)
            {
                CreateParams handleparam = base.CreateParams;
                handleparam.ExStyle |= 0x02000000;
                return handleparam;
            }
            else
            {
                return base.CreateParams;
            }
        }
    }
}
