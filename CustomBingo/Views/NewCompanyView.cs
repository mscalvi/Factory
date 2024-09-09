using CustomBingo.Models;
using CustomBingo.Services;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomBingo.Views
{
    public partial class NewCompanyView : UserControl
    {

        private string selectedImagePath;

        public NewCompanyView()
        {
            InitializeComponent();
        }

        private void BtnLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                PicLogo.Image = Image.FromFile(selectedImagePath);
            }
        }

        private void SaveImageToPC(Image image, string fileName)
        {
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

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            CompanyModel company = new CompanyModel();

            company.Name = BoxName.Text.Trim();
            company.CardName = BoxCardName.Text.Trim();
            company.Phone = BoxPhone.Text.Trim();
            company.Email = BoxEmail.Text.Trim();
            company.Logo = "logo_" + Guid.NewGuid().ToString() + Path.GetExtension(selectedImagePath);
            company.AddDate = DateTime.Now.ToString("MMddyyyy");

            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(company.CardName))
            {
                if (PicLogo.Image != null)
                {
                    SaveImageToPC(PicLogo.Image, company.Logo);
                    company.Logo = "logo_" + Guid.NewGuid().ToString() + Path.GetExtension(selectedImagePath);
                } 

                try
                {
                    DataService.AddCompany(company.Name, company.CardName, company.Phone, company.Email, company.Logo, company.AddDate);
                    LblMessage.Text = "Empresa " + company.Name + " adicionada com sucesso.";
                }
                catch
                {
                    LblMessage.Text = "Erro ao adicionar a empresa.";
                }

                BoxName.Text = "";
                BoxCardName.Text = "";
                BoxEmail.Text = "";
                BoxPhone.Text = "";
                PicLogo.Image = null;
            } else
            {
                LblMessage.Text = "Nome e Nome para Cartela são obrigatórios.";
            }
        }
    }
}
