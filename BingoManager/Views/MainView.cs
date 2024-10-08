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

            LoadLists();
            LoadComps();
            EditListConfigureLayout();
            LoadAllComp();
            
        }

        //M�todo para Criar uma Lista
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
                    TxtCreateListMessage.Text = "Nome da Lista � obrigat�rio.";
                }
                else if (string.IsNullOrEmpty(BoxCreateListDescription.Text))
                {
                    TxtCreateListMessage.Text = "Descri��o da Lista � obrigat�ria.";
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

        //M�todo para Criar uma empresa
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
                    int companyId = DataService.AddCompany(company.Name, company.CardName, company.Phone, company.Email, company.Logo, company.AddDate);

                    if (CboCreateCompanyList.SelectedItem != null)
                    {
                        ListItem selectedList = CboCreateCompanyList.SelectedItem as ListItem;
                        int selectedListId = selectedList.Value;

                        DataService.AddCompaniesToAllocation(selectedListId, new List<string> { companyId.ToString() });

                        TxtCreateCompanyMessage.Text = $"Empresa {company.Name} adicionada ao banco de dados e � lista com sucesso.";
                    }
                    else
                    {
                        TxtCreateCompanyMessage.Text = $"Empresa {company.Name} adicionada ao banco de dados com sucesso.";
                    }
                }
                catch (Exception ex)
                {
                    TxtCreateCompanyMessage.Text = "Erro ao adicionar a empresa: " + ex.Message;
                }

                BoxCreateCompanyName.Text = "";
                BoxCreateCompanyCardName.Text = "";
                BoxCreateCompanyEmail.Text = "";
                BoxCreateCompanyPhone.Text = "";
                PicCreateCompanyLogo.Image = null;
                CboCreateCompanyList.SelectedIndex = -1;
                LoadComps();
                LoadAllComp();
            }
            else
            {
                TxtCreateCompanyMessage.Text = "Nome e Nome para Cartela s�o obrigat�rios.";
            }
        }

        private void EditListConfigureLayout()
        {
            FlowEditViewAll.AutoScroll = true;
            FlowEditViewSel.AutoScroll = true;
        }

        // M�todo para carregar todas as empresas e filtrar as que j� est�o na lista selecionada
        private void LoadAllComp(int? selectedListId = null)
        {
            FlowEditViewAll.Controls.Clear();

            // Carregar todas as empresas
            DataTable companiesTable = DataService.GetCompanies();
            allCompaniesList = companiesTable.AsEnumerable()
                                             .OrderBy(row => row.Field<string>("Name"))
                                             .ToList();

            if (selectedListId.HasValue)
            {
                // Carregar as empresas que j� est�o na lista selecionada
                List<DataRow> companiesInList = DataService.GetCompaniesByListId(selectedListId.Value);

                // Filtrar as empresas que ainda n�o est�o na lista selecionada
                allCompaniesList = allCompaniesList.Where(row => !companiesInList.Any(c => c["Id"].ToString() == row["Id"].ToString()))
                                                   .ToList();
            }

            // Exibir as empresas filtradas
            EditListShowComps(allCompaniesList);
        }


        private void EditListShowComps(List<DataRow> CompList)
        {
            FlowEditViewAll.Controls.Clear();

            foreach (DataRow row in CompList)
            {
                string CompanyId = row["Id"].ToString();
                string companyName = row["Name"].ToString();
                string logoName = row["Logo"].ToString();
                string companyFull = companyName;

                if (companyName.Length > 10)
                {
                    companyFull = companyName;
                    companyName = companyName.Substring(0, 10);
                }

                Panel companyPanel = new Panel();
                companyPanel.Width = 100;
                companyPanel.Height = 70;
                companyPanel.Margin = new Padding(1);

                companyPanel.Tag = CompanyId;

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
                picBox.Width = 75;
                picBox.Height = 50;
                picBox.Location = new Point(20, 5);

                CheckBox chkBox = new CheckBox();
                chkBox.Width = 20;
                chkBox.Height = 20;
                chkBox.Location = new Point(0, 50);

                Label lblName = new Label();
                lblName.Text = companyName;
                lblName.Width = 70;
                lblName.Height = 20;
                lblName.Location = new Point(22, 50);
                lblName.TextAlign = ContentAlignment.MiddleLeft;

                toolTip.SetToolTip(picBox, companyFull);
                toolTip.SetToolTip(lblName, companyFull);

                chkBox.CheckedChanged += (sender, e) =>
                {
                    if (chkBox.Checked)
                    {
                        companyPanel.BackColor = Color.LightBlue;
                    }
                    else
                    {
                        companyPanel.BackColor = Color.LightGray;
                    }
                };

                companyPanel.Controls.Add(picBox);
                companyPanel.Controls.Add(chkBox);
                companyPanel.Controls.Add(lblName);

                FlowEditViewAll.Controls.Add(companyPanel);
            }
        }
        
        // M�todo para manipular a mudan�a de valor da ComboBox de listas
        private void CboEditListSel_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboEditListSel.SelectedItem != null)
            {
                int selectedListId = (int)(CboEditListSel.SelectedItem as dynamic).Value;

                // Carrega as empresas n�o alocadas na lista selecionada
                LoadAllComp(selectedListId);

                // Carrega as empresas j� associadas � lista selecionada
                List<DataRow> companyList = DataService.GetCompaniesByListId(selectedListId);

                // Exibe apenas as empresas j� associadas
                EditListShowSel(companyList);
            }
        }


        private void EditListShowSel(List<DataRow> CompList)
        {
            FlowEditViewSel.Controls.Clear(); 

            foreach (DataRow row in CompList)
            {
                string CompanyId = row["Id"].ToString();
                string companyName = row["Name"].ToString();
                string logoName = row["Logo"].ToString();
                string companyFull = companyName;

                if (companyName.Length > 10)
                {
                    companyFull = companyName;
                    companyName = companyName.Substring(0, 10);
                }

                Panel companyPanel = new Panel();
                companyPanel.Width = 100;
                companyPanel.Height = 70;
                companyPanel.Margin = new Padding(1);

                companyPanel.Tag = CompanyId;

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
                picBox.Width = 75;
                picBox.Height = 50;
                picBox.Location = new Point(20, 5);

                CheckBox chkBox = new CheckBox();
                chkBox.Width = 20;
                chkBox.Height = 20;
                chkBox.Location = new Point(0, 50);

                Label lblName = new Label();
                lblName.Text = companyName;
                lblName.Width = 70;
                lblName.Height = 20;
                lblName.Location = new Point(22, 50);
                lblName.TextAlign = ContentAlignment.MiddleLeft;

                toolTip.SetToolTip(picBox, companyFull);
                toolTip.SetToolTip(lblName, companyFull);

                chkBox.CheckedChanged += (sender, e) =>
                {
                    if (chkBox.Checked)
                    {
                        companyPanel.BackColor = Color.LightBlue;
                    }
                    else
                    {
                        companyPanel.BackColor = Color.LightGray;
                    }
                };

                companyPanel.Controls.Add(picBox);
                companyPanel.Controls.Add(chkBox);
                companyPanel.Controls.Add(lblName);

                FlowEditViewSel.Controls.Add(companyPanel);  // Altere para o painel correto
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

        //M�todo para adicionar empresas a uma lista no editor
        private void BtnEditAddCL_Click(object sender, EventArgs e)
        {
            List<string> selectedCompanies = new List<string>();

            foreach (Control panel in FlowEditViewAll.Controls)
            {
                if (panel is Panel companyPanel)
                {
                    CheckBox companyCheckBox = companyPanel.Controls.OfType<CheckBox>().FirstOrDefault();

                    if (companyCheckBox != null && companyCheckBox.Checked)
                    {
                        string companyId = companyPanel.Tag.ToString();
                        selectedCompanies.Add(companyId);
                    }
                }
            }

            if (CboEditListSel.SelectedItem != null)
            {
                var selectedList = CboEditListSel.SelectedItem as dynamic;
                int selectedListId = selectedList.Value;

                List<DataRow> companyList = DataService.GetCompaniesByListId(selectedListId);

                if (selectedCompanies.Count > 0)
                {
                    DataService.AddCompaniesToAllocation(selectedListId, selectedCompanies);
                    TxtEditListMsg.Text = "Empresas alocadas com sucesso!";
                    EditListShowSel(companyList);
                    LoadAllComp(selectedListId);
                }
                else
                {
                    TxtEditListMsg.Text = "Nenhuma empresa foi alocada!";
                }
            }
            else
            {
                TxtEditListMsg.Text = "Nenhuma Lista foi selecionada!";
            }
        }

        //M�todo para carregar as ComboBox de Listas
        private void LoadLists()
        {
            DataTable listsTable = DataService.GetLists();

            CboCreateCardsList.Items.Clear();
            CboCreateCompanyList.Items.Clear();
            CboEditListSel.Items.Clear();

            foreach (DataRow row in listsTable.Rows)
            {
                string listName = row["Name"].ToString();
                int listId = Convert.ToInt32(row["Id"]);

                // Use a classe ListItem
                CboCreateCardsList.Items.Add(new ListItem { Text = listName, Value = listId });
                CboCreateCompanyList.Items.Add(new ListItem { Text = listName, Value = listId });
                CboEditListSel.Items.Add(new ListItem { Text = listName, Value = listId });
            }

            CboCreateCardsList.DisplayMember = "Text";
            CboCreateCompanyList.DisplayMember = "Text";
            CboEditListSel.DisplayMember = "Text";
        }

        //M�todo para detectar entradas ao Criar Cartelas
        private void BtnCreateCards_Click(object sender, EventArgs e)
        {
            TxtCreateCardsMsg.Text = "";
            int Qnt;

            string CardsName = BoxCreateCardsName.Text.Trim();
            string CardsQuant = BoxCreateCardsQuant.Text.Trim();
            string CardsEnd = BoxCreateCardsEnd.Text.Trim();
            string CardsTitle = BoxCreateCardsTitle.Text.Trim();

            if (CboCreateCardsList.SelectedItem != null)
            {
                int CardsList = (int)(CboCreateCardsList.SelectedItem as dynamic).Value;

                List<DataRow> CompList = DataService.GetCompaniesByListId(CardsList);

                int CompanyCount = CompList.Count;

                if (CompanyCount < 40)
                {
                    TxtCreateCardsMsg.Text = "A lista deve ter pelo menos 40 empresas, a lista " + CardsList + " tem apenas " + CompanyCount + "!";
                    return;
                }

                if (string.IsNullOrEmpty(CardsTitle))
                {
                    TxtCreateCardsMsg.Text = "Insira um t�tulo para as cartelas!";
                    return;
                }

                if (int.TryParse(CardsQuant, out Qnt))
                {
                    CardsService.CreateCards(CompList, CardsList, CompanyCount, Qnt, CardsTitle, CardsEnd, CardsName);
                }
                else
                {
                    TxtCreateCardsMsg.Text = "Apenas n�meros na quantidade!";
                    return;
                }
            }
            else
            {
                TxtCreateCardsMsg.Text = "Selecione uma lista!";
            }
        }

        //M�todo para selecionar Empresa para Edi��o
        private void CboEditComp_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboEditComp.SelectedItem != null)
            {
                CompanyModel selectedCompany = CboEditComp.SelectedItem as CompanyModel;

                if (selectedCompany != null)
                {
                    BoxEditNameComp.Text = selectedCompany.Name;
                    BoxEditCardNameComp.Text = selectedCompany.CardName;
                    BoxEditEmailComp.Text = selectedCompany.Email;
                    BoxEditPhoneComp.Text = selectedCompany.Phone;

                    PicEditLogoComp.Image = DataService.LoadImageFromFile(selectedCompany.Logo) ?? Image.FromFile(@"Images\default_logo.png");
                }
            }
        }

        //M�todo para carregar a lista de Empresas para Edi��o
        private void LoadComps()
        {
            List<CompanyModel> companyList = new List<CompanyModel>();

            DataTable compsTable = DataService.GetCompanies();

            foreach (DataRow row in compsTable.Rows)
            {
                CompanyModel company = new CompanyModel
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    CardName = row["CardName"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Logo = row["Logo"].ToString(),
                    AddDate = row["AddTime"].ToString()
                };

                companyList.Add(company);
            }

            CboEditComp.DataSource = companyList;

            CboEditComp.DisplayMember = "CardName";
            CboEditComp.ValueMember = "Id";

            BoxEditNameComp.Text = "";
            BoxEditCardNameComp.Text = "";
            BoxEditPhoneComp.Text = "";
            BoxEditEmailComp.Text = "";
            PicEditLogoComp.Image = null;
            CboEditComp.SelectedIndex = -1;
        }

        // M�todo para Excluir uma Empresa
        private void BtnRemoveComp_Click(object sender, EventArgs e)
        {
            if (CboEditComp.SelectedIndex == -1)
            {
                LblEditCompName.Text = "Por favor, selecione uma empresa para excluir.";
                return;
            }

            CompanyModel selectedCompany = CboEditComp.SelectedItem as CompanyModel;

            if (selectedCompany == null)
            {
                LblEditCompName.Text = "Erro ao carregar os detalhes da empresa selecionada.";
                return;
            }

            DialogResult dialogResult = MessageBox.Show($"Tem certeza de que deseja excluir a empresa '{selectedCompany.Name}'?",
                                                        "Confirmar Exclus�o",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    DataService.DeleteCompany(selectedCompany.Id);

                    LblEditCompName.Text = $"Empresa '{selectedCompany.Name}' exclu�da com sucesso.";

                    BoxEditNameComp.Text = "";
                    BoxEditCardNameComp.Text = "";
                    BoxEditPhoneComp.Text = "";
                    BoxEditEmailComp.Text = "";
                    PicEditLogoComp.Image = null;
                    CboEditComp.SelectedIndex = -1;
                    LoadComps();
                }
                catch (Exception ex)
                {
                    LblEditCompName.Text = "Erro ao excluir a empresa. " + ex.Message;
                }
            }
            else
            {
                LblEditCompName.Text = "A exclus�o foi cancelada.";
            }
        }

        //M�todo para Editar uma Empresa
        private void BtnEditComp_Click(object sender, EventArgs e)
        {
            if (CboEditComp.SelectedIndex == -1)
            {
                LblEditMsgComp.Text = "Por favor, selecione uma empresa para editar.";
                return;
            }

            CompanyModel selectedCompany = CboEditComp.SelectedItem as CompanyModel;

            if (selectedCompany == null)
            {
                LblEditCompName.Text = "Erro ao carregar os detalhes da empresa selecionada.";
                return;
            }

            CompanyModel company = new CompanyModel
            {
                Id = selectedCompany.Id,
                Name = BoxEditNameComp.Text.Trim(),
                CardName = BoxEditCardNameComp.Text.Trim(),
                Phone = BoxEditPhoneComp.Text.Trim(),
                Email = BoxEditEmailComp.Text.Trim(),
                AddDate = DateTime.Now.ToString("MMddyyyy - HH:mm:ss")
            };

            if (PicEditLogoComp.Image != null && !string.IsNullOrEmpty(selectedImagePath))
            {
                company.Logo = "logo_" + Guid.NewGuid().ToString() + Path.GetExtension(selectedImagePath);
                SaveImageToPC(PicEditLogoComp.Image, company.Logo);
            }
            else
            {
                company.Logo = selectedCompany.Logo;
            }

            if (!string.IsNullOrEmpty(company.Name) && !string.IsNullOrEmpty(company.CardName))
            {
                try
                {
                    DataService.UpdateCompany(company.Id, company.Name, company.CardName, company.Phone, company.Email, company.Logo, company.AddDate);
                    LblEditMsgComp.Text = "Empresa " + company.Name + " editada com sucesso.";
                }
                catch
                {
                    LblEditMsgComp.Text = "Erro ao editar a empresa.";
                }

                BoxEditNameComp.Text = "";
                BoxEditCardNameComp.Text = "";
                BoxEditPhoneComp.Text = "";
                BoxEditEmailComp.Text = "";
                PicEditLogoComp.Image = null;
                CboEditComp.SelectedIndex = -1;
                LoadComps();
            }
            else
            {
                LblEditMsgComp.Text = "Nome e Nome para Cartela s�o obrigat�rios.";
            }
        }
    }
}
