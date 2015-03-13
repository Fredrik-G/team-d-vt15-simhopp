using System.Windows.Forms;

namespace Simhopp
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
        public static void CreateInfoBox(string message)
        {
            MessageBox.Show
            (
                message,//text
                "Information",//title
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1
            );
        }
    }
}
