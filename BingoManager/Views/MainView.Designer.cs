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
            TxtCreateListMessage = new Label();
            BtnCreateList = new Button();
            BoxCreateListName = new TextBox();
            BoxCreateListDescription = new TextBox();
            TxtCreateListDescription = new Label();
            TxtCreatListeName = new Label();
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
            TabEditPage = new TabPage();
            EditPage = new TabControl();
            TabEditMain = new TabPage();
            TabEditList = new TabPage();
            TxtEditListSel = new Label();
            TxtEditListAll = new Label();
            BtnEditRemoveCL = new Button();
            BtnEditAddCL = new Button();
            CboEditListSel = new ComboBox();
            BoxEditFilterCL = new TextBox();
            PnlEditAllCompany = new Panel();
            FlowEditViewAll = new FlowLayoutPanel();
            PnlEditSelList = new Panel();
            FlowEditViewSel = new FlowLayoutPanel();
            TabEditCompany = new TabPage();
            TabEditCards = new TabPage();
            TabPlayPage = new TabPage();
            MainPage.SuspendLayout();
            TabCreatePage.SuspendLayout();
            CreatePage.SuspendLayout();
            TabCreateMain.SuspendLayout();
            TabCreateList.SuspendLayout();
            TabCreateCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicCreateCompanyLogo).BeginInit();
            TabEditPage.SuspendLayout();
            EditPage.SuspendLayout();
            TabEditList.SuspendLayout();
            PnlEditAllCompany.SuspendLayout();
            PnlEditSelList.SuspendLayout();
            SuspendLayout();
            // 
            // MainPage
            // 
            MainPage.Controls.Add(TabMainPage);
            MainPage.Controls.Add(TabCreatePage);
            MainPage.Controls.Add(TabEditPage);
            MainPage.Controls.Add(TabPlayPage);
            MainPage.Location = new Point(12, 12);
            MainPage.Name = "MainPage";
            MainPage.SelectedIndex = 0;
            MainPage.Size = new Size(1078, 626);
            MainPage.TabIndex = 0;
            // 
            // TabMainPage
            // 
            TabMainPage.Location = new Point(4, 24);
            TabMainPage.Name = "TabMainPage";
            TabMainPage.Padding = new Padding(3);
            TabMainPage.Size = new Size(1070, 598);
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
            TabCreatePage.Size = new Size(1070, 598);
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
            CreatePage.Location = new Point(6, 6);
            CreatePage.Name = "CreatePage";
            CreatePage.SelectedIndex = 0;
            CreatePage.Size = new Size(1058, 586);
            CreatePage.TabIndex = 0;
            // 
            // TabCreateMain
            // 
            TabCreateMain.Controls.Add(label1);
            TabCreateMain.Location = new Point(4, 24);
            TabCreateMain.Name = "TabCreateMain";
            TabCreateMain.Padding = new Padding(3);
            TabCreateMain.Size = new Size(1050, 558);
            TabCreateMain.TabIndex = 0;
            TabCreateMain.Text = "Início";
            TabCreateMain.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Location = new Point(6, 3);
            label1.Name = "label1";
            label1.Size = new Size(1041, 552);
            label1.TabIndex = 0;
            label1.Text = resources.GetString("label1.Text");
            // 
            // TabCreateList
            // 
            TabCreateList.Controls.Add(TxtCreateListMessage);
            TabCreateList.Controls.Add(BtnCreateList);
            TabCreateList.Controls.Add(BoxCreateListName);
            TabCreateList.Controls.Add(BoxCreateListDescription);
            TabCreateList.Controls.Add(TxtCreateListDescription);
            TabCreateList.Controls.Add(TxtCreatListeName);
            TabCreateList.Location = new Point(4, 24);
            TabCreateList.Name = "TabCreateList";
            TabCreateList.Padding = new Padding(3);
            TabCreateList.Size = new Size(1050, 558);
            TabCreateList.TabIndex = 1;
            TabCreateList.Text = "Nova Lista";
            TabCreateList.UseVisualStyleBackColor = true;
            // 
            // TxtCreateListMessage
            // 
            TxtCreateListMessage.Anchor = AnchorStyles.None;
            TxtCreateListMessage.Location = new Point(57, 255);
            TxtCreateListMessage.Name = "TxtCreateListMessage";
            TxtCreateListMessage.Size = new Size(393, 23);
            TxtCreateListMessage.TabIndex = 5;
            TxtCreateListMessage.Text = "label4";
            // 
            // BtnCreateList
            // 
            BtnCreateList.Anchor = AnchorStyles.None;
            BtnCreateList.Location = new Point(556, 160);
            BtnCreateList.Name = "BtnCreateList";
            BtnCreateList.Size = new Size(71, 67);
            BtnCreateList.TabIndex = 4;
            BtnCreateList.Text = "button1";
            BtnCreateList.UseVisualStyleBackColor = true;
            BtnCreateList.Click += BtnCreateList_Click;
            // 
            // BoxCreateListName
            // 
            BoxCreateListName.Anchor = AnchorStyles.None;
            BoxCreateListName.Location = new Point(57, 124);
            BoxCreateListName.Name = "BoxCreateListName";
            BoxCreateListName.Size = new Size(393, 23);
            BoxCreateListName.TabIndex = 3;
            // 
            // BoxCreateListDescription
            // 
            BoxCreateListDescription.Anchor = AnchorStyles.None;
            BoxCreateListDescription.Location = new Point(57, 212);
            BoxCreateListDescription.Name = "BoxCreateListDescription";
            BoxCreateListDescription.Size = new Size(393, 23);
            BoxCreateListDescription.TabIndex = 2;
            // 
            // TxtCreateListDescription
            // 
            TxtCreateListDescription.Anchor = AnchorStyles.None;
            TxtCreateListDescription.Location = new Point(57, 186);
            TxtCreateListDescription.Name = "TxtCreateListDescription";
            TxtCreateListDescription.Size = new Size(393, 23);
            TxtCreateListDescription.TabIndex = 1;
            TxtCreateListDescription.Text = "label3";
            // 
            // TxtCreatListeName
            // 
            TxtCreatListeName.Anchor = AnchorStyles.None;
            TxtCreatListeName.Location = new Point(57, 98);
            TxtCreatListeName.Name = "TxtCreatListeName";
            TxtCreatListeName.Size = new Size(393, 23);
            TxtCreatListeName.TabIndex = 0;
            TxtCreatListeName.Text = "label2";
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
            TabCreateCompany.Size = new Size(1050, 558);
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
            TabCreateCards.Location = new Point(4, 24);
            TabCreateCards.Name = "TabCreateCards";
            TabCreateCards.Padding = new Padding(3);
            TabCreateCards.Size = new Size(1050, 558);
            TabCreateCards.TabIndex = 3;
            TabCreateCards.Text = "Novas Cartelas";
            TabCreateCards.UseVisualStyleBackColor = true;
            // 
            // TabEditPage
            // 
            TabEditPage.Controls.Add(EditPage);
            TabEditPage.Location = new Point(4, 24);
            TabEditPage.Name = "TabEditPage";
            TabEditPage.Padding = new Padding(3);
            TabEditPage.Size = new Size(1070, 598);
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
            EditPage.Location = new Point(6, 6);
            EditPage.Name = "EditPage";
            EditPage.SelectedIndex = 0;
            EditPage.Size = new Size(1058, 589);
            EditPage.TabIndex = 0;
            // 
            // TabEditMain
            // 
            TabEditMain.Location = new Point(4, 24);
            TabEditMain.Name = "TabEditMain";
            TabEditMain.Padding = new Padding(3);
            TabEditMain.Size = new Size(1050, 561);
            TabEditMain.TabIndex = 0;
            TabEditMain.Text = "Início";
            TabEditMain.UseVisualStyleBackColor = true;
            // 
            // TabEditList
            // 
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
            TabEditList.Size = new Size(1050, 561);
            TabEditList.TabIndex = 1;
            TabEditList.Text = "Editar Listas";
            TabEditList.UseVisualStyleBackColor = true;
            // 
            // TxtEditListSel
            // 
            TxtEditListSel.Location = new Point(551, 56);
            TxtEditListSel.Name = "TxtEditListSel";
            TxtEditListSel.Size = new Size(488, 23);
            TxtEditListSel.TabIndex = 7;
            TxtEditListSel.Text = "label8";
            // 
            // TxtEditListAll
            // 
            TxtEditListAll.Location = new Point(11, 56);
            TxtEditListAll.Name = "TxtEditListAll";
            TxtEditListAll.Size = new Size(487, 23);
            TxtEditListAll.TabIndex = 6;
            TxtEditListAll.Text = "label6";
            // 
            // BtnEditRemoveCL
            // 
            BtnEditRemoveCL.Location = new Point(510, 253);
            BtnEditRemoveCL.Name = "BtnEditRemoveCL";
            BtnEditRemoveCL.Size = new Size(30, 30);
            BtnEditRemoveCL.TabIndex = 5;
            BtnEditRemoveCL.Text = "button2";
            BtnEditRemoveCL.UseVisualStyleBackColor = true;
            // 
            // BtnEditAddCL
            // 
            BtnEditAddCL.Location = new Point(510, 194);
            BtnEditAddCL.Name = "BtnEditAddCL";
            BtnEditAddCL.Size = new Size(30, 30);
            BtnEditAddCL.TabIndex = 4;
            BtnEditAddCL.Text = "button1";
            BtnEditAddCL.UseVisualStyleBackColor = true;
            // 
            // CboEditListSel
            // 
            CboEditListSel.FormattingEnabled = true;
            CboEditListSel.Location = new Point(551, 82);
            CboEditListSel.Name = "CboEditListSel";
            CboEditListSel.Size = new Size(488, 23);
            CboEditListSel.TabIndex = 3;
            // 
            // BoxEditFilterCL
            // 
            BoxEditFilterCL.Location = new Point(11, 82);
            BoxEditFilterCL.Name = "BoxEditFilterCL";
            BoxEditFilterCL.Size = new Size(487, 23);
            BoxEditFilterCL.TabIndex = 2;
            BoxEditFilterCL.TextChanged += BoxEditFilterCL_TextChanged;
            // 
            // PnlEditAllCompany
            // 
            PnlEditAllCompany.Anchor = AnchorStyles.None;
            PnlEditAllCompany.AutoScroll = true;
            PnlEditAllCompany.AutoSize = true;
            PnlEditAllCompany.BackColor = Color.Black;
            PnlEditAllCompany.Controls.Add(FlowEditViewAll);
            PnlEditAllCompany.Location = new Point(11, 111);
            PnlEditAllCompany.Name = "PnlEditAllCompany";
            PnlEditAllCompany.Size = new Size(487, 439);
            PnlEditAllCompany.TabIndex = 0;
            // 
            // FlowEditViewAll
            // 
            FlowEditViewAll.BackColor = Color.Gray;
            FlowEditViewAll.Dock = DockStyle.Fill;
            FlowEditViewAll.Location = new Point(0, 0);
            FlowEditViewAll.Name = "FlowEditViewAll";
            FlowEditViewAll.Size = new Size(487, 439);
            FlowEditViewAll.TabIndex = 0;
            // 
            // PnlEditSelList
            // 
            PnlEditSelList.Anchor = AnchorStyles.None;
            PnlEditSelList.AutoScroll = true;
            PnlEditSelList.AutoSize = true;
            PnlEditSelList.BackColor = Color.Black;
            PnlEditSelList.Controls.Add(FlowEditViewSel);
            PnlEditSelList.Location = new Point(551, 111);
            PnlEditSelList.Name = "PnlEditSelList";
            PnlEditSelList.Size = new Size(488, 439);
            PnlEditSelList.TabIndex = 1;
            // 
            // FlowEditViewSel
            // 
            FlowEditViewSel.BackColor = Color.Gray;
            FlowEditViewSel.Dock = DockStyle.Fill;
            FlowEditViewSel.Location = new Point(0, 0);
            FlowEditViewSel.Name = "FlowEditViewSel";
            FlowEditViewSel.Size = new Size(488, 439);
            FlowEditViewSel.TabIndex = 0;
            // 
            // TabEditCompany
            // 
            TabEditCompany.Location = new Point(4, 24);
            TabEditCompany.Name = "TabEditCompany";
            TabEditCompany.Padding = new Padding(3);
            TabEditCompany.Size = new Size(1050, 561);
            TabEditCompany.TabIndex = 2;
            TabEditCompany.Text = "Editar Empresas";
            TabEditCompany.UseVisualStyleBackColor = true;
            // 
            // TabEditCards
            // 
            TabEditCards.Location = new Point(4, 24);
            TabEditCards.Name = "TabEditCards";
            TabEditCards.Padding = new Padding(3);
            TabEditCards.Size = new Size(1050, 561);
            TabEditCards.TabIndex = 3;
            TabEditCards.Text = "Editar Cartelas";
            TabEditCards.UseVisualStyleBackColor = true;
            // 
            // TabPlayPage
            // 
            TabPlayPage.Location = new Point(4, 24);
            TabPlayPage.Name = "TabPlayPage";
            TabPlayPage.Padding = new Padding(3);
            TabPlayPage.Size = new Size(1070, 598);
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
            Text = "Form1";
            MainPage.ResumeLayout(false);
            TabCreatePage.ResumeLayout(false);
            CreatePage.ResumeLayout(false);
            TabCreateMain.ResumeLayout(false);
            TabCreateList.ResumeLayout(false);
            TabCreateList.PerformLayout();
            TabCreateCompany.ResumeLayout(false);
            TabCreateCompany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PicCreateCompanyLogo).EndInit();
            TabEditPage.ResumeLayout(false);
            EditPage.ResumeLayout(false);
            TabEditList.ResumeLayout(false);
            TabEditList.PerformLayout();
            PnlEditAllCompany.ResumeLayout(false);
            PnlEditSelList.ResumeLayout(false);
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
    }
}
