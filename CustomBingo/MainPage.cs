using CustomBingo.Views;

namespace CustomBingo
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();

            mainPageView.Show();
            createView.Hide();
            editView.Hide();
            playView.Hide();
        }



        public void BtnStart_Click(object sender, EventArgs e)
        {
            mainPageView.Show();
            createView.Hide();
            editView.Hide();
            playView.Hide();

            mainPageView.BringToFront();
        }

        public void BtnCreate_Click(object sender, EventArgs e)
        {
            mainPageView.Hide();
            createView.Show();
            editView.Hide();
            playView.Hide();

            createView.BringToFront();
        }

        public void BtnEdit_Click(object sender, EventArgs e)
        {
            mainPageView.Hide();
            createView.Hide();
            editView.Show();
            playView.Hide();

            editView.BringToFront();
        }

        public void BtnPlay_Click(object sender, EventArgs e)
        {
            mainPageView.Hide();
            createView.Hide();
            editView.Hide();
            playView.Show();

            playView.BringToFront();
        }
    }
}
