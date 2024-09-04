namespace CustomBingo.Views
{
    partial class NewListView
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
            TxtMessage = new Label();
            TxtTitle = new Label();
            TxtName = new Label();
            TxtDescription = new Label();
            BtnCreate = new Button();
            BoxName = new TextBox();
            BoxDescription = new TextBox();
            PnlContent = new Panel();
            PnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // TxtMessage
            // 
            TxtMessage.Anchor = AnchorStyles.None;
            TxtMessage.Location = new Point(65, 460);
            TxtMessage.Name = "TxtMessage";
            TxtMessage.Size = new Size(255, 54);
            TxtMessage.TabIndex = 0;
            // 
            // TxtTitle
            // 
            TxtTitle.Anchor = AnchorStyles.None;
            TxtTitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtTitle.Location = new Point(0, 0);
            TxtTitle.Name = "TxtTitle";
            TxtTitle.Size = new Size(871, 83);
            TxtTitle.TabIndex = 1;
            TxtTitle.Text = "Nova Lista";
            TxtTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TxtName
            // 
            TxtName.Anchor = AnchorStyles.None;
            TxtName.Location = new Point(65, 169);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(100, 23);
            TxtName.TabIndex = 2;
            TxtName.Text = "Nome";
            // 
            // TxtDescription
            // 
            TxtDescription.Anchor = AnchorStyles.None;
            TxtDescription.Location = new Point(65, 280);
            TxtDescription.Name = "TxtDescription";
            TxtDescription.Size = new Size(100, 23);
            TxtDescription.TabIndex = 3;
            TxtDescription.Text = "Descrição";
            // 
            // BtnCreate
            // 
            BtnCreate.Anchor = AnchorStyles.None;
            BtnCreate.Location = new Point(703, 460);
            BtnCreate.Name = "BtnCreate";
            BtnCreate.Size = new Size(102, 54);
            BtnCreate.TabIndex = 4;
            BtnCreate.Text = "Criar";
            BtnCreate.UseVisualStyleBackColor = true;
            BtnCreate.Click += BtnCreate_Click;
            // 
            // BoxName
            // 
            BoxName.Anchor = AnchorStyles.None;
            BoxName.Location = new Point(65, 195);
            BoxName.Name = "BoxName";
            BoxName.Size = new Size(740, 23);
            BoxName.TabIndex = 5;
            // 
            // BoxDescription
            // 
            BoxDescription.Anchor = AnchorStyles.None;
            BoxDescription.Location = new Point(65, 306);
            BoxDescription.Multiline = true;
            BoxDescription.Name = "BoxDescription";
            BoxDescription.Size = new Size(740, 128);
            BoxDescription.TabIndex = 6;
            // 
            // PnlContent
            // 
            PnlContent.Controls.Add(TxtTitle);
            PnlContent.Controls.Add(TxtMessage);
            PnlContent.Controls.Add(TxtName);
            PnlContent.Controls.Add(TxtDescription);
            PnlContent.Controls.Add(BtnCreate);
            PnlContent.Controls.Add(BoxName);
            PnlContent.Controls.Add(BoxDescription);
            PnlContent.Dock = DockStyle.Fill;
            PnlContent.Location = new Point(0, 0);
            PnlContent.Name = "PnlContent";
            PnlContent.Size = new Size(871, 682);
            PnlContent.TabIndex = 7;
            // 
            // NewListView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(PnlContent);
            Name = "NewListView";
            Size = new Size(871, 682);
            PnlContent.ResumeLayout(false);
            PnlContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label TxtMessage;
        private Label TxtTitle;
        private Label TxtName;
        private Label TxtDescription;
        private Button BtnCreate;
        private TextBox BoxName;
        private TextBox BoxDescription;
        private Panel PnlContent;
    }
}
