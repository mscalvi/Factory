using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DeckManager.Enums;
using DeckManager.Services; // Certifique-se de ter acesso ao seu DataService

namespace DeckManager.Views
{
    public partial class DelFilter : Form
    {
        public FilterType SelectedFilterType { get; private set; }
        public string UserInput { get; private set; }

        public DelFilter()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            CboFilter.Items.AddRange(Enum.GetNames(typeof(FilterType)));

            CboFilter.SelectedIndexChanged += CboFilter_SelectedIndexChanged;
            CboFilter.SelectedIndex = 0; 
        }

        private void CboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Limpa a segunda ComboBox
            CboFilterName.Items.Clear();

            // Obtem o tipo de filtro selecionado
            FilterType selectedFilter = (FilterType)CboFilter.SelectedIndex;

            // Carrega os filtros correspondentes na segunda ComboBox
            LoadFiltersForType(selectedFilter);
        }

        private void LoadFiltersForType(FilterType filterType)
        {
            List<string> filters = new List<string>();

            // Aqui você deve buscar os filtros correspondentes no seu DataService
            switch (filterType)
            {
                case FilterType.Format:
                    filters.AddRange(DataService.GetFormats().Select(f => f.Name));
                    break;
                case FilterType.Owner:
                    filters.AddRange(DataService.GetOwners().Select(o => o.Name));
                    break;
                case FilterType.Archetype:
                    filters.AddRange(DataService.GetArchetypes().Select(a => a.Name));
                    break;
                case FilterType.Color:
                    filters.AddRange(DataService.GetColors().Select(c => c.Name));
                    break;
            }

            // Limpa os itens existentes no ComboBox
            CboFilterName.Items.Clear();

            if (filters.Count > 0)
            {
                CboFilterName.Items.AddRange(filters.ToArray());
                CboFilterName.SelectedIndex = 0; // Seleciona o primeiro item
                CboFilterName.Enabled = true; // Habilita o ComboBox
            }
            else
            {
                CboFilterName.Enabled = false; // Desabilita o ComboBox se não houver filtros
                                               // Você pode também mostrar uma mensagem ao usuário, se preferir
                MessageBox.Show("Nenhum filtro disponível para o tipo selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void BtnFilterConfirm_Click(object sender, EventArgs e)
        {
            if (CboFilter.SelectedIndex != -1 && CboFilterName.SelectedIndex != -1)
            {
                UserInput = CboFilterName.Text;
                SelectedFilterType = (FilterType)CboFilter.SelectedIndex;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnFilterCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

