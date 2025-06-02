using BingoManager.Models;
using BingoManager.Services;
using BingoManager.Views;
using System.ComponentModel.Design;
using System.Data;
using System.Xml.Linq;
using Microsoft.Win32;
using System.Windows.Forms;

namespace BingoManager
{
    public partial class MainView : Form
    {
        private string selectedImagePath;
        private ToolTip toolTip;
        private List<DataRow> allCompaniesList = new List<DataRow>();
        private LogoView logoDisplayForm;
        private readonly string appDataPath;
        private readonly string imageFolderPath;
        private System.Windows.Forms.ToolTip _toolTip;

        public MainView()
        {
            InitializeComponent();

            _toolTip = new System.Windows.Forms.ToolTip
            {
                AutoPopDelay = 5000,  // quanto tempo o balão fica visível
                InitialDelay = 500,   // antes do primeiro aparecimento
                ReshowDelay = 100,   // antes de reaparecer
                ShowAlways = true   // mesmo sem foco
            };

            DataService.InitializeDatabase();

            HideTabControlTabs();

            toolTip = new ToolTip
            {
                AutoPopDelay = 0,
                InitialDelay = 0,
                ReshowDelay = 500,
                ShowAlways = true
            };

            appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            imageFolderPath = Path.Combine(appDataPath, "BingoManager", "Images");

            // Subscrição ao evento para detectar mudanças nos monitores
            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);

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

            // Definindo limites de caracteres
            int maxNameLength = 50;
            int maxDescriptionLength = 250;

            // Verifica se o nome e a descrição não estão vazios e se estão dentro dos limites
            if (!string.IsNullOrEmpty(list.Name))
            {
                if (list.Name.Length > maxNameLength)
                {
                    LblCreateListMessage.Text = $"O nome da Lista deve ter no máximo {maxNameLength} caracteres.";
                    return;
                }

                if (list.Description.Length > maxDescriptionLength)
                {
                    LblCreateListMessage.Text = $"A descrição da Lista deve ter no máximo {maxDescriptionLength} caracteres.";
                    return;
                }

                if (string.IsNullOrEmpty(list.Description))
                {
                    list.Description = "*";
                }

                try
                {
                    // Insere a lista sem o logo correto, pois ainda não temos o ID
                    int listId = DataService.AddList(list.Name, list.Description, "default_logo.jpg");

                    // Atualiza o logo com base no listId gerado
                    string logoFileName = "default_logo_" + listId;

                    // Se houver uma imagem no PictureBox, salva com o nome do arquivo correto
                    if (PicCreateListLogo.Image != null)
                    {
                        logoFileName = "logo_" + Guid.NewGuid().ToString() + Path.GetExtension(selectedImagePath);
                        SaveImageToPC(PicCreateListLogo.Image, logoFileName);
                    }

                    // Atualiza o logo no banco de dados
                    DataService.UpdateListLogo(listId, logoFileName);

                    LblCreateListMessage.Text = "Lista " + list.Name + " adicionada com sucesso.";
                    BoxCreateListName.Text = "";
                    BoxCreateListDescription.Text = "";
                    PicCreateListLogo.Image = null;

                    // Pergunta ao usuário se ele deseja adicionar elementos à lista
                    DialogResult result = MessageBox.Show("Deseja adicionar Elementos que já foram criados à nova Lista?", "Adicionar Elementos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        FlowEditViewSel.Controls.Clear();

                        LoadLists();
                        LoadComps();
                        EditListConfigureLayout();
                        LoadAllComp();

                        MainPage.SelectedTab = TabEditPage;
                        EditPage.SelectedTab = TabEditList;
                    }
                }
                catch (Exception ex)
                {
                    LblCreateListMessage.Text = "Erro ao conectar ao Banco de Dados: " + ex.Message;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(BoxCreateListName.Text))
                {
                    LblCreateListMessage.Text = "Nome da Lista é obrigatório.";
                }
                else
                {
                    LblCreateListMessage.Text = "Erro ao adicionar a Lista.";
                }
            }

            LoadLists();
        }

        private void BtnCreateListLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                PicCreateListLogo.Image = Image.FromFile(selectedImagePath);
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
            // Define o caminho para a pasta AppData específica do aplicativo
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appFolder = Path.Combine(appDataPath, "BingoManager", "Images");

            // Cria a pasta, caso ela ainda não exista
            if (!Directory.Exists(appFolder))
            {
                Directory.CreateDirectory(appFolder);
            }

            // Define o caminho completo para o arquivo de imagem
            string filePath = Path.Combine(appFolder, fileName);

