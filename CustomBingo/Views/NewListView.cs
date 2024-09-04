using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomBingo.Services;

namespace CustomBingo.Views
{
    public partial class NewListView : UserControl
    {
        public NewListView()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            string ListName = BoxName.Text.ToUpper().Trim();
            string ListDescriptions = BoxDescription.Text.Trim();

            if (!string.IsNullOrEmpty(ListName) && !string.IsNullOrEmpty(ListDescriptions)) 
            {
                try
                {
                    DataService.AddList(ListName, ListDescriptions);
                    TxtMessage.Text = "Lista " + ListName + " adicionada com sucesso.";
                }
                catch
                {
                    TxtMessage.Text = "Erro ao criar a Lista.";
                }
            } else
            {
                if (string.IsNullOrEmpty(BoxName.Text))
                {
                    TxtMessage.Text = "Nome da Lista é obrigatório.";
                } else if (string.IsNullOrEmpty(BoxDescription.Text)) 
                {
                    TxtMessage.Text = "Descrição da Lista é obrigatória.";
                } else
                {
                    TxtMessage.Text = "Erro ao adicionar a lista.";
                }
            }
        }
    }
}
