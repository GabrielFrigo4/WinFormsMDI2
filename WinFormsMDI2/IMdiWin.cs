using System.Drawing;

namespace WinFormsMDI2;
public interface IMdiWin
{
    bool NotMove();
    MdiControl MdiControl { get; set; }

    bool IsMinNotMove();
    int MinInd();

    void SetIco(Image ico);
    void SetTitle(string title);

    void SetMinimizeBox(bool minimizeBox);
    void SetMaximizeBox(bool maximizeBox);

    bool MdiFocus { get; set; }
}
