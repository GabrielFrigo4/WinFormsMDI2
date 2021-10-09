using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;

namespace WinFormsMDI2
{
    public partial class MdiWin : UserControl
    {
        public MdiControl mdiControl;
        public bool isMinNotMove = false;

        Image max = Properties.Resources.Maximisar, min = Properties.Resources.Minimisar, normal = Properties.Resources.Normalisar;
        bool isMove = false, isMin = false, isResize = false;
        int mx, my, rx, ry;
        Point lastLocation, minPos;
        Size lastSize, lastMinSize;
        string lastTitle;

        public MdiWin()
        {
            BackColor = Color.FromArgb(240,240,240);
            InitializeComponent();
            //labelTitle
            labelTitle.MouseDown += panelTop_MouseDown;
            labelTitle.MouseUp += panelTop_MouseUp;
            labelTitle.MouseMove += panelTop_MouseMove;
            labelTitle.DoubleClick += panelTop_DoubleClick;
            //pictureBoxIco
            pictureBoxIco.MouseDown += panelTop_MouseDown;
            pictureBoxIco.MouseUp += panelTop_MouseUp;
            pictureBoxIco.MouseMove += panelTop_MouseMove;
            pictureBoxIco.DoubleClick += panelTop_DoubleClick;
            pictureBoxIco.Select();
            lastTitle = Title;
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

        [Description("Is MdiWin Ico")]
        public Image Ico { get { return pictureBoxIco.Image; } set { pictureBoxIco.Image = value; } }
        #endregion

        #region panelTop
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (Dock != DockStyle.Fill)
            {
                isMove = true;
                isMinNotMove = false;
                mx = MousePosition.X - Location.X;
                my = MousePosition.Y - Location.Y;
            }
        }

        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                Location = new Point(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void panelTop_DoubleClick(object sender, EventArgs e)
        {
            if(Dock == DockStyle.Fill)
            {
                Dock = DockStyle.None;
            }
            else
            {
                Dock = DockStyle.Fill;
            }
            labelTitle.Select();
        }
        #endregion

        #region panelFloor
        private void panelFloor_MouseDown(object sender, MouseEventArgs e)
        {
            if (Dock != DockStyle.Fill)
            {
                isResize = true;
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
            Cursor.Current = Cursors.SizeNS;
        }

        private void panelFloor_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.SizeNS;
        }
        #endregion

        #region panelLeft
        private void panelLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (Dock != DockStyle.Fill)
            {
                isResize = true;
                rx = -MousePosition.X - Size.Width;
                mx = MousePosition.X - Location.X;

                minPos = new Point(Location.X + Size.Width - MinimumSize.Width, Location.Y + Size.Height - MinimumSize.Height);
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
                Size = new Size(-MousePosition.X - rx, Size.Height);
                if (Size.Width >= MinimumSize.Width)
                {
                    if (minPos.X >= MousePosition.X - mx)
                    {
                        Location = new Point(MousePosition.X - mx, Location.Y);
                    }
                    else
                    {
                        Location = new Point(minPos.X, Location.Y);
                    }
                }
            }
            Cursor.Current = Cursors.SizeWE;
        }

        private void panelLeft_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.SizeWE;
        }
        #endregion

        #region panelRight
        private void panelRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (Dock != DockStyle.Fill)
            {
                isResize = true;
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
            Cursor.Current = Cursors.SizeWE;
        }

