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
            EditPage = new TabControl();
            TabEditMain = new TabPage();
            TabEditList = new TabPage();
            TxtEditListMsg = new Label();
            TxtEditListSel = new Label();
            TxtEditListAll = new Label();
            BtnEditRemoveCL = new Button();
            BtnEditAddCL = new Button();
            CboEditListSel = new ComboBox();
            BoxEditFilterCL = new TextBox();
            PnlEditSelList = new Panel();
            FlowEditViewSel = new FlowLayoutPanel();
            PnlEditAllCompany = new Panel();
            FlowEditViewAll = new FlowLayoutPanel();
            TabEditCompany = new TabPage();
            TabEditCards = new TabPage();
            TabPlayPage = new TabPage();
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
            EditPage.SuspendLayout();
            TabEditList.SuspendLayout();
            PnlEditSelList.SuspendLayout();
            PnlEditAllCompany.SuspendLayout();
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
            MainPage.Size = new Size(1102, 650);
            MainPage.TabIndex = 0;
            // 
            // TabMainPage
            // 
            TabMainPage.Location = new Point(4, 24);
            TabMainPage.Name = "TabMainPage";
            TabMainPage.Padding = new Padding(3);
            TabMainPage.Size = new Size(1094, 622);
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
            TabCreatePage.Size = new Size(1094, 622);
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
            CreatePage.Size = new Size(1088, 616);
            CreatePage.TabIndex = 0;
            // 
            // TabCreateMain
            // 
            TabCreateMain.Controls.Add(label1);
            TabCreateMain.Location = new Point(4, 24);
            TabCreateMain.Name = "TabCreateMain";
            TabCreateMain.Padding = new Padding(3);
            TabCreateMain.Size = new Size(1080, 588);
            TabCreateMain.TabIndex = 0;
            TabCreateMain.Text = "Início";
            TabCreateMain.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(1074, 582);
            label1.TabIndex = 0;
            label1.Text = resources.GetString("label1.Text");
            // 
            // TabCreateList
            // 
            TabCreateList.Controls.Add(PnlNewList);
            TabCreateList.Location = new Point(4, 24);
            TabCreateList.Name = "TabCreateList";
            TabCreateList.Padding = new Padding(3);
            TabCreateList.Size = new Size(1080, 588);
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
            PnlNewList.Size = new Size(1074, 582);
            PnlNewList.TabIndex = 6;
            // 
            // TxtCreateListTitle
            // 
            TxtCreateListTitle.Anchor = AnchorStyles.Top;
            TxtCreateListTitle.Font = new Font("Segoe UI", 15F);
            TxtCreateListTitle.Location = new Point(3, 0);
            TxtCreateListTitle.Name = "TxtCreateListTitle";
            TxtCreateListTitle.Size = new Size(1068, 112);
            TxtCreateListTitle.TabIndex = 6;
            TxtCreateListTitle.Text = "Nova Lista";
            TxtCreateListTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TxtCreateListMessage
            // 
            TxtCreateListMessage.Anchor = AnchorStyles.Top;
            TxtCreateListMessage.Location = new Point(71, 508);
            TxtCreateListMessage.Name = "TxtCreateListMessage";
            TxtCreateListMessage.Size = new Size(932, 23);
            TxtCreateListMessage.TabIndex = 5;
            // 
            // BtnCreateList
            // 
            BtnCreateList.Anchor = AnchorStyles.Top;
            BtnCreateList.Location = new Point(232, 404);
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
            TxtCreatListeName.Size = new Size(1068, 23);
            TxtCreatListeName.TabIndex = 0;
            TxtCreatListeName.Text = "Nome";
            // 
            // BoxCreateListName
            // 
            BoxCreateListName.Anchor = AnchorStyles.Top;
            BoxCreateListName.Location = new Point(3, 138);
            BoxCreateListName.Name = "BoxCreateListName";
            BoxCreateListName.Size = new Size(1068, 23);
            BoxCreateListName.TabIndex = 3;
            // 
            // TxtCreateListDescription
            // 
            TxtCreateListDescription.Anchor = AnchorStyles.Top;
            TxtCreateListDescription.Location = new Point(3, 179);
            TxtCreateListDescription.Name = "TxtCreateListDescription";
            TxtCreateListDescription.Size = new Size(1068, 23);
            TxtCreateListDescription.TabIndex = 1;
            TxtCreateListDescription.Text = "Descrição";
            // 
            // BoxCreateListDescription
            // 
            BoxCreateListDescription.Anchor = AnchorStyles.Top;
            BoxCreateListDescription.Location = new Point(3, 205);
            BoxCreateListDescription.Multiline = true;
            BoxCreateListDescription.Name = "BoxCreateListDescription";
            BoxCreateListDescription.Size = new Size(1068, 161);
            BoxCreateListDescription.TabIndex = 2;
            // 
            // TabCreateCompany
            // 
            TabCreateCompany.Controls.Add(PnlNewComp);
            TabCreateCompany.Location = new Point(4, 24);
            TabCreateCompany.Name = "TabCreateCompany";
            TabCreateCompany.Padding = new Padding(3);
            TabCreateCompany.Size = new Size(1080, 588);
            TabCreateCompany.TabIndex = 2;
            TabCreateCompany.Text = "Nova Empresa";
            TabCreateCompany.UseVisualStyleBackColor = true;
            // 
            // PnlNewComp
            // 
            PnlNewComp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
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
            PnlNewComp.Size = new Size(1074, 582);
            PnlNewComp.TabIndex = 13;
            // 
            // TxtCreateCompanyTitle
            // 
            TxtCreateCompanyTitle.Anchor = AnchorStyles.Top;
            TxtCreateCompanyTitle.Font = new Font("Segoe UI", 15F);
            TxtCreateCompanyTitle.Location = new Point(3, 0);
            TxtCreateCompanyTitle.Name = "TxtCreateCompanyTitle";
            TxtCreateCompanyTitle.Size = new Size(1068, 75);
            TxtCreateCompanyTitle.TabIndex = 13;
            TxtCreateCompanyTitle.Text = "Nova Empresa";
            TxtCreateCompanyTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BoxCreateCompanyEmail
            // 
            BoxCreateCompanyEmail.Anchor = AnchorStyles.Top;
            BoxCreateCompanyEmail.Location = new Point(3, 351);
            BoxCreateCompanyEmail.Name = "BoxCreateCompanyEmail";
            BoxCreateCompanyEmail.Size = new Size(1068, 23);
            BoxCreateCompanyEmail.TabIndex = 12;
            // 
            // BoxCreateCompanyPhone
            // 
            BoxCreateCompanyPhone.Anchor = AnchorStyles.Top;
            BoxCreateCompanyPhone.Location = new Point(3, 277);
            BoxCreateCompanyPhone.Name = "BoxCreateCompanyPhone";
            BoxCreateCompanyPhone.Size = new Size(1068, 23);
            BoxCreateCompanyPhone.TabIndex = 11;
            // 
            // BoxCreateCompanyCardName
            // 
            BoxCreateCompanyCardName.Anchor = AnchorStyles.Top;
            BoxCreateCompanyCardName.Location = new Point(3, 203);
            BoxCreateCompanyCardName.Name = "BoxCreateCompanyCardName";
            BoxCreateCompanyCardName.Size = new Size(1068, 23);
            BoxCreateCompanyCardName.TabIndex = 10;
            // 
            // PicCreateCompanyLogo
            // 
            PicCreateCompanyLogo.Anchor = AnchorStyles.Top;
            PicCreateCompanyLogo.Location = new Point(141, 407);
            PicCreateCompanyLogo.Name = "PicCreateCompanyLogo";
            PicCreateCompanyLogo.Size = new Size(271, 163);
            PicCreateCompanyLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            PicCreateCompanyLogo.TabIndex = 8;
            PicCreateCompanyLogo.TabStop = false;
            // 
            // BoxCreateCompanyName
            // 
            BoxCreateCompanyName.Anchor = AnchorStyles.Top;
            BoxCreateCompanyName.Location = new Point(3, 129);
            BoxCreateCompanyName.Name = "BoxCreateCompanyName";
            BoxCreateCompanyName.Size = new Size(1068, 23);
            BoxCreateCompanyName.TabIndex = 9;
            // 
            // BtnFindLogo
            // 
            BtnFindLogo.Anchor = AnchorStyles.Top;
            BtnFindLogo.Location = new Point(31, 452);
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
            label7.Location = new Point(3, 388);
            label7.Name = "label7";
            label7.Size = new Size(1068, 23);
            label7.TabIndex = 5;
            label7.Text = "Logo";
            // 
            // BtnCreateCompany
            // 
            BtnCreateCompany.Anchor = AnchorStyles.Top;
            BtnCreateCompany.Location = new Point(734, 407);
            BtnCreateCompany.Name = "BtnCreateCompany";
            BtnCreateCompany.Size = new Size(105, 82);
            BtnCreateCompany.TabIndex = 7;
            BtnCreateCompany.Text = "Criar Empresa";
            BtnCreateCompany.UseVisualStyleBackColor = true;
            BtnCreateCompany.Click += BtnCreateCompany_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.Location = new Point(3, 92);
            label2.Name = "label2";
            label2.Size = new Size(1068, 23);
            label2.TabIndex = 0;
            label2.Text = "Nome";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.Location = new Point(3, 240);
            label4.Name = "label4";
            label4.Size = new Size(385, 23);
            label4.TabIndex = 2;
            label4.Text = "Telefone";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.Location = new Point(3, 314);
            label5.Name = "label5";
            label5.Size = new Size(382, 23);
            label5.TabIndex = 3;
            label5.Text = "E-mail";
            // 
            // TxtCreateCompanyMessage
            // 
            TxtCreateCompanyMessage.Anchor = AnchorStyles.Top;
            TxtCreateCompanyMessage.Location = new Point(594, 499);
            TxtCreateCompanyMessage.Name = "TxtCreateCompanyMessage";
            TxtCreateCompanyMessage.Size = new Size(385, 71);
            TxtCreateCompanyMessage.TabIndex = 4;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.Location = new Point(3, 166);
            label3.Name = "label3";
            label3.Size = new Size(385, 23);
            label3.TabIndex = 1;
            label3.Text = "Nome para Cartela";
            // 
            // TabCreateCards
            // 
            TabCreateCards.Controls.Add(PnlNewCards);
            TabCreateCards.Location = new Point(4, 24);
            TabCreateCards.Name = "TabCreateCards";
            TabCreateCards.Padding = new Padding(3);
            TabCreateCards.Size = new Size(1080, 588);
            TabCreateCards.TabIndex = 3;
            TabCreateCards.Text = "Novas Cartelas";
            TabCreateCards.UseVisualStyleBackColor = true;
            // 
            // PnlNewCards
            // 
            PnlNewCards.AutoSizeMode = AutoSizeMode.GrowAndShrink;
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
            PnlNewCards.Size = new Size(1074, 582);
            PnlNewCards.TabIndex = 11;
            // 
            // TxtCreateCardsMsg
            // 
            TxtCreateCardsMsg.Anchor = AnchorStyles.Top;
            TxtCreateCardsMsg.Location = new Point(627, 185);
            TxtCreateCardsMsg.Name = "TxtCreateCardsMsg";
            TxtCreateCardsMsg.Size = new Size(361, 64);
            TxtCreateCardsMsg.TabIndex = 10;
            // 
            // BtnCreateCards
            // 
            BtnCreateCards.Anchor = AnchorStyles.Top;
            BtnCreateCards.Location = new Point(745, 280);
            BtnCreateCards.Name = "BtnCreateCards";
            BtnCreateCards.Size = new Size(125, 110);
            BtnCreateCards.TabIndex = 9;
            BtnCreateCards.Text = "Gerar Cartelas";
            BtnCreateCards.UseVisualStyleBackColor = true;
            BtnCreateCards.Click += BtnCreateCards_Click;
            // 
            // TxtCreatCardsEnd
            // 
            TxtCreatCardsEnd.Anchor = AnchorStyles.Top;
            TxtCreatCardsEnd.AutoSize = true;
            TxtCreatCardsEnd.Location = new Point(3, 328);
            TxtCreatCardsEnd.Name = "TxtCreatCardsEnd";
            TxtCreatCardsEnd.Size = new Size(94, 15);
            TxtCreatCardsEnd.TabIndex = 8;
            TxtCreatCardsEnd.Text = "Mensagem Final";
            // 
            // TxtCreateCardsTitle
            // 
            TxtCreateCardsTitle.Anchor = AnchorStyles.Top;
            TxtCreateCardsTitle.AutoSize = true;
            TxtCreateCardsTitle.Location = new Point(3, 257);
            TxtCreateCardsTitle.Name = "TxtCreateCardsTitle";
            TxtCreateCardsTitle.Size = new Size(37, 15);
            TxtCreateCardsTitle.TabIndex = 7;
            TxtCreateCardsTitle.Text = "Título";
            // 
            // TxtCreateCardsQuant
            // 
            TxtCreateCardsQuant.Anchor = AnchorStyles.Top;
            TxtCreateCardsQuant.AutoSize = true;
            TxtCreateCardsQuant.Location = new Point(3, 185);
            TxtCreateCardsQuant.Name = "TxtCreateCardsQuant";
            TxtCreateCardsQuant.Size = new Size(69, 15);
            TxtCreateCardsQuant.TabIndex = 6;
            TxtCreateCardsQuant.Text = "Quantidade";
            // 
            // TxtCreateCardsList
            // 
            TxtCreateCardsList.Anchor = AnchorStyles.Top;
            TxtCreateCardsList.AutoSize = true;
            TxtCreateCardsList.Location = new Point(3, 120);
            TxtCreateCardsList.Name = "TxtCreateCardsList";
            TxtCreateCardsList.Size = new Size(31, 15);
            TxtCreateCardsList.TabIndex = 5;
            TxtCreateCardsList.Text = "Lista";
            // 
            // BoxCreateCardsEnd
            // 
            BoxCreateCardsEnd.Anchor = AnchorStyles.Top;
            BoxCreateCardsEnd.Location = new Point(3, 346);
            BoxCreateCardsEnd.Multiline = true;
            BoxCreateCardsEnd.Name = "BoxCreateCardsEnd";
            BoxCreateCardsEnd.Size = new Size(516, 68);
            BoxCreateCardsEnd.TabIndex = 3;
            // 
            // BoxCreateCardsTitle
            // 
            BoxCreateCardsTitle.Anchor = AnchorStyles.Top;
            BoxCreateCardsTitle.Location = new Point(3, 275);
            BoxCreateCardsTitle.Name = "BoxCreateCardsTitle";
            BoxCreateCardsTitle.Size = new Size(516, 23);
            BoxCreateCardsTitle.TabIndex = 2;
            // 
            // BoxCreateCardsQuant
            // 
            BoxCreateCardsQuant.Anchor = AnchorStyles.Top;
            BoxCreateCardsQuant.Location = new Point(3, 203);
            BoxCreateCardsQuant.Name = "BoxCreateCardsQuant";
            BoxCreateCardsQuant.Size = new Size(516, 23);
            BoxCreateCardsQuant.TabIndex = 1;
            // 
            // CboCreateCardsList
            // 
            CboCreateCardsList.Anchor = AnchorStyles.Top;
            CboCreateCardsList.FormattingEnabled = true;
            CboCreateCardsList.Location = new Point(3, 138);
            CboCreateCardsList.Name = "CboCreateCardsList";
            CboCreateCardsList.Size = new Size(516, 23);
            CboCreateCardsList.TabIndex = 0;
            // 
            // TabEditPage
            // 
            TabEditPage.Controls.Add(EditPage);
            TabEditPage.Location = new Point(4, 24);
            TabEditPage.Name = "TabEditPage";
            TabEditPage.Padding = new Padding(3);
            TabEditPage.Size = new Size(1094, 622);
            TabEditPage.TabIndex = 2;
            TabEditPage.Text = "Editar";
            TabEditPage.UseVisualStyleBackColor = true;
            // 
            // EditPage
            // 
            EditPage.Controls.Add(TabEditMain);
            EditPage.Controls.Add(TabEditList);
            EditPage.Controls.Add(TabEditCompany);
            EditPage.Controls.Add(TabEditCards);
            EditPage.Dock = DockStyle.Fill;
            EditPage.Location = new Point(3, 3);
            EditPage.Name = "EditPage";
            EditPage.SelectedIndex = 0;
            EditPage.Size = new Size(1088, 616);
            EditPage.TabIndex = 0;
            // 
            // TabEditMain
            // 
            TabEditMain.Location = new Point(4, 24);
            TabEditMain.Name = "TabEditMain";
            TabEditMain.Padding = new Padding(3);
            TabEditMain.Size = new Size(1080, 588);
            TabEditMain.TabIndex = 0;
            TabEditMain.Text = "Início";
            TabEditMain.UseVisualStyleBackColor = true;
            // 
            // TabEditList
            // 
            TabEditList.Controls.Add(TxtEditListMsg);
            TabEditList.Controls.Add(TxtEditListSel);
            TabEditList.Controls.Add(TxtEditListAll);
            TabEditList.Controls.Add(BtnEditRemoveCL);
            TabEditList.Controls.Add(BtnEditAddCL);
            TabEditList.Controls.Add(CboEditListSel);
            TabEditList.Controls.Add(BoxEditFilterCL);
            TabEditList.Controls.Add(PnlEditSelList);
            TabEditList.Controls.Add(PnlEditAllCompany);
            TabEditList.Location = new Point(4, 24);
            TabEditList.Name = "TabEditList";
            TabEditList.Padding = new Padding(3);
            TabEditList.Size = new Size(1080, 588);
            TabEditList.TabIndex = 1;
            TabEditList.Text = "Editar Listas";
            TabEditList.UseVisualStyleBackColor = true;
            // 
            // TxtEditListMsg
            // 
            TxtEditListMsg.Anchor = AnchorStyles.None;
            TxtEditListMsg.Location = new Point(344, 534);
            TxtEditListMsg.Name = "TxtEditListMsg";
            TxtEditListMsg.Size = new Size(392, 42);
            TxtEditListMsg.TabIndex = 8;
            // 
            // TxtEditListSel
            // 
            TxtEditListSel.Anchor = AnchorStyles.None;
            TxtEditListSel.Location = new Point(565, 34);
            TxtEditListSel.Name = "TxtEditListSel";
            TxtEditListSel.Size = new Size(489, 23);
            TxtEditListSel.TabIndex = 7;
            TxtEditListSel.Text = "Lista Selecionada";
            // 
            // TxtEditListAll
            // 
            TxtEditListAll.Anchor = AnchorStyles.None;
            TxtEditListAll.Location = new Point(26, 34);
            TxtEditListAll.Name = "TxtEditListAll";
            TxtEditListAll.Size = new Size(485, 23);
            TxtEditListAll.TabIndex = 6;
            TxtEditListAll.Text = "Empresas Registradas";
            // 
            // BtnEditRemoveCL
            // 
            BtnEditRemoveCL.Anchor = AnchorStyles.None;
            BtnEditRemoveCL.Location = new Point(519, 208);
            BtnEditRemoveCL.Name = "BtnEditRemoveCL";
            BtnEditRemoveCL.Size = new Size(41, 41);
            BtnEditRemoveCL.TabIndex = 5;
            BtnEditRemoveCL.Text = "<-";
            BtnEditRemoveCL.UseVisualStyleBackColor = true;
            // 
            // BtnEditAddCL
            // 
            BtnEditAddCL.Anchor = AnchorStyles.None;
            BtnEditAddCL.Location = new Point(519, 161);
            BtnEditAddCL.Name = "BtnEditAddCL";
            BtnEditAddCL.Size = new Size(41, 41);
            BtnEditAddCL.TabIndex = 4;
            BtnEditAddCL.Text = "->";
            BtnEditAddCL.UseVisualStyleBackColor = true;
            BtnEditAddCL.Click += BtnEditAddCL_Click;
            // 
            // CboEditListSel
            // 
            CboEditListSel.Anchor = AnchorStyles.None;
            CboEditListSel.FormattingEnabled = true;
            CboEditListSel.Location = new Point(565, 60);
            CboEditListSel.Name = "CboEditListSel";
            CboEditListSel.Size = new Size(489, 23);
            CboEditListSel.TabIndex = 3;
            CboEditListSel.SelectedValueChanged += CboEditListSel_SelectedValueChanged;
            // 
            // BoxEditFilterCL
            // 
            BoxEditFilterCL.Anchor = AnchorStyles.None;
            BoxEditFilterCL.Location = new Point(24, 60);
            BoxEditFilterCL.Name = "BoxEditFilterCL";
            BoxEditFilterCL.Size = new Size(489, 23);
            BoxEditFilterCL.TabIndex = 2;
            BoxEditFilterCL.TextChanged += BoxEditFilterCL_TextChanged;
            // 
            // PnlEditSelList
            // 
            PnlEditSelList.Anchor = AnchorStyles.None;
            PnlEditSelList.AutoScroll = true;
            PnlEditSelList.AutoSize = true;
            PnlEditSelList.BackColor = Color.Black;
            PnlEditSelList.Controls.Add(FlowEditViewSel);
            PnlEditSelList.Location = new Point(566, 89);
            PnlEditSelList.Name = "PnlEditSelList";
            PnlEditSelList.Size = new Size(488, 442);
            PnlEditSelList.TabIndex = 1;
            // 
            // FlowEditViewSel
            // 
            FlowEditViewSel.BackColor = Color.Gray;
            FlowEditViewSel.Dock = DockStyle.Fill;
            FlowEditViewSel.Location = new Point(0, 0);
            FlowEditViewSel.Name = "FlowEditViewSel";
            FlowEditViewSel.Size = new Size(488, 442);
            FlowEditViewSel.TabIndex = 0;
            // 
            // PnlEditAllCompany
            // 
            PnlEditAllCompany.Anchor = AnchorStyles.None;
            PnlEditAllCompany.AutoScroll = true;
            PnlEditAllCompany.AutoSize = true;
            PnlEditAllCompany.BackColor = Color.Black;
            PnlEditAllCompany.Controls.Add(FlowEditViewAll);
            PnlEditAllCompany.Location = new Point(26, 89);
            PnlEditAllCompany.Name = "PnlEditAllCompany";
            PnlEditAllCompany.Size = new Size(487, 442);
            PnlEditAllCompany.TabIndex = 0;
            // 
            // FlowEditViewAll
            // 
            FlowEditViewAll.BackColor = Color.Gray;
            FlowEditViewAll.Dock = DockStyle.Fill;
            FlowEditViewAll.Location = new Point(0, 0);
            FlowEditViewAll.Name = "FlowEditViewAll";
            FlowEditViewAll.Size = new Size(487, 442);
            FlowEditViewAll.TabIndex = 0;
            // 
            // TabEditCompany
            // 
            TabEditCompany.Location = new Point(4, 24);
            TabEditCompany.Name = "TabEditCompany";
            TabEditCompany.Padding = new Padding(3);
            TabEditCompany.Size = new Size(1080, 588);
            TabEditCompany.TabIndex = 2;
            TabEditCompany.Text = "Editar Empresas";
            TabEditCompany.UseVisualStyleBackColor = true;
            // 
            // TabEditCards
            // 
            TabEditCards.Location = new Point(4, 24);
            TabEditCards.Name = "TabEditCards";
            TabEditCards.Padding = new Padding(3);
            TabEditCards.Size = new Size(1080, 588);
            TabEditCards.TabIndex = 3;
            TabEditCards.Text = "Editar Cartelas";
            TabEditCards.UseVisualStyleBackColor = true;
            // 
            // TabPlayPage
            // 
            TabPlayPage.Location = new Point(4, 24);
            TabPlayPage.Name = "TabPlayPage";
            TabPlayPage.Padding = new Padding(3);
            TabPlayPage.Size = new Size(1094, 622);
            TabPlayPage.TabIndex = 3;
            TabPlayPage.Text = "Jogar";
            TabPlayPage.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1102, 650);
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
            EditPage.ResumeLayout(false);
            TabEditList.ResumeLayout(false);
            TabEditList.PerformLayout();
            PnlEditSelList.ResumeLayout(false);
            PnlEditAllCompany.ResumeLayout(false);
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
        private TabControl EditPage;
        private TabPage TabEditMain;
        private TabPage TabEditList;
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
        private TabPage TabEditCompany;
        private TabPage TabEditCards;
        private Panel PnlEditSelList;
        private FlowLayoutPanel FlowEditViewSel;
        private Panel PnlEditAllCompany;
        private FlowLayoutPanel FlowEditViewAll;
        private Button BtnEditRemoveCL;
        private Button BtnEditAddCL;
        private ComboBox CboEditListSel;
        private TextBox BoxEditFilterCL;
        private Label TxtEditListSel;
        private Label TxtEditListAll;
        private Panel PnlNewList;
        private Label TxtEditListMsg;
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
    }
}
