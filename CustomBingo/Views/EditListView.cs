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
        private ToolTip toolTip;

        public EditListView()
        {
            InitializeComponent();

            toolTip = new ToolTip
            {
                AutoPopDelay = 0,
                InitialDelay = 0,
                ReshowDelay = 500,
                ShowAlways = true
            };

        }

        public void LoadAllComp()
        {
            FlowViewAll.Controls.Clear();

            DataTable companiesTable = DataService.GetCompanies();

            var sortedRows = companiesTable.AsEnumerable()
                                           .OrderBy(row => row.Field<string>("Name"))
                                           .ToList();

            foreach (DataRow row in sortedRows)
            {
                string companyName = row["Name"].ToString();
                string logoName = row["Logo"].ToString();
                string companyFull = companyName;

                if (companyName.Length > 10)
                {
                    companyFull = companyName;
                    companyName = companyName.Substring(0, 10);
                }

                Panel companyPanel = new Panel();
                companyPanel.Width = 70;  
                companyPanel.Height = 60; 
                companyPanel.Margin = new Padding(5);

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
                picBox.Width = 60; 
                picBox.Height = 40; 
                picBox.Location = new Point(5, 5);

                Label lblName = new Label();
                lblName.Text = companyName;
                lblName.TextAlign = ContentAlignment.MiddleCenter;
                lblName.Width = 70; 
                lblName.Height = 25; 
                lblName.Location = new Point(0, 40);

                toolTip.SetToolTip(picBox, companyFull);
                toolTip.SetToolTip(lblName, companyFull);

                companyPanel.Controls.Add(picBox);
                companyPanel.Controls.Add(lblName);

                FlowViewAll.Controls.Add(companyPanel);
            }
        }

    }
}
