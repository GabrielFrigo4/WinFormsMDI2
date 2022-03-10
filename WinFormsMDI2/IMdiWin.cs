using System;
using System.Drawing;

namespace WinFormsMDI2;
public interface IMdiWin
{
    bool NotMove();
    void SetMdiControl(MdiControl mdiControl);

    bool IsMinNotMove();
    int MinInd();

    void SetIco(Image ico);
    void SetTitle(string title);

    void SetMinimizeBox(bool minimizeBox);
    void SetMaximizeBox(bool maximizeBox);
}
