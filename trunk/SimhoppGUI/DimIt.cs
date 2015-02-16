using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;



public class DialogOverlay : IDisposable
{
   
    public DialogOverlay()
    {
        var cnt = Application.OpenForms.Count;
        for (int ix = 0; ix < cnt; ++ix)
        {
            var form = Application.OpenForms[ix];
            var overlay = new Form
            {
                Location = form.Location,
                Size = form.Size,
                FormBorderStyle = FormBorderStyle.None,
                ShowInTaskbar = false,
                StartPosition = FormStartPosition.Manual,
                AutoScaleMode = AutoScaleMode.None
            };
            overlay.Opacity = 0.3;
            overlay.BackColor = Color.Gray;
            overlay.Show(form);
            forms.Add(overlay);
        }
    }
    public void Dispose()
    {
        foreach (var form in forms) form.Close();
    }
    private List<Form> forms = new List<Form>();
}