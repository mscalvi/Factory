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
                AutoPopDelay = 5000,  // quanto tempo o bal�o fica vis�vel
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

            // Subscri��o ao evento para detectar mudan�as nos monitores
            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);

            LoadLists();
            LoadComps();
            EditListConfigureLayout();
            LoadAllComp();
            LoadGames();
        }

        //M�todo para mostrar Segunda Tela
        private void ShowLogoOnSecondScreen()
        {
            // Verificar se existem v�rias telas conectadas
            if (Screen.AllScreens.Length > 1)
            {
                // Exibir todas as telas conectadas (para fins de depura��o)
                foreach (var screen in Screen.AllScreens)
                {
                    Console.WriteLine($"Screen: {screen.DeviceName}, Resolution: {screen.Bounds.Width}x{screen.Bounds.Height}");
                }

                // Usa a segunda tela (�ndice 1, j� que a primeira � 0)
                Screen secondScreen = Screen.AllScreens[1];

                // Inicializa o formul�rio de exibi��o do logotipo se ainda n�o estiver criado
                if (logoDisplayForm == null || logoDisplayForm.IsDisposed)
                {
                    logoDisplayForm = new LogoView();
                }

                // Move o formul�rio para a segunda tela
                logoDisplayForm.StartPosition = FormStartPosition.Manual;
                logoDisplayForm.Location = secondScreen.WorkingArea.Location; // Define a localiza��o na segunda tela
                logoDisplayForm.WindowState = FormWindowState.Maximized; // Maximiza na segunda tela
                logoDisplayForm.Show();

                // Se j� houver uma imagem no PicPlayLogo, exibi-la na segunda tela
                if (picPlayLogo.Image != null)
                {
                    // Atualiza o logo e o nome da Elemento na segunda tela
                    logoDisplayForm.UpdateLogoAndName(picPlayLogo.Image, lblLastResult.Text);
                }
            }
            else
            {
                MessageBox.Show("A segunda tela n�o est� dispon�vel.");
            }
        }
        private void MainView_Load(object sender, EventArgs e)
        {
            // Inicializa a segunda tela ao carregar o formul�rio principal
            ShowLogoOnSecondScreen();
        }
        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancelar a subscri��o do evento ao fechar o formul�rio
            SystemEvents.DisplaySettingsChanged -= new EventHandler(SystemEvents_DisplaySettingsChanged);
        }
        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            // Verificar novamente as telas dispon�veis e mover o logo para a segunda tela
            ShowLogoOnSecondScreen();
        }


        //Jogar
        //M�todo para carregar todos os jogos para Jogar
        private void LoadGame()
        {
            DataTable gamesTable = DataService.GetGameInfo();

            CboPlayAnSelection.Items.Clear();

            foreach (DataRow row in gamesTable.Rows)
            {
                string cardName = row["Name"].ToString();
                int cardId = Convert.ToInt32(row["SetId"]);

                CboPlayAnSelection.Items.Add(new { Text = cardName, Value = cardId });
            }

            CboPlayAnSelection.DisplayMember = "Text";
            CboPlayAnSelection.ValueMember = "Value";
        }

        // M�todo para come�ar o jogo
        private void btnStart_click(object sender, EventArgs e)
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
                        lblResults.Text = "Erro ao carregar os dados do jogo selecionado.";
                    }
                }
                else
                {
                    lblResults.Text = "Por favor, selecione um jogo.";
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

        // M�todo para mostrar as Elementos durante o jogo
        private void DisplayGamePanels(GameData gameData)
        {
            int buttonSize = 35;
            int panelWidth = flwPlayB.Width;
            int buttonsPerRow = panelWidth / buttonSize;

            int Number = 1;

            flwPlayB.Controls.Clear();
            flwPlayI.Controls.Clear();
            flwPlayN.Controls.Clear();
            flwPlayG.Controls.Clear();
            flwPlayO.Controls.Clear();

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

                // Define o tooltip para o nome da empresa:
                var companyModel = (ElementModel)companyButton.Tag;
                toolTip1.SetToolTip(companyButton, companyModel.Name);

                Number++;
                companyButton.Click += CompanyButton_Click;
                flwPlayB.Controls.Add(companyButton);
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

                // Define o tooltip para o nome da empresa:
                var companyModel = (ElementModel)companyButton.Tag;
                toolTip1.SetToolTip(companyButton, companyModel.Name);
                Number++;
                companyButton.Click += CompanyButton_Click;
                flwPlayI.Controls.Add(companyButton);
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

                // Define o tooltip para o nome da empresa:
                var companyModel = (ElementModel)companyButton.Tag;
                toolTip1.SetToolTip(companyButton, companyModel.Name);
                Number++;
                companyButton.Click += CompanyButton_Click;
                flwPlayN.Controls.Add(companyButton);
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

                // Define o tooltip para o nome da empresa:
                var companyModel = (ElementModel)companyButton.Tag;
                toolTip1.SetToolTip(companyButton, companyModel.Name);
                Number++;
                companyButton.Click += CompanyButton_Click;
                flwPlayG.Controls.Add(companyButton);
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

                // Define o tooltip para o nome da empresa:
                var companyModel = (ElementModel)companyButton.Tag;
                toolTip1.SetToolTip(companyButton, companyModel.Name);
                Number++;
                companyButton.Click += CompanyButton_Click;
                flwPlayO.Controls.Add(companyButton);
            }

            lblResults.Text = "Jogo iniciado!";
        }

        // Configurando os FlowLayoutPanels
        private void SetupFlowPanels()
        {
            foreach (var flow in new[] { flwPlayB, flwPlayI, flwPlayN, flwPlayG, flwPlayO})
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

            if (clickedButton != null && clickedButton.Tag is ElementModel selectedCompany)
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
                    // Se n�o houver logo da empresa, busca o logo da lista associada pelo CardsList
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
                            // Logo da lista n�o encontrado, usar logo padr�o
                            string defaultLogoPath = Path.Combine(imageFolderPath, "default_logo.jpg");
                            logoImage = File.Exists(defaultLogoPath) ? Image.FromFile(defaultLogoPath) : null;
                        }
                    }
                    else
                    {
                        // Nenhuma lista associada ou logo, usar logo padr�o
                        string defaultLogoPath = Path.Combine(imageFolderPath, "default_logo.jpg");
                        logoImage = File.Exists(defaultLogoPath) ? Image.FromFile(defaultLogoPath) : null;
                    }
                }

                // Marca o bot�o como sorteado, alterando a cor para vermelho
                clickedButton.BackColor = Color.Red;

                // Adiciona a empresa sorteada ao servi�o de jogo
                PlayService.AddCompany(selectedCompany.Id);

                // Atualiza o logo e nome na interface do jogo
                if (logoDisplayForm != null && logoDisplayForm.Visible)
                {
                    logoDisplayForm.UpdateLogoAndName(logoImage, selectedCompany.Name);
                }

                // Atualiza o logo na tela principal
                picPlayLogo.Image = logoImage;
                LblPlayAnName.Text = numero + " - " + selectedCompany.Name;

                // buscar cartelas
                List<int> cardNumbers = PlayService.CheckCards(selectedCompany.Id, setId);

                // verificar bingo
                List<int> winningCards = PlayService.CheckBingo(cardNumbers, setId, bingoPhase, selectedCompany.Id);
                if (winningCards.Count > 0)
                {
                    string winningCardsText = string.Join(", ", winningCards);
                    lblResults.Text = $"BINGO! Cartelas vencedoras: {winningCardsText}";
                }
                else
                {
                    lblResults.Text = "Sem bingo!";
                }

            }
        }


        //M�todo para reinicar o jogo
        private void ResetGame()
        {
            BtnPlayAnSelection.Enabled = true;
            BtnPlayDiSelection.Enabled = true;

            picPlayLogo.Image = null;
            LblPlayAnName.Text = string.Empty;
            lblResults.Text = string.Empty;
            PicPlayDiLogo.Image = null;
            LblPlayDiName.Text = string.Empty;
            LblPlayDiMsg.Text = string.Empty;

            BtnPlayDiRandom.Enabled = false;

            flwPlayB.Controls.Clear();
            flwPlayI.Controls.Clear();
            flwPlayN.Controls.Clear();
            flwPlayG.Controls.Clear();
            flwPlayO.Controls.Clear();

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
            // Confirma��o do usu�rio
            var result = MessageBox.Show("Voc� tem certeza que deseja reiniciar o jogo?", "Confirma��o", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ResetGame();
            }
        }

        // M�todo para sortear uma Elemento no modo Digital e verificar as cartelas sorteadas e vencedoras
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

            // Coleta todas as empresas dispon�veis para sorteio
            var availableCompanies = new List<Label>();

            // Adiciona os labels de todas as colunas ao availableCompanies, que ainda n�o foram sorteados (brancos)
            availableCompanies.AddRange(FlwPlayDiB.Controls.OfType<Label>().Where(lbl => lbl.BackColor == Color.White));
            availableCompanies.AddRange(FlwPlayDiI.Controls.OfType<Label>().Where(lbl => lbl.BackColor == Color.White));
            availableCompanies.AddRange(FlwPlayDiN.Controls.OfType<Label>().Where(lbl => lbl.BackColor == Color.White));
            availableCompanies.AddRange(FlwPlayDiG.Controls.OfType<Label>().Where(lbl => lbl.BackColor == Color.White));
            availableCompanies.AddRange(FlwPlayDiO.Controls.OfType<Label>().Where(lbl => lbl.BackColor == Color.White));

            // Verifica se ainda h� empresas dispon�veis para sortear
            if (availableCompanies.Count == 0)
            {
                MessageBox.Show("Todos os Elementos j� foram sorteados.");
                return;
            }

            // Seleciona aleatoriamente uma empresa dispon�vel
            Random random = new Random();
            int randomIndex = random.Next(availableCompanies.Count);
            Label selectedLabel = availableCompanies[randomIndex];

            // Muda a cor do label sorteado para vermelho (marca como sorteado)
            selectedLabel.BackColor = Color.Red;

            // Atualiza a l�gica do jogo para adicionar a empresa sorteada e remover da lista de sorteio
            if (selectedLabel.Tag is ElementModel selectedCompany)
            {
                // Adiciona a empresa � lista de sorteadas no PlayService
                PlayService.AddCompany(selectedCompany.Id);

                // dentro de BtnPlayDiRandom_Click, ap�s PlayService.AddCompany(...)
                Image logoImage = DataService.LoadImageFromFile(selectedCompany.Logo);

                // Se n�o encontrar na empresa, tenta a lista
                if (logoImage == null)
                {
                    var listData = DataService.GetListByCompanyIdFromCards(selectedCompany.Id, setId);
                    if (listData != null)
                        logoImage = DataService.LoadImageFromFile(listData["Logo"].ToString());
                }

                // Se ainda n�o encontrou, usa a default
                if (logoImage == null)
                    logoImage = DataService.LoadImageFromFile("default_logo.jpg");

                // Atualiza o logo e nome
                PicPlayDiLogo.Image = logoImage;
                LblPlayDiName.Text = selectedCompany.Name;

                // Atualiza o logo e nome da empresa sorteada na interface do modo digital
                PicPlayDiLogo.Image = logoImage;
                LblPlayDiName.Text = selectedCompany.Name;

                // Atualiza o logo na segunda tela, se estiver vis�vel
                if (logoDisplayForm != null && logoDisplayForm.Visible)
                {
                    logoDisplayForm.UpdateLogoAndName(logoImage, selectedCompany.Name);
                }

                // Verifica as cartelas que possuem a empresa sorteada
                int bingoPhase = RdPlayDi1.Checked ? 1 : 2;

                List<int> cardNumbers = PlayService.CheckCards(selectedCompany.Id, setId);
                string cardNumbersText = string.Join(", ", cardNumbers);
                LblPlayDiMsg.Text = string.IsNullOrEmpty(cardNumbersText) ? "\nNenhuma cartela sorteada." : $"\nCartelas sorteadas: {cardNumbersText}";

                // Se houver cartelas sorteadas, verifica se h� vencedoras
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

                // N�o remover a label do painel, apenas a empresa da lista de sorteio.
            }
        }
    }
}
