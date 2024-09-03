namespace CustomBingo.Views
{
    partial class CreateView
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            PnlOptions = new Panel();
            BtnList = new Button();
            BtnCompany = new Button();
            BtnCards = new Button();
            BtnFinish = new Button();
            PnlContent = new Panel();
            newCardView = new NewCardView();
            newMainView = new NewMainView();
            newListView = new NewListView();
            newCompanyView = new NewCompanyView();
            PnlOptions.SuspendLayout();
            PnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // PnlOptions
            // 
            PnlOptions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PnlOptions.BackColor = SystemColors.Control;
            PnlOptions.Controls.Add(BtnList);
            PnlOptions.Controls.Add(BtnCompany);
            PnlOptions.Controls.Add(BtnCards);
            PnlOptions.Controls.Add(BtnFinish);
            PnlOptions.Dock = DockStyle.Right;
            PnlOptions.Location = new Point(870, 0);
            PnlOptions.Name = "PnlOptions";
            PnlOptions.Size = new Size(155, 682);
            PnlOptions.TabIndex = 0;
            // 
            // BtnList
            // 
            BtnList.Anchor = AnchorStyles.Right;
            BtnList.Location = new Point(11, 135);
            BtnList.Name = "BtnList";
            BtnList.Size = new Size(132, 91);
            BtnList.TabIndex = 0;
            BtnList.Text = "Nova Lista";
            BtnList.UseVisualStyleBackColor = true;
            BtnList.Click += BtnList_Click;
            // 
            // BtnCompany
            // 
            BtnCompany.Anchor = AnchorStyles.Right;
            BtnCompany.Location = new Point(11, 242);
            BtnCompany.Name = "BtnCompany";
            BtnCompany.Size = new Size(132, 91);
            BtnCompany.TabIndex = 1;
            BtnCompany.Text = "Registrar Empresas";
            BtnCompany.UseVisualStyleBackColor = true;
            BtnCompany.Click += BtnCompany_Click;
            // 
            // BtnCards
            // 
            BtnCards.Anchor = AnchorStyles.Right;
            BtnCards.Location = new Point(11, 349);
            BtnCards.Name = "BtnCards";
            BtnCards.Size = new Size(132, 91);
            BtnCards.TabIndex = 2;
            BtnCards.Text = "Gerar Cartelas";
            BtnCards.UseVisualStyleBackColor = true;
            BtnCards.Click += BtnCards_Click;
            // 
            // BtnFinish
            // 
            BtnFinish.Anchor = AnchorStyles.Right;
            BtnFinish.Location = new Point(11, 456);
            BtnFinish.Name = "BtnFinish";
            BtnFinish.Size = new Size(132, 91);
            BtnFinish.TabIndex = 3;
            BtnFinish.Text = "Confirmar";
            BtnFinish.UseVisualStyleBackColor = true;
            BtnFinish.Click += BtnFinish_Click;
            // 
            // PnlContent
            // 
            PnlContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PnlContent.BackColor = Color.White;
            PnlContent.Controls.Add(newCardView);
            PnlContent.Controls.Add(newMainView);
            PnlContent.Controls.Add(newListView);
            PnlContent.Controls.Add(newCompanyView);
            PnlContent.Location = new Point(0, 0);
            PnlContent.Name = "PnlContent";
            PnlContent.Size = new Size(871, 682);
            PnlContent.TabIndex = 1;
            // 
            // newCardView
            // 
            newCardView.BackColor = SystemColors.ActiveCaption;
            newCardView.Dock = DockStyle.Fill;
            newCardView.Location = new Point(0, 0);
            newCardView.Name = "newCardView";
            newCardView.Size = new Size(871, 682);
            newCardView.TabIndex = 4;
            // 
            // newMainView
            // 
            newMainView.BackColor = SystemColors.ActiveCaption;
            newMainView.Dock = DockStyle.Fill;
            newMainView.Location = new Point(0, 0);
            newMainView.Name = "newMainView";
            newMainView.Size = new Size(871, 682);
            newMainView.TabIndex = 4;
            // 
            // newListView
            // 
            newListView.BackColor = SystemColors.ActiveCaption;
            newListView.Dock = DockStyle.Fill;
            newListView.Location = new Point(0, 0);
            newListView.Name = "newListView";
            newListView.Size = new Size(871, 682);
            newListView.TabIndex = 4;
            // 
            // newCompanyView
            // 
            newCompanyView.BackColor = SystemColors.ActiveCaption;
            newCompanyView.Dock = DockStyle.Fill;
            newCompanyView.Location = new Point(0, 0);
            newCompanyView.Name = "newCompanyView";
            newCompanyView.Size = new Size(871, 682);
            newCompanyView.TabIndex = 0;
            // 
            // CreateView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(PnlContent);
            Controls.Add(PnlOptions);
            Name = "CreateView";
            Size = new Size(1025, 682);
            PnlOptions.ResumeLayout(false);
            PnlContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PnlOptions;
        private Button BtnList;
        private Button BtnCompany;
        private Button BtnCards;
        public Button BtnFinish;
        private Panel PnlContent;
        private NewCardView newCardView;
        private NewMainView newMainView;
        private NewListView newListView;
        private NewCompanyView newCompanyView;
    }
}
