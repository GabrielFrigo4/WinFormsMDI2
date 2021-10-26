using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsMDI2
{
    public partial class MdiControl : UserControl
    {
        public List<MdiWin> mdiWins = new List<MdiWin>();

        public MdiControl()
        {
            BackColor = Color.FromArgb(230, 230, 230);
            InitializeComponent();
        }

        public MdiWin CreateMdiWin()
        {
            int x = 0, y = 0;
            var win = new MdiWin();
            win.mdiControl = this;

            MdiWin[] wins = new MdiWin[] { };
            wins = mdiWins.ToArray();

            Array.Sort(wins, delegate (MdiWin mw1, MdiWin mw2) {
                if (mw1.Location.X - mw1.Location.Y == mw2.Location.X - mw2.Location.Y)
                    return mw1.Location.X.CompareTo(mw2.Location.X);
                else if (mw1.notMove && mw2.notMove)
                    return (mw1.Location.X - mw1.Location.Y).CompareTo(mw2.Location.X - mw2.Location.Y);
                else
                    return -Convert.ToInt32(mw1.notMove).CompareTo(Convert.ToInt32(mw2.notMove));
            });

            int cil = 0;
            foreach (Control cont in wins)
            {
                if (y + win.Height > Height)
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

        public MdiWin CreateMdiWin(Type mdiWinType)
        {
            int x = 0, y = 0;
            var win = Activator.CreateInstance(mdiWinType) as MdiWin;
            win.mdiControl = this;

            MdiWin[] wins = new MdiWin[] { };
            wins = mdiWins.ToArray();

            Array.Sort(wins, delegate (MdiWin mw1, MdiWin mw2) {
                if (mw1.Location.X - mw1.Location.Y == mw2.Location.X - mw2.Location.Y)
                    return mw1.Location.X.CompareTo(mw2.Location.X);
                else if (mw1.notMove && mw2.notMove)
                    return (mw1.Location.X - mw1.Location.Y).CompareTo(mw2.Location.X - mw2.Location.Y);
                else
                    return -Convert.ToInt32(mw1.notMove).CompareTo(Convert.ToInt32(mw2.notMove));
            });

            int cil = 0;
            foreach (Control cont in wins)
            {
                if (y + win.Height > Height)
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

        public MdiWinType CreateMdiWin<MdiWinType>()
        {
            var win = CreateMdiWin(typeof(MdiWinType));
            return (MdiWinType)(object)win;
        }

        public MdiWin CreateMdiWinWithForm(Form form, bool useFormIcon = true, bool useFormText= true)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;

            int x = 0, y = 0;

            var win = new MdiWin();
            if(useFormIcon)
                win.Ico = form.Icon.ToBitmap();
            if (useFormText)
                win.Title = form.Text;
            win.MinimumSize = new Size(form.MinimumSize.Width + 12, form.MinimumSize.Height + 44);
            if (form.MaximumSize.Width > 0 && form.MaximumSize.Height > 0)
                win.MaximumSize = new Size(form.MaximumSize.Width + 12, form.MaximumSize.Height + 44);
            form.Dock = DockStyle.Fill;
            win.Controls.Add(form);
            form.BringToFront();
            form.Show();
            win.mdiControl = this;

            MdiWin[] wins = new MdiWin[] { };
            wins = mdiWins.ToArray();

            Array.Sort(wins, delegate (MdiWin mw1, MdiWin mw2) {
                if (mw1.Location.X - mw1.Location.Y == mw2.Location.X - mw2.Location.Y)
                    return mw1.Location.X.CompareTo(mw2.Location.X);
                else if (mw1.notMove && mw2.notMove)
                    return (mw1.Location.X - mw1.Location.Y).CompareTo(mw2.Location.X - mw2.Location.Y);
                else
                    return -Convert.ToInt32(mw1.notMove).CompareTo(Convert.ToInt32(mw2.notMove));
            });

            int cil = 0;
            foreach (Control cont in wins)
            {
                if (y + win.Height > Height)
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

        public MdiWin CreateMdiWinWithForm(Type mdiWinStyle, Form form, bool useFormIcon = true, bool useFormText = true)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;

            int x = 0, y = 0;

            var win = Activator.CreateInstance(mdiWinStyle) as MdiWin;
            if (useFormIcon)
                win.Ico = form.Icon.ToBitmap();
            if (useFormText)
                win.Title = form.Text;
            win.MinimumSize = new Size(form.MinimumSize.Width + 12, form.MinimumSize.Height + 44);
            if(form.MaximumSize.Width > 0 && form.MaximumSize.Height > 0)
                win.MaximumSize = new Size(form.MaximumSize.Width + 12, form.MaximumSize.Height + 44);
            form.Dock = DockStyle.Fill;
            win.Controls.Add(form);
            form.BringToFront();
            form.Show();
            win.mdiControl = this;

            MdiWin[] wins = new MdiWin[] { };
            wins = mdiWins.ToArray();

            Array.Sort(wins, delegate (MdiWin mw1, MdiWin mw2) {
                if (mw1.Location.X - mw1.Location.Y == mw2.Location.X - mw2.Location.Y)
                    return mw1.Location.X.CompareTo(mw2.Location.X);
                else if (mw1.notMove && mw2.notMove)
                    return (mw1.Location.X - mw1.Location.Y).CompareTo(mw2.Location.X - mw2.Location.Y);
                else
                    return -Convert.ToInt32(mw1.notMove).CompareTo(Convert.ToInt32(mw2.notMove));
            });

            int cil = 0;
            foreach (Control cont in wins)
            {
                if (y + win.Height > Height)
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

        public MdiWinStyle CreateMdiWinWithForm<MdiWinStyle>(Form form, bool useFormIcon = true, bool useFormText = true)
        {
            var win = CreateMdiWinWithForm(typeof(MdiWinStyle), form, useFormIcon, useFormText);
            return (MdiWinStyle)(object)win;
        }

        public void FocusMdiWin(MdiWin win)
        {
            Controls.SetChildIndex(win,0);
        }

        private void MdiControI_Resize(object sender, EventArgs e)
        {
            foreach (MdiWin win in mdiWins)
            {
                if (win.isMinNotMove)
                {
                    win.Location = new Point(win.Location.X, Height - 32 * win.minInd);
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
}
