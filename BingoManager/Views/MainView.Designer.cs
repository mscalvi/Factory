namespace BingoManager
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
            panel1 = new Panel();
            TxtCreatListeName = new Label();
            TxtCreateListMessage = new Label();
            BoxCreateListName = new TextBox();
            TxtCreateListDescription = new Label();
            BoxCreateListDescription = new TextBox();
            BtnCreateList = new Button();
            TabCreateCompany = new TabPage();
            BoxCreateCompanyEmail = new TextBox();
            BoxCreateCompanyPhone = new TextBox();
            BoxCreateCompanyCardName = new TextBox();
            BoxCreateCompanyName = new TextBox();
            PicCreateCompanyLogo = new PictureBox();
            BtnCreateCompany = new Button();
            BtnFindLogo = new Button();
            label7 = new Label();
            TxtCreateCompanyMessage = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            TabCreateCards = new TabPage();
            TxtCreateCardsMsg = new Label();
            BtnCreateCards = new Button();
            TxtCreatCardsEnd = new Label();
            TxtCreateCardsTitle = new Label();
            TxtCreateCardsQuant = new Label();
            TxtCreateCardsList = new Label();
            GrpCreateCardsCenter = new GroupBox();
            RadCreateCardsCenter0 = new RadioButton();
            RadCreateCardsCenter1 = new RadioButton();
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
            panel1.SuspendLayout();
            TabCreateCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicCreateCompanyLogo).BeginInit();
            TabCreateCards.SuspendLayout();
            GrpCreateCardsCenter.SuspendLayout();
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
            TabCreateList.Controls.Add(panel1);
            TabCreateList.Controls.Add(BtnCreateList);
            TabCreateList.Location = new Point(4, 24);
            TabCreateList.Name = "TabCreateList";
            TabCreateList.Padding = new Padding(3);
            TabCreateList.Size = new Size(1080, 588);
            TabCreateList.TabIndex = 1;
            TabCreateList.Text = "Nova Lista";
            TabCreateList.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(TxtCreatListeName);
            panel1.Controls.Add(TxtCreateListMessage);
            panel1.Controls.Add(BoxCreateListName);
            panel1.Controls.Add(TxtCreateListDescription);
            panel1.Controls.Add(BoxCreateListDescription);
            panel1.Location = new Point(6, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(535, 576);
            panel1.TabIndex = 6;
            // 
            // TxtCreatListeName
            // 
            TxtCreatListeName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtCreatListeName.Location = new Point(71, 199);
            TxtCreatListeName.Name = "TxtCreatListeName";
            TxtCreatListeName.Size = new Size(393, 23);
            TxtCreatListeName.TabIndex = 0;
            TxtCreatListeName.Text = "label2";
            // 
            // TxtCreateListMessage
            // 
            TxtCreateListMessage.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtCreateListMessage.Location = new Point(71, 303);
            TxtCreateListMessage.Name = "TxtCreateListMessage";
            TxtCreateListMessage.Size = new Size(393, 23);
            TxtCreateListMessage.TabIndex = 5;
            TxtCreateListMessage.Text = "label4";
            // 
            // BoxCreateListName
            // 
            BoxCreateListName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            BoxCreateListName.Location = new Point(71, 225);
            BoxCreateListName.Name = "BoxCreateListName";
            BoxCreateListName.Size = new Size(393, 23);
            BoxCreateListName.TabIndex = 3;
            // 
            // TxtCreateListDescription
            // 
            TxtCreateListDescription.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtCreateListDescription.Location = new Point(71, 251);
            TxtCreateListDescription.Name = "TxtCreateListDescription";
            TxtCreateListDescription.Size = new Size(393, 23);
            TxtCreateListDescription.TabIndex = 1;
            TxtCreateListDescription.Text = "label3";
            // 
            // BoxCreateListDescription
            // 
            BoxCreateListDescription.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            BoxCreateListDescription.Location = new Point(71, 277);
            BoxCreateListDescription.Name = "BoxCreateListDescription";
            BoxCreateListDescription.Size = new Size(393, 23);
            BoxCreateListDescription.TabIndex = 2;
            // 
            // BtnCreateList
            // 
            BtnCreateList.Anchor = AnchorStyles.None;
            BtnCreateList.Location = new Point(571, 175);
            BtnCreateList.Name = "BtnCreateList";
            BtnCreateList.Size = new Size(71, 67);
            BtnCreateList.TabIndex = 4;
            BtnCreateList.Text = "button1";
            BtnCreateList.UseVisualStyleBackColor = true;
            BtnCreateList.Click += BtnCreateList_Click;
            // 
            // TabCreateCompany
            // 
            TabCreateCompany.Controls.Add(BoxCreateCompanyEmail);
            TabCreateCompany.Controls.Add(BoxCreateCompanyPhone);
            TabCreateCompany.Controls.Add(BoxCreateCompanyCardName);
            TabCreateCompany.Controls.Add(BoxCreateCompanyName);
            TabCreateCompany.Controls.Add(PicCreateCompanyLogo);
            TabCreateCompany.Controls.Add(BtnCreateCompany);
            TabCreateCompany.Controls.Add(BtnFindLogo);
            TabCreateCompany.Controls.Add(label7);
            TabCreateCompany.Controls.Add(TxtCreateCompanyMessage);
            TabCreateCompany.Controls.Add(label5);
            TabCreateCompany.Controls.Add(label4);
            TabCreateCompany.Controls.Add(label3);
            TabCreateCompany.Controls.Add(label2);
            TabCreateCompany.Location = new Point(4, 24);
            TabCreateCompany.Name = "TabCreateCompany";
            TabCreateCompany.Padding = new Padding(3);
            TabCreateCompany.Size = new Size(1080, 588);
            TabCreateCompany.TabIndex = 2;
            TabCreateCompany.Text = "Nova Empresa";
            TabCreateCompany.UseVisualStyleBackColor = true;
            // 
            // BoxCreateCompanyEmail
            // 
            BoxCreateCompanyEmail.Location = new Point(68, 337);
            BoxCreateCompanyEmail.Name = "BoxCreateCompanyEmail";
            BoxCreateCompanyEmail.Size = new Size(385, 23);
            BoxCreateCompanyEmail.TabIndex = 12;
            // 
            // BoxCreateCompanyPhone
            // 
            BoxCreateCompanyPhone.Location = new Point(68, 250);
            BoxCreateCompanyPhone.Name = "BoxCreateCompanyPhone";
            BoxCreateCompanyPhone.Size = new Size(385, 23);
            BoxCreateCompanyPhone.TabIndex = 11;
            // 
            // BoxCreateCompanyCardName
            // 
            BoxCreateCompanyCardName.Location = new Point(68, 181);
            BoxCreateCompanyCardName.Name = "BoxCreateCompanyCardName";
            BoxCreateCompanyCardName.Size = new Size(385, 23);
            BoxCreateCompanyCardName.TabIndex = 10;
            // 
            // BoxCreateCompanyName
            // 
            BoxCreateCompanyName.Location = new Point(68, 111);
            BoxCreateCompanyName.Name = "BoxCreateCompanyName";
            BoxCreateCompanyName.Size = new Size(385, 23);
            BoxCreateCompanyName.TabIndex = 9;
            // 
            // PicCreateCompanyLogo
            // 
            PicCreateCompanyLogo.Location = new Point(581, 197);
            PicCreateCompanyLogo.Name = "PicCreateCompanyLogo";
            PicCreateCompanyLogo.Size = new Size(271, 163);
            PicCreateCompanyLogo.TabIndex = 8;
            PicCreateCompanyLogo.TabStop = false;
            // 
            // BtnCreateCompany
            // 
            BtnCreateCompany.Location = new Point(650, 411);
            BtnCreateCompany.Name = "BtnCreateCompany";
            BtnCreateCompany.Size = new Size(75, 23);
            BtnCreateCompany.TabIndex = 7;
            BtnCreateCompany.Text = "button2";
            BtnCreateCompany.UseVisualStyleBackColor = true;
            BtnCreateCompany.Click += BtnCreateCompany_Click;
            // 
            // BtnFindLogo
            // 
            BtnFindLogo.Location = new Point(675, 168);
            BtnFindLogo.Name = "BtnFindLogo";
            BtnFindLogo.Size = new Size(75, 23);
            BtnFindLogo.TabIndex = 6;
            BtnFindLogo.Text = "button1";
            BtnFindLogo.UseVisualStyleBackColor = true;
            BtnFindLogo.Click += BtnFindLogo_Click;
            // 
            // label7
            // 
            label7.Location = new Point(581, 142);
            label7.Name = "label7";
            label7.Size = new Size(271, 23);
            label7.TabIndex = 5;
            label7.Text = "label7";
            // 
            // TxtCreateCompanyMessage
            // 
            TxtCreateCompanyMessage.Location = new Point(68, 411);
            TxtCreateCompanyMessage.Name = "TxtCreateCompanyMessage";
            TxtCreateCompanyMessage.Size = new Size(385, 23);
            TxtCreateCompanyMessage.TabIndex = 4;
            TxtCreateCompanyMessage.Text = "label6";
            // 
            // label5
            // 
            label5.Location = new Point(68, 311);
            label5.Name = "label5";
            label5.Size = new Size(385, 23);
            label5.TabIndex = 3;
            label5.Text = "label5";
            // 
            // label4
            // 
            label4.Location = new Point(68, 224);
            label4.Name = "label4";
            label4.Size = new Size(385, 23);
            label4.TabIndex = 2;
            label4.Text = "label4";
            // 
            // label3
            // 
            label3.Location = new Point(68, 155);
            label3.Name = "label3";
            label3.Size = new Size(385, 23);
            label3.TabIndex = 1;
            label3.Text = "label3";
            // 
            // label2
            // 
            label2.Location = new Point(68, 85);
            label2.Name = "label2";
            label2.Size = new Size(385, 23);
            label2.TabIndex = 0;
            label2.Text = "label2";
            // 
            // TabCreateCards
            // 
            TabCreateCards.Controls.Add(TxtCreateCardsMsg);
            TabCreateCards.Controls.Add(BtnCreateCards);
            TabCreateCards.Controls.Add(TxtCreatCardsEnd);
            TabCreateCards.Controls.Add(TxtCreateCardsTitle);
            TabCreateCards.Controls.Add(TxtCreateCardsQuant);
            TabCreateCards.Controls.Add(TxtCreateCardsList);
            TabCreateCards.Controls.Add(GrpCreateCardsCenter);
            TabCreateCards.Controls.Add(BoxCreateCardsEnd);
            TabCreateCards.Controls.Add(BoxCreateCardsTitle);
            TabCreateCards.Controls.Add(BoxCreateCardsQuant);
            TabCreateCards.Controls.Add(CboCreateCardsList);
            TabCreateCards.Location = new Point(4, 24);
            TabCreateCards.Name = "TabCreateCards";
            TabCreateCards.Padding = new Padding(3);
            TabCreateCards.Size = new Size(1080, 588);
            TabCreateCards.TabIndex = 3;
            TabCreateCards.Text = "Novas Cartelas";
            TabCreateCards.UseVisualStyleBackColor = true;
            // 
            // TxtCreateCardsMsg
            // 
            TxtCreateCardsMsg.Location = new Point(101, 417);
            TxtCreateCardsMsg.Name = "TxtCreateCardsMsg";
            TxtCreateCardsMsg.Size = new Size(361, 64);
            TxtCreateCardsMsg.TabIndex = 10;
            TxtCreateCardsMsg.Text = "label6";
            // 
            // BtnCreateCards
            // 
            BtnCreateCards.Location = new Point(630, 257);
            BtnCreateCards.Name = "BtnCreateCards";
            BtnCreateCards.Size = new Size(117, 39);
            BtnCreateCards.TabIndex = 9;
            BtnCreateCards.Text = "button1";
            BtnCreateCards.UseVisualStyleBackColor = true;
            BtnCreateCards.Click += BtnCreateCards_Click;
            // 
            // TxtCreatCardsEnd
            // 
            TxtCreatCardsEnd.AutoSize = true;
            TxtCreatCardsEnd.Location = new Point(101, 328);
            TxtCreatCardsEnd.Name = "TxtCreatCardsEnd";
            TxtCreatCardsEnd.Size = new Size(44, 15);
            TxtCreatCardsEnd.TabIndex = 8;
            TxtCreatCardsEnd.Text = "label10";
            // 
            // TxtCreateCardsTitle
            // 
            TxtCreateCardsTitle.AutoSize = true;
            TxtCreateCardsTitle.Location = new Point(101, 257);
            TxtCreateCardsTitle.Name = "TxtCreateCardsTitle";
            TxtCreateCardsTitle.Size = new Size(38, 15);
            TxtCreateCardsTitle.TabIndex = 7;
            TxtCreateCardsTitle.Text = "label9";
            // 
            // TxtCreateCardsQuant
            // 
            TxtCreateCardsQuant.AutoSize = true;
            TxtCreateCardsQuant.Location = new Point(101, 185);
            TxtCreateCardsQuant.Name = "TxtCreateCardsQuant";
            TxtCreateCardsQuant.Size = new Size(38, 15);
            TxtCreateCardsQuant.TabIndex = 6;
            TxtCreateCardsQuant.Text = "label8";
            // 
            // TxtCreateCardsList
            // 
            TxtCreateCardsList.AutoSize = true;
            TxtCreateCardsList.Location = new Point(101, 120);
            TxtCreateCardsList.Name = "TxtCreateCardsList";
            TxtCreateCardsList.Size = new Size(38, 15);
            TxtCreateCardsList.TabIndex = 5;
            TxtCreateCardsList.Text = "label6";
            // 
            // GrpCreateCardsCenter
            // 
            GrpCreateCardsCenter.Controls.Add(RadCreateCardsCenter0);
            GrpCreateCardsCenter.Controls.Add(RadCreateCardsCenter1);
            GrpCreateCardsCenter.Location = new Point(630, 120);
            GrpCreateCardsCenter.Name = "GrpCreateCardsCenter";
            GrpCreateCardsCenter.Size = new Size(117, 88);
            GrpCreateCardsCenter.TabIndex = 4;
            GrpCreateCardsCenter.TabStop = false;
            GrpCreateCardsCenter.Text = "groupBox1";
            // 
            // RadCreateCardsCenter0
            // 
            RadCreateCardsCenter0.AutoSize = true;
            RadCreateCardsCenter0.Location = new Point(6, 47);
            RadCreateCardsCenter0.Name = "RadCreateCardsCenter0";
            RadCreateCardsCenter0.Size = new Size(94, 19);
            RadCreateCardsCenter0.TabIndex = 1;
            RadCreateCardsCenter0.TabStop = true;
            RadCreateCardsCenter0.Text = "radioButton2";
            RadCreateCardsCenter0.UseVisualStyleBackColor = true;
            // 
            // RadCreateCardsCenter1
            // 
            RadCreateCardsCenter1.AutoSize = true;
            RadCreateCardsCenter1.Location = new Point(6, 22);
            RadCreateCardsCenter1.Name = "RadCreateCardsCenter1";
            RadCreateCardsCenter1.Size = new Size(94, 19);
            RadCreateCardsCenter1.TabIndex = 0;
            RadCreateCardsCenter1.TabStop = true;
            RadCreateCardsCenter1.Text = "radioButton1";
            RadCreateCardsCenter1.UseVisualStyleBackColor = true;
            // 
            // BoxCreateCardsEnd
            // 
            BoxCreateCardsEnd.Location = new Point(101, 346);
            BoxCreateCardsEnd.Name = "BoxCreateCardsEnd";
            BoxCreateCardsEnd.Size = new Size(361, 23);
            BoxCreateCardsEnd.TabIndex = 3;
            // 
            // BoxCreateCardsTitle
            // 
            BoxCreateCardsTitle.Location = new Point(101, 275);
            BoxCreateCardsTitle.Name = "BoxCreateCardsTitle";
            BoxCreateCardsTitle.Size = new Size(361, 23);
            BoxCreateCardsTitle.TabIndex = 2;
            // 
            // BoxCreateCardsQuant
            // 
            BoxCreateCardsQuant.Location = new Point(101, 203);
            BoxCreateCardsQuant.Name = "BoxCreateCardsQuant";
            BoxCreateCardsQuant.Size = new Size(361, 23);
            BoxCreateCardsQuant.TabIndex = 1;
            // 
            // CboCreateCardsList
            // 
            CboCreateCardsList.FormattingEnabled = true;
            CboCreateCardsList.Location = new Point(101, 138);
            CboCreateCardsList.Name = "CboCreateCardsList";
            CboCreateCardsList.Size = new Size(361, 23);
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
            TxtEditListMsg.Location = new Point(344, 553);
            TxtEditListMsg.Name = "TxtEditListMsg";
            TxtEditListMsg.Size = new Size(392, 23);
            TxtEditListMsg.TabIndex = 8;
            TxtEditListMsg.Text = "label6";
            // 
            // TxtEditListSel
            // 
            TxtEditListSel.Anchor = AnchorStyles.None;
            TxtEditListSel.Location = new Point(565, 34);
            TxtEditListSel.Name = "TxtEditListSel";
            TxtEditListSel.Size = new Size(488, 23);
            TxtEditListSel.TabIndex = 7;
            TxtEditListSel.Text = "label8";
            // 
            // TxtEditListAll
            // 
            TxtEditListAll.Anchor = AnchorStyles.None;
            TxtEditListAll.Location = new Point(26, 34);
            TxtEditListAll.Name = "TxtEditListAll";
            TxtEditListAll.Size = new Size(487, 23);
            TxtEditListAll.TabIndex = 6;
            TxtEditListAll.Text = "label6";
            // 
            // BtnEditRemoveCL
            // 
            BtnEditRemoveCL.Anchor = AnchorStyles.None;
            BtnEditRemoveCL.Location = new Point(519, 208);
            BtnEditRemoveCL.Name = "BtnEditRemoveCL";
            BtnEditRemoveCL.Size = new Size(41, 41);
            BtnEditRemoveCL.TabIndex = 5;
            BtnEditRemoveCL.Text = "button2";
            BtnEditRemoveCL.UseVisualStyleBackColor = true;
            // 
            // BtnEditAddCL
            // 
            BtnEditAddCL.Anchor = AnchorStyles.None;
            BtnEditAddCL.Location = new Point(519, 161);
            BtnEditAddCL.Name = "BtnEditAddCL";
            BtnEditAddCL.Size = new Size(41, 41);
            BtnEditAddCL.TabIndex = 4;
            BtnEditAddCL.Text = "button1";
            BtnEditAddCL.UseVisualStyleBackColor = true;
            BtnEditAddCL.Click += BtnEditAddCL_Click;
            // 
            // CboEditListSel
            // 
            CboEditListSel.Anchor = AnchorStyles.None;
            CboEditListSel.FormattingEnabled = true;
            CboEditListSel.Location = new Point(565, 60);
            CboEditListSel.Name = "CboEditListSel";
            CboEditListSel.Size = new Size(488, 23);
            CboEditListSel.TabIndex = 3;
            CboEditListSel.SelectedValueChanged += CboEditListSel_SelectedValueChanged;
            // 
            // BoxEditFilterCL
            // 
            BoxEditFilterCL.Anchor = AnchorStyles.None;
            BoxEditFilterCL.Location = new Point(24, 60);
            BoxEditFilterCL.Name = "BoxEditFilterCL";
            BoxEditFilterCL.Size = new Size(487, 23);
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
            FlowEditViewSel.Anchor = AnchorStyles.None;
            FlowEditViewSel.BackColor = Color.Gray;
            FlowEditViewSel.Location = new Point(-1, 0);
            FlowEditViewSel.Name = "FlowEditViewSel";
            FlowEditViewSel.Size = new Size(488, 439);
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
            FlowEditViewAll.Anchor = AnchorStyles.None;
            FlowEditViewAll.BackColor = Color.Gray;
            FlowEditViewAll.Location = new Point(-2, 0);
            FlowEditViewAll.Name = "FlowEditViewAll";
            FlowEditViewAll.Size = new Size(487, 439);
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
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            MainPage.ResumeLayout(false);
            TabCreatePage.ResumeLayout(false);
            CreatePage.ResumeLayout(false);
            TabCreateMain.ResumeLayout(false);
            TabCreateList.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            TabCreateCompany.ResumeLayout(false);
            TabCreateCompany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PicCreateCompanyLogo).EndInit();
            TabCreateCards.ResumeLayout(false);
            TabCreateCards.PerformLayout();
            GrpCreateCardsCenter.ResumeLayout(false);
            GrpCreateCardsCenter.PerformLayout();
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
        private Panel panel1;
        private Label TxtEditListMsg;
        private ComboBox CboCreateCardsList;
        private Label TxtCreatCardsEnd;
        private Label TxtCreateCardsTitle;
        private Label TxtCreateCardsQuant;
        private Label TxtCreateCardsList;
        private GroupBox GrpCreateCardsCenter;
        private RadioButton RadCreateCardsCenter0;
        private RadioButton RadCreateCardsCenter1;
        private TextBox BoxCreateCardsEnd;
        private TextBox BoxCreateCardsTitle;
        private TextBox BoxCreateCardsQuant;
        private Button BtnCreateCards;
        private Label TxtCreateCardsMsg;
    }
}
