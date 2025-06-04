using BingoCreator.Models;
using BingoCreator.Services;
using System.Collections.Generic;
using System.Data;

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
                                      Image = row["ImageName"].ToString()
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


    }
}
