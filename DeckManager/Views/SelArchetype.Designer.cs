namespace DeckManager.Views
{
    partial class SelArchetype
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
            BtnFilterCancel.Location = new Point(355, 264);
            BtnFilterCancel.Name = "BtnFilterCancel";
            BtnFilterCancel.Size = new Size(75, 39);
            BtnFilterCancel.TabIndex = 15;
            BtnFilterCancel.Text = "Cancelar";
            BtnFilterCancel.UseVisualStyleBackColor = true;
            BtnFilterCancel.Click += BtnFilterCancel_Click;
            // 
            // BtnFilterConfirm
            // 
            BtnFilterConfirm.Anchor = AnchorStyles.Top;
            BtnFilterConfirm.Location = new Point(274, 264);
            BtnFilterConfirm.Name = "BtnFilterConfirm";
            BtnFilterConfirm.Size = new Size(75, 39);
            BtnFilterConfirm.TabIndex = 14;
            BtnFilterConfirm.Text = "Ok";
            BtnFilterConfirm.UseVisualStyleBackColor = true;
            BtnFilterConfirm.Click += BtnFilterOk_Click;
            // 
            // CboFilter
            // 
            CboFilter.FormattingEnabled = true;
            CboFilter.Location = new Point(53, 151);
            CboFilter.Name = "CboFilter";
            CboFilter.Size = new Size(336, 23);
            CboFilter.TabIndex = 13;
            // 
            // LblFilter
            // 
            LblFilter.Dock = DockStyle.Top;
            LblFilter.Font = new Font("Segoe UI", 18F);
            LblFilter.Location = new Point(0, 0);
            LblFilter.Name = "LblFilter";
            LblFilter.Size = new Size(442, 86);
            LblFilter.TabIndex = 12;
            LblFilter.Text = "Selecionar Arquétipo";
            LblFilter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SelArchetype
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 306);
            Controls.Add(BtnFilterCancel);
            Controls.Add(BtnFilterConfirm);
            Controls.Add(CboFilter);
            Controls.Add(LblFilter);
            Name = "SelArchetype";
            Text = "SelArchetype";
            ResumeLayout(false);
        }

        #endregion

        private Button BtnFilterCancel;
        private Button BtnFilterConfirm;
        private ComboBox CboFilter;
        private Label LblFilter;
    }
}