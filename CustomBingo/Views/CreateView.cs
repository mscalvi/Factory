using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomBingo;

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

            BtnFinish.Enabled = false;

            newMainView.BringToFront();
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            newListView.Show();
            newCompanyView.Hide();
            newCardView.Hide();

            BtnCards.Enabled = false;
            BtnCompany.Enabled = false;
            BtnList.Enabled = false;
            BtnFinish.Enabled = true;

            newListView.BringToFront();
        }

        private void BtnCompany_Click(object sender, EventArgs e)
        {
            newListView.Hide();
            newCompanyView.Show();
            newCardView.Hide();

            newCompanyView.BringToFront();

            BtnCards.Enabled = false;
            BtnCompany.Enabled = false;
            BtnList.Enabled = false;
            BtnFinish.Enabled = true;
        }

        private void BtnCards_Click(object sender, EventArgs e)
        {
            newListView.Hide();
            newCompanyView.Hide();
            newCardView.Show();

            BtnCards.Enabled = false;
            BtnCompany.Enabled = false;
            BtnList.Enabled = false;
            BtnFinish.Enabled = true;

            newCardView.BringToFront();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            newMainView.Show();
            newListView.Hide();
            newCompanyView.Hide();
            newCardView.Hide();

            BtnCards.Enabled = true;
            BtnCompany.Enabled = true;
            BtnList.Enabled = true;
            BtnFinish.Enabled = false;

            newMainView.BringToFront();
        }
    }
}
