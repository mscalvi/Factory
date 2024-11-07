using DeckManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeckManager.Views
{
    public partial class NewVersion : Form
    {
        public string VersionName { get; private set; }

        public NewVersion(DeckModel deck)
        {
            InitializeComponent();
            LoadVersion(deck);
        }

        private void LoadVersion(DeckModel deck)
        {
            LblDeck.Text = "Salvar Versão: " + deck.Name;
            LblLastVersionName.Text = deck.VersionName;
        }

        // Evento de clique no botão Ok
        private void BtnFilterOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtNewVersionName.Text))
            {
                VersionName = TxtNewVersionName.Text;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        // Evento de clique no botão Cancelar
        private void BtnFilterCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close(); // Fecha a pop-up sem aplicar alterações
        }
    }
}
