using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimhoppGUI
{
    public class DimIt : IDisposable
    {
        public DimIt()
        {
            var openForms = Application.OpenForms.Count;
            for (var i = 0; i < openForms; ++i)
            {
                var form = Application.OpenForms[i];
                var overlay = new Form
                {
                    Location = form.Location,
                    Size = form.Size,
                    FormBorderStyle = FormBorderStyle.None,
                    ShowInTaskbar = false,
                    StartPosition = FormStartPosition.Manual,
                    AutoScaleMode = AutoScaleMode.None,
                    Opacity = 0.2,
                    BackColor = Color.Gray
                };
                overlay.Show(form);
                forms.Add(overlay);
            }
        }

        public void Dispose()
        {
            foreach (var form in forms)
            {
                form.Close();
            }
        }

        private List<Form> forms = new List<Form>();
    }
}