namespace DeckManager.Views
{
    partial class SelColor
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
            CboFilter = new ComboBox();
            LblFilter = new Label();
            SuspendLayout();
            // 
            // BtnFilterCancel
            // 
            BtnFilterCancel.Anchor = AnchorStyles.Top;
            BtnFilterCancel.Location = new Point(355, 261);
            BtnFilterCancel.Name = "BtnFilterCancel";
            BtnFilterCancel.Size = new Size(75, 39);
            BtnFilterCancel.TabIndex = 11;
            BtnFilterCancel.Text = "Cancelar";
            BtnFilterCancel.UseVisualStyleBackColor = true;
            BtnFilterCancel.Click += BtnFilterCancel_Click;
            // 
            // BtnFilterConfirm
            // 
            BtnFilterConfirm.Anchor = AnchorStyles.Top;
            BtnFilterConfirm.Location = new Point(274, 261);
            BtnFilterConfirm.Name = "BtnFilterConfirm";
            BtnFilterConfirm.Size = new Size(75, 39);
            BtnFilterConfirm.TabIndex = 10;
            BtnFilterConfirm.Text = "Ok";
            BtnFilterConfirm.UseVisualStyleBackColor = true;
            BtnFilterConfirm.Click += BtnFilterOk_Click;
            // 
            // CboFilter
            // 
            CboFilter.FormattingEnabled = true;
            CboFilter.Location = new Point(53, 148);
            CboFilter.Name = "CboFilter";
            CboFilter.Size = new Size(336, 23);
            CboFilter.TabIndex = 9;
            // 
            // LblFilter
            // 
            LblFilter.Dock = DockStyle.Top;
            LblFilter.Font = new Font("Segoe UI", 18F);
            LblFilter.Location = new Point(0, 0);
            LblFilter.Name = "LblFilter";
            LblFilter.Size = new Size(442, 86);
            LblFilter.TabIndex = 8;
            LblFilter.Text = "Selecionar Cor";
            LblFilter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SelColor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 306);
            Controls.Add(BtnFilterCancel);
            Controls.Add(BtnFilterConfirm);
            Controls.Add(CboFilter);
            Controls.Add(LblFilter);
            Name = "SelColor";
            Text = "SelColor";
            ResumeLayout(false);
        }

        #endregion

        private Button BtnFilterCancel;
        private Button BtnFilterConfirm;
        private ComboBox CboFilter;
        private Label LblFilter;
    }
}