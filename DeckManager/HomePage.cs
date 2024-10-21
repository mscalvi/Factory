using DeckManager.Services;
using Newtonsoft.Json.Linq;
using DeckManager.Views;

namespace DeckManager
{
    public partial class HomePage : Form
    {
        private readonly ScryfallAPI _api; 
        private Button selectedButton = null;


        public HomePage()
        {
            InitializeComponent();
            _api = new ScryfallAPI();

            CatFlowAtt(); // Inicializar Tabela de Categorias
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
            DecksControl.SelectedTab = TabCategory;
        }



        //Deck Manager
        private void BtnNewCategory_Click(object sender, EventArgs e)
        {
            TextInputDialog inputDialog = new TextInputDialog("Digite o nome da Categoria:");
            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                string catName = inputDialog.UserInput;

                try
                {
                    DataService.NewCategory(catName); 
                    CatFlowAtt();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnDelCategory_Click(object sender, EventArgs e)
        {
            if (selectedButton != null)
            {
                var selectedCategory = (CategoryModel)selectedButton.Tag; 

                DataService.DeleteCategory(selectedCategory.Id);

                FlwCategoryList.Controls.Remove(selectedButton);
                selectedButton = null; 
            }
        }

        private void CatFlowAtt()
        {
            FlwCategoryList.Controls.Clear();

            List<CategoryModel> categories = DataService.GetCategories(); 

            selectedButton = null;

            foreach (var category in categories)
            {
                Button categoryButton = new Button
                {
                    Text = category.Name,
                    Size = new Size(200, 50), 
                    Padding = new Padding(5),
                    BackColor = Color.LightGray, 
                    FlatStyle = FlatStyle.Flat 
                };

                categoryButton.Tag = category; 

                categoryButton.Click += (sender, e) =>
                {
                    if (selectedButton != null)
                    {
                        selectedButton.BackColor = Color.LightGray; 
                    }

                    selectedButton = categoryButton;

                    categoryButton.BackColor = Color.LightBlue; 
                };

                FlwCategoryList.Controls.Add(categoryButton);
            }
        }


    }
}
