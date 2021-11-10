using System;
using System.Drawing;

namespace WinFormsMDI2
{
    public interface IMdiWin
    {
        public bool NotMove();
        public void SetMdiControl(MdiControl mdiControl);

        public bool IsMinNotMove();
        public int MinInd();

        public void SetIco(Image ico);
        public void SetTitle(string title);

        public void SetMinimizeBox(bool minimizeBox);
        public void SetMaximizeBox(bool maximizeBox);
    }
}
