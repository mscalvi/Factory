using System.Windows.Forms;
using DeckManager.Enums;

namespace DeckManager.Views
{
    public partial class NewFilter : Form
    {
        public FilterType SelectedFilterType { get; private set; }
        public string UserInput { get; private set; }

        public NewFilter()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            CboFilter.Items.AddRange(Enum.GetNames(typeof(FilterType)));
            CboFilter.SelectedIndex = 0;
        }

        private void BtnCatOk_Click(object sender, EventArgs e)
        {
            if (CboFilter.SelectedIndex != -1 && !string.IsNullOrEmpty(BoxFilterName.Text))
            {
                UserInput = BoxFilterName.Text;
                SelectedFilterType = (FilterType)CboFilter.SelectedIndex;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnCatCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
