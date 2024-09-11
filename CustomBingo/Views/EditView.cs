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
    public partial class EditView : UserControl
    {
        public EditView()
        {
            InitializeComponent();

            editMainView.Show();
            editCompanyView.Hide();
            editListView.Hide();
            
            BtnFinish.Enabled = false;

            editMainView.BringToFront();
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            editMainView.Hide();
            editCompanyView.Hide();
            editListView.Show();

            BtnFinish.Enabled = true;
            BtnCompany.Enabled = false;
            BtnList.Enabled = false;

            editListView.LoadAllComp();

            editListView.BringToFront();
        }

        private void BtnCompany_Click(object sender, EventArgs e)
        {
            editMainView.Hide();
            editCompanyView.Show();
            editListView.Hide();

            BtnFinish.Enabled = true;
            BtnCompany.Enabled = false;
            BtnList.Enabled = false;

            editCompanyView.BringToFront();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            editMainView.Show();
            editCompanyView.Hide();
            editListView.Hide();

            BtnFinish.Enabled = false;
            BtnCompany.Enabled = true;
            BtnList.Enabled = true;

            editMainView.BringToFront();
        }
    }
}
