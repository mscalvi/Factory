﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BingoManager.Views
{
    public partial class LogoView : Form
    {        
        public LogoView()
        {
            InitializeComponent();
        }

        // Adiciona um método para atualizar o logo e o nome
        public void UpdateLogoAndName(Image logo, string companyName)
        {
            ShowCompLogo.Image = logo; // ShowCompLogo é o nome da PictureBox que você adicionou no Designer
            ShowCompName.Text = companyName; // ShowCompName é o nome da Label que você adicionou no Designer
        }
    }
}
