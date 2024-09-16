using BingoManager.Models;
using BingoManager.Services;
using System.Data;
using System.Xml.Linq;

namespace BingoManager
{
    public partial class MainView : Form
    {
        private string selectedImagePath;
        private ToolTip toolTip;
        private List<DataRow> allCompaniesList = new List<DataRow>();

        public MainView()
        {
            InitializeComponent();

            toolTip = new ToolTip
            {
                AutoPopDelay = 0,
                InitialDelay = 0,
                ReshowDelay = 500,
                ShowAlways = true
            };

            EditListConfigureLayout();
            EditListLoadLists();
            EditListLoadAllComp();
        }

        private void BtnCreateList_Click(object sender, EventArgs e)
        {
            ListClass list = new ListClass();

            list.Name = BoxCreateListName.Text.ToUpper().Trim();
            list.Description = BoxCreateListDescription.Text.Trim();

            if (!string.IsNullOrEmpty(list.Name) && !string.IsNullOrEmpty(list.Description))
            {
                try
                {
                    DataService.AddList(list.Name, list.Description);
                    TxtCreateListMessage.Text = "Lista " + list.Name + " adicionada com sucesso.";
                    BoxCreateListName.Text = "";
                    BoxCreateListDescription.Text = "";
                }
                catch
                {
                    TxtCreateListMessage.Text = "Erro ao conectar no Banco de Dados.";
                }
            }
            else
            {
                if (string.IsNullOrEmpty(BoxCreateListName.Text))
                {
                    TxtCreateListMessage.Text = "Nome da Lista é obrigatório.";
                }
                else if (string.IsNullOrEmpty(BoxCreateListDescription.Text))
                {
                    TxtCreateListMessage.Text = "Descrição da Lista é obrigatória.";
                }
                else
                {
                    TxtCreateListMessage.Text = "Erro ao adicionar a lista.";
                }
            }
        }

        private void BtnFindLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                PicCreateCompanyLogo.Image = Image.FromFile(selectedImagePath);
            }
        }

        private void SaveImageToPC(Image image, string fileName)
        {
            string directoryPath = Path.Combine(Application.StartupPath, "Images");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, fileName);

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                File.WriteAllBytes(filePath, ms.ToArray());
            }
        }

        private void BtnCreateCompany_Click(object sender, EventArgs e)
        {
            CompanyModel company = new CompanyModel();

            company.Name = BoxCreateCompanyName.Text.Trim();
            company.CardName = BoxCreateCompanyCardName.Text.Trim();
            company.Phone = BoxCreateCompanyPhone.Text.Trim();
            company.Email = BoxCreateCompanyEmail.Text.Trim();

            if (PicCreateCompanyLogo.Image != null)
            {
                company.Logo = "logo_" + Guid.NewGuid().ToString() + Path.GetExtension(selectedImagePath);
            }
            else
            {
                company.Logo = "";
            }

            company.AddDate = DateTime.Now.ToString("MMddyyyy - HH:mm:ss");

            if (!string.IsNullOrEmpty(company.Name) && !string.IsNullOrEmpty(company.CardName))
            {
                if (PicCreateCompanyLogo.Image != null)
                {
                    SaveImageToPC(PicCreateCompanyLogo.Image, company.Logo);
                }

                try
                {
                    DataService.AddCompany(company.Name, company.CardName, company.Phone, company.Email, company.Logo, company.AddDate);
                    TxtCreateCompanyMessage.Text = "Empresa " + company.Name + " adicionada com sucesso.";
                }
                catch
                {
                    TxtCreateCompanyMessage.Text = "Erro ao adicionar a empresa.";
                }

                BoxCreateCompanyName.Text = "";
                BoxCreateCompanyCardName.Text = "";
                BoxCreateCompanyEmail.Text = "";
                BoxCreateCompanyPhone.Text = "";
                PicCreateCompanyLogo.Image = null;
            }
            else
            {
                TxtCreateCompanyMessage.Text = "Nome e Nome para Cartela são obrigatórios.";
            }
        }

        private void EditListLoadLists()
        {
            DataTable listsTable = DataService.GetLists();

            CboEditListSel.Items.Clear();

            foreach (DataRow row in listsTable.Rows)
            {
                string listName = row["Name"].ToString();
                CboEditListSel.Items.Add(listName);
            }
        }

        private void EditListConfigureLayout()
        {
            FlowEditViewAll.AutoScroll = true;
            FlowEditViewSel.AutoScroll = true;
        }

        private void EditListLoadAllComp()
        {
            FlowEditViewAll.Controls.Clear();

            DataTable companiesTable = DataService.GetCompanies();

            allCompaniesList = companiesTable.AsEnumerable()
                                             .OrderBy(row => row.Field<string>("Name"))
                                             .ToList();

            EditListShowComps(allCompaniesList);
        }

        private void EditListShowComps(List<DataRow> CompList)
        {
            FlowEditViewAll.Controls.Clear();

            foreach (DataRow row in CompList)
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

                FlowEditViewAll.Controls.Add(companyPanel);
            }
        }

        private void BoxEditFilterCL_TextChanged(object sender, EventArgs e)
        {
            string filterText = BoxEditFilterCL.Text.ToLower();

            var filteredList = allCompaniesList
                .Where(row => row.Field<string>("Name").ToLower().Contains(filterText))
                .ToList();

            EditListShowComps(filteredList);
        }
    }
}
