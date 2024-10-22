using DeckManager.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DeckManager.Views
{
    public partial class NewDeck : Form
    {
        public string UserInput { get; private set; }
        public int SelectedFormatId { get; private set; }

        public NewDeck()
        {
            InitializeComponent();
            CatFlowAtt();
        }

        private void CatFlowAtt()
        {
            FlwDeckCat.Controls.Clear();

            List<FormatModel> categories = DataService.GetFormats();

            foreach (var category in categories)
            {
                RadioButton categoryRadioButton = new RadioButton
                {
                    Text = category.Name,
                    AutoSize = true,
                    Padding = new Padding(5),
                    Tag = category
                };

                FlwDeckCat.Controls.Add(categoryRadioButton);
            }
        }

        private void BtnDeckConfirm_Click(object sender, EventArgs e)
        {
            UserInput = BoxDeckName.Text;

            foreach (var control in FlwDeckCat.Controls)
            {
                if (control is RadioButton rb && rb.Checked)
                {
                    var selectedFormat = (FormatModel)rb.Tag;
                    SelectedFormatId = selectedFormat.Id;
                    break;
                }
            }

            if (string.IsNullOrEmpty(UserInput) || SelectedFormatId == null)
            {
                MessageBox.Show("Por favor, insira um nome de deck e selecione uma categoria.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnDeckCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

