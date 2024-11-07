using DeckManager.Services;
using Newtonsoft.Json.Linq;
using DeckManager.Views;
using DeckManager.Models;
using DeckManager.Services;
using DeckManager.Enums;
using System.Data.Entity.Migrations.Builders;
using System.Windows.Forms;

namespace DeckManager
{
    public partial class HomePage : Form
    {
        private readonly ScryfallAPI _api;

        private int? selectedFormatId = null;
        private int? selectedOwnerId = null;
        private int? selectedArchetypeId = null;
        private int? selectedColorId = null;

        private Button selectedFormatButton = null;
        private Button selectedOwnerButton = null;
        private Button selectedArchetypeButton = null;
        private Button selectedColorButton = null;

        Panel selectedRowPanel = null;


        public HomePage()
        {
            InitializeComponent();
            _api = new ScryfallAPI();

            FiltersAtt(); // Inicializar os Filtros
            DecksFlowAtt(); // Inicializar Tabela de Decks
        }

        //Card Finder
        private async void BoxFinder_TextChanged(object sender, EventArgs e)
        {
            string cardName = BoxFinder.Text.Trim();

            if (!string.IsNullOrEmpty(cardName))
            {
                var scryfallService = new ScryfallAPI();
                string result = await scryfallService.SearchCardByNameAsync(cardName);

                // Aqui você pode tratar o JSON retornado e exibir os resultados no FlowLayoutPanel (FlwFinder)
                // Parsear o resultado JSON e popular a interface
                DisplayCardResults(result);
            }

            if (string.IsNullOrEmpty(cardName))
            {
                FlwFinder.Controls.Clear();
            }
        }

        private async void BtnFinder_Click(object sender, EventArgs e)
        {
            string cardName = BoxFinder.Text;
            if (!string.IsNullOrEmpty(cardName))
            {
                var scryfallService = new ScryfallAPI();
                string result = await scryfallService.SearchCardByNameAsync(cardName);
                DisplayCardResults(result);
            }
        }

        // Exibe as cartas encontradas no FlowLayoutPanel
        private void DisplayCardResults(string jsonResponse)
        {
            // Limpa o FlowLayoutPanel antes de adicionar novos resultados
            FlwFinder.Controls.Clear();

            // Aqui você faria o parse do JSON e mostraria os resultados. Exemplo simplificado:
            if (jsonResponse.StartsWith("{") || jsonResponse.StartsWith("["))
            {
                // Use um parser de JSON, como o Newtonsoft.Json, para analisar a resposta e criar controles visuais
                dynamic cards = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse);

                foreach (var card in cards.data)  // Assumindo que há um array "data" com as cartas
                {
                    // Exibe o nome da carta em um Label (pode customizar como desejar)
                    var cardLabel = new Label();
                    cardLabel.Text = card.name.ToString();
                    FlwFinder.Controls.Add(cardLabel);
                }
            }
            else
            {
                // Exibir mensagem de erro se a resposta não for JSON válido
                MessageBox.Show(jsonResponse);
            }
        }

        // Método para criar um painel com as informações da carta
        private Panel CreateCardPanel(JObject card)
        {
            string name = card["name"].ToString();
            string type = card["type_line"].ToString();
            string imageUrl = card["image_uris"]?["small"]?.ToString();
            string oracleText = card["oracle_text"]?.ToString() ?? "Texto não disponível";

            // Criar o painel para a carta
            Panel panel = new Panel();
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Width = 200;
            panel.Height = 300;
            panel.Margin = new Padding(10);

            // Criar os controles para o nome, tipo e imagem
            Label lblName = new Label();
            lblName.Text = name;
            lblName.Font = new Font("Arial", 10, FontStyle.Bold);
            lblName.AutoSize = true;
            lblName.Location = new Point(10, 10);

            Label lblType = new Label();
            lblType.Text = type;
            lblType.Font = new Font("Arial", 8);
            lblType.AutoSize = true;
            lblType.Location = new Point(10, 40);

            Label lblOracleText = new Label();
            lblOracleText.Text = oracleText;
            lblOracleText.Font = new Font("Arial", 7);
            lblOracleText.AutoSize = true;
            lblOracleText.MaximumSize = new Size(180, 60);
            lblOracleText.Location = new Point(10, 70);

            // Criar PictureBox para exibir a imagem
            PictureBox pictureBox = new PictureBox();
            if (!string.IsNullOrEmpty(imageUrl))
            {
                pictureBox.Load(imageUrl); // Carregar a imagem da URL
            }
            else
            {
                pictureBox.BackColor = Color.Gray; // Se não houver imagem, usar cor de fundo
            }
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Location = new Point(10, 140);
            pictureBox.Size = new Size(180, 150);

            // Adicionar os controles ao painel da carta
            panel.Controls.Add(lblName);
            panel.Controls.Add(lblType);
            panel.Controls.Add(lblOracleText);
            panel.Controls.Add(pictureBox);

            return panel;
        }


