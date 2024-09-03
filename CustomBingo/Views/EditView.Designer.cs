namespace CustomBingo.Views
{
    partial class EditView
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
            PnlContent = new Panel();
            editCompanyView = new EditCompanyView();
            editListView = new EditListView();
            PnlOptions = new Panel();
            BtnFinish = new Button();
            BtnList = new Button();
            BtnCompany = new Button();
            editMainView = new EditMainView();
            PnlContent.SuspendLayout();
            PnlOptions.SuspendLayout();
            SuspendLayout();
            // 
            // PnlContent
            // 
            PnlContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PnlContent.BackColor = Color.White;
            PnlContent.Controls.Add(editMainView);
            PnlContent.Controls.Add(editCompanyView);
            PnlContent.Controls.Add(editListView);
            PnlContent.Location = new Point(0, 0);
            PnlContent.Name = "PnlContent";
            PnlContent.Size = new Size(871, 682);
            PnlContent.TabIndex = 0;
            // 
            // editCompanyView
            // 
            editCompanyView.BackColor = SystemColors.ActiveCaption;
            editCompanyView.Dock = DockStyle.Fill;
            editCompanyView.Location = new Point(0, 0);
            editCompanyView.Name = "editCompanyView";
            editCompanyView.Size = new Size(871, 682);
            editCompanyView.TabIndex = 5;
            // 
            // editListView
            // 
            editListView.BackColor = SystemColors.ActiveCaption;
            editListView.Dock = DockStyle.Fill;
            editListView.Location = new Point(0, 0);
            editListView.Name = "editListView";
            editListView.Size = new Size(871, 682);
            editListView.TabIndex = 0;
            // 
            // PnlOptions
            // 
            PnlOptions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PnlOptions.Controls.Add(BtnFinish);
            PnlOptions.Controls.Add(BtnList);
            PnlOptions.Controls.Add(BtnCompany);
            PnlOptions.Dock = DockStyle.Right;
            PnlOptions.Location = new Point(870, 0);
            PnlOptions.Name = "PnlOptions";
            PnlOptions.Size = new Size(155, 682);
            PnlOptions.TabIndex = 1;
            // 
            // BtnFinish
            // 
            BtnFinish.Anchor = AnchorStyles.Right;
            BtnFinish.Location = new Point(11, 401);
            BtnFinish.Name = "BtnFinish";
            BtnFinish.Size = new Size(132, 91);
            BtnFinish.TabIndex = 4;
            BtnFinish.Text = "Confirmar";
            BtnFinish.UseVisualStyleBackColor = true;
            BtnFinish.Click += BtnFinish_Click;
            // 
            // BtnList
            // 
            BtnList.Anchor = AnchorStyles.Right;
            BtnList.Location = new Point(11, 191);
            BtnList.Name = "BtnList";
            BtnList.Size = new Size(132, 91);
            BtnList.TabIndex = 2;
            BtnList.Text = "Editar Lista";
            BtnList.UseVisualStyleBackColor = true;
            BtnList.Click += BtnList_Click;
            // 
            // BtnCompany
            // 
            BtnCompany.Anchor = AnchorStyles.Right;
            BtnCompany.Location = new Point(11, 296);
            BtnCompany.Name = "BtnCompany";
            BtnCompany.Size = new Size(132, 91);
            BtnCompany.TabIndex = 3;
            BtnCompany.Text = "Editar Empresa";
            BtnCompany.UseVisualStyleBackColor = true;
            BtnCompany.Click += BtnCompany_Click;
            // 
            // editMainView
            // 
            editMainView.BackColor = SystemColors.ActiveCaption;
            editMainView.Dock = DockStyle.Fill;
            editMainView.Location = new Point(0, 0);
            editMainView.Name = "editMainView";
            editMainView.Size = new Size(871, 682);
            editMainView.TabIndex = 5;
            // 
            // EditView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(PnlOptions);
            Controls.Add(PnlContent);
            Name = "EditView";
            Size = new Size(1025, 682);
            PnlContent.ResumeLayout(false);
            PnlOptions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PnlContent;
        private Panel PnlOptions;
        private Button BtnList;
        private Button BtnCompany;
        private Button BtnFinish;
        private EditCompanyView editCompanyView;
        private EditListView editListView;
        private EditMainView editMainView;
    }
}