            // Salva a imagem
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                File.WriteAllBytes(filePath, ms.ToArray());
            }
        }


        // Método para Criar uma Elemento
        private void BtnCreateCompany_Click(object sender, EventArgs e)
        {
            CompanyModel company = new CompanyModel();

            company.Name = BoxCreateCompanyName.Text.Trim();
            company.CardName = BoxCreateCompanyCardName.Text.Trim();
            company.Phone = BoxCreateCompanyPhone.Text.Trim();
            company.Email = BoxCreateCompanyEmail.Text.Trim();

            // Definindo limites de caracteres
            int maxNameLength = 60;
            int maxCardNameLength = 45;
            int maxContactLength = 250;

            // Validação dos campos
            if (string.IsNullOrEmpty(company.Name) || string.IsNullOrEmpty(company.CardName))
            {
                LblCreateCompanyMessage.Text = "Nome e Nome para Cartela são obrigatórios.";
                return;
            }

            if (company.Name.Length > maxNameLength)
            {
                LblCreateCompanyMessage.Text = $"O nome da Elemento deve ter no máximo {maxNameLength} caracteres.";
                return;
            }

            if (company.CardName.Length > maxCardNameLength)
            {
                LblCreateCompanyMessage.Text = $"O nome para cartela deve ter no máximo {maxCardNameLength} caracteres.";
                return;
            }

            if (company.Phone.Length > maxContactLength)
            {
                LblCreateCompanyMessage.Text = $"A anotação 1 deve ter no máximo {maxContactLength} caracteres.";
                return;
            }

            if (company.Email.Length > maxContactLength)
            {
                LblCreateCompanyMessage.Text = $"A anotação 2 deve ter no máximo {maxContactLength} caracteres.";
                return;
            }

            // Atribuição do logo
            if (PicCreateCompanyLogo.Image != null)
            {
                company.Logo = "logo_" + Guid.NewGuid().ToString() + Path.GetExtension(selectedImagePath);
                SaveImageToPC(PicCreateCompanyLogo.Image, company.Logo);
            }
            else
            {
                company.Logo = "default_logo.jpg";
            }

            company.AddDate = DateTime.Now.ToString("MMddyyyy - HH:mm:ss");

            // Verifica se a Elemento já existe
            if (DataService.CompanyExists(company.Name, company.CardName))
            {
                LblCreateCompanyMessage.Text = "Já existe um Elemento com o mesmo Nome ou Nome para Cartela.";
                return;
            }

            try
            {
                int companyId = DataService.AddCompany(company.Name, company.CardName, company.Phone, company.Email, company.Logo, company.AddDate);

                if (CboCreateCompanyList.SelectedItem != null)
                {
                    ListItem selectedList = CboCreateCompanyList.SelectedItem as ListItem;
                    int selectedListId = selectedList.Value;

                    DataService.AddCompaniesToAllocation(selectedListId, new List<string> { companyId.ToString() });

                    LblCreateCompanyMessage.Text = $"Elemento, {company.Name}, adicionado ao banco de dados e à Lista, {CboCreateCompanyList.Text}, com sucesso.";
                }
                else
                {
                    LblCreateCompanyMessage.Text = $"Elemento, {company.Name}, adicionado ao banco de dados com sucesso.";
                }
            }
            catch (Exception ex)
            {
                LblCreateCompanyMessage.Text = "Erro ao adicionar o Elemento: " + ex.Message;
            }

            // Limpa os campos após a criação
            BoxCreateCompanyName.Text = "";
            BoxCreateCompanyCardName.Text = "";
            BoxCreateCompanyEmail.Text = "";
            BoxCreateCompanyPhone.Text = "";
            PicCreateCompanyLogo.Image = null;
            CboCreateCompanyList.SelectedIndex = -1;
        }

        // Método para Criar Cartelas// Método para Criar Cartelas
        private void BtnCreateCards_Click(object sender, EventArgs e)
        {
            LblCreateCardsMsg.Text = "";
            int Qnt;

            string CardsName = BoxCreateCardsName.Text.Trim();
            string CardsQuant = BoxCreateCardsQuant.Text.Trim();
            string CardsEnd = BoxCreateCardsEnd.Text.Trim();
            string CardsTitle = BoxCreateCardsTitle.Text.Trim();

            // Definindo limites de caracteres e quantidade
            int maxNameLength = 40;
            int maxTitleLength = 80;
            int maxEndLength = 150;
            int maxQuantity = 1000;

            // Verifica se o nome do conjunto é válido
            if (string.IsNullOrEmpty(CardsName) || CardsName.Length > maxNameLength)
            {
                LblCreateCardsMsg.Text = $"Insira um nome para o conjunto de cartelas com no máximo {maxNameLength} caracteres!";
                return;
            }

            // Verifica se o nome do conjunto já existe no banco de dados
            if (DataService.CardSetExists(CardsName))
            {
                LblCreateCardsMsg.Text = "Já existe um conjunto de cartelas com esse nome!";
                return;
            }

            if (CboCreateCardsList.SelectedItem != null)
            {
                int CardsList = (int)(CboCreateCardsList.SelectedItem as dynamic).Value;

                List<DataRow> CompList = DataService.GetCompaniesByListId(CardsList);

                int CompanyCount = CompList.Count;

                if (CompanyCount < 40)
                {
                    LblCreateCardsMsg.Text = $"A Lista deve ter pelo menos 40 Elementos, a Lista {CardsList} tem apenas {CompanyCount}!";
                    return;
                }

                // Verifica o título
                if (string.IsNullOrEmpty(CardsTitle) || CardsTitle.Length > maxTitleLength)
                {
                    LblCreateCardsMsg.Text = $"Insira um título para as Cartelas com no máximo {maxTitleLength} caracteres!";
                    return;
                }

                // Verifica o final
                if (string.IsNullOrEmpty(CardsEnd) || CardsEnd.Length > maxEndLength)
                {
                    LblCreateCardsMsg.Text = $"O final deve ter no máximo {maxEndLength} caracteres!";
                    return;
                }

                // Verifica a quantidade
                if (int.TryParse(CardsQuant, out Qnt) && Qnt <= maxQuantity)
                {
                    BtnCreateCards.Enabled = false;
                    CardsService.CreateCards(CompList, CardsList, CompanyCount, Qnt, CardsTitle, CardsEnd, CardsName);
                }
                else
                {
                    LblCreateCardsMsg.Text = $"Apenas números na quantidade! A quantidade máxima permitida é {maxQuantity}.";
                    return;
                }
            }
            else
            {
                LblCreateCardsMsg.Text = "Selecione uma Lista!";
            }

            // Limpar campos após a criação
            BoxCreateCardsEnd.Text = string.Empty;
            BoxCreateCardsName.Text = string.Empty;
            BoxCreateCardsQuant.Text = string.Empty;
            BoxCreateCardsTitle.Text = string.Empty;
            CboCreateCardsList.SelectedIndex = -1;
            LblCreateCardsMsg.Text = "Cartelas criadas com sucesso!";
            BtnCreateCards.Enabled = true;
        }

        //Apenas números na quantidade de cartelas
        private void BoxCreateCardsQuant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        //Edição
        //Configuração da Edição de Listas
        private void EditListConfigureLayout()
        {
            FlowEditViewAll.AutoScroll = true;
            FlowEditViewSel.AutoScroll = true;
        }

        // Método para carregar todas as Elementos e filtrar as que já estão na lista selecionada
        private void LoadAllComp(int? selectedListId = null)
        {
            FlowEditViewAll.Controls.Clear();

            // Carregar todas as Elementos
            DataTable companiesTable = DataService.GetCompanies();
            allCompaniesList = companiesTable.AsEnumerable()
                                             .OrderBy(row => row.Field<string>("Name"))
                                             .ToList();

            if (selectedListId.HasValue)
            {
                // Carregar as Elementos que já estão na lista selecionada
                List<DataRow> companiesInList = DataService.GetCompaniesByListId(selectedListId.Value);

                // Filtrar as Elementos que ainda não estão na lista selecionada
                allCompaniesList = allCompaniesList.Where(row => !companiesInList.Any(c => c["Id"].ToString() == row["Id"].ToString()))
                                                   .ToList();
            }

            // Exibir as Elementos filtradas
            EditListShowComps(allCompaniesList);
        }

        // Método para manipular a mudança de valor da ComboBox de listas
        private void CboEditListSel_SelectedValueChanged(object sender, EventArgs e)
        {
            BtnEditAddCL.Enabled = true;
            BtnEditRemoveCL.Enabled = true;
            BtnEditListDelete.Enabled = true;

            if (CboEditListSel.SelectedItem != null)
            {
                int selectedListId = (int)(CboEditListSel.SelectedItem as dynamic).Value;

                // Carrega as Elementos não alocadas na lista selecionada
                LoadAllComp(selectedListId);

                // Carrega as Elementos já associadas à lista selecionada
                List<DataRow> companyList = DataService.GetCompaniesByListId(selectedListId);

                // Exibe apenas as Elementos já associadas
                EditListShowSel(companyList);
            }
        }

        //Método para Exibir todas as Elementos
        private void EditListShowComps(List<DataRow> CompList)
        {
            FlowEditViewAll.Controls.Clear();

            foreach (DataRow row in CompList)
            {
                string companyId = row["Id"].ToString();
                string companyName = row["Name"].ToString();
                string logoName = row["Logo"].ToString();
                string companyFull = companyName;

                if (companyName.Length > 10)
                {
                    companyFull = companyName;
                    companyName = companyName.Substring(0, 10);
                }

                Panel companyPanel = new Panel
                {
                    Tag = companyId,
                    Width = 100,
                    Height = 70,
                    Margin = new Padding(15, 0, 14, 0),
                    BackColor = Color.LightGray // Default background color
                };

                PictureBox picBox = new PictureBox
                {
                    Image = !string.IsNullOrEmpty(logoName)
                        ? Image.FromFile(Path.Combine(imageFolderPath, logoName))
                        : Image.FromFile(Path.Combine(imageFolderPath, "default_logo.jpg")),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = 80,
                    Height = 50,
                    Location = new Point(10, 5)
                };

                CheckBox chkBox = new CheckBox
                {
                    Width = 15,
                    Height = 15,
                    Location = new Point(5, 55)
                };

                Label lblName = new Label
                {
                    Text = companyName,
                    Width = 75,
                    Height = 20,
                    Location = new Point(25, 50),
                    TextAlign = ContentAlignment.MiddleLeft
                };

                toolTip.SetToolTip(picBox, companyFull);
                toolTip.SetToolTip(lblName, companyFull);

                // Evento para mudar a cor de fundo quando o CheckBox for alterado
                chkBox.CheckedChanged += (sender, e) =>
                {
                    companyPanel.BackColor = chkBox.Checked ? Color.LightBlue : Color.LightGray;
                };

                // Evento para clicar na imagem e marcar/desmarcar o CheckBox correspondente
                picBox.Click += (sender, e) =>
                {
                    chkBox.Checked = !chkBox.Checked;  // Alterna o estado do CheckBox
                };

                companyPanel.Controls.Add(picBox);
                companyPanel.Controls.Add(chkBox);
                companyPanel.Controls.Add(lblName);

                FlowEditViewAll.Controls.Add(companyPanel);
            }
        }

        // Método para mostrar as Elementos de uma Lista
        private void EditListShowSel(List<DataRow> CompList)
        {
            FlowEditViewSel.Controls.Clear();

            foreach (DataRow row in CompList)
            {
                string companyId = row["Id"].ToString();
                string companyName = row["Name"].ToString();
                string logoName = row["Logo"].ToString();
                string companyFull = companyName;

                if (companyName.Length > 10)
                {
                    companyFull = companyName;
                    companyName = companyName.Substring(0, 10);
                }

                Panel companyPanel = new Panel
                {
                    Tag = companyId,
                    Width = 100,
                    Height = 70,
                    Margin = new Padding(15, 0, 14, 0),
                    BackColor = Color.LightGray // Cor de fundo padrão
                };

                PictureBox picBox = new PictureBox
                {
                    Image = !string.IsNullOrEmpty(logoName)
                        ? Image.FromFile(Path.Combine(imageFolderPath, logoName))
                        : Image.FromFile(Path.Combine(imageFolderPath, "default_logo.jpg")),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = 80,
                    Height = 50,
                    Location = new Point(10, 5)
                };

                CheckBox chkBox = new CheckBox
                {
                    Width = 15,
                    Height = 15,
                    Location = new Point(5, 55)
                };

                Label lblName = new Label
                {
                    Text = companyName,
                    Width = 75,
                    Height = 20,
                    Location = new Point(25, 50),
                    TextAlign = ContentAlignment.MiddleLeft
                };

                toolTip.SetToolTip(picBox, companyFull);
                toolTip.SetToolTip(lblName, companyFull);

                // Evento para mudar a cor de fundo quando o CheckBox for alterado
                chkBox.CheckedChanged += (sender, e) =>
                {
                    companyPanel.BackColor = chkBox.Checked ? Color.LightBlue : Color.LightGray;
                };

                // Evento para selecionar/desselecionar o CheckBox ao clicar na imagem
                picBox.Click += (sender, e) =>
                {
                    chkBox.Checked = !chkBox.Checked;  // Alterna o estado do CheckBox
                };

                companyPanel.Controls.Add(picBox);
                companyPanel.Controls.Add(chkBox);
                companyPanel.Controls.Add(lblName);

                FlowEditViewSel.Controls.Add(companyPanel);  // Adiciona ao painel correto
            }
        }


        //Método para filtrar as Elementos mostradas
        private void BoxEditFilterCL_TextChanged(object sender, EventArgs e)
        {
            string filterText = BoxEditFilterCL.Text.ToLower();

            var filteredList = allCompaniesList
                .Where(row => row.Field<string>("Name").ToLower().Contains(filterText))
                .ToList();

            EditListShowComps(filteredList);
        }

        // Método para adicionar Elementos a uma lista no editor
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

            if (selectedCompanies.Count > 0)
            {

                DialogResult dialogResult = MessageBox.Show($"Tem certeza de que deseja inserir Elementos na Lista? Todas as Cartelas " +
                    $"que foram feitas com Listas que o utilizam serão excluídas.",
                                                            "Confirmar Exclusão",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    if (CboEditListSel.SelectedItem != null)
                    {
                        if (selectedCompanies.Count > 0)
                        {
                            DataService.AddCompaniesToAllocation(selectedListId, selectedCompanies);
                            DataService.RemoveCardsByListId(selectedListId);
                            companyList = DataService.GetCompaniesByListId(selectedListId);

                            LblEditListMsg.Text = "Elementos adicionados à Lista!";


                            EditListShowSel(companyList);
                            LoadAllComp(selectedListId);
                            LoadGames();

                            // Pergunta ao usuário se ele deseja criar cartelas
                            DialogResult result = MessageBox.Show("Deseja criar Cartelas?", "Criar Cartelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                FlowEditViewSel.Controls.Clear();
                                CboEditListSel.SelectedIndex = -1;
                                LblEditListMsg.Text = string.Empty;

                                LoadLists();
                                LoadComps();
                                EditListConfigureLayout();
                                LoadAllComp();

                                MainPage.SelectedTab = TabCreatePage;
                                CreatePage.SelectedTab = TabCreateCards;
                            }
                        }
                        else
                        {
                            LblEditListMsg.Text = "Falha ao adicionar Elementos!";
                        }
                    }
                    else
                    {
                        LblEditListMsg.Text = "Nenhuma Lista foi selecionada!";
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

        }

        // Método para remover Elementos a uma lista no editor
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

            if (selectedCompanies.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show($"Tem certeza de que deseja remover Elementos da Lista'? Todas as Cartelas " +
                    $"que foram feitas com Listas que o utilizam serão excluídas.",
                                                            "Confirmar Exclusão",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    if (CboEditListSel.SelectedItem != null)
                    {
                        if (selectedCompanies.Count > 0)
                        {
                            DataService.RemoveCompaniesFromAllocation(selectedListId, selectedCompanies);
                            DataService.RemoveCardsByListId(selectedListId);
                            companyList = DataService.GetCompaniesByListId(selectedListId);

                            LblEditListMsg.Text = "Elementos removidos da Lista!";

                            EditListShowSel(companyList);
                            LoadAllComp(selectedListId);
                            LoadGames();
                        }
                        else
                        {
                            LblEditListMsg.Text = "Nenhum Elemento foi selecionada para remoção!";
                        }
                    }
                    else
                    {
                        LblEditListMsg.Text = "Nenhuma Lista foi selecionada!";
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        // Método para Excluir uma Elemento
        private void BtnRemoveComp_Click(object sender, EventArgs e)
        {
            if (CboEditComp.SelectedIndex == -1)
            {
                LblEditCompName.Text = "Por favor, selecione um Elemento para excluir.";
                return;
            }

            CompanyModel selectedCompany = CboEditComp.SelectedItem as CompanyModel;

            if (selectedCompany == null)
            {
                LblEditCompName.Text = "Erro ao carregar os detalhes do Elemento selecionado.";
                return;
            }

            DialogResult dialogResult = MessageBox.Show($"Tem certeza de que deseja excluir o Elemento '{selectedCompany.Name}'? Todas as Cartelas " +
                $"que foram feitas com Listas que o utilizam também serão excluídas.",
                                                        "Confirmar Exclusão",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    DataService.DeleteCompany(selectedCompany.Id);

                    LblEditCompName.Text = $"Elemento '{selectedCompany.Name}' excluído com sucesso.";

                    BoxEditNameComp.Text = "";
                    BoxEditCardNameComp.Text = "";
                    BoxEditPhoneComp.Text = "";
                    BoxEditEmailComp.Text = "";
                    PicEditLogoComp.Image = null;
                    CboEditComp.Text = "";
                    CboEditComp.SelectedIndex = -1;
                    LoadComps();
                    LoadAllComp();
                }
                catch (Exception ex)
                {
                    LblEditCompName.Text = "Erro ao excluir o Elemento. " + ex.Message;
                }
            }
            else
            {
                LblEditCompName.Text = "A exclusão foi cancelada.";
            }
        }

        //Método para selecionar Elemento para Edição
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

                    // Define a imagem do logo na AppData ou a padrão
                    PicEditLogoComp.Image = DataService.LoadImageFromFile(selectedCompany.Logo)
                        ?? DataService.LoadImageFromFile("default_logo.jpg");
                }
            }
        }

        //Método para Editar uma Elemento
        private void BtnEditComp_Click(object sender, EventArgs e)
        {
            if (CboEditComp.SelectedIndex == -1)
            {
                LblEditMsgComp.Text = "Por favor, selecione um Elemento para editar.";
                return;
            }

            CompanyModel selectedCompany = CboEditComp.SelectedItem as CompanyModel;

            if (selectedCompany == null)
            {
                LblEditCompName.Text = "Erro ao carregar os detalhes do Elemento selecionada.";
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
                    LblEditMsgComp.Text = "Elemento " + company.Name + " editado com sucesso.";
                }
                catch
                {
                    LblEditMsgComp.Text = "Erro ao editar o Elemento.";
                }

                BoxEditNameComp.Text = "";
                BoxEditCardNameComp.Text = "";
                BoxEditPhoneComp.Text = "";
                BoxEditEmailComp.Text = "";
                PicEditLogoComp.Image = null;
                CboEditComp.Text = "";
                CboEditComp.SelectedIndex = -1;
                LoadComps();
                LoadAllComp();
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

            DialogResult dialogResult = MessageBox.Show($"Tem certeza de que deseja excluir a lista '{selectedListId}'? Todas as cartelas associadas também serão excluídas.",
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
                    CboEditListSel.Text = "";
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
                LblEditListMsg.Text = "A exclusão foi cancelada.";
            }

            LoadAllComp();
        }

        //Métodos para visualizar os Dados
        // Evento que é chamado quando o valor da ComboBox muda
        private void CboVisu_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlwEditVisu.Controls.Clear();

            string selectedOption = CboVisu.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedOption))
            {
                return;
            }

            switch (selectedOption)
            {
                case "Elementos":
                    LblVisu1.Text = "Nome:";
                    LblVisu2.Text = "Nome para Cartela:";
                    LblVisu3.Text = "Anotação 1:";
                    LblVisu4.Text = "Anotação 2:";
                    LblVisu5.Text = "Listas:";
                    PopulateElements();
                    break;
                case "Listas":
                    LblVisu1.Text = "Nome:";
                    LblVisu2.Text = "Total de Elementos:";
                    LblVisu3.Text = "Descrição:";
                    LblVisu4.Text = "";
                    LblVisu5.Text = "";
                    PopulateLists();
                    break;
                case "Cartelas":
                    LblVisu1.Text = "Nome:";
                    LblVisu2.Text = "Quantidade:";
                    LblVisu3.Text = "Título:";
                    LblVisu4.Text = "Mensagem Final:";
                    LblVisu5.Text = "";
                    PopulateCards();
                    break;
                default:
                    break;
            }
        }

        // Método para popular com Elementos
        private void PopulateElements()
        {
            FlwEditVisu.Controls.Clear();
            FlwEditVisu.AutoScroll = true;

            LblVisuCont1.Text = "";
            LblVisuCont2.Text = "";
            LblVisuCont3.Text = "";
            LblVisuCont4.Text = "";
            LblVisuCont5.Text = "";
            PicVisuLogo.Image = null;

            // Obtém a tabela de Elementos
            DataTable companiesTable = DataService.GetCompanies();

            // Ordena os dados em ordem alfabética
            DataView sortedCompanies = new DataView(companiesTable);
            sortedCompanies.Sort = "Name ASC";

            // Itera pelos elementos e cria Labels clicáveis
            foreach (DataRowView row in sortedCompanies)
            {
                // Cria um Label para o nome da Elemento
                Label lblName = new Label
                {
                    Text = row["Name"].ToString(),
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    AutoSize = false,
                    Padding = new Padding(0, 5, 0, 5),
                    Height = 30,
                    Width = FlwEditVisu.ClientSize.Width - 30,
                    Tag = row["Id"], // Armazena o ID da Elemento no Tag para referência
                    Cursor = Cursors.Hand, // Muda o cursor para mão
                };

                // Adiciona um evento de clique ao Label
                lblName.Click += (sender, e) => OnCompanyLabelClick(lblName);

                // Adiciona o Label ao FlowLayoutPanel
                FlwEditVisu.Controls.Add(lblName);
            }

            FlwEditVisu.VerticalScroll.Enabled = true;
            FlwEditVisu.HorizontalScroll.Enabled = false;
        }

        // Método para popular com Listas
        private void PopulateLists()
        {
            FlwEditVisu.Controls.Clear();
            FlwEditVisu.AutoScroll = true;

            LblVisuCont1.Text = "";
            LblVisuCont2.Text = "";
            LblVisuCont3.Text = "";
            LblVisuCont4.Text = "";
            LblVisuCont5.Text = "";
            PicVisuLogo.Image = null;

            // Obtém a tabela de Listas
            DataTable listsTable = DataService.GetLists();

            // Ordena os dados em ordem alfabética
            DataView sortedLists = new DataView(listsTable);
            sortedLists.Sort = "Name ASC";

            // Itera pelas listas e cria Labels clicáveis
            foreach (DataRowView row in sortedLists)
            {
                // Cria um Label para o nome da Lista
                Label lblName = new Label
                {
                    Text = row["Name"].ToString(),
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    AutoSize = false,
                    Padding = new Padding(0, 5, 0, 5),
                    Height = 30,
                    Width = FlwEditVisu.ClientSize.Width - 30,
                    Tag = row["Id"], // Armazena o ID da Lista no Tag para referência
                    Cursor = Cursors.Hand,
                };

                // Adiciona um evento de clique ao Label
                lblName.Click += (sender, e) => OnListLabelClick(lblName);

                // Adiciona o Label ao FlowLayoutPanel
                FlwEditVisu.Controls.Add(lblName);
            }

            FlwEditVisu.VerticalScroll.Enabled = true;
            FlwEditVisu.HorizontalScroll.Enabled = false;
        }

        // Método para popular com Cartelas
        private void PopulateCards()
        {
            FlwEditVisu.Controls.Clear();
            FlwEditVisu.AutoScroll = true;

            LblVisuCont1.Text = "";
            LblVisuCont2.Text = "";
            LblVisuCont3.Text = "";
            LblVisuCont4.Text = "";
            LblVisuCont5.Text = "";
            PicVisuLogo.Image = null;

            DataTable cardsTable = DataService.GetCards();

            DataView sortedCards = new DataView(cardsTable);
            sortedCards.Sort = "Name ASC";

            foreach (DataRowView row in sortedCards)
            {
                Label lblName = new Label
                {
                    Text = row["Name"].ToString(),
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    AutoSize = false,
                    Padding = new Padding(0, 5, 0, 5),
                    Height = 30,
                    Width = FlwEditVisu.ClientSize.Width - 30,
                    Tag = row["SetId"],
                    Cursor = Cursors.Hand,
                };

                lblName.Click += (sender, e) => OnCardLabelClick(lblName);

                FlwEditVisu.Controls.Add(lblName);
            }

            FlwEditVisu.VerticalScroll.Enabled = true;
            FlwEditVisu.HorizontalScroll.Enabled = false;
        }

        //Métodos para informações dos Elementos
        private void OnCompanyLabelClick(Label clickedLabel)
        {
            // Desmarca todos os Labels (remove o destaque)
            foreach (Control control in FlwEditVisu.Controls)
            {
                if (control is Label lbl)
                {
                    lbl.BackColor = Color.Transparent; // Volta à cor original
                }
            }

            // Destaca o Label clicado
            clickedLabel.BackColor = Color.LightBlue;

            // Obtém o ID da Elemento do Tag do Label
            int companyId = Convert.ToInt32(clickedLabel.Tag);

            // Carrega as informações da Elemento
            LoadCompanyDetails(companyId);
        }
        private void LoadCompanyDetails(int companyId)
        {
            // Obter as informações da Elemento do banco de dados
            DataRow company = DataService.GetCompanyById(companyId);

            if (company != null)
            {
                // Atualiza os Labels com as informações da Elemento
                LblVisuCont1.Text = company["Name"].ToString();
                LblVisuCont2.Text = company["CardName"].ToString();
                LblVisuCont3.Text = company["Phone"].ToString();
                LblVisuCont4.Text = company["Email"].ToString();

                // Define o caminho da pasta de imagens na AppData
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string imageFolderPath = Path.Combine(appDataPath, "BingoManager", "Images");
                string logoPath = Path.Combine(imageFolderPath, company["Logo"].ToString());

                // Carrega a imagem do logo ou a imagem padrão se não existir
                if (File.Exists(logoPath))
                {
                    PicVisuLogo.Image = Image.FromFile(logoPath);
                }
                else
                {
                    string defaultLogoPath = Path.Combine(imageFolderPath, "default_logo.jpg");
                    PicVisuLogo.Image = File.Exists(defaultLogoPath)
                        ? Image.FromFile(defaultLogoPath)
                        : null; // Define como nulo se nenhuma imagem padrão estiver disponível
                }

                // Carrega as listas a que a Elemento pertence
                List<string> lists = DataService.GetCompanyLists(companyId);

                if (lists.Count == 0)
                {
                    LblVisuCont5.Text = "O Elemento não foi adicionado à nenhuma Lista ainda.";
                }
                else
                {
                    LblVisuCont5.Text = string.Join(", ", lists);
                }
            }
        }


        //Métodos para informações das Cartelas
        private void OnCardLabelClick(Label clickedLabel)
        {
            // Remove o destaque de todos os Labels
            foreach (Control control in FlwEditVisu.Controls)
            {
                if (control is Label lbl)
                {
                    lbl.BackColor = Color.Transparent; // Remove o destaque
                }
            }

            // Destaca o Label clicado
            clickedLabel.BackColor = Color.LightBlue;

            // Obtém o ID da cartela do Tag do Label
            int cardSetId = Convert.ToInt32(clickedLabel.Tag);

            // Carrega os detalhes da cartela
            LoadCardDetails(cardSetId);
        }
        private void LoadCardDetails(int cardSetId)
        {
            DataRow cardDetails = DataService.GetCardSetAndListBySetId(cardSetId);

            if (cardDetails != null)
            {
                // Atualiza os Labels com as informações da Cartela
                LblVisuCont1.Text = cardDetails["Name"].ToString();
                LblVisuCont2.Text = cardDetails["Qnt"].ToString();
                LblVisuCont3.Text = cardDetails["Title"].ToString();
                LblVisuCont4.Text = cardDetails["End"].ToString();
                LblVisuCont5.Text = cardDetails["ListName"].ToString();

                // Define o caminho da pasta de imagens na AppData
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string imageFolderPath = Path.Combine(appDataPath, "BingoManager", "Images");

                // Define o caminho do logo da lista
                string listLogoFileName = cardDetails["Logo"].ToString();
                string listLogoPath = Path.Combine(imageFolderPath, listLogoFileName);

                // Carrega o logo da lista ou a imagem padrão se o logo não existir
                Image logoImage = null;
                if (File.Exists(listLogoPath))
                {
                    logoImage = Image.FromFile(listLogoPath);
                }

                string defaultLogoPath = Path.Combine(imageFolderPath, "default_logo.jpg");
                PicVisuLogo.Image = logoImage ?? (File.Exists(defaultLogoPath) ? Image.FromFile(defaultLogoPath) : null);
            }
            else
            {
                MessageBox.Show("Cartela não encontrada.");
            }
        }


        //Métodos para informações das Listas
        private void OnListLabelClick(Label clickedLabel)
        {
            // Remove o destaque de todos os Labels
            foreach (Control control in FlwEditVisu.Controls)
            {
                if (control is Label lbl)
                {
                    lbl.BackColor = Color.Transparent; // Remove o destaque
                }
            }

            // Destaca o Label clicado
            clickedLabel.BackColor = Color.LightBlue;

            // Obtém o ID da lista do Tag do Label
            int listId = Convert.ToInt32(clickedLabel.Tag);

            // Carrega os detalhes da lista
            LoadListDetails(listId);
        }
        private void LoadListDetails(int listId)
        {
            DataRow listDetails = DataService.GetListById(listId);
            List<DataRow> listSize = DataService.GetCompaniesByListId(listId);

            if (listDetails != null)
            {
                // Define as informações da lista nos labels
                LblVisuCont1.Text = listDetails["Name"].ToString();
                LblVisuCont2.Text = listSize.Count.ToString();
                LblVisuCont3.Text = listDetails["Description"].ToString();

                // Configura o caminho da pasta de imagens na AppData
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string imageFolderPath = Path.Combine(appDataPath, "BingoManager", "Images");

                // Define o caminho do logo da lista
                string listLogoFileName = listDetails["Logo"].ToString();
                string listLogoPath = Path.Combine(imageFolderPath, listLogoFileName);

                // Tenta carregar o logo da lista; caso contrário, usa o logo padrão
                Image logoImage = null;
                if (File.Exists(listLogoPath))
                {
                    logoImage = Image.FromFile(listLogoPath);
                }

                string defaultLogoPath = Path.Combine(imageFolderPath, "default_logo.jpg");
                PicVisuLogo.Image = logoImage ?? (File.Exists(defaultLogoPath) ? Image.FromFile(defaultLogoPath) : null);
            }
            else
            {
                MessageBox.Show("Lista não encontrada.");
            }
        }


        //Método para Exclusão
        private void BtnEditVisu_Click(object sender, EventArgs e)
        {
            string visuOpt = CboVisu.Text;

            if (string.IsNullOrEmpty(LblVisuCont1.Text))
            {
                return;
            }

            if (visuOpt == "Listas")
            {
                string selectedListName = LblVisuCont1.Text;

                DialogResult dialogResult = MessageBox.Show($"Tem certeza de que deseja excluir a lista '{selectedListName}'? Todas as cartelas associadas também serão excluídas.",
                                                            "Confirmar Exclusão",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        int listId = DataService.GetListId(selectedListName);
                        DataService.DeleteList(listId);

                        PopulateLists();
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao Excluir a Lista");
                    }
                }
                else
                {
                    return;
                }
            } else if (visuOpt == "Elementos")
            {
                string selectedCompName = LblVisuCont1.Text;

                DialogResult dialogResult = MessageBox.Show($"Tem certeza de que deseja excluir o Elemento '{selectedCompName}'? Todas as Cartelas e Listas associadas também serão excluídas.",
                                                            "Confirmar Exclusão",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        int compId = DataService.GetCompId(selectedCompName);
                        DataService.DeleteCompany(compId);

                        PopulateElements();
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao Excluir o Elemento");
                    }
                }
                else
                {
                    return;
                }
            } else if (visuOpt == "Cartelas")
            {
                string selectedSetName = LblVisuCont1.Text;

                DialogResult dialogResult = MessageBox.Show($"Tem certeza de que deseja excluir as Cartelas do conjunto '{selectedSetName}'?",
                                                            "Confirmar Exclusão",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        int setId = DataService.GetCardsId(selectedSetName);
                        DataService.DeleteCards(setId);

                        PopulateCards();
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao Excluir as Cartelas");
                    }
                }
                else
                {
                    return;
                }
            } else
            {
                return;
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

        //Método para carregar a lista de Elementos para Edição
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
            CboEditComp.Text = "";
            CboEditComp.SelectedIndex = -1;
        }

        //Método para mostrar Segunda Tela
        private void ShowLogoOnSecondScreen()
        {
            // Verificar se existem várias telas conectadas
            if (Screen.AllScreens.Length > 1)
            {
                // Exibir todas as telas conectadas (para fins de depuração)
                foreach (var screen in Screen.AllScreens)
                {
                    Console.WriteLine($"Screen: {screen.DeviceName}, Resolution: {screen.Bounds.Width}x{screen.Bounds.Height}");
                }

                // Usa a segunda tela (índice 1, já que a primeira é 0)
                Screen secondScreen = Screen.AllScreens[1];

                // Inicializa o formulário de exibição do logotipo se ainda não estiver criado
                if (logoDisplayForm == null || logoDisplayForm.IsDisposed)
                {
                    logoDisplayForm = new LogoView();
                }

                // Move o formulário para a segunda tela
                logoDisplayForm.StartPosition = FormStartPosition.Manual;
                logoDisplayForm.Location = secondScreen.WorkingArea.Location; // Define a localização na segunda tela
                logoDisplayForm.WindowState = FormWindowState.Maximized; // Maximiza na segunda tela
                logoDisplayForm.Show();

                // Se já houver uma imagem no PicPlayLogo, exibi-la na segunda tela
                if (PicPlayAnLogo.Image != null)
                {
                    // Atualiza o logo e o nome da Elemento na segunda tela
                    logoDisplayForm.UpdateLogoAndName(PicPlayAnLogo.Image, LblPlayAnName.Text);
                }
            }
            else
            {
                MessageBox.Show("A segunda tela não está disponível.");
            }
        }
        private void MainView_Load(object sender, EventArgs e)
        {
            // Inicializa a segunda tela ao carregar o formulário principal
            ShowLogoOnSecondScreen();
        }
        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancelar a subscrição do evento ao fechar o formulário
            SystemEvents.DisplaySettingsChanged -= new EventHandler(SystemEvents_DisplaySettingsChanged);
        }

        // Evento que é chamado quando as configurações de exibição mudam (telas conectadas/desconectadas)
        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            // Verificar novamente as telas disponíveis e mover o logo para a segunda tela
            ShowLogoOnSecondScreen();
        }



        //Jogar
        //Método para carregar todos os jogos para Jogar
        private void LoadGames()
        {
            DataTable gamesTable = DataService.GetAllCards();

            CboPlayAnSelection.Items.Clear();
            CboPlayDiSelection.Items.Clear();

            foreach (DataRow row in gamesTable.Rows)
            {
                string cardName = row["Name"].ToString();
                int cardId = Convert.ToInt32(row["SetId"]);

                CboPlayAnSelection.Items.Add(new { Text = cardName, Value = cardId });
                CboPlayDiSelection.Items.Add(new { Text = cardName, Value = cardId });
            }

            CboPlayAnSelection.DisplayMember = "Text";
            CboPlayAnSelection.ValueMember = "Value";
            CboPlayDiSelection.DisplayMember = "Text";
            CboPlayDiSelection.ValueMember = "Value";
        }

        // Método para começar o jogo com base no conjunto de fichas selecionado
        private void BtnPlaySelection_Click(object sender, EventArgs e)
        {
            PlayService.ResetGame();

            if (PlayPage.SelectedTab == TabPlayAnalog)
            {
                if (CboPlayAnSelection.SelectedItem != null)
                {
                    var selectedGame = CboPlayAnSelection.SelectedItem as dynamic;

                    int selectedGameId = selectedGame.Value;

                    var gameData = DataService.GetGameCompanies(selectedGameId);

                    if (gameData != null)
                    {
                        DisplayGamePanels(gameData); 
                        BtnPlayAnSelection.Enabled = false;
                        CboPlayAnSelection.Enabled = false;
                        BtnRestartAn.Enabled = true;
                    }
                    else
                    {
                        LblPlayAnMsg.Text = "Erro ao carregar os dados do jogo selecionado.";
                    }
                }
                else
                {
                    LblPlayAnMsg.Text = "Por favor, selecione um jogo.";
                }
            }
            else if (PlayPage.SelectedTab == TabPlayDigital)
            {
                if (CboPlayDiSelection.SelectedItem != null)
                {
                    BtnPlayDiRandom.Enabled = true;

                    var selectedGame = CboPlayDiSelection.SelectedItem as dynamic;

                    int selectedGameId = selectedGame.Value;

                    var gameData = DataService.GetGameCompanies(selectedGameId);

                    if (gameData != null)
                    {
                        DisplayGamePanelsDi(gameData);
                        BtnPlayDiSelection.Enabled = false;
                        CboPlayDiSelection.Enabled = false;
                        BtnRestartDigital.Enabled = true;
                    }
                    else
                    {
                        LblPlayDiMsg.Text = "Erro ao carregar os dados do jogo selecionado.";
                    }
                }
                else
                {
                    LblPlayDiMsg.Text = "Por favor, selecione um jogo.";
                }
            }
        }

        // Método para mostrar as Elementos durante o jogo
        private void DisplayGamePanels(GameData gameData)
        {
            int buttonSize = 35;
            int panelWidth = FlwPlayAnB.Width;
            int buttonsPerRow = panelWidth / buttonSize;

            int Number = 1;

            FlwPlayAnB.Controls.Clear();
            FlwPlayAnI.Controls.Clear();
            FlwPlayAnN.Controls.Clear();
            FlwPlayAnG.Controls.Clear();
            FlwPlayAnO.Controls.Clear();

            SetupFlowPanels();

            // Adicionar botões ao grupo B
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

                // Define o tooltip para o nome da empresa:
                var companyModel = (CompanyModel)companyButton.Tag;
                toolTip1.SetToolTip(companyButton, companyModel.Name);

                Number++;
                companyButton.Click += CompanyButton_Click;
                FlwPlayAnB.Controls.Add(companyButton);
            }

            // Adicionar botões ao grupo I
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

                // Define o tooltip para o nome da empresa:
                var companyModel = (CompanyModel)companyButton.Tag;
                toolTip1.SetToolTip(companyButton, companyModel.Name);
                Number++;
                companyButton.Click += CompanyButton_Click;
                FlwPlayAnI.Controls.Add(companyButton);
            }

            // Adicionar botões ao grupo N
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

                // Define o tooltip para o nome da empresa:
                var companyModel = (CompanyModel)companyButton.Tag;
                toolTip1.SetToolTip(companyButton, companyModel.Name);
                Number++;
                companyButton.Click += CompanyButton_Click;
                FlwPlayAnN.Controls.Add(companyButton);
            }

            // Adicionar botões ao grupo G
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

                // Define o tooltip para o nome da empresa:
                var companyModel = (CompanyModel)companyButton.Tag;
                toolTip1.SetToolTip(companyButton, companyModel.Name);
                Number++;
                companyButton.Click += CompanyButton_Click;
                FlwPlayAnG.Controls.Add(companyButton);
            }

            // Adicionar botões ao grupo O
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

                // Define o tooltip para o nome da empresa:
                var companyModel = (CompanyModel)companyButton.Tag;
                toolTip1.SetToolTip(companyButton, companyModel.Name);
                Number++;
                companyButton.Click += CompanyButton_Click;
                FlwPlayAnO.Controls.Add(companyButton);
            }

            LblPlayAnMsg.Text = "Jogo iniciado!";
        }

        // Método para mostrar as Elementos durante o jogo digital
        private void DisplayGamePanelsDi(GameData gameData)
        {
            int labelSize = 35;
            int panelWidth = FlwPlayDiB.Width;
            int labelsPerRow = panelWidth / labelSize;

            int Number = 1;

            // Limpar os controles existentes nos novos FlowLayoutPanels
            FlwPlayDiB.Controls.Clear();
            FlwPlayDiI.Controls.Clear();
            FlwPlayDiN.Controls.Clear();
            FlwPlayDiG.Controls.Clear();
            FlwPlayDiO.Controls.Clear();

            SetupFlowPanels(); // Configurar os painéis (se necessário)

            // Adicionar Labels ao grupo B
            foreach (var company in gameData.GroupB)
            {
                Label companyLabel = new Label
                {
                    Text = Number.ToString(),
                    Tag = company,
                    Width = labelSize,
                    Height = labelSize,
                    BorderStyle = BorderStyle.FixedSingle,  // Adiciona a borda
                    TextAlign = ContentAlignment.MiddleCenter, // Centraliza o texto
                    BackColor = Color.White, // Cor de fundo branca
                    ForeColor = Color.Black  // Cor do texto
                };

                // Define o tooltip para o nome da empresa:
                var companyModel = (CompanyModel)companyLabel.Tag;
                toolTip1.SetToolTip(companyLabel, companyModel.Name);
                Number++;
                FlwPlayDiB.Controls.Add(companyLabel);
            }

            // Adicionar Labels ao grupo I
            foreach (var company in gameData.GroupI)
            {
                Label companyLabel = new Label
                {
                    Text = Number.ToString(),
                    Tag = company,
                    Width = labelSize,
                    Height = labelSize,
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };

                // Define o tooltip para o nome da empresa:
                var companyModel = (CompanyModel)companyLabel.Tag;
                toolTip1.SetToolTip(companyLabel, companyModel.Name);
                Number++;
                FlwPlayDiI.Controls.Add(companyLabel);
            }

            // Adicionar Labels ao grupo N
            foreach (var company in gameData.GroupN)
            {
                Label companyLabel = new Label
                {
                    Text = Number.ToString(),
                    Tag = company,
                    Width = labelSize,
                    Height = labelSize,
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };

                // Define o tooltip para o nome da empresa:
                var companyModel = (CompanyModel)companyLabel.Tag;
                toolTip1.SetToolTip(companyLabel, companyModel.Name);
                Number++;
                FlwPlayDiN.Controls.Add(companyLabel);
            }

            // Adicionar Labels ao grupo G
            foreach (var company in gameData.GroupG)
            {
                Label companyLabel = new Label
                {
                    Text = Number.ToString(),
                    Tag = company,
                    Width = labelSize,
                    Height = labelSize,
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };

                // Define o tooltip para o nome da empresa:
                var companyModel = (CompanyModel)companyLabel.Tag;
                toolTip1.SetToolTip(companyLabel, companyModel.Name);
                Number++;
                FlwPlayDiG.Controls.Add(companyLabel);
            }

            // Adicionar Labels ao grupo O
            foreach (var company in gameData.GroupO)
            {
                Label companyLabel = new Label
                {
                    Text = Number.ToString(),
                    Tag = company,
                    Width = labelSize,
                    Height = labelSize,
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };

                // Define o tooltip para o nome da empresa:
                var companyModel = (CompanyModel)companyLabel.Tag;
                toolTip1.SetToolTip(companyLabel, companyModel.Name);
                Number++;
                FlwPlayDiO.Controls.Add(companyLabel);
            }

            LblPlayAnMsg.Text = "Jogo iniciado!";
        }

        // Configurando os FlowLayoutPanels
        private void SetupFlowPanels()
        {
            int Width = 0;
            int Height = 0;

            //foreach (var panel in new[] { PnlPlayAnNumbersB, PnlPlayAnNumbersI, PnlPlayAnNumbersN, PnlPlayAnNumbersG, PnlPlayAnNumbersO, PnlPlayDiNumbersB, PnlPlayDiNumbersI, PnlPlayDiNumbersN, PnlPlayDiNumbersG, PnlPlayDiNumbersO })
            //{
            //    Height += panel.Height;
            //    panel.AutoSize = true;
            //    panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //    panel.Padding = new Padding(0);
            //    panel.Margin = new Padding(0);
            //    panel.Dock = DockStyle.None;
            //}

            //foreach (var flowPanel in new[] { FlwPlayAnB, FlwPlayAnI, FlwPlayAnN, FlwPlayAnG, FlwPlayAnO, FlwPlayDiB, FlwPlayDiI, FlwPlayDiN, FlwPlayDiG, FlwPlayDiO })
            //{
            //    flowPanel.FlowDirection = FlowDirection.LeftToRight;
            //    flowPanel.WrapContents = true;
            //    flowPanel.AutoSize = false;        
            //    flowPanel.AutoScroll = true;                
            //    flowPanel.Dock = DockStyle.Fill;
            //    flowPanel.Padding = new Padding(10);
            //    flowPanel.Margin = new Padding(0);
            //}

            foreach (var flow in new[] { FlwPlayAnB, FlwPlayAnI, FlwPlayAnN, FlwPlayAnG, FlwPlayAnO, FlwPlayDiB,FlwPlayDiI,FlwPlayDiN,FlwPlayDiG,FlwPlayDiO })
            {
                flow.FlowDirection = FlowDirection.LeftToRight;
                flow.WrapContents = true;
                flow.AutoSize = false;
                flow.AutoScroll = true;
                flow.Dock = DockStyle.Fill;
                flow.Padding = new Padding(5);
                flow.Margin = new Padding(0);
            }
        }

        private void CompanyButton_Click(object sender, EventArgs e)
        {
            int bingoPhase = RdPlayAn1.Checked ? 1 : (RdPlayAn2.Checked ? 2 : 0);
            var selectedGame = CboPlayAnSelection.SelectedItem as dynamic;
            int setId = selectedGame.Value;

            Button clickedButton = sender as Button;

            if (clickedButton != null && clickedButton.Tag is CompanyModel selectedCompany)
            {
                string numero = clickedButton.Text;

                // Configura o caminho na AppData
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string imageFolderPath = Path.Combine(appDataPath, "BingoManager", "Images");

                // Caminho do logo da empresa
                string companyLogoPath = Path.Combine(imageFolderPath, selectedCompany.Logo);
                Image logoImage = null;

                if (File.Exists(companyLogoPath))
                {
                    // Logo da empresa encontrado
                    logoImage = Image.FromFile(companyLogoPath);
                }
                else
                {
                    // Se não houver logo da empresa, busca o logo da lista associada pelo CardsList
                    var listData = DataService.GetListByCompanyIdFromCards(selectedCompany.Id, setId);
                    if (listData != null)
                    {
                        // Caminho do logo da lista
                        string listLogoPath = Path.Combine(imageFolderPath, listData["Logo"].ToString());
                        if (File.Exists(listLogoPath))
                        {
                            // Logo da lista encontrado
                            logoImage = Image.FromFile(listLogoPath);
                        }
                        else
                        {
                            // Logo da lista não encontrado, usar logo padrão
                            string defaultLogoPath = Path.Combine(imageFolderPath, "default_logo.jpg");
                            logoImage = File.Exists(defaultLogoPath) ? Image.FromFile(defaultLogoPath) : null;
                        }
                    }
                    else
                    {
                        // Nenhuma lista associada ou logo, usar logo padrão
                        string defaultLogoPath = Path.Combine(imageFolderPath, "default_logo.jpg");
                        logoImage = File.Exists(defaultLogoPath) ? Image.FromFile(defaultLogoPath) : null;
                    }
                }

                // Marca o botão como sorteado, alterando a cor para vermelho
                clickedButton.BackColor = Color.Red;

                // Adiciona a empresa sorteada ao serviço de jogo
                PlayService.AddCompany(selectedCompany.Id);

                // Atualiza o logo e nome na interface do jogo
                if (logoDisplayForm != null && logoDisplayForm.Visible)
                {
                    logoDisplayForm.UpdateLogoAndName(logoImage, selectedCompany.Name);
                }

                // Atualiza o logo na tela principal
                PicPlayAnLogo.Image = logoImage;
                LblPlayAnName.Text = numero + " - " + selectedCompany.Name;

                // buscar cartelas
                List<int> cardNumbers = PlayService.CheckCards(selectedCompany.Id, setId);

                // verificar bingo
                List<int> winningCards = PlayService.CheckBingo(cardNumbers, setId, bingoPhase, selectedCompany.Id);
                if (winningCards.Count > 0)
                {
                    string winningCardsText = string.Join(", ", winningCards);
                    LblPlayAnMsg.Text = $"BINGO! Cartelas vencedoras: {winningCardsText}";
                }
                else
                {
                    LblPlayAnMsg.Text = "Sem bingo!";
                }

            }
        }


        //Método para reinicar o jogo
        private void ResetGame()
        {
            BtnPlayAnSelection.Enabled = true;
            BtnPlayDiSelection.Enabled = true;

            PicPlayAnLogo.Image = null;
            LblPlayAnName.Text = string.Empty;
            LblPlayAnMsg.Text = string.Empty;
            PicPlayDiLogo.Image = null;
            LblPlayDiName.Text = string.Empty;
            LblPlayDiMsg.Text = string.Empty;

            BtnPlayDiRandom.Enabled = false;

            FlwPlayAnB.Controls.Clear();
            FlwPlayAnI.Controls.Clear();
            FlwPlayAnN.Controls.Clear();
            FlwPlayAnG.Controls.Clear();
            FlwPlayAnO.Controls.Clear();

            FlwPlayDiB.Controls.Clear();
            FlwPlayDiI.Controls.Clear();
            FlwPlayDiN.Controls.Clear();
            FlwPlayDiG.Controls.Clear();
            FlwPlayDiO.Controls.Clear();

            PlayService.ResetGame();

            LoadGames();

            CboPlayAnSelection.Text = string.Empty;
            CboPlayAnSelection.SelectedIndex = -1;
            CboPlayAnSelection.Enabled = true;

            CboPlayDiSelection.Text = string.Empty;
            CboPlayDiSelection.SelectedIndex = -1;
            CboPlayDiSelection.Enabled = true;
        }
        private void BtnRestart_Click(object sender, EventArgs e)
        {
            // Confirmação do usuário
            var result = MessageBox.Show("Você tem certeza que deseja reiniciar o jogo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ResetGame();
            }
        }

        // Método para sortear uma Elemento no modo Digital e verificar as cartelas sorteadas e vencedoras
        private void BtnPlayDiRandom_Click(object sender, EventArgs e)
        {
            // Obter o jogo selecionado
            var selectedGame = CboPlayDiSelection.SelectedItem as dynamic;

            if (selectedGame == null)
            {
                MessageBox.Show("Por favor, selecione um jogo antes de sortear uma empresa.");
                return;
            }

            // Carregar o setId do jogo selecionado
            int setId = selectedGame.Value;

            // Coleta todas as empresas disponíveis para sorteio
            var availableCompanies = new List<Label>();

            // Adiciona os labels de todas as colunas ao availableCompanies, que ainda não foram sorteados (brancos)
            availableCompanies.AddRange(FlwPlayDiB.Controls.OfType<Label>().Where(lbl => lbl.BackColor == Color.White));
            availableCompanies.AddRange(FlwPlayDiI.Controls.OfType<Label>().Where(lbl => lbl.BackColor == Color.White));
            availableCompanies.AddRange(FlwPlayDiN.Controls.OfType<Label>().Where(lbl => lbl.BackColor == Color.White));
            availableCompanies.AddRange(FlwPlayDiG.Controls.OfType<Label>().Where(lbl => lbl.BackColor == Color.White));
            availableCompanies.AddRange(FlwPlayDiO.Controls.OfType<Label>().Where(lbl => lbl.BackColor == Color.White));

            // Verifica se ainda há empresas disponíveis para sortear
            if (availableCompanies.Count == 0)
            {
                MessageBox.Show("Todos os Elementos já foram sorteados.");
                return;
            }

            // Seleciona aleatoriamente uma empresa disponível
            Random random = new Random();
            int randomIndex = random.Next(availableCompanies.Count);
            Label selectedLabel = availableCompanies[randomIndex];

            // Muda a cor do label sorteado para vermelho (marca como sorteado)
            selectedLabel.BackColor = Color.Red;

            // Atualiza a lógica do jogo para adicionar a empresa sorteada e remover da lista de sorteio
            if (selectedLabel.Tag is CompanyModel selectedCompany)
            {
                // Adiciona a empresa à lista de sorteadas no PlayService
                PlayService.AddCompany(selectedCompany.Id);

                // dentro de BtnPlayDiRandom_Click, após PlayService.AddCompany(...)
                Image logoImage = DataService.LoadImageFromFile(selectedCompany.Logo);

                // Se não encontrar na empresa, tenta a lista
                if (logoImage == null)
                {
                    var listData = DataService.GetListByCompanyIdFromCards(selectedCompany.Id, setId);
                    if (listData != null)
                        logoImage = DataService.LoadImageFromFile(listData["Logo"].ToString());
                }

                // Se ainda não encontrou, usa a default
                if (logoImage == null)
                    logoImage = DataService.LoadImageFromFile("default_logo.jpg");

                // Atualiza o logo e nome
                PicPlayDiLogo.Image = logoImage;
                LblPlayDiName.Text = selectedCompany.Name;

                // Atualiza o logo e nome da empresa sorteada na interface do modo digital
                PicPlayDiLogo.Image = logoImage;
                LblPlayDiName.Text = selectedCompany.Name;

                // Atualiza o logo na segunda tela, se estiver visível
                if (logoDisplayForm != null && logoDisplayForm.Visible)
                {
                    logoDisplayForm.UpdateLogoAndName(logoImage, selectedCompany.Name);
                }

                // Verifica as cartelas que possuem a empresa sorteada
                int bingoPhase = RdPlayDi1.Checked ? 1 : 2;

                List<int> cardNumbers = PlayService.CheckCards(selectedCompany.Id, setId);
                string cardNumbersText = string.Join(", ", cardNumbers);
                LblPlayDiMsg.Text = string.IsNullOrEmpty(cardNumbersText) ? "\nNenhuma cartela sorteada." : $"\nCartelas sorteadas: {cardNumbersText}";

                // Se houver cartelas sorteadas, verifica se há vencedoras
                if (!string.IsNullOrEmpty(cardNumbersText))
                {
                    List<int> winningCards = PlayService.CheckBingo(cardNumbers, setId, bingoPhase, selectedCompany.Id);

                    if (winningCards.Count > 0)
                    {
                        string winningCardsText = string.Join(", ", winningCards);
                        LblPlayDiMsg.Text += string.IsNullOrEmpty(LblPlayDiMsg.Text) ? "" : "\n\n";
                        LblPlayDiMsg.Text += $"Cartelas vencedoras: {winningCardsText}";
                    }
                }

                // Não remover a label do painel, apenas a empresa da lista de sorteio.
            }
        }





        //Design

        private void HideTabControlTabs()
        {
            MainPage.Appearance = TabAppearance.FlatButtons;
            MainPage.ItemSize = new Size(0, 1);
            MainPage.SizeMode = TabSizeMode.Fixed;

            CreatePage.Appearance = TabAppearance.FlatButtons;
            CreatePage.ItemSize = new Size(0, 1);
            CreatePage.SizeMode = TabSizeMode.Fixed;

            EditPage.Appearance = TabAppearance.FlatButtons;
            EditPage.ItemSize = new Size(0, 1);
            EditPage.SizeMode = TabSizeMode.Fixed;

            PlayPage.Appearance = TabAppearance.FlatButtons;
            PlayPage.ItemSize = new Size(0, 1);
            PlayPage.SizeMode = TabSizeMode.Fixed;
        }

        //Home Screen
        private void BtnCreateScreen_MouseHover(object sender, EventArgs e)
        {
            LblHomeCreate.Visible = true;
        }
        private void BtnEditScreen_MouseHover(object sender, EventArgs e)
        {
            LblHomeEdit.Visible = true;
        }
        private void BtnPlayScreen_MouseHover(object sender, EventArgs e)
        {
            LblHomePlay.Visible = true;
        }
        private void BtnCreateScreen_MouseLeave(object sender, EventArgs e)
        {
            LblHomeCreate.Visible = false;
        }
        private void BtnEditScreen_MouseLeave(object sender, EventArgs e)
        {
            LblHomeEdit.Visible = false;
        }
        private void BtnPlayScreen_MouseLeave(object sender, EventArgs e)
        {
            LblHomePlay.Visible = false;
        }
        private void BtnCreateScreen_Click(object sender, EventArgs e)
        {
            CreatePage.SelectedTab = TabCreateMain;
            MainPage.SelectedTab = TabCreatePage;
        }
        private void BtnEditScreen_Click(object sender, EventArgs e)
        {
            EditPage.SelectedTab = TabEditMain;
            MainPage.SelectedTab = TabEditPage;
        }
        private void BtnPlayScreen_Click(object sender, EventArgs e)
        {
            PlayPage.SelectedTab = TabPlayMain;
            MainPage.SelectedTab = TabPlayPage;
        }
        private void BtnNewList_Click(object sender, EventArgs e)
        {
            CreatePage.SelectedTab = TabCreateList;
        }
        private void BtnNewComp_Click(object sender, EventArgs e)
        {
            CreatePage.SelectedTab = TabCreateCompany;
        }
        private void BtnNewCards_Click(object sender, EventArgs e)
        {
            CreatePage.SelectedTab = TabCreateCards;
        }
        private void BtnEditList_Click(object sender, EventArgs e)
        {
            BtnEditAddCL.Enabled = false;
            BtnEditRemoveCL.Enabled = false;
            BtnEditListDelete.Enabled = false;

            FlowEditViewSel.Controls.Clear();

            LoadLists();
            LoadComps();
            EditListConfigureLayout();
            LoadAllComp();

            EditPage.SelectedTab = TabEditList;

        }
        private void BtnEditCompany_Click(object sender, EventArgs e)
        {
            LoadLists();
            LoadComps();
            EditListConfigureLayout();
            LoadAllComp();

            EditPage.SelectedTab = TabEditCompany;
        }
        private void BtnVisuComp_Click(object sender, EventArgs e)
        {
            LblVisu1.Text = "";
            LblVisu2.Text = "";
            LblVisu3.Text = "";
            LblVisu4.Text = "";
            LblVisu5.Text = "";
            CboVisu.Text = "";
            FlwEditVisu.Controls.Clear();
            EditPage.SelectedTab = TabEditVisualize;
        }
        private void BtnPlayAnalog_Click(object sender, EventArgs e)
        {
            BtnRestartAn.Enabled = false;
            PlayPage.SelectedTab = TabPlayAnalog;
        }
        private void BtnPlayDigital_Click(object sender, EventArgs e)
        {
            BtnRestartDigital.Enabled = false;
            PlayPage.SelectedTab = TabPlayDigital;
        }
        private void BtnReturnCreateMain_Click(object sender, EventArgs e)
        {
            ReturnToMain();
        }
        private void BtnReturnPlayMain_Click(object sender, EventArgs e)
        {
            ReturnToMain();
        }
        private void BtnReturnEditMain_Click(object sender, EventArgs e)
        {
            ReturnToMain();
        }
        private void BtnReturnCreateList_Click(object sender, EventArgs e)
        {
            ReturnToCreate();
        }
        private void BtnReturnCreateCompany_Click(object sender, EventArgs e)
        {
            ReturnToCreate();
        }
        private void BtnReturnCreateCards_Click(object sender, EventArgs e)
        {
            ReturnToCreate();
        }
        private void BtnReturnEditCompany_Click(object sender, EventArgs e)
        {
            ReturnToEdit();
        }
        private void BtnReturnEditList_Click(object sender, EventArgs e)
        {
            ReturnToEdit();
        }
        private void BtnReturnVisu_Click(object sender, EventArgs e)
        {
            ReturnToEdit();
        }
        private void BtnReturnPlayDigital_Click(object sender, EventArgs e)
        {
            ReturnToPlay();
        }
        private void BtnReturnPlayAnalog_Click(object sender, EventArgs e)
        {
            ReturnToPlay();
        }
        private void ReturnToMain()
        {
            MainPage.SelectedTab = TabMainPage;
        }
        private void ReturnToEdit()
        {
            CboEditListSel.SelectedIndex = -1;
            CboEditListSel.Text = String.Empty;
            BoxEditFilterCL.Text = String.Empty;
            LblEditListMsg.Text = String.Empty;

            CboEditComp.SelectedIndex = -1;
            CboEditComp.Text = String.Empty;
            BoxEditNameComp.Text = String.Empty;
            BoxEditCardNameComp.Text = String.Empty;
            BoxEditPhoneComp.Text = String.Empty;
            BoxEditEmailComp.Text = String.Empty;
            LblEditMsgComp.Text = String.Empty;
            PicEditLogoComp.Image = null;

            LblVisuCont1.Text = String.Empty;
            LblVisuCont2.Text = String.Empty;
            LblVisuCont3.Text = String.Empty;
            LblVisuCont4.Text = String.Empty;
            LblVisuCont5.Text = String.Empty;
            PicVisuLogo.Image = null;

            LblVisu1.Text = String.Empty;
            LblVisu2.Text = String.Empty;
            LblVisu3.Text = String.Empty;
            LblVisu4.Text = String.Empty;
            LblVisu5.Text = String.Empty;
            CboVisu.Text = String.Empty;

            foreach (Control control in FlwEditVisu.Controls)
            {
                if (control is Label lbl)
                {
                    lbl.BackColor = Color.Transparent;
                }
            }

            LoadLists();
            LoadComps();
            EditListConfigureLayout();
            LoadAllComp();
            LoadGames();

            EditPage.SelectedTab = TabEditMain;
        }
        private void ReturnToCreate()
        {
            BoxCreateListName.Text = String.Empty;
            BoxCreateListDescription.Text = String.Empty;
            PicCreateListLogo.Image = null;
            LblCreateListMessage.Text = String.Empty;

            BoxCreateCompanyName.Text = String.Empty;
            BoxCreateCompanyCardName.Text = String.Empty;
            BoxCreateCompanyPhone.Text = String.Empty;
            BoxCreateCompanyEmail.Text = String.Empty;
            CboCreateCompanyList.SelectedIndex = -1;
            CboCreateCompanyList.Text = String.Empty;
            PicCreateCompanyLogo.Image = null;
            LblCreateCompanyMessage.Text = String.Empty;

            CboCreateCardsList.SelectedIndex = -1;
            CboCreateCardsList.Text = String.Empty;
            BoxCreateCardsName.Text = String.Empty;
            BoxCreateCardsQuant.Text = String.Empty;
            BoxCreateCardsTitle.Text = String.Empty;
            BoxCreateCardsEnd.Text = String.Empty;
            LblCreateCardsMsg.Text = String.Empty;

            FlwEditVisu.Controls.Clear();

            LoadLists();
            LoadComps();
            EditListConfigureLayout();
            LoadAllComp();
            LoadGames();

            CreatePage.SelectedTab = TabCreateMain;
        }
        private void ReturnToPlay()
        {
            if (string.IsNullOrEmpty(CboPlayAnSelection.Text) && string.IsNullOrEmpty(CboPlayDiSelection.Text))
            {
                ResetGame();

                CboPlayAnSelection.SelectedIndex = -1;
                CboPlayAnSelection.Text = String.Empty;
                CboPlayDiSelection.SelectedIndex = -1;
                CboPlayDiSelection.Text = String.Empty;

                LoadLists();
                LoadComps();
                EditListConfigureLayout();
                LoadAllComp();
                LoadGames();

                PlayPage.SelectedTab = TabPlayMain;
            }
            else
            {
                var result = MessageBox.Show("Você tem certeza que deseja retornar ao menu de jogo? A partida será reinicada e todos os sorteios serão perdidos.",
                                               "Confirmar Retorno",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }

                ResetGame();

                CboPlayAnSelection.SelectedIndex = -1;
                CboPlayAnSelection.Text = String.Empty;
                CboPlayDiSelection.SelectedIndex = -1;
                CboPlayDiSelection.Text = String.Empty;

                LoadLists();
                LoadComps();
                EditListConfigureLayout();
                LoadAllComp();
                LoadGames();

                PlayPage.SelectedTab = TabPlayMain;
            }
        }
    }
}
