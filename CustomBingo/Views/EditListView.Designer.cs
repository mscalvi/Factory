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
            ScrollSel = new Panel();
            FlowViewSel = new FlowLayoutPanel();
            ScrollAll = new Panel();
            FlowViewAll = new FlowLayoutPanel();
            LblTitle = new Label();
            CboListSel = new ComboBox();
            LblListSel = new Label();
            BoxListAll = new TextBox();
            LblListAll = new Label();
            BtnRemove = new Button();
            BtnAdd = new Button();
            PnlContent.SuspendLayout();
            ScrollSel.SuspendLayout();
            ScrollAll.SuspendLayout();
            SuspendLayout();
            // 
            // PnlContent
            // 
            PnlContent.Controls.Add(ScrollSel);
            PnlContent.Controls.Add(ScrollAll);
            PnlContent.Controls.Add(LblTitle);
            PnlContent.Controls.Add(CboListSel);
            PnlContent.Controls.Add(LblListSel);
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
            // ScrollSel
            // 
            ScrollSel.Anchor = AnchorStyles.None;
            ScrollSel.AutoScroll = true;
            ScrollSel.Controls.Add(FlowViewSel);
            ScrollSel.Location = new Point(476, 227);
            ScrollSel.Name = "ScrollSel";
            ScrollSel.Size = new Size(341, 424);
            ScrollSel.TabIndex = 10;
            // 
            // FlowViewSel
            // 
            FlowViewSel.AutoSize = true;
            FlowViewSel.BackColor = SystemColors.Control;
            FlowViewSel.Dock = DockStyle.Fill;
            FlowViewSel.Location = new Point(0, 0);
            FlowViewSel.Name = "FlowViewSel";
            FlowViewSel.Size = new Size(341, 424);
            FlowViewSel.TabIndex = 8;
            // 
            // ScrollAll
            // 
            ScrollAll.Anchor = AnchorStyles.None;
            ScrollAll.AutoScroll = true;
            ScrollAll.BackColor = SystemColors.ActiveBorder;
            ScrollAll.Controls.Add(FlowViewAll);
            ScrollAll.Location = new Point(54, 227);
            ScrollAll.Name = "ScrollAll";
            ScrollAll.Size = new Size(340, 424);
            ScrollAll.TabIndex = 9;
            // 
            // FlowViewAll
            // 
            FlowViewAll.AutoSize = true;
            FlowViewAll.BackColor = SystemColors.Control;
            FlowViewAll.Dock = DockStyle.Fill;
            FlowViewAll.Location = new Point(0, 0);
            FlowViewAll.Name = "FlowViewAll";
            FlowViewAll.Size = new Size(340, 424);
            FlowViewAll.TabIndex = 7;
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
            // CboListSel
            // 
            CboListSel.Anchor = AnchorStyles.None;
            CboListSel.FormattingEnabled = true;
            CboListSel.Location = new Point(476, 173);
            CboListSel.Name = "CboListSel";
            CboListSel.Size = new Size(341, 23);
            CboListSel.TabIndex = 5;
            CboListSel.SelectedIndexChanged += CboListSel_SelectedIndexChanged;
            // 
            // LblListSel
            // 
            LblListSel.Anchor = AnchorStyles.None;
            LblListSel.Location = new Point(476, 134);
            LblListSel.Name = "LblListSel";
            LblListSel.Size = new Size(341, 36);
            LblListSel.TabIndex = 4;
            LblListSel.Text = "Empresas na Lista";
            LblListSel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // BoxListAll
            // 
            BoxListAll.Anchor = AnchorStyles.None;
            BoxListAll.Location = new Point(54, 173);
            BoxListAll.Name = "BoxListAll";
            BoxListAll.Size = new Size(340, 23);
            BoxListAll.TabIndex = 6;
            BoxListAll.TextChanged += BoxListAll_TextChanged;
            // 
            // LblListAll
            // 
            LblListAll.Anchor = AnchorStyles.None;
            LblListAll.Location = new Point(54, 134);
            LblListAll.Name = "LblListAll";
            LblListAll.Size = new Size(340, 36);
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
            ScrollSel.ResumeLayout(false);
            ScrollSel.PerformLayout();
            ScrollAll.ResumeLayout(false);
            ScrollAll.PerformLayout();
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
        private Label LblTitle;
        private FlowLayoutPanel FlowViewAll;
        private FlowLayoutPanel FlowViewSel;
        private Panel ScrollSel;
        private Panel ScrollAll;
    }
}
