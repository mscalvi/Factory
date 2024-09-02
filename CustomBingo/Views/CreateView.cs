using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomBingo.Views
{
    public partial class CreateView : UserControl
    {
        public CreateView()
        {
            InitializeComponent();

            newMainView.Show();
            newCompanyView.Hide();
            newListView.Hide();
            newCardView.Hide();

            newMainView.BringToFront();
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            newListView.Show();
            newCompanyView.Hide();
            newCardView.Hide();

            newListView.BringToFront();
        }

        private void BtnCompany_Click(object sender, EventArgs e)
        {
            newListView.Hide();
            newCompanyView.Show();
            newCardView.Hide();

            newCompanyView.BringToFront();
        }

        private void BtnCards_Click(object sender, EventArgs e)
        {
            newListView.Hide();
            newCompanyView.Hide();
            newCardView.Show();

            newCardView.BringToFront();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            newMainView.Show();
            newListView.Hide();
            newCompanyView.Hide();
            newCardView.Hide();

            newMainView.BringToFront();
        }
    }
}
