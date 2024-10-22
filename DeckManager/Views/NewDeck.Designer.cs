namespace DeckManager.Views
{
    partial class NewDeck
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
            BtnDeckConfirm = new Button();
            LblDeck = new Label();
            BoxDeckName = new TextBox();
            BtnDeckCancel = new Button();
            GrpDeckCat = new GroupBox();
            FlwDeckCat = new FlowLayoutPanel();
            LblDeckName = new Label();
            GrpDeckCat.SuspendLayout();
            SuspendLayout();
            // 
            // BtnDeckConfirm
            // 
            BtnDeckConfirm.Anchor = AnchorStyles.Top;
            BtnDeckConfirm.Location = new Point(274, 255);
            BtnDeckConfirm.Name = "BtnDeckConfirm";
            BtnDeckConfirm.Size = new Size(75, 39);
            BtnDeckConfirm.TabIndex = 3;
            BtnDeckConfirm.Text = "Ok";
            BtnDeckConfirm.UseVisualStyleBackColor = true;
            BtnDeckConfirm.Click += BtnDeckConfirm_Click;
            // 
            // LblDeck
            // 
            LblDeck.Dock = DockStyle.Top;
            LblDeck.Font = new Font("Segoe UI", 18F);
            LblDeck.Location = new Point(0, 0);
            LblDeck.Name = "LblDeck";
            LblDeck.Size = new Size(442, 86);
            LblDeck.TabIndex = 4;
            LblDeck.Text = "Novo Deck";
            LblDeck.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BoxDeckName
            // 
            BoxDeckName.Anchor = AnchorStyles.Top;
            BoxDeckName.Location = new Point(94, 89);
            BoxDeckName.Name = "BoxDeckName";
            BoxDeckName.Size = new Size(336, 23);
            BoxDeckName.TabIndex = 5;
            // 
            // BtnDeckCancel
            // 
            BtnDeckCancel.Anchor = AnchorStyles.Top;
            BtnDeckCancel.Location = new Point(355, 255);
            BtnDeckCancel.Name = "BtnDeckCancel";
            BtnDeckCancel.Size = new Size(75, 39);
            BtnDeckCancel.TabIndex = 6;
            BtnDeckCancel.Text = "Cancelar";
            BtnDeckCancel.UseVisualStyleBackColor = true;
            BtnDeckCancel.Click += BtnDeckCancel_Click;
            // 
            // GrpDeckCat
            // 
            GrpDeckCat.Anchor = AnchorStyles.Top;
            GrpDeckCat.Controls.Add(FlwDeckCat);
            GrpDeckCat.Font = new Font("Segoe UI", 12F);
            GrpDeckCat.Location = new Point(12, 118);
            GrpDeckCat.Name = "GrpDeckCat";
            GrpDeckCat.Size = new Size(418, 115);
            GrpDeckCat.TabIndex = 7;
            GrpDeckCat.TabStop = false;
            GrpDeckCat.Text = "Formatos";
            // 
            // FlwDeckCat
            // 
            FlwDeckCat.Dock = DockStyle.Fill;
            FlwDeckCat.Location = new Point(3, 25);
            FlwDeckCat.Name = "FlwDeckCat";
            FlwDeckCat.Size = new Size(412, 87);
            FlwDeckCat.TabIndex = 0;
            // 
            // LblDeckName
            // 
            LblDeckName.Anchor = AnchorStyles.Top;
            LblDeckName.Font = new Font("Segoe UI", 12F);
            LblDeckName.Location = new Point(12, 89);
            LblDeckName.Name = "LblDeckName";
            LblDeckName.Size = new Size(76, 23);
            LblDeckName.TabIndex = 8;
            LblDeckName.Text = "Nome:";
            LblDeckName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // NewDeck
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 306);
            Controls.Add(LblDeckName);
            Controls.Add(GrpDeckCat);
            Controls.Add(BtnDeckCancel);
            Controls.Add(BoxDeckName);
            Controls.Add(LblDeck);
            Controls.Add(BtnDeckConfirm);
            Name = "NewDeck";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NewDeck";
            GrpDeckCat.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnDeckConfirm;
        private Label LblDeck;
        private TextBox BoxDeckName;
        private Button BtnDeckCancel;
        private GroupBox GrpDeckCat;
        private Label LblDeckName;
        private FlowLayoutPanel FlwDeckCat;
    }
}