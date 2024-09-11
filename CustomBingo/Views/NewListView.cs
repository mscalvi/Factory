using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomBingo.Models;
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
            ListClass list = new ListClass();

            list.Name = BoxName.Text.ToUpper().Trim();
            list.Description = BoxDescription.Text.Trim();

            if (!string.IsNullOrEmpty(list.Name) && !string.IsNullOrEmpty(list.Description)) 
            {
                try
                {
                    DataService.AddList(list.Name, list.Description);
                    TxtMessage.Text = "Lista " + list.Name + " adicionada com sucesso.";
                    BoxName.Text = "";
                    BoxDescription.Text = "";
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
