using DeckManager.Services;
using Newtonsoft.Json.Linq;

namespace DeckManager
{
    public partial class HomePage : Form
    {
        private CardSearchHandler cardSearchHandler;

        public HomePage()
        {
            InitializeComponent();
            cardSearchHandler = new CardSearchHandler(BoxFinder, FlwFinder);
        }

        private async void BoxFinder_TextChanged(object sender, EventArgs e)
        {
            string CardName = BoxFinder.Text.Trim();

            await cardSearchHandler.SearchAndDisplayResults();
        }
    }
}
