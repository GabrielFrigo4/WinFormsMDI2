using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsMDI2
{
    public partial class MdiControI : UserControl
    {
        public List<MdiWin> mdiWins = new List<MdiWin>();

        public MdiControI()
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
                return mw1.Location.X.CompareTo(mw2.Location.X);
            });

            foreach (Control cont in wins)
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
                return mw1.Location.X.CompareTo(mw2.Location.X);
            });

            foreach (Control cont in wins)
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
