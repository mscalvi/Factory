namespace BingoManager
{
    partial class NewCardView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NewCardsBelongList = new System.Windows.Forms.ComboBox();
            this.lblCardList = new System.Windows.Forms.Label();
            this.btnNewListReady = new System.Windows.Forms.Button();
            this.btnReturnCreate = new System.Windows.Forms.Button();
            this.TitleNewCards = new System.Windows.Forms.Label();
            this.lblCardQuant = new System.Windows.Forms.Label();
            this.NewCompName = new System.Windows.Forms.TextBox();
            this.lblCardCenter = new System.Windows.Forms.Label();
            this.NewCardCenterNo = new System.Windows.Forms.RadioButton();
            this.NewCardCenterYes = new System.Windows.Forms.RadioButton();
            this.CardCenterGroupBox = new System.Windows.Forms.GroupBox();
            this.lblResultCards = new System.Windows.Forms.Label();
            this.lblLastText = new System.Windows.Forms.Label();
            this.LastText = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.TextBox();
            this.CardCenterGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewCardsBelongList
            // 
            this.NewCardsBelongList.FormattingEnabled = true;
            this.NewCardsBelongList.Location = new System.Drawing.Point(100, 183);
            this.NewCardsBelongList.Name = "NewCardsBelongList";
            this.NewCardsBelongList.Size = new System.Drawing.Size(465, 21);
            this.NewCardsBelongList.TabIndex = 16;
            // 
            // lblCardList
            // 
            this.lblCardList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardList.Location = new System.Drawing.Point(95, 145);
            this.lblCardList.Name = "lblCardList";
            this.lblCardList.Size = new System.Drawing.Size(111, 35);
            this.lblCardList.TabIndex = 15;
            this.lblCardList.Text = "Lista";
            // 
            // btnNewListReady
            // 
            this.btnNewListReady.Location = new System.Drawing.Point(546, 520);
            this.btnNewListReady.Name = "btnNewListReady";
            this.btnNewListReady.Size = new System.Drawing.Size(124, 57);
            this.btnNewListReady.TabIndex = 14;
            this.btnNewListReady.Text = "Montar";
            this.btnNewListReady.UseVisualStyleBackColor = true;
            // 
            // btnReturnCreate
            // 
            this.btnReturnCreate.Location = new System.Drawing.Point(12, 12);
            this.btnReturnCreate.Name = "btnReturnCreate";
            this.btnReturnCreate.Size = new System.Drawing.Size(68, 68);
            this.btnReturnCreate.TabIndex = 13;
            this.btnReturnCreate.Text = "Fechar";
            this.btnReturnCreate.UseVisualStyleBackColor = true;
            this.btnReturnCreate.Click += new System.EventHandler(this.btnReturnCreate_Click);
            // 
            // TitleNewCards
            // 
            this.TitleNewCards.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TitleNewCards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitleNewCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleNewCards.Location = new System.Drawing.Point(0, 2);
            this.TitleNewCards.Name = "TitleNewCards";
            this.TitleNewCards.Size = new System.Drawing.Size(1220, 92);
            this.TitleNewCards.TabIndex = 12;
            this.TitleNewCards.Text = "Gerar Cartelas";
            this.TitleNewCards.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCardQuant
            // 
            this.lblCardQuant.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardQuant.Location = new System.Drawing.Point(95, 245);
            this.lblCardQuant.Name = "lblCardQuant";
            this.lblCardQuant.Size = new System.Drawing.Size(124, 35);
            this.lblCardQuant.TabIndex = 22;
            this.lblCardQuant.Text = "Quantidade";
            // 
            // NewCompName
            // 
            this.NewCompName.Location = new System.Drawing.Point(100, 283);
            this.NewCompName.Name = "NewCompName";
            this.NewCompName.Size = new System.Drawing.Size(465, 20);
            this.NewCompName.TabIndex = 21;
            // 
            // lblCardCenter
            // 
            this.lblCardCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardCenter.Location = new System.Drawing.Point(668, 145);
            this.lblCardCenter.Name = "lblCardCenter";
            this.lblCardCenter.Size = new System.Drawing.Size(111, 35);
            this.lblCardCenter.TabIndex = 23;
            this.lblCardCenter.Text = "Centro";
            // 
            // NewCardCenterNo
            // 
            this.NewCardCenterNo.AutoSize = true;
            this.NewCardCenterNo.Location = new System.Drawing.Point(6, 14);
            this.NewCardCenterNo.Name = "NewCardCenterNo";
            this.NewCardCenterNo.Size = new System.Drawing.Size(90, 17);
            this.NewCardCenterNo.TabIndex = 25;
            this.NewCardCenterNo.Text = "Sem Empresa";
            this.NewCardCenterNo.UseVisualStyleBackColor = true;
            // 
            // NewCardCenterYes
            // 
            this.NewCardCenterYes.AutoSize = true;
            this.NewCardCenterYes.Checked = true;
            this.NewCardCenterYes.Location = new System.Drawing.Point(104, 14);
            this.NewCardCenterYes.Name = "NewCardCenterYes";
            this.NewCardCenterYes.Size = new System.Drawing.Size(90, 17);
            this.NewCardCenterYes.TabIndex = 26;
            this.NewCardCenterYes.TabStop = true;
            this.NewCardCenterYes.Text = "Com Empresa";
            this.NewCardCenterYes.UseVisualStyleBackColor = true;
            // 
            // CardCenterGroupBox
            // 
            this.CardCenterGroupBox.Controls.Add(this.NewCardCenterYes);
            this.CardCenterGroupBox.Controls.Add(this.NewCardCenterNo);
            this.CardCenterGroupBox.Location = new System.Drawing.Point(673, 174);
            this.CardCenterGroupBox.Name = "CardCenterGroupBox";
            this.CardCenterGroupBox.Size = new System.Drawing.Size(200, 45);
            this.CardCenterGroupBox.TabIndex = 31;
            this.CardCenterGroupBox.TabStop = false;
            // 
            // lblResultCards
            // 
            this.lblResultCards.Location = new System.Drawing.Point(520, 591);
            this.lblResultCards.Name = "lblResultCards";
            this.lblResultCards.Size = new System.Drawing.Size(181, 23);
            this.lblResultCards.TabIndex = 32;
            this.lblResultCards.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastText
            // 
            this.lblLastText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastText.Location = new System.Drawing.Point(95, 357);
            this.lblLastText.Name = "lblLastText";
            this.lblLastText.Size = new System.Drawing.Size(124, 35);
            this.lblLastText.TabIndex = 34;
            this.lblLastText.Text = "Frase Final";
            // 
            // LastText
            // 
            this.LastText.Location = new System.Drawing.Point(100, 395);
            this.LastText.Name = "LastText";
            this.LastText.Size = new System.Drawing.Size(1038, 20);
            this.LastText.TabIndex = 33;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(668, 245);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(124, 35);
            this.lblTitle.TabIndex = 36;
            this.lblTitle.Text = "Título";
            // 
            // Title
            // 
            this.Title.Location = new System.Drawing.Point(673, 283);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(465, 20);
            this.Title.TabIndex = 35;
            // 
            // NewCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 639);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.lblLastText);
            this.Controls.Add(this.LastText);
            this.Controls.Add(this.lblResultCards);
            this.Controls.Add(this.CardCenterGroupBox);
            this.Controls.Add(this.lblCardCenter);
            this.Controls.Add(this.lblCardQuant);
            this.Controls.Add(this.NewCompName);
            this.Controls.Add(this.NewCardsBelongList);
            this.Controls.Add(this.lblCardList);
            this.Controls.Add(this.btnNewListReady);
            this.Controls.Add(this.btnReturnCreate);
            this.Controls.Add(this.TitleNewCards);
            this.Name = "NewCard";
            this.Text = "NewCards";
            this.CardCenterGroupBox.ResumeLayout(false);
            this.CardCenterGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox NewCardsBelongList;
        private System.Windows.Forms.Label lblCardList;
        private System.Windows.Forms.Button btnNewListReady;
        private System.Windows.Forms.Button btnReturnCreate;
        private System.Windows.Forms.Label TitleNewCards;
        private System.Windows.Forms.Label lblCardQuant;
        private System.Windows.Forms.TextBox NewCompName;
        private System.Windows.Forms.Label lblCardCenter;
        private System.Windows.Forms.RadioButton NewCardCenterNo;
        private System.Windows.Forms.RadioButton NewCardCenterYes;
        private System.Windows.Forms.GroupBox CardCenterGroupBox;
        private System.Windows.Forms.Label lblResultCards;
        private System.Windows.Forms.Label lblLastText;
        private System.Windows.Forms.TextBox LastText;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox Title;
    }
}