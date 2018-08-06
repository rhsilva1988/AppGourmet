using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppJogoGourmet.View
{
    public partial class InputBoxDialog : Form
    {
        public InputBoxDialog()
        {
            InitializeComponent();
        }

        public string Show(string title, string promptText)
        {
            Text = title;
            label.Text = promptText;

            btnOk.DialogResult = DialogResult.Yes;

            var dialogResult = ShowDialog();
            return textBox.Text;
        }
    }
}
