using CustomBingo.Services;
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
    public partial class EditListView : UserControl
    {
        public EditListView()
        {
            InitializeComponent();
            LoadAllComp();
        }

        private void LoadAllComp()
        {
            FlowViewAll.Controls.Clear();

            DataTable companiesTable = DataService.GetCompanies();

            foreach (DataRow row in companiesTable.Rows)
            {
                string companyName = row["Name"].ToString();
                string logoName = row["Logo"].ToString();

                Panel companyPanel = new Panel();
                companyPanel.Width = 120;  
                companyPanel.Height = 150; 
                companyPanel.Margin = new Padding(10);

                PictureBox picBox = new PictureBox();
                if (!string.IsNullOrEmpty(logoName))
                {
                    picBox.Image = Image.FromFile(@"Images/" + logoName);
                }
                else
                {
                    picBox.Image = Image.FromFile(@"Images/default_logo.png");
                }

                picBox.SizeMode = PictureBoxSizeMode.Zoom;
                picBox.Width = 100; 
                picBox.Height = 100; 
                picBox.Location = new Point(10, 10); 

                Label lblName = new Label();
                lblName.Text = companyName;
                lblName.TextAlign = ContentAlignment.MiddleCenter;
                lblName.Width = 100; 
                lblName.Height = 30; 
                lblName.Location = new Point(10, 110); 

                companyPanel.Controls.Add(picBox);
                companyPanel.Controls.Add(lblName);

                FlowViewAll.Controls.Add(companyPanel);
            }
        }
    }
}
