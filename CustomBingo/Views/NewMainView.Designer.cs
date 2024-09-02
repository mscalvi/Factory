namespace CustomBingo.Views
{
    partial class NewMainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewMainView));
            PnlContent = new Panel();
            LblExplanation = new Label();
            LblTitle = new Label();
            PnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // PnlContent
            // 
            PnlContent.Controls.Add(LblTitle);
            PnlContent.Controls.Add(LblExplanation);
            PnlContent.Dock = DockStyle.Fill;
            PnlContent.Location = new Point(0, 0);
            PnlContent.Name = "PnlContent";
            PnlContent.Size = new Size(871, 682);
            PnlContent.TabIndex = 0;
            // 
            // LblExplanation
            // 
            LblExplanation.Location = new Point(12, 83);
            LblExplanation.Name = "LblExplanation";
            LblExplanation.Size = new Size(841, 584);
            LblExplanation.TabIndex = 1;
            LblExplanation.Text = resources.GetString("LblExplanation.Text");
            // 
            // LblTitle
            // 
            LblTitle.Anchor = AnchorStyles.None;
            LblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblTitle.Location = new Point(0, 0);
            LblTitle.Name = "LblTitle";
            LblTitle.Size = new Size(871, 83);
            LblTitle.TabIndex = 3;
            LblTitle.Text = "Criando seu Bingo";
            LblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NewMainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(PnlContent);
            Name = "NewMainView";
            Size = new Size(871, 682);
            PnlContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PnlContent;
        private Label LblExplanation;
        private Label LblTitle;
    }
}
