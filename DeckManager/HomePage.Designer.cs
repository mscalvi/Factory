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
            BtnWishlist = new Button();
            BtnLogin = new Button();
            BtnCardFinder = new Button();
            BtnDeckManager = new Button();
            TabFinder = new TabPage();
            PnlFinder = new Panel();
            TxtFinder = new Label();
            FlwFinder = new FlowLayoutPanel();
            BoxFinder = new TextBox();
            TabDecks = new TabPage();
            DecksControl = new TabControl();
            TabFormats = new TabPage();
            PnlDeckManager = new Panel();
            PnlDecks = new Panel();
            PnlDecksList = new Panel();
            FlwDecksList = new FlowLayoutPanel();
            BtnImportDeck = new Button();
            BtnNewDeck = new Button();
            PnlFormat = new Panel();
            BtnClearFilters = new Button();
            PnlPnlFilters = new Panel();
            PnlFlwOwner = new Panel();
            FlwOwnersList = new FlowLayoutPanel();
            PnlFlwFormat = new Panel();
            FlwFormatsList = new FlowLayoutPanel();
            PnlFlwArchetypes = new Panel();
            FlwArchetypesList = new FlowLayoutPanel();
            PnlFlwColors = new Panel();
            FlwColorsList = new FlowLayoutPanel();
            BtnDelFilter = new Button();
            BtnNewFilter = new Button();
            BtnReturn = new Button();
            TabDeckManager = new TabPage();
            PnlDeckModel = new Panel();
            BtnSaveDeck = new Button();
            LblDeckName = new Label();
            PnlCardView = new Panel();
            PnlDeckHelper = new Panel();
            ControlHelper = new TabControl();
            HelpList = new TabPage();
            PnlHelpList = new Panel();
            TblHelpList = new TableLayoutPanel();
            LblOpenList = new Label();
            CboHelpList = new ComboBox();
            Statistics = new TabPage();
            BtnColorChange = new Button();
            BtnArchetypeChange = new Button();
            BtnOwnerChange = new Button();
            LblColor = new Label();
            LblArchetype = new Label();
            LblOwner = new Label();
            CboDeckVersion = new ComboBox();
            PnlDeckReal = new Panel();
            TblDeckReal = new TableLayoutPanel();
            MainControl.SuspendLayout();
            TabHome.SuspendLayout();
            PnlHome.SuspendLayout();
            TabFinder.SuspendLayout();
            PnlFinder.SuspendLayout();
            TabDecks.SuspendLayout();
            DecksControl.SuspendLayout();
            TabFormats.SuspendLayout();
            PnlDeckManager.SuspendLayout();
            PnlDecks.SuspendLayout();
            PnlDecksList.SuspendLayout();
            PnlFormat.SuspendLayout();
            PnlPnlFilters.SuspendLayout();
            PnlFlwOwner.SuspendLayout();
            PnlFlwFormat.SuspendLayout();
            PnlFlwArchetypes.SuspendLayout();
            PnlFlwColors.SuspendLayout();
            TabDeckManager.SuspendLayout();
            PnlDeckModel.SuspendLayout();
            PnlDeckHelper.SuspendLayout();
            ControlHelper.SuspendLayout();
            HelpList.SuspendLayout();
            PnlHelpList.SuspendLayout();
            Statistics.SuspendLayout();
            PnlDeckReal.SuspendLayout();
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
            BtnDeckManager.Click += BtnDeckManager_Click;
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
            PnlFinder.Controls.Add(TxtFinder);
            PnlFinder.Controls.Add(FlwFinder);
            PnlFinder.Controls.Add(BoxFinder);
            PnlFinder.Dock = DockStyle.Fill;
            PnlFinder.Location = new Point(3, 3);
            PnlFinder.Name = "PnlFinder";
            PnlFinder.Size = new Size(1890, 1007);
            PnlFinder.TabIndex = 0;
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
            // DecksControl
            // 
            DecksControl.Controls.Add(TabFormats);
            DecksControl.Controls.Add(TabDeckManager);
            DecksControl.Dock = DockStyle.Fill;
            DecksControl.Location = new Point(3, 3);
            DecksControl.Name = "DecksControl";
            DecksControl.SelectedIndex = 0;
            DecksControl.Size = new Size(1890, 1007);
            DecksControl.TabIndex = 5;
            DecksControl.Enter += DecksControl_Enter;
            // 
            // TabFormats
            // 
            TabFormats.Controls.Add(PnlDeckManager);
            TabFormats.Location = new Point(4, 24);
            TabFormats.Name = "TabFormats";
            TabFormats.Padding = new Padding(3);
            TabFormats.Size = new Size(1882, 979);
            TabFormats.TabIndex = 0;
            TabFormats.Text = "Menu";
            TabFormats.UseVisualStyleBackColor = true;
            // 
            // PnlDeckManager
            // 
            PnlDeckManager.Controls.Add(PnlDecks);
            PnlDeckManager.Controls.Add(PnlFormat);
            PnlDeckManager.Dock = DockStyle.Fill;
            PnlDeckManager.Location = new Point(3, 3);
            PnlDeckManager.Name = "PnlDeckManager";
            PnlDeckManager.Size = new Size(1876, 973);
            PnlDeckManager.TabIndex = 0;
            // 
            // PnlDecks
            // 
            PnlDecks.Controls.Add(PnlDecksList);
            PnlDecks.Controls.Add(BtnImportDeck);
            PnlDecks.Controls.Add(BtnNewDeck);
            PnlDecks.Dock = DockStyle.Fill;
            PnlDecks.Location = new Point(0, 283);
            PnlDecks.Name = "PnlDecks";
            PnlDecks.Size = new Size(1876, 690);
            PnlDecks.TabIndex = 6;
            // 
            // PnlDecksList
            // 
            PnlDecksList.Anchor = AnchorStyles.Top;
            PnlDecksList.AutoScroll = true;
            PnlDecksList.Controls.Add(FlwDecksList);
            PnlDecksList.Location = new Point(258, 6);
            PnlDecksList.Name = "PnlDecksList";
            PnlDecksList.Size = new Size(1611, 681);
            PnlDecksList.TabIndex = 10;
            // 
            // FlwDecksList
            // 
            FlwDecksList.Dock = DockStyle.Fill;
            FlwDecksList.Location = new Point(0, 0);
            FlwDecksList.Name = "FlwDecksList";
            FlwDecksList.Size = new Size(1611, 681);
            FlwDecksList.TabIndex = 0;
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
            BtnNewDeck.Click += BtnNewDeck_Click;
            // 
            // PnlFormat
            // 
            PnlFormat.Controls.Add(BtnClearFilters);
            PnlFormat.Controls.Add(PnlPnlFilters);
            PnlFormat.Controls.Add(BtnDelFilter);
            PnlFormat.Controls.Add(BtnNewFilter);
            PnlFormat.Controls.Add(BtnReturn);
            PnlFormat.Dock = DockStyle.Top;
            PnlFormat.Location = new Point(0, 0);
            PnlFormat.Name = "PnlFormat";
            PnlFormat.Size = new Size(1876, 283);
            PnlFormat.TabIndex = 5;
            // 
            // BtnClearFilters
            // 
            BtnClearFilters.Anchor = AnchorStyles.Top;
            BtnClearFilters.Font = new Font("Segoe UI", 18F);
            BtnClearFilters.Location = new Point(6, 79);
            BtnClearFilters.Name = "BtnClearFilters";
            BtnClearFilters.Size = new Size(246, 54);
            BtnClearFilters.TabIndex = 10;
            BtnClearFilters.Text = "Limpar Filtros";
            BtnClearFilters.UseVisualStyleBackColor = true;
            BtnClearFilters.Click += BtnClearFilters_Click;
            // 
            // PnlPnlFilters
            // 
            PnlPnlFilters.Anchor = AnchorStyles.Top;
            PnlPnlFilters.Controls.Add(PnlFlwOwner);
            PnlPnlFilters.Controls.Add(PnlFlwFormat);
            PnlPnlFilters.Controls.Add(PnlFlwArchetypes);
            PnlPnlFilters.Controls.Add(PnlFlwColors);
            PnlPnlFilters.Location = new Point(258, 3);
            PnlPnlFilters.Name = "PnlPnlFilters";
            PnlPnlFilters.Size = new Size(1611, 274);
            PnlPnlFilters.TabIndex = 9;
            // 
            // PnlFlwOwner
            // 
            PnlFlwOwner.Anchor = AnchorStyles.Top;
            PnlFlwOwner.AutoScroll = true;
            PnlFlwOwner.Controls.Add(FlwOwnersList);
            PnlFlwOwner.Location = new Point(406, 3);
            PnlFlwOwner.Name = "PnlFlwOwner";
            PnlFlwOwner.Size = new Size(395, 271);
            PnlFlwOwner.TabIndex = 9;
            // 
            // FlwOwnersList
            // 
            FlwOwnersList.Dock = DockStyle.Fill;
            FlwOwnersList.Location = new Point(0, 0);
            FlwOwnersList.Name = "FlwOwnersList";
            FlwOwnersList.Size = new Size(395, 271);
            FlwOwnersList.TabIndex = 0;
            // 
            // PnlFlwFormat
            // 
            PnlFlwFormat.Anchor = AnchorStyles.Top;
            PnlFlwFormat.AutoScroll = true;
            PnlFlwFormat.Controls.Add(FlwFormatsList);
            PnlFlwFormat.Location = new Point(3, 3);
            PnlFlwFormat.Name = "PnlFlwFormat";
            PnlFlwFormat.Size = new Size(395, 271);
            PnlFlwFormat.TabIndex = 7;
            // 
            // FlwFormatsList
            // 
            FlwFormatsList.Dock = DockStyle.Fill;
            FlwFormatsList.Location = new Point(0, 0);
            FlwFormatsList.Name = "FlwFormatsList";
            FlwFormatsList.Size = new Size(395, 271);
            FlwFormatsList.TabIndex = 0;
            // 
            // PnlFlwArchetypes
            // 
            PnlFlwArchetypes.Anchor = AnchorStyles.Top;
            PnlFlwArchetypes.AutoScroll = true;
            PnlFlwArchetypes.Controls.Add(FlwArchetypesList);
            PnlFlwArchetypes.Location = new Point(809, 3);
            PnlFlwArchetypes.Name = "PnlFlwArchetypes";
            PnlFlwArchetypes.Size = new Size(395, 271);
            PnlFlwArchetypes.TabIndex = 9;
            // 
            // FlwArchetypesList
            // 
            FlwArchetypesList.Dock = DockStyle.Fill;
            FlwArchetypesList.Location = new Point(0, 0);
            FlwArchetypesList.Name = "FlwArchetypesList";
            FlwArchetypesList.Size = new Size(395, 271);
            FlwArchetypesList.TabIndex = 0;
            // 
            // PnlFlwColors
            // 
            PnlFlwColors.Anchor = AnchorStyles.Top;
            PnlFlwColors.AutoScroll = true;
            PnlFlwColors.Controls.Add(FlwColorsList);
            PnlFlwColors.Location = new Point(1212, 3);
            PnlFlwColors.Name = "PnlFlwColors";
            PnlFlwColors.Size = new Size(395, 271);
            PnlFlwColors.TabIndex = 8;
            // 
            // FlwColorsList
            // 
            FlwColorsList.Dock = DockStyle.Fill;
            FlwColorsList.Location = new Point(0, 0);
            FlwColorsList.Name = "FlwColorsList";
            FlwColorsList.Size = new Size(395, 271);
            FlwColorsList.TabIndex = 0;
            // 
            // BtnDelFilter
            // 
            BtnDelFilter.Anchor = AnchorStyles.Top;
            BtnDelFilter.Font = new Font("Segoe UI", 18F);
            BtnDelFilter.Location = new Point(6, 219);
            BtnDelFilter.Name = "BtnDelFilter";
            BtnDelFilter.Size = new Size(246, 54);
            BtnDelFilter.TabIndex = 6;
            BtnDelFilter.Text = "Deletar Filtro";
            BtnDelFilter.UseVisualStyleBackColor = true;
            BtnDelFilter.Click += BtnDelFilter_Click;
            // 
            // BtnNewFilter
            // 
            BtnNewFilter.Anchor = AnchorStyles.Top;
            BtnNewFilter.Font = new Font("Segoe UI", 18F);
            BtnNewFilter.Location = new Point(6, 149);
            BtnNewFilter.Name = "BtnNewFilter";
            BtnNewFilter.Size = new Size(246, 54);
            BtnNewFilter.TabIndex = 0;
            BtnNewFilter.Text = "Novo Filtro";
            BtnNewFilter.UseVisualStyleBackColor = true;
            BtnNewFilter.Click += BtnNewFilter_Click;
            // 
            // BtnReturn
            // 
            BtnReturn.Anchor = AnchorStyles.Top;
            BtnReturn.Font = new Font("Segoe UI", 18F);
            BtnReturn.Location = new Point(6, 9);
            BtnReturn.Name = "BtnReturn";
            BtnReturn.Size = new Size(246, 54);
            BtnReturn.TabIndex = 5;
            BtnReturn.Text = "Voltar";
            BtnReturn.UseVisualStyleBackColor = true;
            BtnReturn.Click += BtnReturn_Click;
            // 
            // TabDeckManager
            // 
            TabDeckManager.Controls.Add(PnlDeckModel);
            TabDeckManager.Location = new Point(4, 24);
            TabDeckManager.Name = "TabDeckManager";
            TabDeckManager.Padding = new Padding(3);
            TabDeckManager.Size = new Size(1882, 979);
            TabDeckManager.TabIndex = 1;
            TabDeckManager.Text = "Model";
            TabDeckManager.UseVisualStyleBackColor = true;
            // 
            // PnlDeckModel
            // 
            PnlDeckModel.Controls.Add(BtnSaveDeck);
            PnlDeckModel.Controls.Add(LblDeckName);
            PnlDeckModel.Controls.Add(PnlCardView);
            PnlDeckModel.Controls.Add(PnlDeckHelper);
            PnlDeckModel.Controls.Add(CboDeckVersion);
            PnlDeckModel.Controls.Add(PnlDeckReal);
            PnlDeckModel.Dock = DockStyle.Fill;
            PnlDeckModel.Location = new Point(3, 3);
            PnlDeckModel.Name = "PnlDeckModel";
            PnlDeckModel.Size = new Size(1876, 973);
            PnlDeckModel.TabIndex = 4;
            // 
            // BtnSaveDeck
            // 
            BtnSaveDeck.Anchor = AnchorStyles.Top;
            BtnSaveDeck.Location = new Point(5, 6);
            BtnSaveDeck.Name = "BtnSaveDeck";
            BtnSaveDeck.Size = new Size(61, 43);
            BtnSaveDeck.TabIndex = 9;
            BtnSaveDeck.Text = "Save";
            BtnSaveDeck.UseVisualStyleBackColor = true;
            // 
            // LblDeckName
            // 
            LblDeckName.Anchor = AnchorStyles.Top;
            LblDeckName.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblDeckName.Location = new Point(5, 6);
            LblDeckName.Name = "LblDeckName";
            LblDeckName.Size = new Size(976, 43);
            LblDeckName.TabIndex = 6;
            LblDeckName.Text = "Deck";
            LblDeckName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PnlCardView
            // 
            PnlCardView.BackColor = Color.Transparent;
            PnlCardView.Location = new Point(987, 496);
            PnlCardView.Name = "PnlCardView";
            PnlCardView.Size = new Size(886, 474);
            PnlCardView.TabIndex = 5;
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
            HelpList.Controls.Add(PnlHelpList);
            HelpList.Controls.Add(LblOpenList);
            HelpList.Controls.Add(CboHelpList);
            HelpList.Location = new Point(4, 24);
            HelpList.Name = "HelpList";
            HelpList.Padding = new Padding(3);
            HelpList.Size = new Size(878, 456);
            HelpList.TabIndex = 0;
            HelpList.Text = "Help List";
            HelpList.UseVisualStyleBackColor = true;
            // 
            // PnlHelpList
            // 
            PnlHelpList.Controls.Add(TblHelpList);
            PnlHelpList.Location = new Point(6, 51);
            PnlHelpList.Name = "PnlHelpList";
            PnlHelpList.Size = new Size(866, 399);
            PnlHelpList.TabIndex = 12;
            // 
            // TblHelpList
            // 
            TblHelpList.AutoScroll = true;
            TblHelpList.ColumnCount = 3;
            TblHelpList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            TblHelpList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            TblHelpList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            TblHelpList.Dock = DockStyle.Fill;
            TblHelpList.Location = new Point(0, 0);
            TblHelpList.Name = "TblHelpList";
            TblHelpList.RowCount = 2;
            TblHelpList.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TblHelpList.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TblHelpList.Size = new Size(866, 399);
            TblHelpList.TabIndex = 11;
            // 
            // LblOpenList
            // 
            LblOpenList.Anchor = AnchorStyles.Top;
            LblOpenList.Location = new Point(425, 6);
            LblOpenList.Name = "LblOpenList";
            LblOpenList.Size = new Size(447, 23);
            LblOpenList.TabIndex = 10;
            LblOpenList.Text = "Open List";
            LblOpenList.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CboHelpList
            // 
            CboHelpList.FormattingEnabled = true;
            CboHelpList.Location = new Point(6, 6);
            CboHelpList.Name = "CboHelpList";
            CboHelpList.Size = new Size(413, 23);
            CboHelpList.TabIndex = 9;
            // 
            // Statistics
            // 
            Statistics.Controls.Add(BtnColorChange);
            Statistics.Controls.Add(BtnArchetypeChange);
            Statistics.Controls.Add(BtnOwnerChange);
            Statistics.Controls.Add(LblColor);
            Statistics.Controls.Add(LblArchetype);
            Statistics.Controls.Add(LblOwner);
            Statistics.Location = new Point(4, 24);
            Statistics.Name = "Statistics";
            Statistics.Padding = new Padding(3);
            Statistics.Size = new Size(878, 456);
            Statistics.TabIndex = 1;
            Statistics.Text = "Estatísticas";
            Statistics.UseVisualStyleBackColor = true;
            // 
            // BtnColorChange
            // 
            BtnColorChange.Anchor = AnchorStyles.Top;
            BtnColorChange.Location = new Point(6, 76);
            BtnColorChange.Name = "BtnColorChange";
            BtnColorChange.Size = new Size(35, 27);
            BtnColorChange.TabIndex = 5;
            BtnColorChange.Text = ">";
            BtnColorChange.UseVisualStyleBackColor = true;
            // 
            // BtnArchetypeChange
            // 
            BtnArchetypeChange.Anchor = AnchorStyles.Top;
            BtnArchetypeChange.Location = new Point(6, 43);
            BtnArchetypeChange.Name = "BtnArchetypeChange";
            BtnArchetypeChange.Size = new Size(35, 27);
            BtnArchetypeChange.TabIndex = 4;
            BtnArchetypeChange.Text = ">";
            BtnArchetypeChange.UseVisualStyleBackColor = true;
            // 
            // BtnOwnerChange
            // 
            BtnOwnerChange.Anchor = AnchorStyles.Top;
            BtnOwnerChange.Location = new Point(6, 10);
            BtnOwnerChange.Name = "BtnOwnerChange";
            BtnOwnerChange.Size = new Size(35, 27);
            BtnOwnerChange.TabIndex = 3;
            BtnOwnerChange.Text = ">";
            BtnOwnerChange.UseVisualStyleBackColor = true;
            // 
            // LblColor
            // 
            LblColor.Anchor = AnchorStyles.Top;
            LblColor.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            LblColor.Location = new Point(47, 76);
            LblColor.Name = "LblColor";
            LblColor.Size = new Size(100, 27);
            LblColor.TabIndex = 2;
            LblColor.Text = "Colors";
            LblColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblArchetype
            // 
            LblArchetype.Anchor = AnchorStyles.Top;
            LblArchetype.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            LblArchetype.Location = new Point(47, 43);
            LblArchetype.Name = "LblArchetype";
            LblArchetype.Size = new Size(100, 27);
            LblArchetype.TabIndex = 1;
            LblArchetype.Text = "Archetype";
            LblArchetype.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblOwner
            // 
            LblOwner.Anchor = AnchorStyles.Top;
            LblOwner.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            LblOwner.Location = new Point(47, 10);
            LblOwner.Name = "LblOwner";
            LblOwner.Size = new Size(100, 27);
            LblOwner.TabIndex = 0;
            LblOwner.Text = "Owner";
            LblOwner.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CboDeckVersion
            // 
            CboDeckVersion.Anchor = AnchorStyles.Top;
            CboDeckVersion.FormattingEnabled = true;
            CboDeckVersion.Location = new Point(5, 52);
            CboDeckVersion.Name = "CboDeckVersion";
            CboDeckVersion.Size = new Size(978, 23);
            CboDeckVersion.TabIndex = 1;
            // 
            // PnlDeckReal
            // 
            PnlDeckReal.Anchor = AnchorStyles.Top;
            PnlDeckReal.BackColor = Color.DimGray;
            PnlDeckReal.Controls.Add(TblDeckReal);
            PnlDeckReal.Location = new Point(5, 81);
            PnlDeckReal.Name = "PnlDeckReal";
            PnlDeckReal.Size = new Size(976, 889);
            PnlDeckReal.TabIndex = 0;
            // 
            // TblDeckReal
            // 
            TblDeckReal.AutoScroll = true;
            TblDeckReal.ColumnCount = 2;
            TblDeckReal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TblDeckReal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TblDeckReal.Dock = DockStyle.Fill;
            TblDeckReal.Location = new Point(0, 0);
            TblDeckReal.Name = "TblDeckReal";
            TblDeckReal.RowCount = 2;
            TblDeckReal.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TblDeckReal.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TblDeckReal.Size = new Size(976, 889);
            TblDeckReal.TabIndex = 0;
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
            DecksControl.ResumeLayout(false);
            TabFormats.ResumeLayout(false);
            PnlDeckManager.ResumeLayout(false);
            PnlDecks.ResumeLayout(false);
            PnlDecksList.ResumeLayout(false);
            PnlFormat.ResumeLayout(false);
            PnlPnlFilters.ResumeLayout(false);
            PnlFlwOwner.ResumeLayout(false);
            PnlFlwFormat.ResumeLayout(false);
            PnlFlwArchetypes.ResumeLayout(false);
            PnlFlwColors.ResumeLayout(false);
            TabDeckManager.ResumeLayout(false);
            PnlDeckModel.ResumeLayout(false);
            PnlDeckHelper.ResumeLayout(false);
            ControlHelper.ResumeLayout(false);
            HelpList.ResumeLayout(false);
            PnlHelpList.ResumeLayout(false);
            Statistics.ResumeLayout(false);
            PnlDeckReal.ResumeLayout(false);
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
        private TabPage TabDecks;
        private Button BtnDeckManager;
        private Panel PnlHome;
        private Button BtnWishlist;
        private Button BtnCardFinder;
        private Button BtnLogin;
        private Panel PnlDeckManager;
        private Button BtnNewDeck;
        private Button BtnImportDeck;
        private Button BtnNewFilter;
        private TabControl DecksControl;
        private TabPage TabFormats;
        private TabPage TabDeckManager;
        private Panel PnlFormat;
        private Panel PnlDecks;
        private Button BtnReturn;
        private ComboBox CboDeckIdeal;
        private ComboBox CboDeckVersion;
        private Panel PnlDeckReal;
        private Panel PnlDeckModel;
        private Panel PnlDeckHelper;
        private Panel PnlCardView;
        private TabControl ControlHelper;
        private TabPage HelpList;
        private TabPage Statistics;
        private Button BtnDelFilter;
        private Panel PnlFlwFormat;
        private Panel PnlDecksList;
        private FlowLayoutPanel FlwDecksList;
        private Panel PnlPnlFilters;
        private Panel PnlFlwArchetypes;
        private Panel PnlFlwColors;
        private Panel PnlFlwOwner;
        private FlowLayoutPanel FlwFormatsList;
        private FlowLayoutPanel FlwOwnersList;
        private FlowLayoutPanel FlwArchetypesList;
        private FlowLayoutPanel FlwColorsList;
        private Button BtnClearFilters;
        private Label LblDeckName;
        private Button BtnSaveIdeal;
        private Button BtnSaveDeck;
        private ComboBox CboHelpList;
        private Label LblColor;
        private Label LblArchetype;
        private Label LblOwner;
        private Button BtnColorChange;
        private Button BtnArchetypeChange;
        private Button BtnOwnerChange;
        private Label LblOpenList;
        private TableLayoutPanel TblDeckReal;
        private TableLayoutPanel TblHelpList;
        private Panel PnlHelpList;
    }
}
