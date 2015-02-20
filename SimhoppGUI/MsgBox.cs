using System.Windows.Forms;

namespace SimhoppGUI
{
    public static class MsgBox
    {
        public static void CreateErrorBox(string errorMessage, string functionName)
        {
            MessageBox.Show
            (
                errorMessage + "\n" + functionName,//text
                "Exception Error",//title
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1
            );
        }
    }
}