        //Ui Control
        private void BtnDeckManager_Click(object sender, EventArgs e)
        {
            MainControl.SelectedTab = TabDecks;
            DecksControl.SelectedTab = TabFormats;
        }
        private void BtnReturn_Click(object sender, EventArgs e)
        {
            MainControl.SelectedTab = TabHome;
            DecksControl.SelectedTab = TabFormats;
        }



        //Deck Manager
        //Filtros
        private void BtnNewFilter_Click(object sender, EventArgs e)
        {
            NewFilter newFilterDialog = new NewFilter();
            if (newFilterDialog.ShowDialog() == DialogResult.OK)
            {
                string filterName = newFilterDialog.UserInput;
                FilterType filterType = newFilterDialog.SelectedFilterType;

                DataService.CreateFilter(filterName, filterType);
                FiltersAtt();
            }
        }
        private void BtnDelFilter_Click(object sender, EventArgs e)
        {
            DelFilter newFilterDialog = new DelFilter();
            if (newFilterDialog.ShowDialog() == DialogResult.OK)
            {
                string filterName = newFilterDialog.UserInput;
                FilterType filterType = newFilterDialog.SelectedFilterType;

                DataService.DeleteFilter(filterName, filterType);
                FiltersAtt();
            }
        }
        private void FiltersAtt()
        {
            FormatsFlowAtt();
            OwnersFlowAtt();
            ArchetypesFlowAtt();
            ColorsFlowAtt();
        }
        private void FormatsFlowAtt()
        {
            FlwFormatsList.Controls.Clear();

            List<FormatModel> formats = DataService.GetFormats();

            var sortedFormats = formats.OrderBy(f => f.Name).ToList();

            foreach (var format in sortedFormats)
            {
                CreateFilterButton(format.Name, format.Id, FlwFormatsList, (selectedId, clickedButton) =>
                {
                    selectedFormatButton = clickedButton; // Atualiza o botão selecionado
                    selectedFormatId = selectedId;
                    DecksFlowAtt(selectedFormatId, selectedOwnerId, selectedArchetypeId, selectedColorId);
                });
            }
        }
        private void OwnersFlowAtt()
        {
            FlwOwnersList.Controls.Clear();

            List<OwnerModel> owners = DataService.GetOwners();

            var sortedOwners = owners.OrderBy(f => f.Name).ToList();

            foreach (var owner in sortedOwners)
            {
                CreateFilterButton(owner.Name, owner.Id, FlwOwnersList, (selectedId, clickedButton) =>
                {
                    selectedOwnerButton = clickedButton; // Atualiza o botão selecionado
                    selectedOwnerId = selectedId;
                    DecksFlowAtt(selectedFormatId, selectedOwnerId, selectedArchetypeId, selectedColorId);
                });
            }
        }
        private void ArchetypesFlowAtt()
        {
            FlwArchetypesList.Controls.Clear();

            List<ArchetypeModel> archetypes = DataService.GetArchetypes();

            var sortedArchetypes = archetypes.OrderBy(f => f.Name).ToList();

            foreach (var archetype in sortedArchetypes)
            {
                CreateFilterButton(archetype.Name, archetype.Id, FlwArchetypesList, (selectedId, clickedButton) =>
                {
                    selectedArchetypeButton = clickedButton; // Atualiza o botão selecionado
                    selectedArchetypeId = selectedId;
                    DecksFlowAtt(selectedFormatId, selectedOwnerId, selectedArchetypeId, selectedColorId);
                });
            }
        }
        private void ColorsFlowAtt()
        {
            FlwColorsList.Controls.Clear();

            List<ColorModel> colors = DataService.GetColors();

            var sortedColors = colors.OrderBy(f => f.Name).ToList();

            foreach (var color in sortedColors)
            {
                CreateFilterButton(color.Name, color.Id, FlwColorsList, (selectedId, clickedButton) =>
                {
                    selectedColorButton = clickedButton; // Atualiza o botão selecionado
                    selectedColorId = selectedId;
                    DecksFlowAtt(selectedFormatId, selectedOwnerId, selectedArchetypeId, selectedColorId);
                });
            }
        }
        private void CreateFilterButton(string buttonText, int tag, FlowLayoutPanel parentPanel, Action<int, Button> onClickAction)
        {
            Button filterButton = new Button
            {
                Text = buttonText,
                AutoSize = true,
                Padding = new Padding(5),
                Size = new Size(120, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.Control,
                Tag = tag
            };

            filterButton.Click += (sender, e) =>
            {
                Button clickedButton = sender as Button; // Captura o botão que foi clicado

                if (clickedButton != null)
                {
                    if (parentPanel == FlwFormatsList)
                    {
                        if (clickedButton.Tag.Equals(selectedFormatId))
                        {
                            clickedButton.BackColor = SystemColors.Control;
                            selectedFormatId = null;
                            selectedFormatButton = null;
                        }
                        else if (selectedFormatButton != null)
                        {
                            selectedFormatButton.BackColor = SystemColors.Control;
                            selectedFormatButton = clickedButton;
                            clickedButton.BackColor = Color.LightBlue;
                            onClickAction((int)clickedButton.Tag, clickedButton);
                        }
                        else
                        {
                            clickedButton.BackColor = Color.LightBlue;
                            onClickAction((int)clickedButton.Tag, clickedButton);
                        }
                    }

                    if (parentPanel == FlwOwnersList)
                    {
                        if (clickedButton.Tag.Equals(selectedOwnerId))
                        {
                            clickedButton.BackColor = SystemColors.Control;
                            selectedOwnerId = null;
                            selectedOwnerButton = null;
                        }
                        else if (selectedOwnerButton != null)
                        {
                            selectedOwnerButton.BackColor = SystemColors.Control;
                            selectedOwnerButton = clickedButton;
                            clickedButton.BackColor = Color.LightBlue;
                            onClickAction((int)clickedButton.Tag, clickedButton);
                        }
                        else
                        {
                            clickedButton.BackColor = Color.LightBlue;
                            onClickAction((int)clickedButton.Tag, clickedButton);
                        }
                    }

                    if (parentPanel == FlwArchetypesList)
                    {
                        if (clickedButton.Tag.Equals(selectedArchetypeId))
                        {
                            clickedButton.BackColor = SystemColors.Control;
                            selectedArchetypeId = null;
                            selectedArchetypeButton = null;
                        }
                        else if (selectedArchetypeButton != null)
                        {
                            selectedArchetypeButton.BackColor = SystemColors.Control;
                            selectedArchetypeButton = clickedButton;
                            clickedButton.BackColor = Color.LightBlue;
                            onClickAction((int)clickedButton.Tag, clickedButton);
                        }
                        else
                        {
                            clickedButton.BackColor = Color.LightBlue;
                            onClickAction((int)clickedButton.Tag, clickedButton);
                        }
                    }

                    if (parentPanel == FlwColorsList)
                    {
                        if (clickedButton.Tag.Equals(selectedColorId))
                        {
                            clickedButton.BackColor = SystemColors.Control;
                            selectedColorId = null;
                            selectedColorButton = null;
                        }
                        else if (selectedColorButton != null)
                        {
                            selectedColorButton.BackColor = SystemColors.Control;
                            selectedColorButton = clickedButton;
                            clickedButton.BackColor = Color.LightBlue;
                            onClickAction((int)clickedButton.Tag, clickedButton);
                        }
                        else
                        {
                            clickedButton.BackColor = Color.LightBlue;
                            onClickAction((int)clickedButton.Tag, clickedButton);
                        }
                    }

                    DecksFlowAtt(selectedFormatId, selectedOwnerId, selectedArchetypeId, selectedColorId);
                }
            };

            parentPanel.Controls.Add(filterButton);
        }
        private void BtnClearFilters_Click(object sender, EventArgs e)
        {
            ResetButtonColors(FlwFormatsList);
            ResetButtonColors(FlwOwnersList);
            ResetButtonColors(FlwArchetypesList);
            ResetButtonColors(FlwColorsList);

            selectedFormatButton = null;
            selectedOwnerButton = null;
            selectedArchetypeButton = null;
            selectedColorButton = null;

            selectedFormatId = null;
            selectedOwnerId = null;
            selectedArchetypeId = null;
            selectedColorId = null;

            DecksFlowAtt();
        }
        private void ResetButtonColors(FlowLayoutPanel flowPanel)
        {
            foreach (Control control in flowPanel.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = SystemColors.Control;
                }
            }
        }

