using System.Drawing;

namespace WinFormsMDI2;
public interface IMdiWin
{
    MdiControl MdiControl { get; set; }

    bool IsMinNotMove { get; }
    bool NotMove { get; }
    int MinInd { get; }

    void SetIco(Image ico);
    void SetTitle(string title);

    void SetMinimizeBox(bool minimizeBox);
    void SetMaximizeBox(bool maximizeBox);

    bool MdiFocus { get; set; }
}
