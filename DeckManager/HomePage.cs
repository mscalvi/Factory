using DeckManager.Services;
using Newtonsoft.Json.Linq;
using DeckManager.Views;
using DeckManager.Models;
using DeckManager.Services;
using DeckManager.Enums;

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

            foreach (var format in formats)
            {
                CreateFilterButton(format.Name, format.Id, FlwFormatsList, (selectedId, clickedButton) =>
                {
                    selectedFormatButton = clickedButton; // Atualiza o botão selecionado
                    DecksFlowAtt(selectedId, selectedOwnerId, selectedArchetypeId, selectedColorId);
                });
            }
        }

        private void OwnersFlowAtt()
        {
            FlwOwnersList.Controls.Clear();

            List<OwnerModel> owners = DataService.GetOwners();

            foreach (var owner in owners)
            {
                CreateFilterButton(owner.Name, owner.Id, FlwOwnersList, (selectedId, clickedButton) =>
                {
                    selectedOwnerButton = clickedButton; // Atualiza o botão selecionado
                    DecksFlowAtt(selectedFormatId, selectedId, selectedArchetypeId, selectedColorId);
                });
            }
        }

        private void ArchetypesFlowAtt()
        {
            FlwArchetypesList.Controls.Clear();

            List<ArchetypeModel> archetypes = DataService.GetArchetypes();

            foreach (var archetype in archetypes)
            {
                CreateFilterButton(archetype.Name, archetype.Id, FlwArchetypesList, (selectedId, clickedButton) =>
                {
                    selectedArchetypeButton = clickedButton; // Atualiza o botão selecionado
                    DecksFlowAtt(selectedFormatId, selectedOwnerId, selectedId, selectedColorId);
                });
            }
        }

        private void ColorsFlowAtt()
        {
            FlwColorsList.Controls.Clear();

            List<ColorModel> colors = DataService.GetColors();

            foreach (var color in colors)
            {
                CreateFilterButton(color.Name, color.Id, FlwColorsList, (selectedId, clickedButton) =>
                {
                    selectedColorButton = clickedButton; // Atualiza o botão selecionado
                    DecksFlowAtt(selectedFormatId, selectedOwnerId, selectedArchetypeId, selectedId);
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
                Size = new Size(200, 50),
                FlatStyle = FlatStyle.Flat,
                Tag = tag
            };

            filterButton.Click += (sender, e) =>
            {
                Button clickedButton = sender as Button; // Captura o botão que foi clicado

                if (clickedButton != null)
                {
                    // Desmarcar o botão anterior, se houver
                    if (selectedFormatButton != null)
                    {
                        selectedFormatButton.BackColor = SystemColors.Control;
                    }

                    if (selectedOwnerButton != null)
                    {
                        selectedOwnerButton.BackColor = SystemColors.Control;
                    }

                    if (selectedArchetypeButton != null)
                    {
                        selectedArchetypeButton.BackColor = SystemColors.Control;
                    }

                    if (selectedColorButton != null)
                    {
                        selectedColorButton.BackColor = SystemColors.Control;
                    }

                    // Atualiza o botão selecionado
                    // Aqui você verifica o tipo de botão e atualiza a variável correspondente
                    if (parentPanel == FlwFormatsList)
                    {
                        selectedFormatButton = clickedButton; // Atualiza para o botão de formato
                    }
                    else if (parentPanel == FlwOwnersList)
                    {
                        selectedOwnerButton = clickedButton; // Atualiza para o botão de dono
                    }
                    else if (parentPanel == FlwArchetypesList)
                    {
                        selectedArchetypeButton = clickedButton; // Atualiza para o botão de arquétipo
                    }
                    else if (parentPanel == FlwColorsList)
                    {
                        selectedColorButton = clickedButton; // Atualiza para o botão de cor
                    }

                    clickedButton.BackColor = Color.LightBlue;

                    // Chama a ação passada com o ID do botão e o botão clicado
                    onClickAction((int)clickedButton.Tag, clickedButton);
                }
            };

            parentPanel.Controls.Add(filterButton);
        }


        //Decks
        private void BtnNewDeck_Click(object sender, EventArgs e)
        {
            {
                NewDeck inputDialog = new NewDeck();
                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    string deckName = inputDialog.UserInput;
                    int deckFormat = inputDialog.SelectedFormatId;

                    try
                    {
                        DataService.NewDeck(deckName, deckFormat);
                        FormatsFlowAtt();
                        DecksFlowAtt();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DecksFlowAtt(int? formatId = null, int? ownerId = null, int? archetypeId = null, int? colorId = null)
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
                ColumnCount = 7,
                AutoSize = false,
                Width = PnlDecksList.Width,
                Height = PnlDecksList.Height,
                RowCount = decks.Count + 1
            };

            Font headerFont = new Font("Arial", 14, FontStyle.Bold);
            Font dataFont = new Font("Arial", 12);

            table.Controls.Add(new Label { Text = "Nº", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(121, 30) }, 0, 0);
            table.Controls.Add(new Label { Text = "ID", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(121, 30) }, 1, 0);
            table.Controls.Add(new Label { Text = "Nome", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(400, 30) }, 2, 0);
            table.Controls.Add(new Label { Text = "Formato", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(223, 30) }, 3, 0);
            table.Controls.Add(new Label { Text = "Dono", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(223, 30) }, 4, 0);
            table.Controls.Add(new Label { Text = "Arquétipo", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(300, 30) }, 5, 0);
            table.Controls.Add(new Label { Text = "Cores", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(223, 30) }, 6, 0);

            for (int i = 0; i < decks.Count; i++)
            {
                var deck = decks[i];

                table.Controls.Add(new Label { Text = (i + 1).ToString(), AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(121, 30) }, 0, i + 1);
                table.Controls.Add(new Label { Text = deck.Id.ToString(), AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(121, 30) }, 1, i + 1);
                table.Controls.Add(new Label { Text = deck.Name, AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(400, 30) }, 2, i + 1);
                table.Controls.Add(new Label { Text = deck.FormatName, AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(223, 30) }, 3, i + 1);
                table.Controls.Add(new Label { Text = deck.OwnerName, AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(223, 30) }, 4, i + 1);
                table.Controls.Add(new Label { Text = deck.ArchetypeName, AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(300, 30) }, 5, i + 1);
                table.Controls.Add(new Label { Text = deck.ColorNames, AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(223, 30) }, 6, i + 1);
            }

            FlwDecksList.Controls.Add(table);
        }

    }
}
