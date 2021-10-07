using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsMDI2
{
    public partial class MdiControI2 : UserControl
    {
        public List<MdiWin> mdiWins = new List<MdiWin>();

        public MdiControI2()
        {
            BackColor = Color.LightGray;
            InitializeComponent();
        }

        public MdiWin CreateMdiWin()
        {
            var win = new MdiWin(this);
            Controls.Add(win);
            mdiWins.Add(win);
            return win;
        }

        public void FocusMdiWin(MdiWin win)
        {
            Controls.SetChildIndex(win,0);
        }
    }
}
