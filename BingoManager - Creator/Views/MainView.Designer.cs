namespace BingoCreator
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
            pnlMainView = new Panel();
            tabControlMain = new TabControl();
            tabCreatePage = new TabPage();
            tabControlCreate = new TabControl();
            tabCreateElement = new TabPage();
            lblElementMessage = new Label();
            lblElementTitle = new Label();
            cboElementList = new ComboBox();
            picElement = new PictureBox();
            btnElementImage = new Button();
            lblElementList = new Label();
            boxelementNote2 = new TextBox();
            boxElementNote1 = new TextBox();
            boxElementCardName = new TextBox();
            boxElementName = new TextBox();
            lblElementImage = new Label();
            lblElementNote2 = new Label();
            lblElementNote1 = new Label();
            lblElementCardName = new Label();
            lblElementName = new Label();
            tabCreateList = new TabPage();
            lblListMessage = new Label();
            picList = new PictureBox();
            btnListImage = new Button();
            lblListImage = new Label();
            boxListDescription = new TextBox();
            boxListName = new TextBox();
            lblListDescription = new Label();
            lblListName = new Label();
            lblListTitle = new Label();
            tabCreateCards = new TabPage();
            boxCardsEnd = new TextBox();
            lblCardsHeader = new Label();
            lblCardsMessage = new Label();
            boxCardsTitle = new TextBox();
            boxCardsName = new TextBox();
            lblCardsTitle = new Label();
            lblCardsName = new Label();
            tabEditPage = new TabPage();
            lblCardsEnd = new Label();
            lblCardsQuant = new Label();
            boxCardsQuant = new TextBox();
            cboCardsList = new ComboBox();
            lblCardsList = new Label();
            btnElementCreate = new Button();
            btnListCreate = new Button();
            btnCardsExport = new Button();
            lblEditHeader = new Label();
            btnEditEdit = new Button();
            lblEditMessage = new Label();
            cboEdit = new ComboBox();
            picEdit = new PictureBox();
            btnEditImage = new Button();
            boxEditText4 = new TextBox();
            boxEditText3 = new TextBox();
            boxEditText2 = new TextBox();
            boxEditText1 = new TextBox();
            lblEditImage = new Label();
            lblEditText4 = new Label();
            lblEditText3 = new Label();
            lblEditText2 = new Label();
            lblEditText1 = new Label();
            flwEditItens = new FlowLayoutPanel();
            btnEditExclude = new Button();
            boxEditText5 = new TextBox();
            lblEditText5 = new Label();
            pnlMainView.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabCreatePage.SuspendLayout();
            tabControlCreate.SuspendLayout();
            tabCreateElement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picElement).BeginInit();
            tabCreateList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picList).BeginInit();
            tabCreateCards.SuspendLayout();
            tabEditPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picEdit).BeginInit();
            SuspendLayout();
            // 
            // pnlMainView
            // 
            pnlMainView.AutoSize = true;
            pnlMainView.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlMainView.Controls.Add(tabControlMain);
            pnlMainView.Dock = DockStyle.Fill;
            pnlMainView.Location = new Point(0, 0);
            pnlMainView.Name = "pnlMainView";
            pnlMainView.Size = new Size(1190, 744);
            pnlMainView.TabIndex = 0;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabCreatePage);
            tabControlMain.Controls.Add(tabEditPage);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Location = new Point(0, 0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(1190, 744);
            tabControlMain.TabIndex = 2;
            // 
            // tabCreatePage
            // 
            tabCreatePage.Controls.Add(tabControlCreate);
            tabCreatePage.Location = new Point(4, 24);
            tabCreatePage.Name = "tabCreatePage";
            tabCreatePage.Padding = new Padding(3);
            tabCreatePage.Size = new Size(1182, 716);
            tabCreatePage.TabIndex = 1;
            tabCreatePage.Text = "CreatePage";
            tabCreatePage.UseVisualStyleBackColor = true;
            // 
            // tabControlCreate
            // 
            tabControlCreate.Controls.Add(tabCreateElement);
            tabControlCreate.Controls.Add(tabCreateList);
            tabControlCreate.Controls.Add(tabCreateCards);
            tabControlCreate.Dock = DockStyle.Fill;
            tabControlCreate.Location = new Point(3, 3);
            tabControlCreate.Name = "tabControlCreate";
            tabControlCreate.SelectedIndex = 0;
            tabControlCreate.Size = new Size(1176, 710);
            tabControlCreate.TabIndex = 0;
            // 
            // tabCreateElement
            // 
            tabCreateElement.Controls.Add(btnElementCreate);
            tabCreateElement.Controls.Add(lblElementMessage);
            tabCreateElement.Controls.Add(lblElementTitle);
            tabCreateElement.Controls.Add(cboElementList);
            tabCreateElement.Controls.Add(picElement);
            tabCreateElement.Controls.Add(btnElementImage);
            tabCreateElement.Controls.Add(lblElementList);
            tabCreateElement.Controls.Add(boxelementNote2);
            tabCreateElement.Controls.Add(boxElementNote1);
            tabCreateElement.Controls.Add(boxElementCardName);
            tabCreateElement.Controls.Add(boxElementName);
            tabCreateElement.Controls.Add(lblElementImage);
            tabCreateElement.Controls.Add(lblElementNote2);
            tabCreateElement.Controls.Add(lblElementNote1);
            tabCreateElement.Controls.Add(lblElementCardName);
            tabCreateElement.Controls.Add(lblElementName);
            tabCreateElement.Location = new Point(4, 24);
            tabCreateElement.Name = "tabCreateElement";
            tabCreateElement.Padding = new Padding(3);
            tabCreateElement.Size = new Size(1168, 682);
            tabCreateElement.TabIndex = 0;
            tabCreateElement.Text = "Element";
            tabCreateElement.UseVisualStyleBackColor = true;
            // 
            // lblElementMessage
            // 
            lblElementMessage.Anchor = AnchorStyles.Top;
            lblElementMessage.Font = new Font("Segoe UI", 12F);
            lblElementMessage.Location = new Point(787, 263);
            lblElementMessage.Name = "lblElementMessage";
            lblElementMessage.Size = new Size(295, 216);
            lblElementMessage.TabIndex = 13;
            lblElementMessage.Text = "Mensagem";
            lblElementMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblElementTitle
            // 
            lblElementTitle.Dock = DockStyle.Top;
            lblElementTitle.Font = new Font("Segoe UI", 16F);
            lblElementTitle.Location = new Point(3, 3);
            lblElementTitle.Name = "lblElementTitle";
            lblElementTitle.Size = new Size(1162, 87);
            lblElementTitle.TabIndex = 12;
            lblElementTitle.Text = "Criar Elemento";
            lblElementTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboElementList
            // 
            cboElementList.FormattingEnabled = true;
            cboElementList.Location = new Point(787, 210);
            cboElementList.Name = "cboElementList";
            cboElementList.Size = new Size(295, 23);
            cboElementList.TabIndex = 5;
            // 
            // picElement
            // 
            picElement.Location = new Point(275, 413);
            picElement.Name = "picElement";
            picElement.Size = new Size(395, 224);
            picElement.TabIndex = 10;
            picElement.TabStop = false;
            // 
            // btnElementImage
            // 
            btnElementImage.Location = new Point(32, 479);
            btnElementImage.Name = "btnElementImage";
            btnElementImage.Size = new Size(165, 48);
            btnElementImage.TabIndex = 6;
            btnElementImage.Text = "Procurar";
            btnElementImage.UseVisualStyleBackColor = true;
            // 
            // lblElementList
            // 
            lblElementList.Anchor = AnchorStyles.Top;
            lblElementList.Font = new Font("Segoe UI", 12F);
            lblElementList.Location = new Point(787, 151);
            lblElementList.Name = "lblElementList";
            lblElementList.Size = new Size(295, 38);
            lblElementList.TabIndex = 8;
            lblElementList.Text = "Lista:";
            lblElementList.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // boxelementNote2
            // 
            boxelementNote2.Anchor = AnchorStyles.Top;
            boxelementNote2.Font = new Font("Segoe UI", 12F);
            boxelementNote2.Location = new Point(275, 348);
            boxelementNote2.Name = "boxelementNote2";
            boxelementNote2.Size = new Size(395, 29);
            boxelementNote2.TabIndex = 4;
            // 
            // boxElementNote1
            // 
            boxElementNote1.Anchor = AnchorStyles.Top;
            boxElementNote1.Font = new Font("Segoe UI", 12F);
            boxElementNote1.Location = new Point(275, 273);
            boxElementNote1.Name = "boxElementNote1";
            boxElementNote1.Size = new Size(395, 29);
            boxElementNote1.TabIndex = 3;
            // 
            // boxElementCardName
            // 
            boxElementCardName.Anchor = AnchorStyles.Top;
            boxElementCardName.Font = new Font("Segoe UI", 12F);
            boxElementCardName.Location = new Point(275, 216);
            boxElementCardName.Name = "boxElementCardName";
            boxElementCardName.Size = new Size(395, 29);
            boxElementCardName.TabIndex = 2;
            // 
            // boxElementName
            // 
            boxElementName.Anchor = AnchorStyles.Top;
            boxElementName.Font = new Font("Segoe UI", 12F);
            boxElementName.Location = new Point(275, 160);
            boxElementName.Name = "boxElementName";
            boxElementName.Size = new Size(395, 29);
            boxElementName.TabIndex = 1;
            // 
            // lblElementImage
            // 
            lblElementImage.Anchor = AnchorStyles.Top;
            lblElementImage.Font = new Font("Segoe UI", 12F);
            lblElementImage.ImageAlign = ContentAlignment.MiddleLeft;
            lblElementImage.Location = new Point(32, 413);
            lblElementImage.Name = "lblElementImage";
            lblElementImage.Size = new Size(237, 38);
            lblElementImage.TabIndex = 4;
            lblElementImage.Text = "Imagem:";
            lblElementImage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblElementNote2
            // 
            lblElementNote2.Anchor = AnchorStyles.Top;
            lblElementNote2.Font = new Font("Segoe UI", 12F);
            lblElementNote2.ImageAlign = ContentAlignment.MiddleLeft;
            lblElementNote2.Location = new Point(32, 342);
            lblElementNote2.Name = "lblElementNote2";
            lblElementNote2.Size = new Size(237, 38);
            lblElementNote2.TabIndex = 3;
            lblElementNote2.Text = "Anotação 2:";
            lblElementNote2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblElementNote1
            // 
            lblElementNote1.Anchor = AnchorStyles.Top;
            lblElementNote1.Font = new Font("Segoe UI", 12F);
            lblElementNote1.ImageAlign = ContentAlignment.MiddleLeft;
            lblElementNote1.Location = new Point(32, 273);
            lblElementNote1.Name = "lblElementNote1";
            lblElementNote1.Size = new Size(237, 38);
            lblElementNote1.TabIndex = 2;
            lblElementNote1.Text = "Anotação 1:";
            lblElementNote1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblElementCardName
            // 
            lblElementCardName.Anchor = AnchorStyles.Top;
            lblElementCardName.Font = new Font("Segoe UI", 12F);
            lblElementCardName.ImageAlign = ContentAlignment.MiddleLeft;
            lblElementCardName.Location = new Point(32, 210);
            lblElementCardName.Name = "lblElementCardName";
            lblElementCardName.Size = new Size(237, 38);
            lblElementCardName.TabIndex = 1;
            lblElementCardName.Text = "Nome para Cartela:";
            lblElementCardName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblElementName
            // 
            lblElementName.Anchor = AnchorStyles.Top;
            lblElementName.Font = new Font("Segoe UI", 12F);
            lblElementName.ImageAlign = ContentAlignment.MiddleLeft;
            lblElementName.Location = new Point(32, 151);
            lblElementName.Name = "lblElementName";
            lblElementName.Size = new Size(237, 38);
            lblElementName.TabIndex = 0;
            lblElementName.Text = "Nome:";
            lblElementName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tabCreateList
            // 
            tabCreateList.Controls.Add(btnListCreate);
            tabCreateList.Controls.Add(lblListMessage);
            tabCreateList.Controls.Add(picList);
            tabCreateList.Controls.Add(btnListImage);
            tabCreateList.Controls.Add(lblListImage);
            tabCreateList.Controls.Add(boxListDescription);
            tabCreateList.Controls.Add(boxListName);
            tabCreateList.Controls.Add(lblListDescription);
            tabCreateList.Controls.Add(lblListName);
            tabCreateList.Controls.Add(lblListTitle);
            tabCreateList.Location = new Point(4, 24);
            tabCreateList.Name = "tabCreateList";
            tabCreateList.Padding = new Padding(3);
            tabCreateList.Size = new Size(1168, 682);
            tabCreateList.TabIndex = 1;
            tabCreateList.Text = "List";
            tabCreateList.UseVisualStyleBackColor = true;
            // 
            // lblListMessage
            // 
            lblListMessage.Anchor = AnchorStyles.Top;
            lblListMessage.Font = new Font("Segoe UI", 12F);
            lblListMessage.Location = new Point(817, 172);
            lblListMessage.Name = "lblListMessage";
            lblListMessage.Size = new Size(295, 289);
            lblListMessage.TabIndex = 21;
            lblListMessage.Text = "Mensagem";
            lblListMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picList
            // 
            picList.Location = new Point(290, 398);
            picList.Name = "picList";
            picList.Size = new Size(395, 224);
            picList.TabIndex = 20;
            picList.TabStop = false;
            // 
            // btnListImage
            // 
            btnListImage.Location = new Point(47, 464);
            btnListImage.Name = "btnListImage";
            btnListImage.Size = new Size(165, 48);
            btnListImage.TabIndex = 19;
            btnListImage.Text = "Procurar";
            btnListImage.UseVisualStyleBackColor = true;
            // 
            // lblListImage
            // 
            lblListImage.Anchor = AnchorStyles.Top;
            lblListImage.Font = new Font("Segoe UI", 12F);
            lblListImage.ImageAlign = ContentAlignment.MiddleLeft;
            lblListImage.Location = new Point(47, 398);
            lblListImage.Name = "lblListImage";
            lblListImage.Size = new Size(237, 38);
            lblListImage.TabIndex = 18;
            lblListImage.Text = "Imagem:";
            lblListImage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // boxListDescription
            // 
            boxListDescription.Anchor = AnchorStyles.Top;
            boxListDescription.Font = new Font("Segoe UI", 12F);
            boxListDescription.Location = new Point(290, 237);
            boxListDescription.Name = "boxListDescription";
            boxListDescription.Size = new Size(395, 29);
            boxListDescription.TabIndex = 17;
            // 
            // boxListName
            // 
            boxListName.Anchor = AnchorStyles.Top;
            boxListName.Font = new Font("Segoe UI", 12F);
            boxListName.Location = new Point(290, 181);
            boxListName.Name = "boxListName";
            boxListName.Size = new Size(395, 29);
            boxListName.TabIndex = 15;
            // 
            // lblListDescription
            // 
            lblListDescription.Anchor = AnchorStyles.Top;
            lblListDescription.Font = new Font("Segoe UI", 12F);
            lblListDescription.ImageAlign = ContentAlignment.MiddleLeft;
            lblListDescription.Location = new Point(47, 231);
            lblListDescription.Name = "lblListDescription";
            lblListDescription.Size = new Size(237, 38);
            lblListDescription.TabIndex = 16;
            lblListDescription.Text = "Descrição:";
            lblListDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblListName
            // 
            lblListName.Anchor = AnchorStyles.Top;
            lblListName.Font = new Font("Segoe UI", 12F);
            lblListName.ImageAlign = ContentAlignment.MiddleLeft;
            lblListName.Location = new Point(47, 172);
            lblListName.Name = "lblListName";
            lblListName.Size = new Size(237, 38);
            lblListName.TabIndex = 14;
            lblListName.Text = "Nome:";
            lblListName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblListTitle
            // 
            lblListTitle.Dock = DockStyle.Top;
            lblListTitle.Font = new Font("Segoe UI", 16F);
            lblListTitle.Location = new Point(3, 3);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(1162, 87);
            lblListTitle.TabIndex = 13;
            lblListTitle.Text = "Criar Lista";
            lblListTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabCreateCards
            // 
            tabCreateCards.Controls.Add(btnCardsExport);
            tabCreateCards.Controls.Add(lblCardsList);
            tabCreateCards.Controls.Add(cboCardsList);
            tabCreateCards.Controls.Add(lblCardsQuant);
            tabCreateCards.Controls.Add(boxCardsQuant);
            tabCreateCards.Controls.Add(lblCardsEnd);
            tabCreateCards.Controls.Add(boxCardsEnd);
            tabCreateCards.Controls.Add(lblCardsHeader);
            tabCreateCards.Controls.Add(lblCardsMessage);
            tabCreateCards.Controls.Add(boxCardsTitle);
            tabCreateCards.Controls.Add(boxCardsName);
            tabCreateCards.Controls.Add(lblCardsTitle);
            tabCreateCards.Controls.Add(lblCardsName);
            tabCreateCards.Location = new Point(4, 24);
            tabCreateCards.Name = "tabCreateCards";
            tabCreateCards.Size = new Size(1168, 682);
            tabCreateCards.TabIndex = 2;
            tabCreateCards.Text = "Cards";
            tabCreateCards.UseVisualStyleBackColor = true;
            // 
            // boxCardsEnd
            // 
            boxCardsEnd.Anchor = AnchorStyles.Top;
            boxCardsEnd.Font = new Font("Segoe UI", 12F);
            boxCardsEnd.Location = new Point(310, 319);
            boxCardsEnd.Name = "boxCardsEnd";
            boxCardsEnd.Size = new Size(395, 29);
            boxCardsEnd.TabIndex = 28;
            // 
            // lblCardsHeader
            // 
            lblCardsHeader.Dock = DockStyle.Top;
            lblCardsHeader.Font = new Font("Segoe UI", 16F);
            lblCardsHeader.Location = new Point(0, 0);
            lblCardsHeader.Name = "lblCardsHeader";
            lblCardsHeader.Size = new Size(1168, 87);
            lblCardsHeader.TabIndex = 27;
            lblCardsHeader.Text = "Criar Cartelas";
            lblCardsHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCardsMessage
            // 
            lblCardsMessage.Anchor = AnchorStyles.Top;
            lblCardsMessage.Font = new Font("Segoe UI", 12F);
            lblCardsMessage.Location = new Point(819, 185);
            lblCardsMessage.Name = "lblCardsMessage";
            lblCardsMessage.Size = new Size(295, 305);
            lblCardsMessage.TabIndex = 26;
            lblCardsMessage.Text = "Mensagem";
            lblCardsMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // boxCardsTitle
            // 
            boxCardsTitle.Anchor = AnchorStyles.Top;
            boxCardsTitle.Font = new Font("Segoe UI", 12F);
            boxCardsTitle.Location = new Point(310, 250);
            boxCardsTitle.Name = "boxCardsTitle";
            boxCardsTitle.Size = new Size(395, 29);
            boxCardsTitle.TabIndex = 25;
            // 
            // boxCardsName
            // 
            boxCardsName.Anchor = AnchorStyles.Top;
            boxCardsName.Font = new Font("Segoe UI", 12F);
            boxCardsName.Location = new Point(310, 194);
            boxCardsName.Name = "boxCardsName";
            boxCardsName.Size = new Size(395, 29);
            boxCardsName.TabIndex = 23;
            // 
            // lblCardsTitle
            // 
            lblCardsTitle.Anchor = AnchorStyles.Top;
            lblCardsTitle.Font = new Font("Segoe UI", 12F);
            lblCardsTitle.ImageAlign = ContentAlignment.MiddleLeft;
            lblCardsTitle.Location = new Point(67, 244);
            lblCardsTitle.Name = "lblCardsTitle";
            lblCardsTitle.Size = new Size(237, 38);
            lblCardsTitle.TabIndex = 24;
            lblCardsTitle.Text = "Título para Cartela:";
            lblCardsTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCardsName
            // 
            lblCardsName.Anchor = AnchorStyles.Top;
            lblCardsName.Font = new Font("Segoe UI", 12F);
            lblCardsName.ImageAlign = ContentAlignment.MiddleLeft;
            lblCardsName.Location = new Point(67, 185);
            lblCardsName.Name = "lblCardsName";
            lblCardsName.Size = new Size(237, 38);
            lblCardsName.TabIndex = 22;
            lblCardsName.Text = "Nome do Conjunto:";
            lblCardsName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tabEditPage
            // 
            tabEditPage.Controls.Add(boxEditText5);
            tabEditPage.Controls.Add(lblEditText5);
            tabEditPage.Controls.Add(btnEditExclude);
            tabEditPage.Controls.Add(flwEditItens);
            tabEditPage.Controls.Add(btnEditEdit);
            tabEditPage.Controls.Add(lblEditMessage);
            tabEditPage.Controls.Add(cboEdit);
            tabEditPage.Controls.Add(picEdit);
            tabEditPage.Controls.Add(btnEditImage);
            tabEditPage.Controls.Add(boxEditText4);
            tabEditPage.Controls.Add(boxEditText3);
            tabEditPage.Controls.Add(boxEditText2);
            tabEditPage.Controls.Add(boxEditText1);
            tabEditPage.Controls.Add(lblEditImage);
            tabEditPage.Controls.Add(lblEditText4);
            tabEditPage.Controls.Add(lblEditText3);
            tabEditPage.Controls.Add(lblEditText2);
            tabEditPage.Controls.Add(lblEditText1);
            tabEditPage.Controls.Add(lblEditHeader);
            tabEditPage.Location = new Point(4, 24);
            tabEditPage.Name = "tabEditPage";
            tabEditPage.Size = new Size(1182, 716);
            tabEditPage.TabIndex = 2;
            tabEditPage.Text = "EditPage";
            tabEditPage.UseVisualStyleBackColor = true;
            // 
            // lblCardsEnd
            // 
            lblCardsEnd.Anchor = AnchorStyles.Top;
            lblCardsEnd.Font = new Font("Segoe UI", 12F);
            lblCardsEnd.ImageAlign = ContentAlignment.MiddleLeft;
            lblCardsEnd.Location = new Point(67, 313);
            lblCardsEnd.Name = "lblCardsEnd";
            lblCardsEnd.Size = new Size(237, 38);
            lblCardsEnd.TabIndex = 29;
            lblCardsEnd.Text = "Mensagem Final:";
            lblCardsEnd.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCardsQuant
            // 
            lblCardsQuant.Anchor = AnchorStyles.Top;
            lblCardsQuant.Font = new Font("Segoe UI", 12F);
            lblCardsQuant.ImageAlign = ContentAlignment.MiddleLeft;
            lblCardsQuant.Location = new Point(67, 386);
            lblCardsQuant.Name = "lblCardsQuant";
            lblCardsQuant.Size = new Size(237, 38);
            lblCardsQuant.TabIndex = 31;
            lblCardsQuant.Text = "Quantidade:";
            lblCardsQuant.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // boxCardsQuant
            // 
            boxCardsQuant.Anchor = AnchorStyles.Top;
            boxCardsQuant.Font = new Font("Segoe UI", 12F);
            boxCardsQuant.Location = new Point(310, 392);
            boxCardsQuant.Name = "boxCardsQuant";
            boxCardsQuant.Size = new Size(395, 29);
            boxCardsQuant.TabIndex = 30;
            // 
            // cboCardsList
            // 
            cboCardsList.FormattingEnabled = true;
            cboCardsList.Location = new Point(310, 463);
            cboCardsList.Name = "cboCardsList";
            cboCardsList.Size = new Size(395, 23);
            cboCardsList.TabIndex = 32;
            // 
            // lblCardsList
            // 
            lblCardsList.Anchor = AnchorStyles.Top;
            lblCardsList.Font = new Font("Segoe UI", 12F);
            lblCardsList.ImageAlign = ContentAlignment.MiddleLeft;
            lblCardsList.Location = new Point(67, 452);
            lblCardsList.Name = "lblCardsList";
            lblCardsList.Size = new Size(237, 38);
            lblCardsList.TabIndex = 33;
            lblCardsList.Text = "Lista:";
            lblCardsList.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnElementCreate
            // 
            btnElementCreate.Anchor = AnchorStyles.Top;
            btnElementCreate.Location = new Point(787, 528);
            btnElementCreate.Name = "btnElementCreate";
            btnElementCreate.Size = new Size(295, 76);
            btnElementCreate.TabIndex = 14;
            btnElementCreate.Text = "Criar";
            btnElementCreate.UseVisualStyleBackColor = true;
            // 
            // btnListCreate
            // 
            btnListCreate.Anchor = AnchorStyles.Top;
            btnListCreate.Location = new Point(817, 502);
            btnListCreate.Name = "btnListCreate";
            btnListCreate.Size = new Size(295, 76);
            btnListCreate.TabIndex = 22;
            btnListCreate.Text = "Criar";
            btnListCreate.UseVisualStyleBackColor = true;
            // 
            // btnCardsExport
            // 
            btnCardsExport.Anchor = AnchorStyles.Top;
            btnCardsExport.Font = new Font("Segoe UI", 12F);
            btnCardsExport.Location = new Point(437, 557);
            btnCardsExport.Name = "btnCardsExport";
            btnCardsExport.Size = new Size(295, 76);
            btnCardsExport.TabIndex = 35;
            btnCardsExport.Text = "Exportar Jogo";
            btnCardsExport.UseVisualStyleBackColor = true;
            // 
            // lblEditHeader
            // 
            lblEditHeader.Dock = DockStyle.Top;
            lblEditHeader.Font = new Font("Segoe UI", 16F);
            lblEditHeader.Location = new Point(0, 0);
            lblEditHeader.Name = "lblEditHeader";
            lblEditHeader.Size = new Size(1182, 87);
            lblEditHeader.TabIndex = 13;
            lblEditHeader.Text = "Editar";
            lblEditHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnEditEdit
            // 
            btnEditEdit.Anchor = AnchorStyles.Top;
            btnEditEdit.Location = new Point(499, 619);
            btnEditEdit.Name = "btnEditEdit";
            btnEditEdit.Size = new Size(267, 76);
            btnEditEdit.TabIndex = 28;
            btnEditEdit.Text = "Editar";
            btnEditEdit.UseVisualStyleBackColor = true;
            // 
            // lblEditMessage
            // 
            lblEditMessage.Anchor = AnchorStyles.Top;
            lblEditMessage.Font = new Font("Segoe UI", 12F);
            lblEditMessage.Location = new Point(27, 585);
            lblEditMessage.Name = "lblEditMessage";
            lblEditMessage.Size = new Size(391, 110);
            lblEditMessage.TabIndex = 27;
            lblEditMessage.Text = "Mensagem";
            lblEditMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboEdit
            // 
            cboEdit.FormattingEnabled = true;
            cboEdit.Location = new Point(27, 119);
            cboEdit.Name = "cboEdit";
            cboEdit.Size = new Size(391, 23);
            cboEdit.TabIndex = 24;
            // 
            // picEdit
            // 
            picEdit.Location = new Point(742, 405);
            picEdit.Name = "picEdit";
            picEdit.Size = new Size(395, 191);
            picEdit.TabIndex = 26;
            picEdit.TabStop = false;
            // 
            // btnEditImage
            // 
            btnEditImage.Location = new Point(524, 501);
            btnEditImage.Name = "btnEditImage";
            btnEditImage.Size = new Size(165, 48);
            btnEditImage.TabIndex = 25;
            btnEditImage.Text = "Procurar";
            btnEditImage.UseVisualStyleBackColor = true;
            // 
            // boxEditText4
            // 
            boxEditText4.Anchor = AnchorStyles.Top;
            boxEditText4.Font = new Font("Segoe UI", 12F);
            boxEditText4.Location = new Point(742, 287);
            boxEditText4.Name = "boxEditText4";
            boxEditText4.Size = new Size(395, 29);
            boxEditText4.TabIndex = 22;
            // 
            // boxEditText3
            // 
            boxEditText3.Anchor = AnchorStyles.Top;
            boxEditText3.Font = new Font("Segoe UI", 12F);
            boxEditText3.Location = new Point(742, 230);
            boxEditText3.Name = "boxEditText3";
            boxEditText3.Size = new Size(395, 29);
            boxEditText3.TabIndex = 20;
            // 
            // boxEditText2
            // 
            boxEditText2.Anchor = AnchorStyles.Top;
            boxEditText2.Font = new Font("Segoe UI", 12F);
            boxEditText2.Location = new Point(742, 173);
            boxEditText2.Name = "boxEditText2";
            boxEditText2.Size = new Size(395, 29);
            boxEditText2.TabIndex = 18;
            // 
            // boxEditText1
            // 
            boxEditText1.Anchor = AnchorStyles.Top;
            boxEditText1.Font = new Font("Segoe UI", 12F);
            boxEditText1.Location = new Point(742, 114);
            boxEditText1.Name = "boxEditText1";
            boxEditText1.Size = new Size(395, 29);
            boxEditText1.TabIndex = 16;
            // 
            // lblEditImage
            // 
            lblEditImage.Anchor = AnchorStyles.Top;
            lblEditImage.Font = new Font("Segoe UI", 12F);
            lblEditImage.ImageAlign = ContentAlignment.MiddleLeft;
            lblEditImage.Location = new Point(499, 429);
            lblEditImage.Name = "lblEditImage";
            lblEditImage.Size = new Size(237, 38);
            lblEditImage.TabIndex = 23;
            lblEditImage.Text = "Imagem:";
            lblEditImage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEditText4
            // 
            lblEditText4.Anchor = AnchorStyles.Top;
            lblEditText4.Font = new Font("Segoe UI", 12F);
            lblEditText4.ImageAlign = ContentAlignment.MiddleLeft;
            lblEditText4.Location = new Point(499, 281);
            lblEditText4.Name = "lblEditText4";
            lblEditText4.Size = new Size(237, 38);
            lblEditText4.TabIndex = 21;
            lblEditText4.Text = "Informação 4:";
            lblEditText4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEditText3
            // 
            lblEditText3.Anchor = AnchorStyles.Top;
            lblEditText3.Font = new Font("Segoe UI", 12F);
            lblEditText3.ImageAlign = ContentAlignment.MiddleLeft;
            lblEditText3.Location = new Point(499, 224);
            lblEditText3.Name = "lblEditText3";
            lblEditText3.Size = new Size(237, 38);
            lblEditText3.TabIndex = 19;
            lblEditText3.Text = "Informação 3:";
            lblEditText3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEditText2
            // 
            lblEditText2.Anchor = AnchorStyles.Top;
            lblEditText2.Font = new Font("Segoe UI", 12F);
            lblEditText2.ImageAlign = ContentAlignment.MiddleLeft;
            lblEditText2.Location = new Point(499, 167);
            lblEditText2.Name = "lblEditText2";
            lblEditText2.Size = new Size(237, 38);
            lblEditText2.TabIndex = 17;
            lblEditText2.Text = "Informação 2:";
            lblEditText2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEditText1
            // 
            lblEditText1.Anchor = AnchorStyles.Top;
            lblEditText1.Font = new Font("Segoe UI", 12F);
            lblEditText1.ImageAlign = ContentAlignment.MiddleLeft;
            lblEditText1.Location = new Point(499, 110);
            lblEditText1.Name = "lblEditText1";
            lblEditText1.Size = new Size(237, 38);
            lblEditText1.TabIndex = 15;
            lblEditText1.Text = "Informação 1:";
            lblEditText1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flwEditItens
            // 
            flwEditItens.Location = new Point(27, 148);
            flwEditItens.Name = "flwEditItens";
            flwEditItens.Size = new Size(391, 401);
            flwEditItens.TabIndex = 29;
            // 
            // btnEditExclude
            // 
            btnEditExclude.Anchor = AnchorStyles.Top;
            btnEditExclude.Location = new Point(820, 619);
            btnEditExclude.Name = "btnEditExclude";
            btnEditExclude.Size = new Size(267, 76);
            btnEditExclude.TabIndex = 30;
            btnEditExclude.Text = "Excluir";
            btnEditExclude.UseVisualStyleBackColor = true;
            // 
            // boxEditText5
            // 
            boxEditText5.Anchor = AnchorStyles.Top;
            boxEditText5.Font = new Font("Segoe UI", 12F);
            boxEditText5.Location = new Point(742, 344);
            boxEditText5.Name = "boxEditText5";
            boxEditText5.Size = new Size(395, 29);
            boxEditText5.TabIndex = 32;
            // 
            // lblEditText5
            // 
            lblEditText5.Anchor = AnchorStyles.Top;
            lblEditText5.Font = new Font("Segoe UI", 12F);
            lblEditText5.ImageAlign = ContentAlignment.MiddleLeft;
            lblEditText5.Location = new Point(499, 338);
            lblEditText5.Name = "lblEditText5";
            lblEditText5.Size = new Size(237, 38);
            lblEditText5.TabIndex = 31;
            lblEditText5.Text = "Informação 5:";
            lblEditText5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1190, 744);
            Controls.Add(pnlMainView);
            Name = "MainView";
            Text = "BingoManager - Creator";
            pnlMainView.ResumeLayout(false);
            tabControlMain.ResumeLayout(false);
            tabCreatePage.ResumeLayout(false);
            tabControlCreate.ResumeLayout(false);
            tabCreateElement.ResumeLayout(false);
            tabCreateElement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picElement).EndInit();
            tabCreateList.ResumeLayout(false);
            tabCreateList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picList).EndInit();
            tabCreateCards.ResumeLayout(false);
            tabCreateCards.PerformLayout();
            tabEditPage.ResumeLayout(false);
            tabEditPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picEdit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlMainView;
        private TabControl tabControlMain;
        private TabPage tabCreatePage;
        private TabPage tabEditPage;
        private TabControl tabControlCreate;
        private TabPage tabCreateElement;
        private TabPage tabCreateList;
        private TabPage tabCreateCards;
        private TextBox boxElementName;
        private Label lblElementImage;
        private Label lblElementNote2;
        private Label lblElementNote1;
        private Label lblElementCardName;
        private Label lblElementName;
        private Button btnElementImage;
        private Label lblElementList;
        private TextBox boxelementNote2;
        private TextBox boxElementNote1;
        private TextBox boxElementCardName;
        private Label lblElementTitle;
        private ComboBox cboElementList;
        private PictureBox picElement;
        private Label lblElementMessage;
        private Label lblListMessage;
        private PictureBox picList;
        private Button btnListImage;
        private Label lblListImage;
        private TextBox boxListDescription;
        private TextBox boxListName;
        private Label lblListDescription;
        private Label lblListName;
        private Label lblListTitle;
        private Label lblCardsHeader;
        private Label lblCardsMessage;
        private TextBox boxCardsTitle;
        private TextBox boxCardsName;
        private Label lblCardsTitle;
        private Label lblCardsName;
        private TextBox boxCardsEnd;
        private Label lblCardsList;
        private ComboBox cboCardsList;
        private Label lblCardsQuant;
        private TextBox boxCardsQuant;
        private Label lblCardsEnd;
        private Button btnElementCreate;
        private Button btnListCreate;
        private Button btnCardsExport;
        private FlowLayoutPanel flwEditItens;
        private Button btnEditEdit;
        private Label lblEditMessage;
        private ComboBox cboEdit;
        private PictureBox picEdit;
        private Button btnEditImage;
        private TextBox boxEditText4;
        private TextBox boxEditText3;
        private TextBox boxEditText2;
        private TextBox boxEditText1;
        private Label lblEditImage;
        private Label lblEditText4;
        private Label lblEditText3;
        private Label lblEditText2;
        private Label lblEditText1;
        private Label lblEditHeader;
        private Button btnEditExclude;
        private TextBox boxEditText5;
        private Label lblEditText5;
    }
}
