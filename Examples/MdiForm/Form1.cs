using WinFormsMDI2;

namespace MdiForm;
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void bCreateFormWin_Click(object sender, EventArgs e)
    {
        MdiWin mdiWin = mdiControl.CreateMdiWinWithForm(new Form2());           //create a mdi window with form2
    }
}