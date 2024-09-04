namespace CustomBingo.Views
{
    partial class NewCompanyView
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
            LblMessage = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            BtnLogo = new Button();
            BtnConfirm = new Button();
            PicLogo = new PictureBox();
            TxtTitle = new Label();
            BoxName = new TextBox();
            BoxCardName = new TextBox();
            BoxPhone = new TextBox();
            BoxEmail = new TextBox();
            PnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicLogo).BeginInit();
            SuspendLayout();
            // 
            // PnlContent
            // 
            PnlContent.Controls.Add(LblMessage);
            PnlContent.Controls.Add(label5);
            PnlContent.Controls.Add(label4);
            PnlContent.Controls.Add(label3);
            PnlContent.Controls.Add(label2);
            PnlContent.Controls.Add(label1);
            PnlContent.Controls.Add(BtnLogo);
            PnlContent.Controls.Add(BtnConfirm);
            PnlContent.Controls.Add(PicLogo);
            PnlContent.Controls.Add(TxtTitle);
            PnlContent.Controls.Add(BoxName);
            PnlContent.Controls.Add(BoxCardName);
            PnlContent.Controls.Add(BoxPhone);
            PnlContent.Controls.Add(BoxEmail);
            PnlContent.Dock = DockStyle.Fill;
            PnlContent.Location = new Point(0, 0);
            PnlContent.Name = "PnlContent";
            PnlContent.Size = new Size(871, 682);
            PnlContent.TabIndex = 0;
            // 
            // LblMessage
            // 
            LblMessage.Anchor = AnchorStyles.None;
            LblMessage.Location = new Point(210, 558);
            LblMessage.Name = "LblMessage";
            LblMessage.Size = new Size(221, 54);
            LblMessage.TabIndex = 15;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.Location = new Point(643, 216);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 14;
            label5.Text = "Logo";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.Location = new Point(75, 422);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 13;
            label4.Text = "E-mail";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.Location = new Point(75, 343);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 12;
            label3.Text = "Telefone";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.Location = new Point(75, 264);
            label2.Name = "label2";
            label2.Size = new Size(173, 23);
            label2.TabIndex = 11;
            label2.Text = "Nome para Cartela";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.Location = new Point(75, 185);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 10;
            label1.Text = "Nome";
            // 
            // BtnLogo
            // 
            BtnLogo.Anchor = AnchorStyles.None;
            BtnLogo.Location = new Point(658, 242);
            BtnLogo.Name = "BtnLogo";
            BtnLogo.Size = new Size(75, 23);
            BtnLogo.TabIndex = 5;
            BtnLogo.Text = "Procurar";
            BtnLogo.UseVisualStyleBackColor = true;
            BtnLogo.Click += BtnLogo_Click;
            // 
            // BtnConfirm
            // 
            BtnConfirm.Anchor = AnchorStyles.None;
            BtnConfirm.Location = new Point(505, 558);
            BtnConfirm.Name = "BtnConfirm";
            BtnConfirm.Size = new Size(102, 54);
            BtnConfirm.TabIndex = 6;
            BtnConfirm.Text = "Confirmar";
            BtnConfirm.UseVisualStyleBackColor = true;
            BtnConfirm.Click += BtnConfirm_Click;
            // 
            // PicLogo
            // 
            PicLogo.Anchor = AnchorStyles.None;
            PicLogo.Location = new Point(596, 271);
            PicLogo.Name = "PicLogo";
            PicLogo.Size = new Size(200, 200);
            PicLogo.SizeMode = PictureBoxSizeMode.Zoom;
            PicLogo.TabIndex = 7;
            PicLogo.TabStop = false;
            // 
            // TxtTitle
            // 
            TxtTitle.Anchor = AnchorStyles.None;
            TxtTitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtTitle.Location = new Point(0, 0);
            TxtTitle.Name = "TxtTitle";
            TxtTitle.Size = new Size(871, 83);
            TxtTitle.TabIndex = 2;
            TxtTitle.Text = "Registrar Empresa";
            TxtTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BoxName
            // 
            BoxName.Anchor = AnchorStyles.None;
            BoxName.Location = new Point(75, 211);
            BoxName.Name = "BoxName";
            BoxName.Size = new Size(420, 23);
            BoxName.TabIndex = 1;
            // 
            // BoxCardName
            // 
            BoxCardName.Anchor = AnchorStyles.None;
            BoxCardName.Location = new Point(75, 290);
            BoxCardName.Name = "BoxCardName";
            BoxCardName.Size = new Size(420, 23);
            BoxCardName.TabIndex = 2;
            // 
            // BoxPhone
            // 
            BoxPhone.Anchor = AnchorStyles.None;
            BoxPhone.Location = new Point(75, 369);
            BoxPhone.Name = "BoxPhone";
            BoxPhone.Size = new Size(420, 23);
            BoxPhone.TabIndex = 3;
            // 
            // BoxEmail
            // 
            BoxEmail.Anchor = AnchorStyles.None;
            BoxEmail.Location = new Point(75, 448);
            BoxEmail.Name = "BoxEmail";
            BoxEmail.Size = new Size(420, 23);
            BoxEmail.TabIndex = 4;
            // 
            // NewCompanyView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(PnlContent);
            Name = "NewCompanyView";
            Size = new Size(871, 682);
            PnlContent.ResumeLayout(false);
            PnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PicLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PnlContent;
        private Label TxtTitle;
        private Button BtnLogo;
        private Button BtnConfirm;
        private PictureBox PicLogo;
        private TextBox BoxName;
        private TextBox BoxCardName;
        private TextBox BoxPhone;
        private TextBox BoxEmail;
        private Label LblMessage;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}
