﻿namespace BingoManager
{
    partial class MainView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            MainPage = new TabControl();
            TabMainPage = new TabPage();
            TabCreatePage = new TabPage();
            CreatePage = new TabControl();
            TabCreateMain = new TabPage();
            label1 = new Label();
            TabCreateList = new TabPage();
            PnlNewList = new Panel();
            TxtCreateListTitle = new Label();
            TxtCreateListMessage = new Label();
            BtnCreateList = new Button();
            TxtCreatListeName = new Label();
            BoxCreateListName = new TextBox();
            TxtCreateListDescription = new Label();
            BoxCreateListDescription = new TextBox();
            TabCreateCompany = new TabPage();
            PnlNewComp = new Panel();
            CboCreateCompanyList = new ComboBox();
            label11 = new Label();
            TxtCreateCompanyTitle = new Label();
            BoxCreateCompanyEmail = new TextBox();
            BoxCreateCompanyPhone = new TextBox();
            BoxCreateCompanyCardName = new TextBox();
            PicCreateCompanyLogo = new PictureBox();
            BoxCreateCompanyName = new TextBox();
            BtnFindLogo = new Button();
            label7 = new Label();
            BtnCreateCompany = new Button();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            TxtCreateCompanyMessage = new Label();
            label3 = new Label();
            TabCreateCards = new TabPage();
            PnlNewCards = new Panel();
            BoxCreateCardsName = new TextBox();
            label16 = new Label();
            label6 = new Label();
            TxtCreateCardsMsg = new Label();
            BtnCreateCards = new Button();
            TxtCreatCardsEnd = new Label();
            TxtCreateCardsTitle = new Label();
            TxtCreateCardsQuant = new Label();
            TxtCreateCardsList = new Label();
            BoxCreateCardsEnd = new TextBox();
            BoxCreateCardsTitle = new TextBox();
            BoxCreateCardsQuant = new TextBox();
            CboCreateCardsList = new ComboBox();
            TabEditPage = new TabPage();
            TabPlayPage = new TabPage();
            TabEditCompany = new TabPage();
            PnlEditCompany = new Panel();
            label9 = new Label();
            CboEditComp = new ComboBox();
            label10 = new Label();
            LblEditCompName = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            LblEditMsgComp = new Label();
            BoxEditNameComp = new TextBox();
            BoxEditCardNameComp = new TextBox();
            BoxEditPhoneComp = new TextBox();
            BoxEditEmailComp = new TextBox();
            BtnEditLogoComp = new Button();
            BtnEditComp = new Button();
            PicEditLogoComp = new PictureBox();
            BtnRemoveComp = new Button();
            TabEditList = new TabPage();
            PnlEditList = new Panel();
            PnlEditSelList = new Panel();
            FlowEditViewSel = new FlowLayoutPanel();
            PnlEditAllCompany = new Panel();
            FlowEditViewAll = new FlowLayoutPanel();
            CboEditListSel = new ComboBox();
            BtnEditAddCL = new Button();
            BtnEditRemoveCL = new Button();
            TxtEditListAll = new Label();
            TxtEditListSel = new Label();
            TxtEditListMsg = new Label();
            label8 = new Label();
            BoxEditFilterCL = new TextBox();
            TabEditMain = new TabPage();
            EditPage = new TabControl();
            MainPage.SuspendLayout();
            TabCreatePage.SuspendLayout();
            CreatePage.SuspendLayout();
            TabCreateMain.SuspendLayout();
            TabCreateList.SuspendLayout();
            PnlNewList.SuspendLayout();
            TabCreateCompany.SuspendLayout();
            PnlNewComp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicCreateCompanyLogo).BeginInit();
            TabCreateCards.SuspendLayout();
            PnlNewCards.SuspendLayout();
            TabEditPage.SuspendLayout();
            TabEditCompany.SuspendLayout();
            PnlEditCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicEditLogoComp).BeginInit();
            TabEditList.SuspendLayout();
            PnlEditList.SuspendLayout();
            PnlEditSelList.SuspendLayout();
            PnlEditAllCompany.SuspendLayout();
            EditPage.SuspendLayout();
            SuspendLayout();
            // 
            // MainPage
            // 
            MainPage.Controls.Add(TabMainPage);
            MainPage.Controls.Add(TabCreatePage);
            MainPage.Controls.Add(TabEditPage);
            MainPage.Controls.Add(TabPlayPage);
            MainPage.Dock = DockStyle.Fill;
            MainPage.Location = new Point(0, 0);
            MainPage.Name = "MainPage";
            MainPage.SelectedIndex = 0;
            MainPage.Size = new Size(1350, 729);
            MainPage.TabIndex = 0;
            // 
            // TabMainPage
            // 
            TabMainPage.Location = new Point(4, 24);
            TabMainPage.Name = "TabMainPage";
            TabMainPage.Padding = new Padding(3);
            TabMainPage.Size = new Size(1342, 701);
            TabMainPage.TabIndex = 0;
            TabMainPage.Text = "Início";
            TabMainPage.UseVisualStyleBackColor = true;
            // 
            // TabCreatePage
            // 
            TabCreatePage.Controls.Add(CreatePage);
            TabCreatePage.Location = new Point(4, 24);
            TabCreatePage.Name = "TabCreatePage";
            TabCreatePage.Padding = new Padding(3);
            TabCreatePage.Size = new Size(1342, 701);
            TabCreatePage.TabIndex = 1;
            TabCreatePage.Text = "Criar";
            TabCreatePage.UseVisualStyleBackColor = true;
            // 
            // CreatePage
            // 
            CreatePage.Controls.Add(TabCreateMain);
            CreatePage.Controls.Add(TabCreateList);
            CreatePage.Controls.Add(TabCreateCompany);
            CreatePage.Controls.Add(TabCreateCards);
            CreatePage.Dock = DockStyle.Fill;
            CreatePage.Location = new Point(3, 3);
            CreatePage.Name = "CreatePage";
            CreatePage.SelectedIndex = 0;
            CreatePage.Size = new Size(1336, 695);
            CreatePage.TabIndex = 0;
            // 
            // TabCreateMain
            // 
            TabCreateMain.Controls.Add(label1);
            TabCreateMain.Location = new Point(4, 24);
            TabCreateMain.Name = "TabCreateMain";
            TabCreateMain.Padding = new Padding(3);
            TabCreateMain.Size = new Size(1328, 667);
            TabCreateMain.TabIndex = 0;
            TabCreateMain.Text = "Início";
            TabCreateMain.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(1322, 661);
            label1.TabIndex = 0;
            label1.Text = resources.GetString("label1.Text");
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TabCreateList
            // 
            TabCreateList.Controls.Add(PnlNewList);
            TabCreateList.Location = new Point(4, 24);
            TabCreateList.Name = "TabCreateList";
            TabCreateList.Padding = new Padding(3);
            TabCreateList.Size = new Size(1328, 667);
            TabCreateList.TabIndex = 1;
            TabCreateList.Text = "Nova Lista";
            TabCreateList.UseVisualStyleBackColor = true;
            // 
            // PnlNewList
            // 
            PnlNewList.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PnlNewList.Controls.Add(TxtCreateListTitle);
            PnlNewList.Controls.Add(TxtCreateListMessage);
            PnlNewList.Controls.Add(BtnCreateList);
            PnlNewList.Controls.Add(TxtCreatListeName);
            PnlNewList.Controls.Add(BoxCreateListName);
            PnlNewList.Controls.Add(TxtCreateListDescription);
            PnlNewList.Controls.Add(BoxCreateListDescription);
            PnlNewList.Dock = DockStyle.Fill;
            PnlNewList.Location = new Point(3, 3);
            PnlNewList.Name = "PnlNewList";
            PnlNewList.Size = new Size(1322, 661);
            PnlNewList.TabIndex = 6;
            // 
            // TxtCreateListTitle
            // 
            TxtCreateListTitle.Dock = DockStyle.Top;
            TxtCreateListTitle.Font = new Font("Segoe UI", 15F);
            TxtCreateListTitle.Location = new Point(0, 0);
            TxtCreateListTitle.Name = "TxtCreateListTitle";
            TxtCreateListTitle.Size = new Size(1322, 112);
            TxtCreateListTitle.TabIndex = 6;
            TxtCreateListTitle.Text = "Nova Lista";
            TxtCreateListTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TxtCreateListMessage
            // 
            TxtCreateListMessage.Anchor = AnchorStyles.Top;
            TxtCreateListMessage.Location = new Point(195, 508);
            TxtCreateListMessage.Name = "TxtCreateListMessage";
            TxtCreateListMessage.Size = new Size(932, 23);
            TxtCreateListMessage.TabIndex = 5;
            // 
            // BtnCreateList
            // 
            BtnCreateList.Anchor = AnchorStyles.Top;
            BtnCreateList.Location = new Point(356, 404);
            BtnCreateList.Name = "BtnCreateList";
            BtnCreateList.Size = new Size(610, 67);
            BtnCreateList.TabIndex = 4;
            BtnCreateList.Text = "Criar Lista";
            BtnCreateList.UseVisualStyleBackColor = true;
            BtnCreateList.Click += BtnCreateList_Click;
            // 
            // TxtCreatListeName
            // 
            TxtCreatListeName.Anchor = AnchorStyles.Top;
            TxtCreatListeName.Location = new Point(3, 112);
            TxtCreatListeName.Name = "TxtCreatListeName";
            TxtCreatListeName.Size = new Size(1192, 23);
            TxtCreatListeName.TabIndex = 0;
            TxtCreatListeName.Text = "Nome";
            // 
            // BoxCreateListName
            // 
            BoxCreateListName.Anchor = AnchorStyles.Top;
            BoxCreateListName.Location = new Point(3, 138);
            BoxCreateListName.Name = "BoxCreateListName";
            BoxCreateListName.Size = new Size(1316, 23);
            BoxCreateListName.TabIndex = 3;
            // 
            // TxtCreateListDescription
            // 
            TxtCreateListDescription.Anchor = AnchorStyles.Top;
            TxtCreateListDescription.Location = new Point(3, 179);
            TxtCreateListDescription.Name = "TxtCreateListDescription";
            TxtCreateListDescription.Size = new Size(1316, 23);
            TxtCreateListDescription.TabIndex = 1;
            TxtCreateListDescription.Text = "Descrição";
            // 
            // BoxCreateListDescription
            // 
            BoxCreateListDescription.Anchor = AnchorStyles.Top;
            BoxCreateListDescription.Location = new Point(3, 205);
            BoxCreateListDescription.Multiline = true;
            BoxCreateListDescription.Name = "BoxCreateListDescription";
            BoxCreateListDescription.Size = new Size(1316, 161);
            BoxCreateListDescription.TabIndex = 2;
            // 
            // TabCreateCompany
            // 
            TabCreateCompany.Controls.Add(PnlNewComp);
            TabCreateCompany.Location = new Point(4, 24);
            TabCreateCompany.Name = "TabCreateCompany";
            TabCreateCompany.Padding = new Padding(3);
            TabCreateCompany.Size = new Size(1328, 667);
            TabCreateCompany.TabIndex = 2;
            TabCreateCompany.Text = "Nova Empresa";
            TabCreateCompany.UseVisualStyleBackColor = true;
            // 
            // PnlNewComp
            // 
            PnlNewComp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PnlNewComp.Controls.Add(CboCreateCompanyList);
            PnlNewComp.Controls.Add(label11);
            PnlNewComp.Controls.Add(TxtCreateCompanyTitle);
            PnlNewComp.Controls.Add(BoxCreateCompanyEmail);
            PnlNewComp.Controls.Add(BoxCreateCompanyPhone);
            PnlNewComp.Controls.Add(BoxCreateCompanyCardName);
            PnlNewComp.Controls.Add(PicCreateCompanyLogo);
            PnlNewComp.Controls.Add(BoxCreateCompanyName);
            PnlNewComp.Controls.Add(BtnFindLogo);
            PnlNewComp.Controls.Add(label7);
            PnlNewComp.Controls.Add(BtnCreateCompany);
            PnlNewComp.Controls.Add(label2);
            PnlNewComp.Controls.Add(label4);
            PnlNewComp.Controls.Add(label5);
            PnlNewComp.Controls.Add(TxtCreateCompanyMessage);
            PnlNewComp.Controls.Add(label3);
            PnlNewComp.Dock = DockStyle.Fill;
            PnlNewComp.Location = new Point(3, 3);
            PnlNewComp.Name = "PnlNewComp";
            PnlNewComp.Size = new Size(1322, 661);
            PnlNewComp.TabIndex = 13;
            // 
            // CboCreateCompanyList
            // 
            CboCreateCompanyList.Anchor = AnchorStyles.Top;
            CboCreateCompanyList.FormattingEnabled = true;
            CboCreateCompanyList.Location = new Point(842, 323);
            CboCreateCompanyList.Name = "CboCreateCompanyList";
            CboCreateCompanyList.Size = new Size(448, 23);
            CboCreateCompanyList.TabIndex = 15;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top;
            label11.Location = new Point(1016, 297);
            label11.Name = "label11";
            label11.Size = new Size(100, 23);
            label11.TabIndex = 14;
            label11.Text = "Adicionar a Lista:";
            // 
            // TxtCreateCompanyTitle
            // 
            TxtCreateCompanyTitle.Dock = DockStyle.Top;
            TxtCreateCompanyTitle.Font = new Font("Segoe UI", 15F);
            TxtCreateCompanyTitle.Location = new Point(0, 0);
            TxtCreateCompanyTitle.Name = "TxtCreateCompanyTitle";
            TxtCreateCompanyTitle.Size = new Size(1322, 120);
            TxtCreateCompanyTitle.TabIndex = 13;
            TxtCreateCompanyTitle.Text = "Nova Empresa";
            TxtCreateCompanyTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BoxCreateCompanyEmail
            // 
            BoxCreateCompanyEmail.Anchor = AnchorStyles.Top;
            BoxCreateCompanyEmail.Location = new Point(6, 364);
            BoxCreateCompanyEmail.Name = "BoxCreateCompanyEmail";
            BoxCreateCompanyEmail.Size = new Size(780, 23);
            BoxCreateCompanyEmail.TabIndex = 12;
            // 
            // BoxCreateCompanyPhone
            // 
            BoxCreateCompanyPhone.Anchor = AnchorStyles.Top;
            BoxCreateCompanyPhone.Location = new Point(3, 294);
            BoxCreateCompanyPhone.Name = "BoxCreateCompanyPhone";
            BoxCreateCompanyPhone.Size = new Size(783, 23);
            BoxCreateCompanyPhone.TabIndex = 11;
            // 
            // BoxCreateCompanyCardName
            // 
            BoxCreateCompanyCardName.Anchor = AnchorStyles.Top;
            BoxCreateCompanyCardName.Location = new Point(3, 214);
            BoxCreateCompanyCardName.Name = "BoxCreateCompanyCardName";
            BoxCreateCompanyCardName.Size = new Size(1316, 23);
            BoxCreateCompanyCardName.TabIndex = 10;
            // 
            // PicCreateCompanyLogo
            // 
            PicCreateCompanyLogo.Anchor = AnchorStyles.Top;
            PicCreateCompanyLogo.Location = new Point(278, 407);
            PicCreateCompanyLogo.Name = "PicCreateCompanyLogo";
            PicCreateCompanyLogo.Size = new Size(367, 251);
            PicCreateCompanyLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            PicCreateCompanyLogo.TabIndex = 8;
            PicCreateCompanyLogo.TabStop = false;
            // 
            // BoxCreateCompanyName
            // 
            BoxCreateCompanyName.Anchor = AnchorStyles.Top;
            BoxCreateCompanyName.Location = new Point(3, 146);
            BoxCreateCompanyName.Name = "BoxCreateCompanyName";
            BoxCreateCompanyName.Size = new Size(1316, 23);
            BoxCreateCompanyName.TabIndex = 9;
            // 
            // BtnFindLogo
            // 
            BtnFindLogo.Anchor = AnchorStyles.Top;
            BtnFindLogo.Location = new Point(90, 499);
            BtnFindLogo.Name = "BtnFindLogo";
            BtnFindLogo.Size = new Size(104, 71);
            BtnFindLogo.TabIndex = 6;
            BtnFindLogo.Text = "Procurar";
            BtnFindLogo.UseVisualStyleBackColor = true;
            BtnFindLogo.Click += BtnFindLogo_Click;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.Location = new Point(6, 407);
            label7.Name = "label7";
            label7.Size = new Size(266, 23);
            label7.TabIndex = 5;
            label7.Text = "Logo";
            // 
            // BtnCreateCompany
            // 
            BtnCreateCompany.Anchor = AnchorStyles.Top;
            BtnCreateCompany.Location = new Point(769, 447);
            BtnCreateCompany.Name = "BtnCreateCompany";
            BtnCreateCompany.Size = new Size(479, 82);
            BtnCreateCompany.TabIndex = 7;
            BtnCreateCompany.Text = "Criar Empresa";
            BtnCreateCompany.UseVisualStyleBackColor = true;
            BtnCreateCompany.Click += BtnCreateCompany_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.Location = new Point(3, 120);
            label2.Name = "label2";
            label2.Size = new Size(1316, 23);
            label2.TabIndex = 0;
            label2.Text = "Nome";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.Location = new Point(3, 268);
            label4.Name = "label4";
            label4.Size = new Size(1316, 23);
            label4.TabIndex = 2;
            label4.Text = "Telefone";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.Location = new Point(6, 338);
            label5.Name = "label5";
            label5.Size = new Size(1313, 23);
            label5.TabIndex = 3;
            label5.Text = "E-mail";
            // 
            // TxtCreateCompanyMessage
            // 
            TxtCreateCompanyMessage.Anchor = AnchorStyles.Top;
            TxtCreateCompanyMessage.Location = new Point(816, 556);
            TxtCreateCompanyMessage.Name = "TxtCreateCompanyMessage";
            TxtCreateCompanyMessage.Size = new Size(385, 71);
            TxtCreateCompanyMessage.TabIndex = 4;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.Location = new Point(3, 188);
            label3.Name = "label3";
            label3.Size = new Size(1316, 23);
            label3.TabIndex = 1;
            label3.Text = "Nome para Cartela";
            // 
            // TabCreateCards
            // 
            TabCreateCards.Controls.Add(PnlNewCards);
            TabCreateCards.Location = new Point(4, 24);
            TabCreateCards.Name = "TabCreateCards";
            TabCreateCards.Padding = new Padding(3);
            TabCreateCards.Size = new Size(1328, 667);
            TabCreateCards.TabIndex = 3;
            TabCreateCards.Text = "Novas Cartelas";
            TabCreateCards.UseVisualStyleBackColor = true;
            // 
            // PnlNewCards
            // 
            PnlNewCards.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PnlNewCards.Controls.Add(BoxCreateCardsName);
            PnlNewCards.Controls.Add(label16);
            PnlNewCards.Controls.Add(label6);
            PnlNewCards.Controls.Add(TxtCreateCardsMsg);
            PnlNewCards.Controls.Add(BtnCreateCards);
            PnlNewCards.Controls.Add(TxtCreatCardsEnd);
            PnlNewCards.Controls.Add(TxtCreateCardsTitle);
            PnlNewCards.Controls.Add(TxtCreateCardsQuant);
            PnlNewCards.Controls.Add(TxtCreateCardsList);
            PnlNewCards.Controls.Add(BoxCreateCardsEnd);
            PnlNewCards.Controls.Add(BoxCreateCardsTitle);
            PnlNewCards.Controls.Add(BoxCreateCardsQuant);
            PnlNewCards.Controls.Add(CboCreateCardsList);
            PnlNewCards.Dock = DockStyle.Fill;
            PnlNewCards.Location = new Point(3, 3);
            PnlNewCards.Name = "PnlNewCards";
            PnlNewCards.Size = new Size(1322, 661);
            PnlNewCards.TabIndex = 11;
            // 
            // BoxCreateCardsName
            // 
            BoxCreateCardsName.Anchor = AnchorStyles.Top;
            BoxCreateCardsName.Location = new Point(0, 150);
            BoxCreateCardsName.Name = "BoxCreateCardsName";
            BoxCreateCardsName.Size = new Size(640, 23);
            BoxCreateCardsName.TabIndex = 13;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top;
            label16.Location = new Point(0, 132);
            label16.Name = "label16";
            label16.Size = new Size(516, 15);
            label16.TabIndex = 12;
            label16.Text = "Nome do Jogo";
            // 
            // label6
            // 
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(1322, 120);
            label6.TabIndex = 11;
            label6.Text = "Criar Cartelas";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TxtCreateCardsMsg
            // 
            TxtCreateCardsMsg.Anchor = AnchorStyles.Top;
            TxtCreateCardsMsg.Location = new Point(803, 290);
            TxtCreateCardsMsg.Name = "TxtCreateCardsMsg";
            TxtCreateCardsMsg.Size = new Size(389, 85);
            TxtCreateCardsMsg.TabIndex = 10;
            // 
            // BtnCreateCards
            // 
            BtnCreateCards.Anchor = AnchorStyles.Top;
            BtnCreateCards.Location = new Point(803, 153);
            BtnCreateCards.Name = "BtnCreateCards";
            BtnCreateCards.Size = new Size(389, 85);
            BtnCreateCards.TabIndex = 9;
            BtnCreateCards.Text = "Gerar Cartelas";
            BtnCreateCards.UseVisualStyleBackColor = true;
            BtnCreateCards.Click += BtnCreateCards_Click;
            // 
            // TxtCreatCardsEnd
            // 
            TxtCreatCardsEnd.Anchor = AnchorStyles.Top;
            TxtCreatCardsEnd.AutoSize = true;
            TxtCreatCardsEnd.Location = new Point(0, 348);
            TxtCreatCardsEnd.Name = "TxtCreatCardsEnd";
            TxtCreatCardsEnd.Size = new Size(94, 15);
            TxtCreatCardsEnd.TabIndex = 8;
            TxtCreatCardsEnd.Text = "Mensagem Final";
            // 
            // TxtCreateCardsTitle
            // 
            TxtCreateCardsTitle.Anchor = AnchorStyles.Top;
            TxtCreateCardsTitle.AutoSize = true;
            TxtCreateCardsTitle.Location = new Point(0, 290);
            TxtCreateCardsTitle.Name = "TxtCreateCardsTitle";
            TxtCreateCardsTitle.Size = new Size(37, 15);
            TxtCreateCardsTitle.TabIndex = 7;
            TxtCreateCardsTitle.Text = "Título";
            // 
            // TxtCreateCardsQuant
            // 
            TxtCreateCardsQuant.Anchor = AnchorStyles.Top;
            TxtCreateCardsQuant.AutoSize = true;
            TxtCreateCardsQuant.Location = new Point(0, 232);
            TxtCreateCardsQuant.Name = "TxtCreateCardsQuant";
            TxtCreateCardsQuant.Size = new Size(69, 15);
            TxtCreateCardsQuant.TabIndex = 6;
            TxtCreateCardsQuant.Text = "Quantidade";
            // 
            // TxtCreateCardsList
            // 
            TxtCreateCardsList.Anchor = AnchorStyles.Top;
            TxtCreateCardsList.Location = new Point(0, 188);
            TxtCreateCardsList.Name = "TxtCreateCardsList";
            TxtCreateCardsList.Size = new Size(516, 15);
            TxtCreateCardsList.TabIndex = 5;
            TxtCreateCardsList.Text = "Lista";
            // 
            // BoxCreateCardsEnd
            // 
            BoxCreateCardsEnd.Anchor = AnchorStyles.Top;
            BoxCreateCardsEnd.Location = new Point(0, 375);
            BoxCreateCardsEnd.Multiline = true;
            BoxCreateCardsEnd.Name = "BoxCreateCardsEnd";
            BoxCreateCardsEnd.Size = new Size(640, 68);
            BoxCreateCardsEnd.TabIndex = 3;
            // 
            // BoxCreateCardsTitle
            // 
            BoxCreateCardsTitle.Anchor = AnchorStyles.Top;
            BoxCreateCardsTitle.Location = new Point(0, 308);
            BoxCreateCardsTitle.Name = "BoxCreateCardsTitle";
            BoxCreateCardsTitle.Size = new Size(640, 23);
            BoxCreateCardsTitle.TabIndex = 2;
            // 
            // BoxCreateCardsQuant
            // 
            BoxCreateCardsQuant.Anchor = AnchorStyles.Top;
            BoxCreateCardsQuant.Location = new Point(0, 253);
            BoxCreateCardsQuant.Name = "BoxCreateCardsQuant";
            BoxCreateCardsQuant.Size = new Size(640, 23);
            BoxCreateCardsQuant.TabIndex = 1;
            // 
            // CboCreateCardsList
            // 
            CboCreateCardsList.Anchor = AnchorStyles.Top;
            CboCreateCardsList.FormattingEnabled = true;
            CboCreateCardsList.Location = new Point(0, 206);
            CboCreateCardsList.Name = "CboCreateCardsList";
            CboCreateCardsList.Size = new Size(640, 23);
            CboCreateCardsList.TabIndex = 0;
            // 
            // TabEditPage
            // 
            TabEditPage.Controls.Add(EditPage);
            TabEditPage.Location = new Point(4, 24);
            TabEditPage.Name = "TabEditPage";
            TabEditPage.Padding = new Padding(3);
            TabEditPage.Size = new Size(1342, 701);
            TabEditPage.TabIndex = 2;
            TabEditPage.Text = "Editar";
            TabEditPage.UseVisualStyleBackColor = true;
            // 
            // TabPlayPage
            // 
            TabPlayPage.Location = new Point(4, 24);
            TabPlayPage.Name = "TabPlayPage";
            TabPlayPage.Padding = new Padding(3);
            TabPlayPage.Size = new Size(1342, 701);
            TabPlayPage.TabIndex = 3;
            TabPlayPage.Text = "Jogar";
            TabPlayPage.UseVisualStyleBackColor = true;
            // 
            // TabEditCompany
            // 
            TabEditCompany.Controls.Add(PnlEditCompany);
            TabEditCompany.Location = new Point(4, 24);
            TabEditCompany.Name = "TabEditCompany";
            TabEditCompany.Padding = new Padding(3);
            TabEditCompany.Size = new Size(1328, 667);
            TabEditCompany.TabIndex = 2;
            TabEditCompany.Text = "Editar Empresas";
            TabEditCompany.UseVisualStyleBackColor = true;
            // 
            // PnlEditCompany
            // 
            PnlEditCompany.Controls.Add(BtnRemoveComp);
            PnlEditCompany.Controls.Add(PicEditLogoComp);
            PnlEditCompany.Controls.Add(BtnEditComp);
            PnlEditCompany.Controls.Add(BtnEditLogoComp);
            PnlEditCompany.Controls.Add(BoxEditEmailComp);
            PnlEditCompany.Controls.Add(BoxEditPhoneComp);
            PnlEditCompany.Controls.Add(BoxEditCardNameComp);
            PnlEditCompany.Controls.Add(BoxEditNameComp);
            PnlEditCompany.Controls.Add(LblEditMsgComp);
            PnlEditCompany.Controls.Add(label15);
            PnlEditCompany.Controls.Add(label14);
            PnlEditCompany.Controls.Add(label13);
            PnlEditCompany.Controls.Add(label12);
            PnlEditCompany.Controls.Add(LblEditCompName);
            PnlEditCompany.Controls.Add(label10);
            PnlEditCompany.Controls.Add(CboEditComp);
            PnlEditCompany.Controls.Add(label9);
            PnlEditCompany.Dock = DockStyle.Fill;
            PnlEditCompany.Location = new Point(3, 3);
            PnlEditCompany.Name = "PnlEditCompany";
            PnlEditCompany.Size = new Size(1322, 661);
            PnlEditCompany.TabIndex = 1;
            // 
            // label9
            // 
            label9.Dock = DockStyle.Top;
            label9.Font = new Font("Segoe UI", 15F);
            label9.Location = new Point(0, 0);
            label9.Name = "label9";
            label9.Size = new Size(1322, 120);
            label9.TabIndex = 0;
            label9.Text = "Editar Empresa";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CboEditComp
            // 
            CboEditComp.Anchor = AnchorStyles.Top;
            CboEditComp.FormattingEnabled = true;
            CboEditComp.Location = new Point(0, 154);
            CboEditComp.Name = "CboEditComp";
            CboEditComp.Size = new Size(1322, 23);
            CboEditComp.TabIndex = 1;
            CboEditComp.SelectedValueChanged += CboEditComp_SelectedValueChanged;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top;
            label10.Location = new Point(3, 128);
            label10.Name = "label10";
            label10.Size = new Size(1319, 23);
            label10.TabIndex = 2;
            label10.Text = "Selecionar Empresa";
            // 
            // LblEditCompName
            // 
            LblEditCompName.Anchor = AnchorStyles.Top;
            LblEditCompName.Location = new Point(3, 204);
            LblEditCompName.Name = "LblEditCompName";
            LblEditCompName.Size = new Size(1316, 23);
            LblEditCompName.TabIndex = 3;
            LblEditCompName.Text = "Nome";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top;
            label12.Location = new Point(3, 283);
            label12.Name = "label12";
            label12.Size = new Size(1316, 23);
            label12.TabIndex = 4;
            label12.Text = "Nome para Cartela";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top;
            label13.Location = new Point(3, 421);
            label13.Name = "label13";
            label13.Size = new Size(1316, 23);
            label13.TabIndex = 5;
            label13.Text = "Email";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top;
            label14.Location = new Point(3, 353);
            label14.Name = "label14";
            label14.Size = new Size(1316, 23);
            label14.TabIndex = 6;
            label14.Text = "Telefone";
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top;
            label15.Location = new Point(3, 484);
            label15.Name = "label15";
            label15.Size = new Size(196, 23);
            label15.TabIndex = 7;
            label15.Text = "Logo";
            // 
            // LblEditMsgComp
            // 
            LblEditMsgComp.Anchor = AnchorStyles.Top;
            LblEditMsgComp.Location = new Point(627, 484);
            LblEditMsgComp.Name = "LblEditMsgComp";
            LblEditMsgComp.Size = new Size(291, 161);
            LblEditMsgComp.TabIndex = 8;
            LblEditMsgComp.Text = "Mensagem";
            LblEditMsgComp.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BoxEditNameComp
            // 
            BoxEditNameComp.Anchor = AnchorStyles.Top;
            BoxEditNameComp.Location = new Point(3, 230);
            BoxEditNameComp.Name = "BoxEditNameComp";
            BoxEditNameComp.Size = new Size(1316, 23);
            BoxEditNameComp.TabIndex = 9;
            // 
            // BoxEditCardNameComp
            // 
            BoxEditCardNameComp.Anchor = AnchorStyles.Top;
            BoxEditCardNameComp.Location = new Point(3, 309);
            BoxEditCardNameComp.Name = "BoxEditCardNameComp";
            BoxEditCardNameComp.Size = new Size(1316, 23);
            BoxEditCardNameComp.TabIndex = 10;
            // 
            // BoxEditPhoneComp
            // 
            BoxEditPhoneComp.Anchor = AnchorStyles.Top;
            BoxEditPhoneComp.Location = new Point(3, 379);
            BoxEditPhoneComp.Name = "BoxEditPhoneComp";
            BoxEditPhoneComp.Size = new Size(1316, 23);
            BoxEditPhoneComp.TabIndex = 11;
            // 
            // BoxEditEmailComp
            // 
            BoxEditEmailComp.Anchor = AnchorStyles.Top;
            BoxEditEmailComp.Location = new Point(3, 447);
            BoxEditEmailComp.Name = "BoxEditEmailComp";
            BoxEditEmailComp.Size = new Size(1316, 23);
            BoxEditEmailComp.TabIndex = 12;
            // 
            // BtnEditLogoComp
            // 
            BtnEditLogoComp.Anchor = AnchorStyles.Top;
            BtnEditLogoComp.Location = new Point(64, 548);
            BtnEditLogoComp.Name = "BtnEditLogoComp";
            BtnEditLogoComp.Size = new Size(75, 33);
            BtnEditLogoComp.TabIndex = 13;
            BtnEditLogoComp.Text = "Procurar";
            BtnEditLogoComp.UseVisualStyleBackColor = true;
            // 
            // BtnEditComp
            // 
            BtnEditComp.Anchor = AnchorStyles.Top;
            BtnEditComp.Location = new Point(1005, 493);
            BtnEditComp.Name = "BtnEditComp";
            BtnEditComp.Size = new Size(192, 73);
            BtnEditComp.TabIndex = 14;
            BtnEditComp.Text = "Editar Empresa";
            BtnEditComp.UseVisualStyleBackColor = true;
            BtnEditComp.Click += BtnEditComp_Click;
            // 
            // PicEditLogoComp
            // 
            PicEditLogoComp.Anchor = AnchorStyles.Top;
            PicEditLogoComp.Location = new Point(205, 484);
            PicEditLogoComp.Name = "PicEditLogoComp";
            PicEditLogoComp.Size = new Size(312, 161);
            PicEditLogoComp.SizeMode = PictureBoxSizeMode.Zoom;
            PicEditLogoComp.TabIndex = 15;
            PicEditLogoComp.TabStop = false;
            // 
            // BtnRemoveComp
            // 
            BtnRemoveComp.Anchor = AnchorStyles.Top;
            BtnRemoveComp.Location = new Point(1005, 572);
            BtnRemoveComp.Name = "BtnRemoveComp";
            BtnRemoveComp.Size = new Size(192, 73);
            BtnRemoveComp.TabIndex = 16;
            BtnRemoveComp.Text = "Remover Empresa";
            BtnRemoveComp.UseVisualStyleBackColor = true;
            BtnRemoveComp.Click += BtnRemoveComp_Click;
            // 
            // TabEditList
            // 
            TabEditList.Controls.Add(PnlEditList);
            TabEditList.Location = new Point(4, 24);
            TabEditList.Name = "TabEditList";
            TabEditList.Padding = new Padding(3);
            TabEditList.Size = new Size(1328, 667);
            TabEditList.TabIndex = 1;
            TabEditList.Text = "Editar Listas";
            TabEditList.UseVisualStyleBackColor = true;
            // 
            // PnlEditList
            // 
            PnlEditList.Controls.Add(BoxEditFilterCL);
            PnlEditList.Controls.Add(label8);
            PnlEditList.Controls.Add(TxtEditListMsg);
            PnlEditList.Controls.Add(TxtEditListSel);
            PnlEditList.Controls.Add(TxtEditListAll);
            PnlEditList.Controls.Add(BtnEditRemoveCL);
            PnlEditList.Controls.Add(BtnEditAddCL);
            PnlEditList.Controls.Add(CboEditListSel);
            PnlEditList.Controls.Add(PnlEditAllCompany);
            PnlEditList.Controls.Add(PnlEditSelList);
            PnlEditList.Dock = DockStyle.Fill;
            PnlEditList.Location = new Point(3, 3);
            PnlEditList.Name = "PnlEditList";
            PnlEditList.Size = new Size(1322, 661);
            PnlEditList.TabIndex = 9;
            // 
            // PnlEditSelList
            // 
            PnlEditSelList.Anchor = AnchorStyles.Top;
            PnlEditSelList.AutoScroll = true;
            PnlEditSelList.AutoSize = true;
            PnlEditSelList.BackColor = Color.Black;
            PnlEditSelList.Controls.Add(FlowEditViewSel);
            PnlEditSelList.Location = new Point(3, 183);
            PnlEditSelList.Name = "PnlEditSelList";
            PnlEditSelList.Size = new Size(1316, 183);
            PnlEditSelList.TabIndex = 1;
            // 
            // FlowEditViewSel
            // 
            FlowEditViewSel.BackColor = Color.Gray;
            FlowEditViewSel.Dock = DockStyle.Fill;
            FlowEditViewSel.Location = new Point(0, 0);
            FlowEditViewSel.Name = "FlowEditViewSel";
            FlowEditViewSel.Size = new Size(1316, 183);
            FlowEditViewSel.TabIndex = 0;
            // 
            // PnlEditAllCompany
            // 
            PnlEditAllCompany.Anchor = AnchorStyles.Top;
            PnlEditAllCompany.AutoScroll = true;
            PnlEditAllCompany.AutoSize = true;
            PnlEditAllCompany.BackColor = Color.Black;
            PnlEditAllCompany.Controls.Add(FlowEditViewAll);
            PnlEditAllCompany.Location = new Point(3, 468);
            PnlEditAllCompany.Name = "PnlEditAllCompany";
            PnlEditAllCompany.Size = new Size(1316, 183);
            PnlEditAllCompany.TabIndex = 0;
            // 
            // FlowEditViewAll
            // 
            FlowEditViewAll.BackColor = Color.Gray;
            FlowEditViewAll.Dock = DockStyle.Fill;
            FlowEditViewAll.Location = new Point(0, 0);
            FlowEditViewAll.Name = "FlowEditViewAll";
            FlowEditViewAll.Size = new Size(1316, 183);
            FlowEditViewAll.TabIndex = 0;
            // 
            // CboEditListSel
            // 
            CboEditListSel.Anchor = AnchorStyles.Top;
            CboEditListSel.FormattingEnabled = true;
            CboEditListSel.Location = new Point(3, 154);
            CboEditListSel.Name = "CboEditListSel";
            CboEditListSel.Size = new Size(1316, 23);
            CboEditListSel.TabIndex = 3;
            CboEditListSel.SelectedValueChanged += CboEditListSel_SelectedValueChanged;
            // 
            // BtnEditAddCL
            // 
            BtnEditAddCL.Anchor = AnchorStyles.Top;
            BtnEditAddCL.Location = new Point(304, 372);
            BtnEditAddCL.Name = "BtnEditAddCL";
            BtnEditAddCL.Size = new Size(114, 41);
            BtnEditAddCL.TabIndex = 4;
            BtnEditAddCL.Text = "Adicionar Empresas";
            BtnEditAddCL.UseVisualStyleBackColor = true;
            BtnEditAddCL.Click += BtnEditAddCL_Click;
            // 
            // BtnEditRemoveCL
            // 
            BtnEditRemoveCL.Anchor = AnchorStyles.Top;
            BtnEditRemoveCL.Location = new Point(904, 373);
            BtnEditRemoveCL.Name = "BtnEditRemoveCL";
            BtnEditRemoveCL.Size = new Size(114, 41);
            BtnEditRemoveCL.TabIndex = 5;
            BtnEditRemoveCL.Text = "Remover Empresas";
            BtnEditRemoveCL.UseVisualStyleBackColor = true;
            // 
            // TxtEditListAll
            // 
            TxtEditListAll.Anchor = AnchorStyles.Top;
            TxtEditListAll.Location = new Point(3, 413);
            TxtEditListAll.Name = "TxtEditListAll";
            TxtEditListAll.Size = new Size(1316, 23);
            TxtEditListAll.TabIndex = 6;
            TxtEditListAll.Text = "Empresas Registradas";
            // 
            // TxtEditListSel
            // 
            TxtEditListSel.Anchor = AnchorStyles.Top;
            TxtEditListSel.Location = new Point(3, 128);
            TxtEditListSel.Name = "TxtEditListSel";
            TxtEditListSel.Size = new Size(1316, 23);
            TxtEditListSel.TabIndex = 7;
            TxtEditListSel.Text = "Lista Selecionada";
            // 
            // TxtEditListMsg
            // 
            TxtEditListMsg.Anchor = AnchorStyles.Top;
            TxtEditListMsg.Location = new Point(466, 372);
            TxtEditListMsg.Name = "TxtEditListMsg";
            TxtEditListMsg.Size = new Size(392, 42);
            TxtEditListMsg.TabIndex = 8;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Segoe UI", 15F);
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(1322, 120);
            label8.TabIndex = 9;
            label8.Text = "Editar Lista";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BoxEditFilterCL
            // 
            BoxEditFilterCL.Anchor = AnchorStyles.Top;
            BoxEditFilterCL.Location = new Point(3, 439);
            BoxEditFilterCL.Name = "BoxEditFilterCL";
            BoxEditFilterCL.Size = new Size(1316, 23);
            BoxEditFilterCL.TabIndex = 2;
            BoxEditFilterCL.TextChanged += BoxEditFilterCL_TextChanged;
            // 
            // TabEditMain
            // 
            TabEditMain.Location = new Point(4, 24);
            TabEditMain.Name = "TabEditMain";
            TabEditMain.Padding = new Padding(3);
            TabEditMain.Size = new Size(1328, 667);
            TabEditMain.TabIndex = 0;
            TabEditMain.Text = "Início";
            TabEditMain.UseVisualStyleBackColor = true;
            // 
            // EditPage
            // 
            EditPage.Controls.Add(TabEditMain);
            EditPage.Controls.Add(TabEditList);
            EditPage.Controls.Add(TabEditCompany);
            EditPage.Dock = DockStyle.Fill;
            EditPage.Location = new Point(3, 3);
            EditPage.Name = "EditPage";
            EditPage.SelectedIndex = 0;
            EditPage.Size = new Size(1336, 695);
            EditPage.TabIndex = 0;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 729);
            Controls.Add(MainPage);
            Name = "MainView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bingo Manager";
            WindowState = FormWindowState.Maximized;
            MainPage.ResumeLayout(false);
            TabCreatePage.ResumeLayout(false);
            CreatePage.ResumeLayout(false);
            TabCreateMain.ResumeLayout(false);
            TabCreateList.ResumeLayout(false);
            PnlNewList.ResumeLayout(false);
            PnlNewList.PerformLayout();
            TabCreateCompany.ResumeLayout(false);
            PnlNewComp.ResumeLayout(false);
            PnlNewComp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PicCreateCompanyLogo).EndInit();
            TabCreateCards.ResumeLayout(false);
            PnlNewCards.ResumeLayout(false);
            PnlNewCards.PerformLayout();
            TabEditPage.ResumeLayout(false);
            TabEditCompany.ResumeLayout(false);
            PnlEditCompany.ResumeLayout(false);
            PnlEditCompany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PicEditLogoComp).EndInit();
            TabEditList.ResumeLayout(false);
            PnlEditList.ResumeLayout(false);
            PnlEditList.PerformLayout();
            PnlEditSelList.ResumeLayout(false);
            PnlEditAllCompany.ResumeLayout(false);
            EditPage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl MainPage;
        private TabPage TabMainPage;
        private TabPage TabCreatePage;
        private TabControl CreatePage;
        private TabPage TabCreateMain;
        private TabPage TabCreateList;
        private Label label1;
        private Label TxtCreateListMessage;
        private Button BtnCreateList;
        private TextBox BoxCreateListName;
        private TextBox BoxCreateListDescription;
        private Label TxtCreateListDescription;
        private Label TxtCreatListeName;
        private TabPage TabCreateCompany;
        private TabPage TabCreateCards;
        private TabPage TabEditPage;
        private TabPage TabPlayPage;
        private TextBox BoxCreateCompanyEmail;
        private TextBox BoxCreateCompanyPhone;
        private TextBox BoxCreateCompanyCardName;
        private TextBox BoxCreateCompanyName;
        private PictureBox PicCreateCompanyLogo;
        private Button BtnCreateCompany;
        private Button BtnFindLogo;
        private Label label7;
        private Label TxtCreateCompanyMessage;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel PnlNewList;
        private ComboBox CboCreateCardsList;
        private Label TxtCreatCardsEnd;
        private Label TxtCreateCardsTitle;
        private Label TxtCreateCardsQuant;
        private Label TxtCreateCardsList;
        private TextBox BoxCreateCardsEnd;
        private TextBox BoxCreateCardsTitle;
        private TextBox BoxCreateCardsQuant;
        private Button BtnCreateCards;
        private Label TxtCreateCardsMsg;
        private Label TxtCreateListTitle;
        private Panel PnlNewComp;
        private Label TxtCreateCompanyTitle;
        private Panel PnlNewCards;
        private Label label6;
        private Label label11;
        private ComboBox CboCreateCompanyList;
        private TextBox BoxCreateCardsName;
        private Label label16;
        private TabControl EditPage;
        private TabPage TabEditMain;
        private TabPage TabEditList;
        private Panel PnlEditList;
        private TextBox BoxEditFilterCL;
        private Label label8;
        private Label TxtEditListMsg;
        private Label TxtEditListSel;
        private Label TxtEditListAll;
        private Button BtnEditRemoveCL;
        private Button BtnEditAddCL;
        private ComboBox CboEditListSel;
        private Panel PnlEditAllCompany;
        private FlowLayoutPanel FlowEditViewAll;
        private Panel PnlEditSelList;
        private FlowLayoutPanel FlowEditViewSel;
        private TabPage TabEditCompany;
        private Panel PnlEditCompany;
        private Button BtnRemoveComp;
        private PictureBox PicEditLogoComp;
        private Button BtnEditComp;
        private Button BtnEditLogoComp;
        private TextBox BoxEditEmailComp;
        private TextBox BoxEditPhoneComp;
        private TextBox BoxEditCardNameComp;
        private TextBox BoxEditNameComp;
        private Label LblEditMsgComp;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label LblEditCompName;
        private Label label10;
        private ComboBox CboEditComp;
        private Label label9;
    }
}
