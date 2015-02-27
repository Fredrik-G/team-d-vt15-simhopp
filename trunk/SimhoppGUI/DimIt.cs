using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimhoppGUI
{
    public class DimIt : IDisposable
    {
        private List<Form> forms = new List<Form>();

        public DimIt()
        {
            var form = Form.ActiveForm;
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var form in forms)
                {
                    // form.Close();
                    form.Dispose();
                }
            }
        }
    }
}