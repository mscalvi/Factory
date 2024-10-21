using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DeckManager.Views
{
    public partial class TextInputDialog : Form
    {
        public string UserInput { get; private set; }

        public TextInputDialog(string prompt)
        {
            InitializeComponent();
            LblCat.Text = prompt;
        }
        private void BtnCatOk_Click(object sender, EventArgs e)
        {
            UserInput = BoxCatName.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCatCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
