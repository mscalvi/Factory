using BingoManager.Models;
using BingoManager.Services;
using System.ComponentModel.Design;
using System.Data;
using System.Xml.Linq;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

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
            LoadGames();
        }

        //Cria��o
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

            LoadLists();
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
            LoadLists();
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

        // M�todo para Criar uma empresa
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
                // Verifica se a empresa j� existe
                if (DataService.CompanyExists(company.Name, company.CardName))
                {
                    TxtCreateCompanyMessage.Text = "J� existe uma empresa com o mesmo Nome ou Nome para Cartela.";
                    return;
                }

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

                // Limpa os campos ap�s a cria��o
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

        // M�todo para Criar Cartelas
        private void BtnCreateCards_Click(object sender, EventArgs e)
        {
            TxtCreateCardsMsg.Text = "";
            int Qnt;

            string CardsName = BoxCreateCardsName.Text.Trim();
            string CardsQuant = BoxCreateCardsQuant.Text.Trim();
            string CardsEnd = BoxCreateCardsEnd.Text.Trim();
            string CardsTitle = BoxCreateCardsTitle.Text.Trim();

            if (string.IsNullOrEmpty(CardsName))
            {
                TxtCreateCardsMsg.Text = "Insira um nome para o conjunto de cartelas!";
                return;
            }

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

            LoadGames();
            BoxCreateCardsEnd.Text = string.Empty;
            BoxCreateCardsName.Text = string.Empty;
            BoxCreateCardsQuant.Text = string.Empty;
            BoxCreateCardsTitle.Text = string.Empty;
            CboCreateCardsList.SelectedIndex = -1;
            TxtCreateCardsMsg.Text = "Cartelas criadas com sucesso!";
        }


        //Edi��o
        //Configura��o da Edi��o de Listas
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

        //M�todo para exibir as empresas de uma lista selecionada
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
                companyPanel.Tag = CompanyId;
                companyPanel.Width = 100;
                companyPanel.Height = 70;
                companyPanel.Margin = new Padding(15, 0, 14, 0);


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
                picBox.Width = 80;
                picBox.Height = 50;
                picBox.Location = new Point(10, 5);

                CheckBox chkBox = new CheckBox();
                chkBox.Width = 15;
                chkBox.Height = 15;
                chkBox.Location = new Point(5, 55);

                Label lblName = new Label();
                lblName.Text = companyName;
                lblName.Width = 75;
                lblName.Height = 20;
                lblName.Location = new Point(25, 50);
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

        //M�todo para mostrar as Empresas de uma Lista
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
                companyPanel.Tag = CompanyId;
                companyPanel.Width = 100;
                companyPanel.Height = 70;
                companyPanel.Margin = new Padding(15, 0, 14, 0);


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
                picBox.Width = 80;
                picBox.Height = 50;
                picBox.Location = new Point(10, 5);

                CheckBox chkBox = new CheckBox();
                chkBox.Width = 15;
                chkBox.Height = 15;
                chkBox.Location = new Point(5, 55);

                Label lblName = new Label();
                lblName.Text = companyName;
                lblName.Width = 75;
                lblName.Height = 20;
                lblName.Location = new Point(25, 50);
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

        //M�todo para filtrar as Empresas mostradas
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
            var selectedList = CboEditListSel.SelectedItem as dynamic;
            int selectedListId = selectedList.Value;

            List<DataRow> companyList = DataService.GetCompaniesByListId(selectedListId);

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
                if (selectedCompanies.Count > 0)
                {
                    DataService.AddCompaniesToAllocation(selectedListId, selectedCompanies);
                    companyList = DataService.GetCompaniesByListId(selectedListId);
                    LblEditListMsg.Text = "Empresas alocadas com sucesso!";
                }
                else
                {
                    LblEditListMsg.Text = "Nenhuma empresa foi alocada!";
                }
            }
            else
            {
                LblEditListMsg.Text = "Nenhuma Lista foi selecionada!";
            }
            EditListShowSel(companyList);
            LoadAllComp(selectedListId);
        }

        //M�todo para remover empresas a uma lista no editor
        private void BtnEditRemoveCL_Click(object sender, EventArgs e)
        {
            var selectedList = CboEditListSel.SelectedItem as dynamic;
            int selectedListId = selectedList.Value;

            List<DataRow> companyList = new List<DataRow>();

            List<string> selectedCompanies = new List<string>();

            foreach (Control panel in FlowEditViewSel.Controls)
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

                if (selectedCompanies.Count > 0)
                {
                    DataService.RemoveCompaniesFromAllocation(selectedListId, selectedCompanies);
                    LblEditListMsg.Text = "Empresas removidas da lista com sucesso!";
                    companyList = DataService.GetCompaniesByListId(selectedListId);
                }
                else
                {
                    LblEditListMsg.Text = "Nenhuma empresa foi selecionada para remo��o!";
                }
            }
            else
            {
                LblEditListMsg.Text = "Nenhuma lista foi selecionada!";
            }

            EditListShowSel(companyList);
            LoadAllComp(selectedListId);
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

            DialogResult dialogResult = MessageBox.Show($"Tem certeza de que deseja excluir a empresa '{selectedCompany.Name}'? Todas as Cartelas " +
                $"que foram feitas com Listas que a utilizam tamb�m ser�o exclu�das.",
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

        // M�todo para Excluir uma Lista
        private void BtnEditListDelete_Click(object sender, EventArgs e)
        {
            if (CboEditListSel.SelectedIndex == -1)
            {
                LblEditListMsg.Text = "Por favor, selecione uma lista para excluir.";
                return;
            }

            // Obt�m a lista selecionada
            dynamic selectedList = CboEditListSel.SelectedItem;

            if (selectedList == null)
            {
                LblEditListMsg.Text = "Erro ao carregar os detalhes da lista selecionada.";
                return;
            }

            int selectedListId = selectedList.Value;
            string selectedListName = selectedList.Text;

            DialogResult dialogResult = MessageBox.Show($"Tem certeza de que deseja excluir a lista '{selectedListId}'? Todas as cartelas associadas tamb�m ser�o exclu�das.",
                                                        "Confirmar Exclus�o",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    // Chama o m�todo de exclus�o de lista no DataService
                    DataService.DeleteList(selectedListId);

                    LblEditListMsg.Text = $"Lista '{selectedListName}' exclu�da com sucesso.";

                    CboEditListSel.SelectedIndex = -1;
                    FlowEditViewSel.Controls.Clear();
                    LoadLists();
                }
                catch (Exception ex)
                {
                    LblEditListMsg.Text = "Erro ao excluir a lista. " + ex.Message;
                }
            }
            else
            {
                LblEditListMsg.Text = "A exclus�o foi cancelada.";
            }

            LoadAllComp();
        }


        //Gerais
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



        //Jogar
        //M�todo para carregar todos os jogos para Jogar
        private void LoadGames()
        {
            DataTable gamesTable = DataService.GetAllCards();

            CboPlaySelection.Items.Clear();

            foreach (DataRow row in gamesTable.Rows)
            {
                string cardName = row["Name"].ToString();
                int cardId = Convert.ToInt32(row["SetId"]);

                CboPlaySelection.Items.Add(new { Text = cardName, Value = cardId });
            }

            CboPlaySelection.DisplayMember = "Text";
            CboPlaySelection.ValueMember = "Value";
        }

        // M�todo para come�ar o jogo com base no conjunto de fichas selecionado
        private void BtnPlaySelection_Click(object sender, EventArgs e)
        {
            if (CboPlaySelection.SelectedItem != null)
            {
                var selectedGame = CboPlaySelection.SelectedItem as dynamic;

                int selectedGameId = selectedGame.Value;

                var gameData = DataService.GetGameCompanies(selectedGameId);

                if (gameData != null)
                {
                    DisplayGamePanels(gameData);
                    CboPlaySelection.Enabled = false;
                }
                else
                {
                    LblPlayMsg.Text = "Erro ao carregar os dados do jogo selecionado.";
                }
            }
            else
            {
                LblPlayMsg.Text = "Por favor, selecione um jogo.";
            }
        }

        // M�todo para mostrar as Empresas durante o jogo
        private void DisplayGamePanels(GameData gameData)
        {
            int buttonSize = 50; 
            int panelWidth = FlwPlayB.Width; 
            int buttonsPerRow = panelWidth / buttonSize;

            int Number = 1;

            FlwPlayB.Controls.Clear();
            FlwPlayI.Controls.Clear();
            FlwPlayN.Controls.Clear();
            FlwPlayG.Controls.Clear();
            FlwPlayO.Controls.Clear();

            SetupFlowPanels();

            // Adicionar bot�es ao grupo B
            foreach (var company in gameData.GroupB)
            {
                Button companyButton = new Button
                {
                    Text = Number.ToString(),
                    Tag = company,
                    Width = buttonSize,
                    Height = buttonSize,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                Number++;
                companyButton.Click += CompanyButton_Click;
                FlwPlayB.Controls.Add(companyButton);
            }

            // Adicionar bot�es ao grupo I
            foreach (var company in gameData.GroupI)
            {
                Button companyButton = new Button
                {
                    Text = Number.ToString(),
                    Tag = company,
                    Width = buttonSize,
                    Height = buttonSize,
                    TextAlign = ContentAlignment.MiddleCenter 
                };
                Number++;
                companyButton.Click += CompanyButton_Click;
                FlwPlayI.Controls.Add(companyButton);
            }

            // Adicionar bot�es ao grupo N
            foreach (var company in gameData.GroupN)
            {
                Button companyButton = new Button
                {
                    Text = Number.ToString(),
                    Tag = company,
                    Width = buttonSize,
                    Height = buttonSize,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                Number++;
                companyButton.Click += CompanyButton_Click;
                FlwPlayN.Controls.Add(companyButton);
            }

            // Adicionar bot�es ao grupo G
            foreach (var company in gameData.GroupG)
            {
                Button companyButton = new Button
                {
                    Text = Number.ToString(),
                    Tag = company,
                    Width = buttonSize,
                    Height = buttonSize,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                Number++;
                companyButton.Click += CompanyButton_Click;
                FlwPlayG.Controls.Add(companyButton);
            }

            // Adicionar bot�es ao grupo O
            foreach (var company in gameData.GroupO)
            {
                Button companyButton = new Button
                {
                    Text = Number.ToString(),
                    Tag = company,
                    Width = buttonSize,
                    Height = buttonSize,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                Number++;
                companyButton.Click += CompanyButton_Click;
                FlwPlayO.Controls.Add(companyButton);
            }

            LblPlayMsg.Text = "Jogo carregado!";
        }

        // Configurando os FlowLayoutPanels
        private void SetupFlowPanels()
        {
            int Width = 0;
            int Height = 0;

            foreach (var panel in new[] { PnlPlayNumbersB, PnlPlayNumbersI, PnlPlayNumbersN, PnlPlayNumbersG, PnlPlayNumbersO})
            {
                Height += panel.Height;
                panel.AutoSize = true; 
                panel.AutoSizeMode = AutoSizeMode.GrowAndShrink; 
                panel.Padding = new Padding(0); 
                panel.Margin = new Padding(0); 
                panel.Dock = DockStyle.None;
            }

            foreach (var flowPanel in new[] { FlwPlayB, FlwPlayI, FlwPlayN, FlwPlayG, FlwPlayO })
            {
                flowPanel.FlowDirection = FlowDirection.LeftToRight; 
                flowPanel.WrapContents = true; 
                flowPanel.AutoSize = true; 
                flowPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink; 
                flowPanel.Padding = new Padding(10); 
                flowPanel.Margin = new Padding(0);
            }

            PnlPlayFather.Location = new Point(
                (1314 / 2) - (PnlPlayNumbersB.Width / 2),
                (633 / 2) - (Height / 2));
            PnlPlayFather.Width = PnlPlayNumbersB.Width;
            PnlPlayFather.Anchor = AnchorStyles.None;
            PnlPlayFather.AutoSizeMode = AutoSizeMode.GrowAndShrink;

        }

        // M�todo para o evento de clique do bot�o de cada empresa
        private void CompanyButton_Click(object sender, EventArgs e)
        {
            int bingoPhase = 0;

            if (RdPlay1.Checked)
            {
                bingoPhase = 1;
            }
            else if (RdPlay2.Checked)
            {
                bingoPhase = 2;
            }

            var selectedGame = CboPlaySelection.SelectedItem as dynamic;

            int setId = selectedGame.Value;

            Button clickedButton = sender as Button;

            if (clickedButton != null && clickedButton.Tag is CompanyModel selectedCompany)
            {
                string logoPath = Path.Combine(Application.StartupPath, "Images", selectedCompany.Logo);

                clickedButton.BackColor = Color.Red;

                PlayService.AddCompany(selectedCompany.Id);

                if (File.Exists(logoPath))
                {
                    PicPlayLogo.Image = Image.FromFile(logoPath);
                }
                else
                {
                    PicPlayLogo.Image = null;
                }

                List<int> winningCards = new List<int>();

                List<int> cardNumbers = PlayService.CheckCards(selectedCompany.Id, setId);

                string cardNumbersText = string.Join(", ", cardNumbers);

                LblPlayMsg.Text = string.IsNullOrEmpty(cardNumbersText) ? "Nenhuma cartela sorteada." : cardNumbersText;

                if (!string.IsNullOrEmpty(cardNumbersText))
                {
                    winningCards = PlayService.CheckBingo(cardNumbers, setId, bingoPhase, selectedCompany.Id);

                    if (winningCards.Count > 0)
                    {
                        string winningCardsText = string.Join(", ", winningCards);

                        LblPlayMsg.Text += string.IsNullOrEmpty(LblPlayMsg.Text) ? "" : "\n\n";
                        LblPlayMsg.Text += $"Cartelas vencedoras: {winningCardsText}";
                    }
                }
            }
        }


    }
}
