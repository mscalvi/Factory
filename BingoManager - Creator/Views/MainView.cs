using BingoCreator.Models;
using BingoCreator.Services;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace BingoCreator
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();

            DataService.InitializeDatabase();

            LoadLists();
        }

        // Métodos de Carregamento
        // Método para carregar as ComboBox de Listas
        private void LoadLists()
        {
            ListModel[] AllLists;
            {
                DataTable dt = DataService.GetLists();
                AllLists = dt.AsEnumerable()
                                  .Select(row => new ListModel
                                  {
                                      Id = Convert.ToInt32(row["Id"]),
                                      Name = row["Name"].ToString(),
                                      Description = row["Description"].ToString(),
                                      ImageName = row["ImageName"].ToString()
                                  })
                                  .ToArray();
            }

            cboElementList.Items.Clear();
            cboCardsList.Items.Clear();

            foreach (var lm in AllLists)
            {
                cboElementList.Items.Add(lm);
                cboCardsList.Items.Add(lm);
            }

            cboElementList.DisplayMember = "Name";
            cboCardsList.DisplayMember = "Name";
        }


        // Métodos de Criação
        // Criar uma Elemento
        private void btnElementCreat_Clicked(object sender, EventArgs e)
        {
            ElementModel element = new ElementModel();

            element.Name = boxElementName.Text.Trim();
            element.CardName = boxElementCardName.Text.Trim();
            element.Note1 = boxElementNote1.Text.Trim();
            element.Note2 = boxElementNote1.Text.Trim();

            int maxNameLength = 100;
            int maxCardNameLength = 60;
            int maxNotesLength = 250;

            if (string.IsNullOrEmpty(element.Name) || string.IsNullOrEmpty(element.CardName))
            {
                lblElementMessage.Text = "Nome e Nome para Cartela são obrigatórios.";
                return;
            }

            if (element.Name.Length > maxNameLength)
            {
                lblElementMessage.Text = $"O nome do Elemento deve ter no máximo {maxNameLength} caracteres.";
                return;
            }

            if (element.CardName.Length > maxCardNameLength)
            {
                lblElementMessage.Text = $"O nome para cartela deve ter no máximo {maxCardNameLength} caracteres.";
                return;
            }

            if (element.Note1.Length > maxNotesLength)
            {
                lblElementMessage.Text = $"A anotação 1 deve ter no máximo {maxNotesLength} caracteres.";
                return;
            }

            if (element.Note2.Length > maxNotesLength)
            {
                lblElementMessage.Text = $"A anotação 2 deve ter no máximo {maxNotesLength} caracteres.";
                return;
            }

            try
            {
                string relativePath = Path.Combine("images", element.CardName + "_e.png");
                element.AddDate = DateTime.Now.ToString("MMddyyyy - HH:mm:ss");
                int elementId = DataService.CreateElement(element.Name, element.CardName, element.Note1, element.Note2, relativePath, element.AddDate);

                lblElementMessage.Text = "Elemento " + element.Name + " adicionado com sucesso.";

                if (cboElementList.SelectedIndex > -1)
                {
                    var list = cboElementList.SelectedItem as ListModel;
                    int selectedList = list.Id;

                    List<int> elements = new List<int>();
                    elements.Add(elementId);
                    
                    try
                    {
                        DataService.AlocateElements(selectedList, elements);

                        lblElementMessage.Text = "Elemento " + element.CardName + " adicionado com sucesso à Lista " + list.Name;
                    }
                    catch (Exception ex)
                    {
                        lblElementMessage.Text = "Erro ao adicionar o Elemento à Lista. " + ex.Message;
                    }
                }

                boxElementName.Text = "";
                boxElementCardName.Text = "";
                boxElementNote1.Text = "";
                boxElementNote2.Text = "";
                cboElementList.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                lblElementMessage.Text = "Erro ao adicionar o Elemento: " + ex.Message;
            }
        }

        // Criar Lista
        private void btnListCreate_Clicked(object sender, EventArgs e)
        {
            ListModel list = new ListModel();

            list.Name = boxListName.Text.ToUpper().Trim();
            list.Description = boxListDescription.Text.Trim();

            int maxNameLength = 100;
            int maxDescriptionLength = 300;

            if (!string.IsNullOrEmpty(list.Name))
            {
                if (list.Name.Length > maxNameLength)
                {
                    lblListMessage.Text = $"O nome da Lista deve ter no máximo {maxNameLength} caracteres.";
                    return;
                }

                if (list.Description.Length > maxDescriptionLength)
                {
                    lblListMessage.Text = $"A descrição da Lista deve ter no máximo {maxDescriptionLength} caracteres.";
                    return;
                }

                if (string.IsNullOrEmpty(list.Description))
                {
                    list.Description = "*";
                }

                try
                {
                    string relativePath = Path.Combine("images", list.Name + "_default.png");
                    DataService.CreateList(list.Name, list.Description, relativePath);

                    lblListMessage.Text = "Lista " + list.Name + " adicionada com sucesso.";
                    boxListName.Text = "";
                    boxListDescription.Text = "";
                }
                catch (Exception ex)
                {
                    lblListMessage.Text = "Erro ao conectar ao Banco de Dados: " + ex.Message;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(boxListName.Text))
                {
                    lblListMessage.Text = "Nome da Lista é obrigatório.";
                }
                else
                {
                    lblListMessage.Text = "Erro ao adicionar a Lista.";
                }
            }

            LoadLists();
        }

        //Criar Cartelas
        private void btnExportCards_Click(object sender, EventArgs e)
        {
            CardSetModel cards = new CardSetModel();

            int maxNameLength = 50;
            int maxQuantity = 2000;
            int maxTitleLength = 120;
            int maxEndLength = 200;

            cards.Name = boxCardsName.Text.Trim();
            cards.Title = boxCardsTitle.Text.Trim();
            cards.End = boxCardsEnd.Text.Trim();

            if (int.TryParse(boxCardsQuant.Text.Trim(), out int quantidade))
            {
                cards.Quantity = quantidade;
            }
            else
            {
                MessageBox.Show("Informe um número válido para a quantidade de cartelas.");
            }

            if (string.IsNullOrEmpty(cards.Name) || cards.Name.Length > maxNameLength)
            {
                lblCardsMessage.Text = $"Insira um nome para o conjunto de cartelas com no máximo {maxNameLength} caracteres!";
                return;
            }

            if (cboCardsList.SelectedItem != null)
            {
                cards.ListId = (int)(cboCardsList.SelectedItem as dynamic).Value;

                List<DataRow> List = DataService.GetElementsInList(cards.ListId);

                int ElementCount = List.Count;

                if (radCardsSize4.Checked == true)
                {
                    if (ElementCount < 35)
                    {
                        lblCardsMessage.Text = $"A Lista deve ter pelo menos 35 Elementos, a Lista {cards.ListId} tem apenas {ElementCount}!";
                        return;
                    }
                }
                else if (radCardsSize5.Checked == true)
                {
                    {
                        if (ElementCount < 45)
                        {
                            lblCardsMessage.Text = $"A Lista deve ter pelo menos 45 Elementos, a Lista {cards.ListId} tem apenas {ElementCount}!";
                            return;
                        }
                    }

                    if (string.IsNullOrEmpty(cards.Title) || cards.Title.Length > maxTitleLength)
                    {
                        lblCardsMessage.Text = $"Insira um título para as Cartelas com no máximo {maxTitleLength} caracteres!";
                        return;
                    }

                    if (string.IsNullOrEmpty(cards.End) || cards.End.Length > maxEndLength)
                    {
                        lblCardsMessage.Text = $"O final deve ter no máximo {maxEndLength} caracteres!";
                        return;
                    }

                    if (cards.Quantity <= maxQuantity)
                    {
                        try
                        {
                            btnCardsExport.Enabled = false;
                            int generatedCards = GeneratingService.CreateCards(cards.ListId, cards.Name, cards.Title, cards.End, cards.Quantity, cards.CardsSize);
                            lblCardsMessage.Text = "Cartelas criadas com sucesso.";
                        }
                        catch
                        {
                            lblCardsMessage.Text = "Erro ao gerar as cartelas.";
                        }
                    }
                    else
                    {
                        lblCardsMessage.Text = $"Apenas números na quantidade! A quantidade máxima permitida é {maxQuantity}.";
                        return;
                    }
                }
            }
            else
            {
                lblCardsMessage.Text = "Selecione uma Lista!";
            }

                boxCardsName.Text = string.Empty;
                boxCardsQuant.Text = string.Empty;
                boxCardsTitle.Text = string.Empty;
                boxCardsEnd.Text = string.Empty;
                cboCardsList.SelectedIndex = -1;
                lblCardsMessage.Text = "Cartelas criadas com sucesso!";
                btnCardsExport.Enabled = true;
        }
    }
}
