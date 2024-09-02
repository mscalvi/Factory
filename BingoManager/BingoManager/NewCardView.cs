using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BingoManager
{
    public partial class NewCardView : Form
    {
        private StartScreen startScreen;

        // Construtor que aceita uma referência do StartScreen
        public NewCardView(StartScreen screen)
        {
            InitializeComponent();
            startScreen = screen;
        }

        private void btnReturnCreate_Click(object sender, EventArgs e)
        {
            // Utilize a referência passada para acessar os componentes públicos
            startScreen.CreationPanel.Enabled = true;
            startScreen.btnReturnStart.Enabled = true;

            this.Close();
        }
    }
}

