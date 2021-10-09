using System;
using System.Collections.Generic;
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

        public MdiWinType CreateMdiWin<MdiWinType>()
        {
            int x = 0, y = 0;
            var win = Activator.CreateInstance(typeof(MdiWinType)) as MdiWin;
            win.mdiControl = this;

            MdiWin[] wins = new MdiWin[] { };
            wins = mdiWins.ToArray();

            Array.Sort(wins, delegate (MdiWin mw1, MdiWin mw2) {
                if (mw1.Location.X - mw1.Location.Y == mw2.Location.X - mw2.Location.Y)
                    return mw1.Location.X.CompareTo(mw2.Location.X);
                else
                    return (mw1.Location.X - mw1.Location.Y).CompareTo(mw2.Location.X - mw2.Location.Y);
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
            return (MdiWinType)(object)win;
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
                else
                    return (mw1.Location.X - mw1.Location.Y).CompareTo(mw2.Location.X - mw2.Location.Y);
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
            win.MinimumSize = new Size(form.MinimumSize.Width + 10, form.MinimumSize.Height + 42);
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
                else
                    return (mw1.Location.X - mw1.Location.Y).CompareTo(mw2.Location.X - mw2.Location.Y);
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
                    win.Location = new Point(win.Location.X, Height - 32);
                }
            }
        }
    }
}
