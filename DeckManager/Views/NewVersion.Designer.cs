namespace DeckManager.Views
{
    partial class NewVersion
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
            BtnFilterCancel = new Button();
            BtnFilterConfirm = new Button();
            LblDeck = new Label();
            LblNewVersionName = new Label();
            TxtNewVersionName = new TextBox();
            LblLastVersion = new Label();
            LblLastVersionName = new Label();
            SuspendLayout();
            // 
            // BtnFilterCancel
            // 
            BtnFilterCancel.Anchor = AnchorStyles.Top;
            BtnFilterCancel.Location = new Point(355, 266);
            BtnFilterCancel.Name = "BtnFilterCancel";
            BtnFilterCancel.Size = new Size(75, 39);
            BtnFilterCancel.TabIndex = 19;
            BtnFilterCancel.Text = "Cancelar";
            BtnFilterCancel.UseVisualStyleBackColor = true;
            BtnFilterCancel.Click += BtnFilterCancel_Click;
            // 
            // BtnFilterConfirm
            // 
            BtnFilterConfirm.Anchor = AnchorStyles.Top;
            BtnFilterConfirm.Location = new Point(274, 266);
            BtnFilterConfirm.Name = "BtnFilterConfirm";
            BtnFilterConfirm.Size = new Size(75, 39);
            BtnFilterConfirm.TabIndex = 18;
            BtnFilterConfirm.Text = "Ok";
            BtnFilterConfirm.UseVisualStyleBackColor = true;
            BtnFilterConfirm.Click += BtnFilterOk_Click;
            // 
            // LblDeck
            // 
            LblDeck.Dock = DockStyle.Top;
            LblDeck.Font = new Font("Segoe UI", 18F);
            LblDeck.Location = new Point(0, 0);
            LblDeck.Name = "LblDeck";
            LblDeck.Size = new Size(442, 86);
            LblDeck.TabIndex = 16;
            LblDeck.Text = "Salvar Versão";
            LblDeck.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LblNewVersionName
            // 
            LblNewVersionName.Anchor = AnchorStyles.Top;
            LblNewVersionName.Location = new Point(12, 189);
            LblNewVersionName.Name = "LblNewVersionName";
            LblNewVersionName.Size = new Size(95, 23);
            LblNewVersionName.TabIndex = 20;
            LblNewVersionName.Text = "Nome:";
            LblNewVersionName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TxtNewVersionName
            // 
            TxtNewVersionName.Anchor = AnchorStyles.Top;
            TxtNewVersionName.Location = new Point(113, 190);
            TxtNewVersionName.Name = "TxtNewVersionName";
            TxtNewVersionName.Size = new Size(317, 23);
            TxtNewVersionName.TabIndex = 21;
            // 
            // LblLastVersion
            // 
            LblLastVersion.Anchor = AnchorStyles.Top;
            LblLastVersion.ImageAlign = ContentAlignment.MiddleRight;
            LblLastVersion.Location = new Point(12, 124);
            LblLastVersion.Name = "LblLastVersion";
            LblLastVersion.Size = new Size(95, 23);
            LblLastVersion.TabIndex = 22;
            LblLastVersion.Text = "Última Versão:";
            LblLastVersion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblLastVersionName
            // 
            LblLastVersionName.Anchor = AnchorStyles.Top;
            LblLastVersionName.ImageAlign = ContentAlignment.MiddleRight;
            LblLastVersionName.Location = new Point(113, 124);
            LblLastVersionName.Name = "LblLastVersionName";
            LblLastVersionName.Size = new Size(317, 23);
            LblLastVersionName.TabIndex = 23;
            LblLastVersionName.Text = "Última Versão";
            LblLastVersionName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NewVersion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 306);
            Controls.Add(LblLastVersionName);
            Controls.Add(LblLastVersion);
            Controls.Add(TxtNewVersionName);
            Controls.Add(LblNewVersionName);
            Controls.Add(BtnFilterCancel);
            Controls.Add(BtnFilterConfirm);
            Controls.Add(LblDeck);
            Name = "NewVersion";
            Text = "NewVersion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnFilterCancel;
        private Button BtnFilterConfirm;
        private Label LblDeck;
        private Label LblNewVersionName;
        private TextBox TxtNewVersionName;
        private Label LblLastVersion;
        private Label LblLastVersionName;
    }
}