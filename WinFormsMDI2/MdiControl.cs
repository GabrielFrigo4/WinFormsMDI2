using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsMDI2;
public partial class MdiControl : UserControl
{
    #region Public
    public List<IMdiWin> MdiWins { get; private set; }

    public MdiControl()
    {
        MdiWins = new();
        BackColor = Color.FromArgb(230, 230, 230);
        InitializeComponent();
    }

    public MdiWin CreateMdiWin()
    {
        MdiWin win = new()
        {
            MdiControl = this
        };

        IMdiWin[] all_wins = MdiWins.ToArray();
        List<IMdiWin> listWinsDontMove = new();
        foreach (IMdiWin subwin in all_wins)
        {
            if (subwin.NotMove)
            {
                listWinsDontMove.Add(subwin);
            }
        }
        IMdiWin[] wins = listWinsDontMove.ToArray();
        Array.Sort(wins, SortMdiWin);
        win.Location = GetWinStartPosition(win, wins);

        Controls.Add(win);
        MdiWins.Add(win);

        FocusMdiWin(win);
        return win;
    }

    public IMdiWin CreateMdiWin(Type mdiWinType)
    {
        if (Activator.CreateInstance(mdiWinType) is not IMdiWin win) 
            throw new Exception($"It is not possible to create an instance using the type {mdiWinType.Name}");

        win.MdiControl = this;

        IMdiWin[] all_wins = MdiWins.ToArray();
        List<IMdiWin> listWinsDontMove = new();
        foreach (IMdiWin subwin in all_wins)
        {
            if (subwin.NotMove)
            {
                listWinsDontMove.Add(subwin);
            }
        }
        IMdiWin[] wins = listWinsDontMove.ToArray();
        Array.Sort(wins, SortMdiWin);
        ((Control)win).Location = GetWinStartPosition(win, wins);

        Controls.Add((Control)win);
        MdiWins.Add(win);

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

        MdiWin win = new();
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
        win.MdiControl = this;

        IMdiWin[] all_wins = MdiWins.ToArray();
        List<IMdiWin> listWinsDontMove = new();
        foreach (IMdiWin subwin in all_wins)
        {
            if (subwin.NotMove)
            {
                listWinsDontMove.Add(subwin);
            }
        }
        IMdiWin[] wins = listWinsDontMove.ToArray();
        Array.Sort(wins, SortMdiWin);
        win.Location = GetWinStartPosition(win, wins);

        Controls.Add(win);
        MdiWins.Add(win);

        FocusMdiWin(win);
        return win;
    }

    public IMdiWin CreateMdiWinWithForm(Type mdiWinstyle, Form form, bool useFormIcon = true, bool useFormText = true)
    {
        form.FormBorderStyle = FormBorderStyle.None;
        form.TopLevel = false;

        if (Activator.CreateInstance(mdiWinstyle) is not IMdiWin win)
            throw new Exception($"It is not possible to create an instance using the type {mdiWinstyle.Name}");

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
        win.MdiControl = this;

        IMdiWin[] all_wins = MdiWins.ToArray();
        List<IMdiWin> listWinsDontMove = new();
        foreach (IMdiWin subwin in all_wins)
        {
            if (subwin.NotMove)
            {
                listWinsDontMove.Add(subwin);
            }
        }
        IMdiWin[] wins = listWinsDontMove.ToArray();
        Array.Sort(wins, SortMdiWin);
        ((Control)win).Location = GetWinStartPosition(win, wins);

        Controls.Add((Control)win);
        MdiWins.Add(win);

        FocusMdiWin(win);
        return win;
    }

    public MdiWinstyle CreateMdiWinWithForm<MdiWinstyle>(Form form, bool useFormIcon = true, bool useFormText = true) where MdiWinstyle : Control, IMdiWin
    {
        var win = CreateMdiWinWithForm(typeof(MdiWinstyle), form, useFormIcon, useFormText);
        return (MdiWinstyle)win;
    }

    public void FocusMdiWin(IMdiWin win)
    {
        win.MdiFocus = true;
        Controls.SetChildIndex((Control)win,0);
        foreach(IMdiWin subwin in MdiWins)
        {
            if (subwin == win) continue;
            subwin.MdiFocus = false;
        }
    }
    #endregion

    #region Private
    int SortMdiWin(IMdiWin mw1, IMdiWin mw2)
    {
        if (mw1 is Control cmw1 && mw2 is Control cmw2)
        {
            if (cmw1.Location.X - cmw1.Location.Y == cmw2.Location.X - cmw2.Location.Y)
            {
                return cmw1.Location.X.CompareTo(cmw2.Location.X);
            }
            else
            {
                return (cmw1.Location.X - cmw1.Location.Y).CompareTo(cmw2.Location.X - cmw2.Location.Y);
            }
        }
        else
        {
            return 0;
        }
    }

    private Point GetWinStartPosition(IMdiWin win, IMdiWin[] wins)
    {
        const int MOVE = 48;
        if(win is not Control winCont) return default;

        int x = 0, y = 0, cil = 0;
        foreach (IMdiWin subwin in wins)
        {
            if (subwin is not Control cont) continue;

            if (cont.Location.Y + cont.Height <= Height)
            {
                if (cont.Location.X == x && cont.Location.Y == y)
                {
                    x += MOVE;
                    y += MOVE;
                }
            }

            if (y + winCont.Height > Height)
            {
                cil++;
                x = MOVE * cil;
                y = 0;
            }
        }
        return new Point(x, y);
    }

    private void MdiControl_Resize(object sender, EventArgs e)
    {
        foreach (IMdiWin win in MdiWins)
        {
            if (win.IsMinNotMove && win is Control control)
            {
                control.Location = new Point(((Control)win).Location.X, Height - 32 * win.MinInd);
            }
        }
    }
    #endregion

    #region Behaviors
    [DefaultValue(true)]
    [Description("Is Remove Screen Flickering")]
    public bool removeScreenFlickering = true;
    public bool RemoveScreenFlickering { get => removeScreenFlickering; set => removeScreenFlickering = value; }
    protected override CreateParams CreateParams
    {
        get
        {
            if (RemoveScreenFlickering)
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
    #endregion
}
