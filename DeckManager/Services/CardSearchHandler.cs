using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace DeckManager.Services
{
    public class CardSearchHandler
    {
        private readonly ScryfallAPI api;
        private TextBox searchBox;        // Referência para a TextBox da HomePage
        private FlowLayoutPanel flowPanel; // Referência para o FlowLayoutPanel da HomePage

        // Construtor que recebe as referências dos controles
        public CardSearchHandler(TextBox searchBox, FlowLayoutPanel flowPanel)
        {
            api = new ScryfallAPI(); // Instanciar a API
            this.searchBox = searchBox;   // Passar referência da TextBox
            this.flowPanel = flowPanel;   // Passar referência do FlowLayoutPanel
        }

        // Método para iniciar a busca e exibir os resultados
        public async Task SearchAndDisplayResults()
        {
            string searchTerm = searchBox.Text; // Pegar o valor da TextBox
            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Fazer a busca via API
                string jsonResponse = await api.SearchCard(searchTerm);
                // Exibir os resultados no FlowLayoutPanel
                DisplayCardResults(jsonResponse);
            }
        }

        // Exibe as cartas encontradas no FlowLayoutPanel
        private void DisplayCardResults(string jsonResponse)
        {
            // Limpar o FlowLayoutPanel antes de adicionar novos resultados
            flowPanel.Controls.Clear();

            if (!string.IsNullOrEmpty(jsonResponse))
            {
                JObject json = JObject.Parse(jsonResponse);
                JArray data = (JArray)json["data"];

                if (data != null && data.Count > 0)
                {
                    foreach (JObject card in data)
                    {
                        // Criar um painel para cada carta e adicionar ao FlowLayoutPanel
                        Panel cardPanel = CreateCardPanel(card);
                        flowPanel.Controls.Add(cardPanel);
                    }
                }
                else
                {
                    MessageBox.Show("Nenhuma carta encontrada.");
                }
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
    }
}