        //Decks
        private void BtnNewDeck_Click(object sender, EventArgs e)
        {
            NewDeck inputDialog = new NewDeck();
            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                string deckName = inputDialog.UserInput;
                int deckFormat = inputDialog.SelectedFormatId;

                try
                {
                    DeckModel newDeck = DataService.NewDeck(deckName, deckFormat);

                    // Cria a nova aba como um clone da TabDeckManager
                    TabService tabBuilder = new TabService(newDeck);
                    TabPage deckTab = tabBuilder.BuildDeckTab(newDeck);
                    DecksControl.TabPages.Add(deckTab);

                    DecksFlowAtt();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void DecksFlowAtt(int? formatId = null, int? ownerId = null, int? archetypeId = null, int? colorId = null)
        {
            FlwDecksList.Controls.Clear();

            List<DeckModel> decks;

            if (formatId == null && ownerId == null && archetypeId == null && colorId == null)
            {
                decks = DataService.GetAllDecks();
            }
            else
            {
                decks = DataService.GetSomeDecks(formatId, ownerId, archetypeId, colorId);
            }

            TableLayoutPanel table = new TableLayoutPanel
            {
                ColumnCount = 8, // Atualiza para 8 colunas
                AutoSize = false,
                Width = PnlDecksList.Width,
                Height = PnlDecksList.Height,
                RowCount = decks.Count + 1,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                Padding = new Padding(0)
            };

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 380));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));

            Font headerFont = new Font("Arial", 14, FontStyle.Bold);
            Font dataFont = new Font("Arial", 11);

            // Adiciona os headers das colunas
            table.Controls.Add(new Label { Text = "", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(100, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 0, 0);
            table.Controls.Add(new Label { Text = "ID", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(100, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 1, 0);
            table.Controls.Add(new Label { Text = "Nome", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(380, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 2, 0);
            table.Controls.Add(new Label { Text = "Formato", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(200, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 3, 0);
            table.Controls.Add(new Label { Text = "Dono", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(200, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 4, 0);
            table.Controls.Add(new Label { Text = "Arquétipo", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(200, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 5, 0);
            table.Controls.Add(new Label { Text = "Cores", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(200, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 6, 0);
            table.Controls.Add(new Label { Text = "Versão", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(200, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 7, 0); // Header da coluna de VersionName

            for (int i = 0; i < decks.Count; i++)
            {
                var deck = decks[i];

                Button actionButton = new Button
                {
                    Text = "Abrir",
                    AutoSize = false,
                    Font = dataFont,
                    Size = new Size(121, 30),
                    BackColor = Color.LightGray,
                    Margin = new Padding(0)
                };

                actionButton.Click += (sender, e) =>
                {
                    OpenDeckTab(deck, deck.Format);
                };

                table.Controls.Add(actionButton, 0, i + 1);
                table.Controls.Add(new Label { Text = deck.Id.ToString(), AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(100, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 1, i + 1);
                table.Controls.Add(new Label { Text = deck.Name, AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(380, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 2, i + 1);
                table.Controls.Add(new Label { Text = deck.FormatName, AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(200, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 3, i + 1);
                table.Controls.Add(new Label { Text = deck.OwnerName, AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(200, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 4, i + 1);
                table.Controls.Add(new Label { Text = deck.ArchetypeName, AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(200, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 5, i + 1);
                table.Controls.Add(new Label { Text = deck.ColorName, AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(200, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 6, i + 1);
                table.Controls.Add(new Label { Text = deck.VersionName ?? "N/A", AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(200, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 7, i + 1); // Nova célula para VersionName
            }

            FlwDecksList.Controls.Add(table);
        }

        private void OpenDeckTab(DeckModel selectedDeck, int formatId)
        {
            // Verifica se a aba já existe
            TabPage existingTab = DecksControl.TabPages.Cast<TabPage>().FirstOrDefault(t => t.Text == selectedDeck.Name);

            selectedDeck = DataService.GetDeckWithDetails(selectedDeck.Id);

            if (existingTab == null)
            {
                TabService tabBuilder = new TabService(selectedDeck);
                TabPage deckTab = tabBuilder.BuildDeckTab(selectedDeck);
                DecksControl.Controls.Add(deckTab);
            }

            // Seleciona a aba
            DecksControl.SelectedTab = existingTab ?? DecksControl.TabPages.Cast<TabPage>().First(t => t.Text == selectedDeck.Name);
        }
        private void DecksControl_Enter(object sender, EventArgs e)
        {
            DecksFlowAtt();
        }
    }
}
