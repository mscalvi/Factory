namespace CustomBingo.Views
{
    partial class EditListView
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
            LblTitle = new Label();
            ListViewSel = new ListView();
            CboListSel = new ComboBox();
            LblListSel = new Label();
            ListViewAll = new ListView();
            BoxListAll = new TextBox();
            LblListAll = new Label();
            BtnRemove = new Button();
            BtnAdd = new Button();
            PnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // PnlContent
            // 
            PnlContent.Controls.Add(LblTitle);
            PnlContent.Controls.Add(ListViewSel);
            PnlContent.Controls.Add(CboListSel);
            PnlContent.Controls.Add(LblListSel);
            PnlContent.Controls.Add(ListViewAll);
            PnlContent.Controls.Add(BoxListAll);
            PnlContent.Controls.Add(LblListAll);
            PnlContent.Controls.Add(BtnRemove);
            PnlContent.Controls.Add(BtnAdd);
            PnlContent.Dock = DockStyle.Fill;
            PnlContent.Location = new Point(0, 0);
            PnlContent.Name = "PnlContent";
            PnlContent.Size = new Size(871, 682);
            PnlContent.TabIndex = 0;
            // 
            // LblTitle
            // 
            LblTitle.Anchor = AnchorStyles.None;
            LblTitle.Font = new Font("Segoe UI", 18F);
            LblTitle.Location = new Point(0, 0);
            LblTitle.Name = "LblTitle";
            LblTitle.Size = new Size(871, 83);
            LblTitle.TabIndex = 0;
            LblTitle.Text = "Editar Listas";
            LblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ListViewSel
            // 
            ListViewSel.Anchor = AnchorStyles.None;
            ListViewSel.Location = new Point(476, 217);
            ListViewSel.Name = "ListViewSel";
            ListViewSel.Size = new Size(322, 430);
            ListViewSel.TabIndex = 8;
            ListViewSel.UseCompatibleStateImageBehavior = false;
            // 
            // CboListSel
            // 
            CboListSel.Anchor = AnchorStyles.None;
            CboListSel.FormattingEnabled = true;
            CboListSel.Location = new Point(476, 173);
            CboListSel.Name = "CboListSel";
            CboListSel.Size = new Size(322, 23);
            CboListSel.TabIndex = 5;
            // 
            // LblListSel
            // 
            LblListSel.Anchor = AnchorStyles.None;
            LblListSel.Location = new Point(476, 134);
            LblListSel.Name = "LblListSel";
            LblListSel.Size = new Size(322, 36);
            LblListSel.TabIndex = 4;
            LblListSel.Text = "Empresas na Lista";
            LblListSel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // ListViewAll
            // 
            ListViewAll.Anchor = AnchorStyles.None;
            ListViewAll.Location = new Point(72, 217);
            ListViewAll.Name = "ListViewAll";
            ListViewAll.Size = new Size(322, 430);
            ListViewAll.TabIndex = 7;
            ListViewAll.UseCompatibleStateImageBehavior = false;
            // 
            // BoxListAll
            // 
            BoxListAll.Anchor = AnchorStyles.None;
            BoxListAll.Location = new Point(72, 173);
            BoxListAll.Name = "BoxListAll";
            BoxListAll.Size = new Size(322, 23);
            BoxListAll.TabIndex = 6;
            // 
            // LblListAll
            // 
            LblListAll.Anchor = AnchorStyles.None;
            LblListAll.Location = new Point(72, 134);
            LblListAll.Name = "LblListAll";
            LblListAll.Size = new Size(322, 36);
            LblListAll.TabIndex = 3;
            LblListAll.Text = "Empresas Cadastradas";
            LblListAll.TextAlign = ContentAlignment.BottomCenter;
            // 
            // BtnRemove
            // 
            BtnRemove.Anchor = AnchorStyles.None;
            BtnRemove.Location = new Point(417, 344);
            BtnRemove.Name = "BtnRemove";
            BtnRemove.Size = new Size(37, 32);
            BtnRemove.TabIndex = 2;
            BtnRemove.Text = "<-";
            BtnRemove.UseVisualStyleBackColor = true;
            // 
            // BtnAdd
            // 
            BtnAdd.Anchor = AnchorStyles.None;
            BtnAdd.Location = new Point(417, 282);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(37, 32);
            BtnAdd.TabIndex = 1;
            BtnAdd.Text = "->";
            BtnAdd.UseVisualStyleBackColor = true;
            // 
            // EditListView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(PnlContent);
            Name = "EditListView";
            Size = new Size(871, 682);
            PnlContent.ResumeLayout(false);
            PnlContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PnlContent;
        private TextBox BoxListAll;
        private ComboBox CboListSel;
        private Label LblListSel;
        private Label LblListAll;
        private Button BtnRemove;
        private Button BtnAdd;
        private ListView ListViewSel;
        private ListView ListViewAll;
        private Label LblTitle;
    }
}
