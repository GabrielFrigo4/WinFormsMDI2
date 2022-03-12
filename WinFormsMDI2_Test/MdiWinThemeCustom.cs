using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsMDI2;

namespace WinFormsMDI2_Test
{
    public partial class MdiWinThemeCustom : UserControl, IMdiWin
    {
        internal bool notMove = true, isMove = false;
        internal int mx, my;
        internal MdiControl mdiControl;

        public MdiWinThemeCustom()
        {
            InitializeComponent();
        }

        private void MdiWin_MouseDown()
        {
            mdiControl.FocusMdiWin(this);
        }

        private void MdiWin_MouseDown(object sender, MouseEventArgs e)
        {
            MdiWin_MouseDown();
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
            }
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
        void IMdiWin.SetMdiControl(MdiControl mdiControl) 
        {
            this.mdiControl = mdiControl;
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
}
