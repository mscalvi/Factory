using BingoManager.Models;
using BingoManager.Services;
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

        //Criação
        //Método para Criar uma Lista
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

        // Método para Criar uma empresa
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
                // Verifica se a empresa já existe
                if (DataService.CompanyExists(company.Name, company.CardName))
                {
                    TxtCreateCompanyMessage.Text = "Já existe uma empresa com o mesmo Nome ou Nome para Cartela.";
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

                        TxtCreateCompanyMessage.Text = $"Empresa {company.Name} adicionada ao banco de dados e à lista com sucesso.";
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

                // Limpa os campos após a criação
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
                TxtCreateCompanyMessage.Text = "Nome e Nome para Cartela são obrigatórios.";
            }
        }

        // Método para Criar Cartelas
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
                    TxtCreateCardsMsg.Text = "Insira um título para as cartelas!";
                    return;
                }

                if (int.TryParse(CardsQuant, out Qnt))
                {
                    CardsService.CreateCards(CompList, CardsList, CompanyCount, Qnt, CardsTitle, CardsEnd, CardsName);
                }
                else
                {
                    TxtCreateCardsMsg.Text = "Apenas números na quantidade!";
                    return;
                }
            }
            else
            {
                TxtCreateCardsMsg.Text = "Selecione uma lista!";
            }

            LoadGames();
        }


        //Edição
        //Configuração da Edição de Listas
        private void EditListConfigureLayout()
        {
            FlowEditViewAll.AutoScroll = true;
            FlowEditViewSel.AutoScroll = true;
        }

        // Método para carregar todas as empresas e filtrar as que já estão na lista selecionada
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
                // Carregar as empresas que já estão na lista selecionada
                List<DataRow> companiesInList = DataService.GetCompaniesByListId(selectedListId.Value);

                // Filtrar as empresas que ainda não estão na lista selecionada
                allCompaniesList = allCompaniesList.Where(row => !companiesInList.Any(c => c["Id"].ToString() == row["Id"].ToString()))
                                                   .ToList();
            }

            // Exibir as empresas filtradas
            EditListShowComps(allCompaniesList);
        }

        // Método para manipular a mudança de valor da ComboBox de listas
        private void CboEditListSel_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboEditListSel.SelectedItem != null)
            {
                int selectedListId = (int)(CboEditListSel.SelectedItem as dynamic).Value;

                // Carrega as empresas não alocadas na lista selecionada
                LoadAllComp(selectedListId);

                // Carrega as empresas já associadas à lista selecionada
                List<DataRow> companyList = DataService.GetCompaniesByListId(selectedListId);

                // Exibe apenas as empresas já associadas
                EditListShowSel(companyList);
            }
        }

        //Método para exibir as empresas de uma lista selecionada
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

        //Método para mostrar as Empresas de uma Lista
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

        //Método para filtrar as Empresas mostradas
        private void BoxEditFilterCL_TextChanged(object sender, EventArgs e)
        {
            string filterText = BoxEditFilterCL.Text.ToLower();

            var filteredList = allCompaniesList
                .Where(row => row.Field<string>("Name").ToLower().Contains(filterText))
                .ToList();

            EditListShowComps(filteredList);
        }

        //Método para adicionar empresas a uma lista no editor
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

        //Método para remover empresas a uma lista no editor
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
                    LblEditListMsg.Text = "Nenhuma empresa foi selecionada para remoção!";
                }
            }
            else
            {
                LblEditListMsg.Text = "Nenhuma lista foi selecionada!";
            }

            EditListShowSel(companyList);
            LoadAllComp(selectedListId);
        }

        //Método para selecionar Empresa para Edição
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

        // Método para Excluir uma Empresa
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
                $"que foram feitas com Listas que a utilizam também serão excluídas.",
                                                        "Confirmar Exclusão",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    DataService.DeleteCompany(selectedCompany.Id);

                    LblEditCompName.Text = $"Empresa '{selectedCompany.Name}' excluída com sucesso.";

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
                LblEditCompName.Text = "A exclusão foi cancelada.";
            }
        }

        //Método para Editar uma Empresa
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
                LblEditMsgComp.Text = "Nome e Nome para Cartela são obrigatórios.";
            }
        }

        // Método para Excluir uma Lista
        private void BtnEditListDelete_Click(object sender, EventArgs e)
        {
            if (CboEditListSel.SelectedIndex == -1)
            {
                LblEditListMsg.Text = "Por favor, selecione uma lista para excluir.";
                return;
            }

            // Obtém a lista selecionada
            dynamic selectedList = CboEditListSel.SelectedItem;

            if (selectedList == null)
            {
                LblEditListMsg.Text = "Erro ao carregar os detalhes da lista selecionada.";
                return;
            }

            int selectedListId = selectedList.Value;
            string selectedListName = selectedList.Text;

            DialogResult dialogResult = MessageBox.Show($"Tem certeza de que deseja excluir a lista '{selectedListName}'? Todas as cartelas associadas também serão excluídas.",
                                                        "Confirmar Exclusão",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    // Chama o método de exclusão de lista no DataService
                    DataService.DeleteList(selectedListId);

                    LblEditListMsg.Text = $"Lista '{selectedListName}' excluída com sucesso.";

                    CboEditListSel.SelectedIndex = -1;
                    FlowEditViewSel.Controls.Clear();
                    LoadLists(); // Atualiza as listas disponíveis após a exclusão
                }
                catch (Exception ex)
                {
                    LblEditListMsg.Text = "Erro ao excluir a lista. " + ex.Message;
                }
            }
            else
            {
                LblEditListMsg.Text = "A exclusão foi cancelada.";
            }
        }


        //Gerais
        //Método para carregar as ComboBox de Listas
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

        //Método para carregar a lista de Empresas para Edição
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
        //Método para carregar todos os jogos para Jogar
        private void LoadGames()
        {
            DataTable gamesTable = DataService.GetAllCards();

            CboPlaySelection.Items.Clear();

            foreach (DataRow row in gamesTable.Rows)
            {
                string cardName = row["Name"].ToString();
                int cardId = Convert.ToInt32(row["Id"]);

                CboPlaySelection.Items.Add(new { Text = cardName, Value = cardId });
            }

            CboPlaySelection.DisplayMember = "Text";
            CboPlaySelection.ValueMember = "Value";
        }

        // Método para começar o jogo com base no conjunto de fichas selecionado
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

        // Método para mostrar as Empresas durante o jogo
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

            // Adicionar botões ao grupo B
            foreach (var company in gameData.GroupB)
            {
                Button companyButton = new Button
                {
                    Text = Number.ToString(),
                    Tag = company.Id,
                    Width = buttonSize,
                    Height = buttonSize,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                Number++;
                companyButton.Click += CompanyButton_Click;
                FlwPlayB.Controls.Add(companyButton);
            }

            // Adicionar botões ao grupo I
            foreach (var company in gameData.GroupI)
            {
                Button companyButton = new Button
                {
                    Text = Number.ToString(),
                    Tag = company.Id,
                    Width = buttonSize,
                    Height = buttonSize,
                    TextAlign = ContentAlignment.MiddleCenter 
                };
                Number++;
                companyButton.Click += CompanyButton_Click;
                FlwPlayI.Controls.Add(companyButton);
            }

            // Adicionar botões ao grupo N
            foreach (var company in gameData.GroupN)
            {
                Button companyButton = new Button
                {
                    Text = Number.ToString(),
                    Tag = company.Id,
                    Width = buttonSize,
                    Height = buttonSize,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                Number++;
                companyButton.Click += CompanyButton_Click;
                FlwPlayN.Controls.Add(companyButton);
            }

            // Adicionar botões ao grupo G
            foreach (var company in gameData.GroupG)
            {
                Button companyButton = new Button
                {
                    Text = Number.ToString(),
                    Tag = company.Id,
                    Width = buttonSize,
                    Height = buttonSize,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                Number++;
                companyButton.Click += CompanyButton_Click;
                FlwPlayG.Controls.Add(companyButton);
            }

            // Adicionar botões ao grupo O
            foreach (var company in gameData.GroupO)
            {
                Button companyButton = new Button
                {
                    Text = Number.ToString(),
                    Tag = company.Id,
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
            PnlPlayFather.Location = new Point(
                this.ClientSize.Width / 2 - PnlPlayFather.Size.Width / 2,
                this.ClientSize.Height / 2 - PnlPlayFather.Size.Height / 2);
            PnlPlayFather.Anchor = AnchorStyles.None;

            PnlPlayNumbersB.Location = new Point(
                this.ClientSize.Width / 2 - PnlPlayNumbersB.Size.Width / 2,
                this.ClientSize.Height / 2 - PnlPlayNumbersB.Size.Height / 2);
            PnlPlayNumbersB.Anchor = AnchorStyles.None;

            PnlPlayNumbersI.Location = new Point(
                this.ClientSize.Width / 2 - PnlPlayNumbersI.Size.Width / 2,
                this.ClientSize.Height / 2 - PnlPlayNumbersI.Size.Height / 2);
            PnlPlayNumbersI.Anchor = AnchorStyles.None;

            PnlPlayNumbersN.Location = new Point(
                this.ClientSize.Width / 2 - PnlPlayNumbersN.Size.Width / 2,
                this.ClientSize.Height / 2 - PnlPlayNumbersN.Size.Height / 2);
            PnlPlayNumbersN.Anchor = AnchorStyles.None;

            PnlPlayNumbersG.Location = new Point(
                this.ClientSize.Width / 2 - PnlPlayNumbersG.Size.Width / 2,
                this.ClientSize.Height / 2 - PnlPlayNumbersG.Size.Height / 2);
            PnlPlayNumbersG.Anchor = AnchorStyles.None;

            PnlPlayNumbersO.Location = new Point(
                this.ClientSize.Width / 2 - PnlPlayNumbersO.Size.Width / 2,
                this.ClientSize.Height / 2 - PnlPlayNumbersO.Size.Height / 2);
            PnlPlayNumbersO.Anchor = AnchorStyles.None;

            // Para cada FlowPanel (B, I, N, G, O)
            foreach (var flowPanel in new[] { FlwPlayB, FlwPlayI, FlwPlayN, FlwPlayG, FlwPlayO })
            {
                flowPanel.FlowDirection = FlowDirection.LeftToRight; // Direção do fluxo
                flowPanel.WrapContents = true; // Permite que os controles quebrem para a próxima linha
                flowPanel.AutoSize = true; // Ajusta o tamanho automaticamente com base no conteúdo
                flowPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink; // Permite que o FlowLayoutPanel cresça
                flowPanel.Padding = new Padding(10); // Espaçamento interno do FlowPanel
                flowPanel.Margin = new Padding(0); // Margem do FlowPanel

                // Se o FlowPanel estiver em um painel, centralize-o
                if (flowPanel.Parent is Panel parentPanel)
                {
                    parentPanel.AutoSize = true; // Ajusta o tamanho automaticamente
                    parentPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink; // Permite que o painel cresça
                    parentPanel.Padding = new Padding(0); // Sem margens
                    parentPanel.Margin = new Padding(0); // Sem margens
                }
            }
        }

        // Método para o evento de clique do botão de cada empresa
        private void CompanyButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int companyId = (int)button.Tag;
                                                
                MessageBox.Show($"Botão da empresa {button.Text} clicado! (ID: {companyId})");
            }
        }



    }
}