        private void panelRight_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.SizeWE;
        }
        #endregion

        #region panelRightFloor
        private void panelRightFloor_MouseDown(object sender, MouseEventArgs e)
        {
            if (Dock != DockStyle.Fill)
            {
                isResize = true;
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
            Cursor.Current = Cursors.SizeNWSE;
        }

        private void panelRightFloor_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.SizeNWSE;
        }
        #endregion

        #region panelLeftFloor
        private void panelLeftFloor_MouseDown(object sender, MouseEventArgs e)
        {
            if (Dock != DockStyle.Fill)
            {
                isResize = true;
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
                Size = new Size(-MousePosition.X - rx, MousePosition.Y - ry);
                if (Size.Width >= MinimumSize.Width)
                {
                    if (minPos.X >= MousePosition.X - mx)
                    {
                        Location = new Point(MousePosition.X - mx, Location.Y);
                    }
                    else
                    {
                        Location = new Point(minPos.X, Location.Y);
                    }
                }
            }
            Cursor.Current = Cursors.SizeNESW;
        }

        private void panelLeftFloor_MouseEnter(object sender, EventArgs e)
        {
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
        private void bExit_Click(object sender, EventArgs e)
        {
            mdiControl.Controls.Remove(this);
            mdiControl.mdiWins.Remove(this);
            Dispose();
            labelTitle.Select();
        }

        private void bMax_Click(object sender, EventArgs e)
        {
            if (Dock == DockStyle.Fill)
            {
                Dock = DockStyle.None;
                bMax.Image = max;
            }
            else
            {
                if (isMin)
                {
                    panelFloor.Visible = true;
                    panelLeft.Visible = true;
                    panelLeftFloor.Visible = true;
                    panelRight.Visible = true;
                    panelRightFloor.Visible = true;

                    Title = lastTitle;
                    Size = lastSize;
                    MinimumSize = lastMinSize;
                    Location = lastLocation;
                    bMin.Image = min;
                    isMin = false;
                    isMinNotMove = false;
                }
                Dock = DockStyle.Fill;
                bMax.Image = normal;
            }
            labelTitle.Select();
        }

        private void bMin_Click(object sender, EventArgs e)
        {
            if (!isMin)
            {
                int x = 0;

                MdiWin[] wins = new MdiWin[] { };
                wins = mdiControl.mdiWins.ToArray();

                Array.Sort(wins, delegate (MdiWin mw1, MdiWin mw2) {
                    return mw1.Location.X.CompareTo(mw2.Location.X);
                });

                foreach (Control cont in wins)
                {
                    if(cont.Location.X == x && cont.Location.Y == mdiControl.Height - 32)
                    {
                        x += 226;
                    }
                    if(cont.Location.X > x)
                    {
                        break;
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

                panelFloor.Visible = false;
                panelLeft.Visible = false;
                panelLeftFloor.Visible = false;
                panelRight.Visible = false;
                panelRightFloor.Visible = false;

                Title = Title.Substring(0,3)+"...";
                MinimumSize = new Size(0, 0);
                Size = new Size(226, 32);
                Location = new Point(x, mdiControl.Height - 32);
                bMin.Image = normal;
                isMin = true;
                isMinNotMove = true;
            }
            else
            {
                panelFloor.Visible = true;
                panelLeft.Visible = true;
                panelLeftFloor.Visible = true;
                panelRight.Visible = true;
                panelRightFloor.Visible = true;

                Title = lastTitle;
                Size = lastSize;
                MinimumSize = lastMinSize;
                Location = lastLocation;
                bMin.Image = min;
                isMin = false;
                isMinNotMove = false;
            }
            
            labelTitle.Select();
        }

        private void bExit_MouseLeave(object sender, EventArgs e)
        {
            labelTitle.Select();
            bExit.BackColor = Color.White;
        }

        private void bMax_MouseLeave(object sender, EventArgs e)
        {
            labelTitle.Select();
            bMax.BackColor = Color.White;

        }

        private void bMin_MouseLeave(object sender, EventArgs e)
        {
            labelTitle.Select();
            bMin.BackColor = Color.White;
        }

        private void bMin_MouseEnter(object sender, EventArgs e)
        {
            bMin.BackColor = Color.LightGray;
        }

        private void bMax_MouseEnter(object sender, EventArgs e)
        {
            bMax.BackColor = Color.LightGray;
        }

        private void bExit_MouseEnter(object sender, EventArgs e)
        {
            bExit.BackColor = Color.FromArgb(255,90,90);
        }

        private void bMin_MouseDown(object sender, MouseEventArgs e)
        {
            bMin.BackColor = Color.Gray;
        }

        private void bMax_MouseDown(object sender, MouseEventArgs e)
        {
            bMax.BackColor = Color.Gray;
        }

        private void bExit_MouseDown(object sender, MouseEventArgs e)
        {
            bExit.BackColor = Color.FromArgb(255, 20, 20);
        }
        #endregion
    }
}
