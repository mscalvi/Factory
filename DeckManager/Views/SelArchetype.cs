using DeckManager.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using DeckManager.Services;
using System.Security.AccessControl;

namespace DeckManager.Views
{
    public partial class SelArchetype : Form
    {
        public int SelectedArchetypeId { get; private set; }

        public SelArchetype()
        {
            InitializeComponent();
            LoadArchetypeIntoComboBox();
        }

        // Carrega a lista de donos do banco de dados para a ComboBox
        private void LoadArchetypeIntoComboBox()
        {
            var archetype = DataService.GetArchetypes(); // Chama o método para buscar os donos no banco de dados

            CboFilter.DisplayMember = "Name"; // Mostra o nome do dono na ComboBox
            CboFilter.ValueMember = "Id";     // Usa o Id como valor da ComboBox

            CboFilter.DataSource = archetype;    // Define a lista de donos como a fonte de dados da ComboBox
        }

        // Evento de clique no botão Ok
        private void BtnFilterOk_Click(object sender, EventArgs e)
        {
            if (CboFilter.SelectedIndex != -1)
            {
                SelectedArchetypeId = (int)CboFilter.SelectedValue; // Armazena o Id do dono selecionado
                DialogResult = DialogResult.OK;
                this.Close(); // Fecha a pop-up
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
