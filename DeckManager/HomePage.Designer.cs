namespace DeckManager
{
    partial class HomePage
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
            MainControl = new TabControl();
            TabHome = new TabPage();
            PnlHome = new Panel();
            BtnLogin = new Button();
            BtnWishlist = new Button();
            BtnCardFinder = new Button();
            BtnDeckManager = new Button();
            TabFinder = new TabPage();
            PnlFinder = new Panel();
            BtnFinder = new Button();
            TxtFinder = new Label();
            FlwFinder = new FlowLayoutPanel();
            BoxFinder = new TextBox();
            TabDecks = new TabPage();
            PnlDeckManager = new Panel();
            BtnNewCategory = new Button();
            BtnImportDeck = new Button();
            BtnNewDeck = new Button();
            FlwCategoryList = new FlowLayoutPanel();
            DecksControl = new TabControl();
            TabCategory = new TabPage();
            TabDeckManager = new TabPage();
            PnlCategory = new Panel();
            PnlDecksLists = new Panel();
            CboTag1 = new ComboBox();
            LblTag1 = new Label();
            LblTag2 = new Label();
            CboTag2 = new ComboBox();
            LblTag3 = new Label();
            CboTag3 = new ComboBox();
            FlwDecksList = new FlowLayoutPanel();
            BtnReturn = new Button();
            PnlDeckReal = new Panel();
            CboDeckReal = new ComboBox();
            CboDeckIdeal = new ComboBox();
            PnlDeckIdeal = new Panel();
            PnlDeckModel = new Panel();
            FlwDeckReal = new FlowLayoutPanel();
            FlwDeckIdeal = new FlowLayoutPanel();
            PnlDeckHelper = new Panel();
            PnlCardView = new Panel();
            ControlHelper = new TabControl();
            HelpList = new TabPage();
            Statistics = new TabPage();
            MainControl.SuspendLayout();
            TabHome.SuspendLayout();
            PnlHome.SuspendLayout();
            TabFinder.SuspendLayout();
            PnlFinder.SuspendLayout();
            TabDecks.SuspendLayout();
            PnlDeckManager.SuspendLayout();
            DecksControl.SuspendLayout();
            TabCategory.SuspendLayout();
            TabDeckManager.SuspendLayout();
            PnlCategory.SuspendLayout();
            PnlDecksLists.SuspendLayout();
            PnlDeckReal.SuspendLayout();
            PnlDeckIdeal.SuspendLayout();
            PnlDeckModel.SuspendLayout();
            PnlDeckHelper.SuspendLayout();
            ControlHelper.SuspendLayout();
            SuspendLayout();
            // 
            // MainControl
            // 
            MainControl.Controls.Add(TabHome);
            MainControl.Controls.Add(TabFinder);
            MainControl.Controls.Add(TabDecks);
            MainControl.Dock = DockStyle.Fill;
            MainControl.Location = new Point(0, 0);
            MainControl.Name = "MainControl";
            MainControl.SelectedIndex = 0;
            MainControl.Size = new Size(1904, 1041);
            MainControl.TabIndex = 0;
            // 
            // TabHome
            // 
            TabHome.Controls.Add(PnlHome);
            TabHome.Location = new Point(4, 24);
            TabHome.Name = "TabHome";
            TabHome.Padding = new Padding(3);
            TabHome.Size = new Size(1896, 1013);
            TabHome.TabIndex = 0;
            TabHome.Text = "Home";
            TabHome.UseVisualStyleBackColor = true;
            // 
            // PnlHome
            // 
            PnlHome.Controls.Add(BtnWishlist);
            PnlHome.Controls.Add(BtnLogin);
            PnlHome.Controls.Add(BtnCardFinder);
            PnlHome.Controls.Add(BtnDeckManager);
            PnlHome.Dock = DockStyle.Fill;
            PnlHome.Location = new Point(3, 3);
            PnlHome.Name = "PnlHome";
            PnlHome.Size = new Size(1890, 1007);
            PnlHome.TabIndex = 1;
            // 
            // BtnLogin
            // 
            BtnLogin.Anchor = AnchorStyles.Top;
            BtnLogin.AutoSize = true;
            BtnLogin.Font = new Font("Segoe UI", 30F);
            BtnLogin.Location = new Point(1019, 561);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(400, 300);
            BtnLogin.TabIndex = 3;
            BtnLogin.Text = "Login";
            BtnLogin.UseVisualStyleBackColor = true;
            // 
            // BtnWishlist
            // 
            BtnWishlist.Anchor = AnchorStyles.Top;
            BtnWishlist.AutoSize = true;
            BtnWishlist.Font = new Font("Segoe UI", 30F);
            BtnWishlist.Location = new Point(1019, 146);
            BtnWishlist.Name = "BtnWishlist";
            BtnWishlist.Size = new Size(400, 300);
            BtnWishlist.TabIndex = 2;
            BtnWishlist.Text = "Wishlist";
            BtnWishlist.UseVisualStyleBackColor = true;
            // 
            // BtnCardFinder
            // 
            BtnCardFinder.Anchor = AnchorStyles.Top;
            BtnCardFinder.AutoSize = true;
            BtnCardFinder.Font = new Font("Segoe UI", 30F);
            BtnCardFinder.Location = new Point(482, 561);
            BtnCardFinder.Name = "BtnCardFinder";
            BtnCardFinder.Size = new Size(400, 300);
            BtnCardFinder.TabIndex = 1;
            BtnCardFinder.Text = "Card Finder";
            BtnCardFinder.UseVisualStyleBackColor = true;
            // 
            // BtnDeckManager
            // 
            BtnDeckManager.Anchor = AnchorStyles.Top;
            BtnDeckManager.AutoSize = true;
            BtnDeckManager.Font = new Font("Segoe UI", 30F);
            BtnDeckManager.Location = new Point(482, 146);
            BtnDeckManager.Name = "BtnDeckManager";
            BtnDeckManager.Size = new Size(400, 300);
            BtnDeckManager.TabIndex = 0;
            BtnDeckManager.Text = "Deck Manager";
            BtnDeckManager.UseVisualStyleBackColor = true;
            // 
            // TabFinder
            // 
            TabFinder.Controls.Add(PnlFinder);
            TabFinder.Location = new Point(4, 24);
            TabFinder.Name = "TabFinder";
            TabFinder.Padding = new Padding(3);
            TabFinder.Size = new Size(1896, 1013);
            TabFinder.TabIndex = 1;
            TabFinder.Text = "Finder";
            TabFinder.UseVisualStyleBackColor = true;
            // 
            // PnlFinder
            // 
            PnlFinder.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PnlFinder.Controls.Add(BtnFinder);
            PnlFinder.Controls.Add(TxtFinder);
            PnlFinder.Controls.Add(FlwFinder);
            PnlFinder.Controls.Add(BoxFinder);
            PnlFinder.Dock = DockStyle.Fill;
            PnlFinder.Location = new Point(3, 3);
            PnlFinder.Name = "PnlFinder";
            PnlFinder.Size = new Size(1890, 1007);
            PnlFinder.TabIndex = 0;
            // 
            // BtnFinder
            // 
            BtnFinder.Location = new Point(908, 160);
            BtnFinder.Name = "BtnFinder";
            BtnFinder.Size = new Size(75, 23);
            BtnFinder.TabIndex = 3;
            BtnFinder.Text = "Procurar";
            BtnFinder.UseVisualStyleBackColor = true;
            BtnFinder.Click += BtnFinder_Click;
            // 
            // TxtFinder
            // 
            TxtFinder.Dock = DockStyle.Top;
            TxtFinder.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtFinder.Location = new Point(0, 0);
            TxtFinder.Name = "TxtFinder";
            TxtFinder.Size = new Size(1890, 128);
            TxtFinder.TabIndex = 2;
            TxtFinder.Text = "Card Finder";
            TxtFinder.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FlwFinder
            // 
            FlwFinder.AutoScroll = true;
            FlwFinder.Dock = DockStyle.Bottom;
            FlwFinder.Location = new Point(0, 201);
            FlwFinder.Name = "FlwFinder";
            FlwFinder.Size = new Size(1890, 806);
            FlwFinder.TabIndex = 1;
            // 
            // BoxFinder
            // 
            BoxFinder.Location = new Point(582, 131);
            BoxFinder.Name = "BoxFinder";
            BoxFinder.Size = new Size(727, 23);
            BoxFinder.TabIndex = 0;
            BoxFinder.TextChanged += BoxFinder_TextChanged;
            // 
            // TabDecks
            // 
            TabDecks.Controls.Add(DecksControl);
            TabDecks.Location = new Point(4, 24);
            TabDecks.Name = "TabDecks";
            TabDecks.Padding = new Padding(3);
            TabDecks.Size = new Size(1896, 1013);
            TabDecks.TabIndex = 2;
            TabDecks.Text = "Decks";
            TabDecks.UseVisualStyleBackColor = true;
            // 
            // PnlDeckManager
            // 
            PnlDeckManager.Controls.Add(PnlDecksLists);
            PnlDeckManager.Controls.Add(PnlCategory);
            PnlDeckManager.Dock = DockStyle.Fill;
            PnlDeckManager.Location = new Point(3, 3);
            PnlDeckManager.Name = "PnlDeckManager";
            PnlDeckManager.Size = new Size(1876, 973);
            PnlDeckManager.TabIndex = 0;
            // 
            // BtnNewCategory
            // 
            BtnNewCategory.Anchor = AnchorStyles.Top;
            BtnNewCategory.Font = new Font("Segoe UI", 18F);
            BtnNewCategory.Location = new Point(3, 144);
            BtnNewCategory.Name = "BtnNewCategory";
            BtnNewCategory.Size = new Size(246, 127);
            BtnNewCategory.TabIndex = 0;
            BtnNewCategory.Text = "Nova Categoria";
            BtnNewCategory.UseVisualStyleBackColor = true;
            // 
            // BtnImportDeck
            // 
            BtnImportDeck.Anchor = AnchorStyles.Top;
            BtnImportDeck.Font = new Font("Segoe UI", 18F);
            BtnImportDeck.Location = new Point(3, 348);
            BtnImportDeck.Name = "BtnImportDeck";
            BtnImportDeck.Size = new Size(246, 160);
            BtnImportDeck.TabIndex = 2;
            BtnImportDeck.Text = "Importar Deck";
            BtnImportDeck.UseVisualStyleBackColor = true;
            // 
            // BtnNewDeck
            // 
            BtnNewDeck.Anchor = AnchorStyles.Top;
            BtnNewDeck.Font = new Font("Segoe UI", 18F);
            BtnNewDeck.Location = new Point(3, 182);
            BtnNewDeck.Name = "BtnNewDeck";
            BtnNewDeck.Size = new Size(246, 160);
            BtnNewDeck.TabIndex = 3;
            BtnNewDeck.Text = "Novo Deck";
            BtnNewDeck.UseVisualStyleBackColor = true;
            // 
            // FlwCategoryList
            // 
            FlwCategoryList.Location = new Point(255, 3);
            FlwCategoryList.Name = "FlwCategoryList";
            FlwCategoryList.Size = new Size(1617, 277);
            FlwCategoryList.TabIndex = 4;
            // 
            // DecksControl
            // 
            DecksControl.Controls.Add(TabCategory);
            DecksControl.Controls.Add(TabDeckManager);
            DecksControl.Dock = DockStyle.Fill;
            DecksControl.Location = new Point(3, 3);
            DecksControl.Name = "DecksControl";
            DecksControl.SelectedIndex = 0;
            DecksControl.Size = new Size(1890, 1007);
            DecksControl.TabIndex = 5;
            // 
            // TabCategory
            // 
            TabCategory.Controls.Add(PnlDeckManager);
            TabCategory.Location = new Point(4, 24);
            TabCategory.Name = "TabCategory";
            TabCategory.Padding = new Padding(3);
            TabCategory.Size = new Size(1882, 979);
            TabCategory.TabIndex = 0;
            TabCategory.Text = "Main";
            TabCategory.UseVisualStyleBackColor = true;
            // 
            // TabDeckManager
            // 
            TabDeckManager.Controls.Add(PnlDeckModel);
            TabDeckManager.Location = new Point(4, 24);
            TabDeckManager.Name = "TabDeckManager";
            TabDeckManager.Padding = new Padding(3);
            TabDeckManager.Size = new Size(1882, 979);
            TabDeckManager.TabIndex = 1;
            TabDeckManager.Text = "Decks";
            TabDeckManager.UseVisualStyleBackColor = true;
            // 
            // PnlCategory
            // 
            PnlCategory.Controls.Add(BtnNewCategory);
            PnlCategory.Controls.Add(BtnReturn);
            PnlCategory.Controls.Add(FlwCategoryList);
            PnlCategory.Dock = DockStyle.Top;
            PnlCategory.Location = new Point(0, 0);
            PnlCategory.Name = "PnlCategory";
            PnlCategory.Size = new Size(1876, 283);
            PnlCategory.TabIndex = 5;
            // 
            // PnlDecksLists
            // 
            PnlDecksLists.Controls.Add(CboTag2);
            PnlDecksLists.Controls.Add(CboTag3);
            PnlDecksLists.Controls.Add(CboTag1);
            PnlDecksLists.Controls.Add(FlwDecksList);
            PnlDecksLists.Controls.Add(LblTag3);
            PnlDecksLists.Controls.Add(LblTag2);
            PnlDecksLists.Controls.Add(LblTag1);
            PnlDecksLists.Controls.Add(BtnImportDeck);
            PnlDecksLists.Controls.Add(BtnNewDeck);
            PnlDecksLists.Dock = DockStyle.Fill;
            PnlDecksLists.Location = new Point(0, 283);
            PnlDecksLists.Name = "PnlDecksLists";
            PnlDecksLists.Size = new Size(1876, 690);
            PnlDecksLists.TabIndex = 6;
            // 
            // CboTag1
            // 
            CboTag1.Anchor = AnchorStyles.Top;
            CboTag1.Font = new Font("Segoe UI", 12F);
            CboTag1.FormattingEnabled = true;
            CboTag1.Location = new Point(319, 9);
            CboTag1.Name = "CboTag1";
            CboTag1.Size = new Size(395, 29);
            CboTag1.TabIndex = 4;
            // 
            // LblTag1
            // 
            LblTag1.Anchor = AnchorStyles.Top;
            LblTag1.Font = new Font("Segoe UI", 12F);
            LblTag1.Location = new Point(255, 6);
            LblTag1.Name = "LblTag1";
            LblTag1.Size = new Size(58, 32);
            LblTag1.TabIndex = 5;
            LblTag1.Text = "Dono:";
            LblTag1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblTag2
            // 
            LblTag2.Anchor = AnchorStyles.Top;
            LblTag2.Font = new Font("Segoe UI", 12F);
            LblTag2.Location = new Point(720, 6);
            LblTag2.Name = "LblTag2";
            LblTag2.Size = new Size(93, 32);
            LblTag2.TabIndex = 7;
            LblTag2.Text = "Arquétipo:";
            LblTag2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CboTag2
            // 
            CboTag2.Anchor = AnchorStyles.Top;
            CboTag2.Font = new Font("Segoe UI", 12F);
            CboTag2.FormattingEnabled = true;
            CboTag2.Location = new Point(819, 9);
            CboTag2.Name = "CboTag2";
            CboTag2.Size = new Size(441, 29);
            CboTag2.TabIndex = 6;
            // 
            // LblTag3
            // 
            LblTag3.Anchor = AnchorStyles.Top;
            LblTag3.Font = new Font("Segoe UI", 12F);
            LblTag3.Location = new Point(1266, 6);
            LblTag3.Name = "LblTag3";
            LblTag3.Size = new Size(53, 32);
            LblTag3.TabIndex = 9;
            LblTag3.Text = "Cores:";
            LblTag3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CboTag3
            // 
            CboTag3.Anchor = AnchorStyles.Top;
            CboTag3.Font = new Font("Segoe UI", 12F);
            CboTag3.FormattingEnabled = true;
            CboTag3.Location = new Point(1325, 9);
            CboTag3.Name = "CboTag3";
            CboTag3.Size = new Size(366, 29);
            CboTag3.TabIndex = 8;
            // 
            // FlwDecksList
            // 
            FlwDecksList.Location = new Point(255, 38);
            FlwDecksList.Name = "FlwDecksList";
            FlwDecksList.Size = new Size(1617, 649);
            FlwDecksList.TabIndex = 10;
            // 
            // BtnReturn
            // 
            BtnReturn.Font = new Font("Segoe UI", 18F);
            BtnReturn.Location = new Point(3, 11);
            BtnReturn.Name = "BtnReturn";
            BtnReturn.Size = new Size(246, 127);
            BtnReturn.TabIndex = 5;
            BtnReturn.Text = "Voltar";
            BtnReturn.UseVisualStyleBackColor = true;
            // 
            // PnlDeckReal
            // 
            PnlDeckReal.Anchor = AnchorStyles.Top;
            PnlDeckReal.Controls.Add(FlwDeckReal);
            PnlDeckReal.Location = new Point(3, 35);
            PnlDeckReal.Name = "PnlDeckReal";
            PnlDeckReal.Size = new Size(486, 938);
            PnlDeckReal.TabIndex = 0;
            // 
            // CboDeckReal
            // 
            CboDeckReal.Anchor = AnchorStyles.Top;
            CboDeckReal.FormattingEnabled = true;
            CboDeckReal.Location = new Point(3, 6);
            CboDeckReal.Name = "CboDeckReal";
            CboDeckReal.Size = new Size(486, 23);
            CboDeckReal.TabIndex = 1;
            // 
            // CboDeckIdeal
            // 
            CboDeckIdeal.Anchor = AnchorStyles.Top;
            CboDeckIdeal.FormattingEnabled = true;
            CboDeckIdeal.Location = new Point(495, 6);
            CboDeckIdeal.Name = "CboDeckIdeal";
            CboDeckIdeal.Size = new Size(486, 23);
            CboDeckIdeal.TabIndex = 3;
            // 
            // PnlDeckIdeal
            // 
            PnlDeckIdeal.Anchor = AnchorStyles.Top;
            PnlDeckIdeal.Controls.Add(FlwDeckIdeal);
            PnlDeckIdeal.Location = new Point(495, 35);
            PnlDeckIdeal.Name = "PnlDeckIdeal";
            PnlDeckIdeal.Size = new Size(486, 938);
            PnlDeckIdeal.TabIndex = 2;
            // 
            // PnlDeckModel
            // 
            PnlDeckModel.Controls.Add(PnlCardView);
            PnlDeckModel.Controls.Add(PnlDeckHelper);
            PnlDeckModel.Controls.Add(CboDeckIdeal);
            PnlDeckModel.Controls.Add(CboDeckReal);
            PnlDeckModel.Controls.Add(PnlDeckReal);
            PnlDeckModel.Controls.Add(PnlDeckIdeal);
            PnlDeckModel.Dock = DockStyle.Fill;
            PnlDeckModel.Location = new Point(3, 3);
            PnlDeckModel.Name = "PnlDeckModel";
            PnlDeckModel.Size = new Size(1876, 973);
            PnlDeckModel.TabIndex = 4;
            // 
            // FlwDeckReal
            // 
            FlwDeckReal.Dock = DockStyle.Fill;
            FlwDeckReal.Location = new Point(0, 0);
            FlwDeckReal.Name = "FlwDeckReal";
            FlwDeckReal.Size = new Size(486, 938);
            FlwDeckReal.TabIndex = 0;
            // 
            // FlwDeckIdeal
            // 
            FlwDeckIdeal.Dock = DockStyle.Fill;
            FlwDeckIdeal.Location = new Point(0, 0);
            FlwDeckIdeal.Name = "FlwDeckIdeal";
            FlwDeckIdeal.Size = new Size(486, 938);
            FlwDeckIdeal.TabIndex = 0;
            // 
            // PnlDeckHelper
            // 
            PnlDeckHelper.Anchor = AnchorStyles.Top;
            PnlDeckHelper.Controls.Add(ControlHelper);
            PnlDeckHelper.Location = new Point(987, 6);
            PnlDeckHelper.Name = "PnlDeckHelper";
            PnlDeckHelper.Size = new Size(886, 484);
            PnlDeckHelper.TabIndex = 4;
            // 
            // PnlCardView
            // 
            PnlCardView.Location = new Point(987, 496);
            PnlCardView.Name = "PnlCardView";
            PnlCardView.Size = new Size(886, 474);
            PnlCardView.TabIndex = 5;
            // 
            // ControlHelper
            // 
            ControlHelper.Controls.Add(HelpList);
            ControlHelper.Controls.Add(Statistics);
            ControlHelper.Dock = DockStyle.Fill;
            ControlHelper.Location = new Point(0, 0);
            ControlHelper.Name = "ControlHelper";
            ControlHelper.SelectedIndex = 0;
            ControlHelper.Size = new Size(886, 484);
            ControlHelper.TabIndex = 0;
            // 
            // HelpList
            // 
            HelpList.Location = new Point(4, 24);
            HelpList.Name = "HelpList";
            HelpList.Padding = new Padding(3);
            HelpList.Size = new Size(878, 456);
            HelpList.TabIndex = 0;
            HelpList.Text = "Help List";
            HelpList.UseVisualStyleBackColor = true;
            // 
            // Statistics
            // 
            Statistics.Location = new Point(4, 24);
            Statistics.Name = "Statistics";
            Statistics.Padding = new Padding(3);
            Statistics.Size = new Size(878, 456);
            Statistics.TabIndex = 1;
            Statistics.Text = "Estatísticas";
            Statistics.UseVisualStyleBackColor = true;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(MainControl);
            Name = "HomePage";
            Text = "Deck Manager";
            WindowState = FormWindowState.Maximized;
            MainControl.ResumeLayout(false);
            TabHome.ResumeLayout(false);
            PnlHome.ResumeLayout(false);
            PnlHome.PerformLayout();
            TabFinder.ResumeLayout(false);
            PnlFinder.ResumeLayout(false);
            PnlFinder.PerformLayout();
            TabDecks.ResumeLayout(false);
            PnlDeckManager.ResumeLayout(false);
            DecksControl.ResumeLayout(false);
            TabCategory.ResumeLayout(false);
            TabDeckManager.ResumeLayout(false);
            PnlCategory.ResumeLayout(false);
            PnlDecksLists.ResumeLayout(false);
            PnlDeckReal.ResumeLayout(false);
            PnlDeckIdeal.ResumeLayout(false);
            PnlDeckModel.ResumeLayout(false);
            PnlDeckHelper.ResumeLayout(false);
            ControlHelper.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl MainControl;
        private TabPage TabHome;
        private TabPage TabFinder;
        private Panel PnlFinder;
        private Label TxtFinder;
        private FlowLayoutPanel FlwFinder;
        private TextBox BoxFinder;
        private Button BtnFinder;
        private TabPage TabDecks;
        private Button BtnDeckManager;
        private Panel PnlHome;
        private Button BtnWishlist;
        private Button BtnCardFinder;
        private Button BtnLogin;
        private Panel PnlDeckManager;
        private Button BtnNewDeck;
        private Button BtnImportDeck;
        private Button BtnNewCategory;
        private FlowLayoutPanel FlwCategoryList;
        private TabControl DecksControl;
        private TabPage TabCategory;
        private TabPage TabDeckManager;
        private Panel PnlCategory;
        private Panel PnlDecksLists;
        private Label LblTag3;
        private ComboBox CboTag3;
        private Label LblTag2;
        private ComboBox CboTag2;
        private Label LblTag1;
        private ComboBox CboTag1;
        private FlowLayoutPanel FlwDecksList;
        private Button BtnReturn;
        private ComboBox CboDeckIdeal;
        private Panel PnlDeckIdeal;
        private ComboBox CboDeckReal;
        private Panel PnlDeckReal;
        private Panel PnlDeckModel;
        private FlowLayoutPanel FlwDeckReal;
        private FlowLayoutPanel FlwDeckIdeal;
        private Panel PnlDeckHelper;
        private Panel PnlCardView;
        private TabControl ControlHelper;
        private TabPage HelpList;
        private TabPage Statistics;
    }
}
