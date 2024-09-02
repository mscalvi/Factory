using System.Windows.Forms;
using System;
using BingoManager.Modelo;
using BingoManager.Banco;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace BingoManager
{
    public partial class NewList : Form
    {
        private StartScreen startScreen;

        // Construtor que aceita uma referência do StartScreen
        public NewList(StartScreen screen)
        {
            InitializeComponent();
            startScreen = screen;
        }

        private void btnReturnCreate_Click(object sender, EventArgs e)
        {
            // Utilize a referência passada para acessar os componentes públicos
            startScreen.CreationPanel.Enabled = true;
            startScreen.btnReturnStart.Enabled = true;

            this.Close();  
        }

        private void btnNewListReady_Click(object sender, EventArgs e)
        {
            //Mover dados
            ListModel NewListCreated = new ListModel();
            NewListCreated.Name = NewListName.Text;
            NewListCreated.Description = NewListDescription.Text;

            //Validar dados
            List<ValidationResult> listErrors = new List<ValidationResult>();
            ValidationContext contexto = new ValidationContext(NewListCreated);
            bool isValid = Validator.TryValidateObject(NewListCreated, contexto, listErrors, true);
            if (isValid)
            {
                if (ListDataAccess.SaveList(NewListCreated.Name, NewListCreated.Description))
                {
                    lblResultList.Text = "Lista criada.";
                    NewListName.Text = "";
                    NewListDescription.Text = "";
                }
                else
                {
                    lblResultList.Text = "Ocorreu um erro.";
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (ValidationResult erro in listErrors)
                {
                    sb.Append(erro.ErrorMessage + "\n");
                }
                lblResultList.Text = sb.ToString();
            }

        }
    }
}
