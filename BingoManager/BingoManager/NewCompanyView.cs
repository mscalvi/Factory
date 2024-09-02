using BingoManager.Modelo;
using BingoManager.Banco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;

namespace BingoManager
{
    public partial class NewCompanyView : Form
    {
        private string selectedImagePath;

        private StartScreen startScreen;

        // Construtor que aceita uma referência do StartScreen
        public NewCompanyView(StartScreen screen)
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

        private void SaveImageToPC(Image image, string fileName)
        {
            // Certifique-se de que o diretório existe
            string directoryPath = Path.Combine(Application.StartupPath, "Images");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, fileName);

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                File.WriteAllBytes(filePath, ms.ToArray());
            }
        }

        private void btnNewCompReady_Click(object sender, EventArgs e)
        {
            string name = NewCompName.Text;
            string cardname = NewCompTableName.Text;
            string email = NewCompEmail.Text;
            string phonenumber = NewCompPhone.Text;
            string logo = "logo_" + Guid.NewGuid().ToString() + Path.GetExtension(selectedImagePath);

            if (NewCompLogo.Image != null)
            {
                SaveImageToPC(NewCompLogo.Image, logo);
            }

            // Validar dados
            CompanyModel NewCompanyCreated = new CompanyModel
            {
                Name = name,
                CardName = cardname,
                Email = email,
                PhoneNumber = phonenumber,
                Logo = logo
            };

            List<ValidationResult> listErrors = new List<ValidationResult>();
            ValidationContext contexto = new ValidationContext(NewCompanyCreated);
            bool isValid = Validator.TryValidateObject(NewCompanyCreated, contexto, listErrors, true);

            if (isValid)
            {
                if (CompanyDataAccess.SaveCompany(NewCompanyCreated.Name, NewCompanyCreated.CardName, NewCompanyCreated.Email, NewCompanyCreated.PhoneNumber, NewCompanyCreated.Logo))
                {
                    lblResultComp.Text = "Empresa adicionada ao Bando de Dados.";
                    NewCompName.Text = "";
                    NewCompTableName.Text = "";
                    NewCompEmail.Text = "";
                    NewCompPhone.Text = "";
                    NewCompLogo.Image = null;
                }
                else
                {
                    lblResultComp.Text = "Ocorreu um erro.";
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (ValidationResult erro in listErrors)
                {
                    sb.Append(erro.ErrorMessage + "\n");
                }
                lblResultComp.Text = sb.ToString();
            }
        }

        private void NewCompLogoFind_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                NewCompLogo.Image = Image.FromFile(selectedImagePath);
            }
        }
    }
}

