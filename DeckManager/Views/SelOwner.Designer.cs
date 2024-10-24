namespace DeckManager.Views
{
    partial class SelOwner
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
            LblFilter = new Label();
            CboFilter = new ComboBox();
            BtnFilterCancel = new Button();
            BtnFilterConfirm = new Button();
            SuspendLayout();
            // 
            // LblFilter
            // 
            LblFilter.Dock = DockStyle.Top;
            LblFilter.Font = new Font("Segoe UI", 18F);
            LblFilter.Location = new Point(0, 0);
            LblFilter.Name = "LblFilter";
            LblFilter.Size = new Size(442, 86);
            LblFilter.TabIndex = 1;
            LblFilter.Text = "Selecionar Dono";
            LblFilter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CboFilter
            // 
            CboFilter.FormattingEnabled = true;
            CboFilter.Location = new Point(53, 142);
            CboFilter.Name = "CboFilter";
            CboFilter.Size = new Size(336, 23);
            CboFilter.TabIndex = 5;
            // 
            // BtnFilterCancel
            // 
            BtnFilterCancel.Anchor = AnchorStyles.Top;
            BtnFilterCancel.Location = new Point(355, 255);
            BtnFilterCancel.Name = "BtnFilterCancel";
            BtnFilterCancel.Size = new Size(75, 39);
            BtnFilterCancel.TabIndex = 7;
            BtnFilterCancel.Text = "Cancelar";
            BtnFilterCancel.UseVisualStyleBackColor = true;
            BtnFilterCancel.Click += BtnFilterCancel_Click;
            // 
            // BtnFilterConfirm
            // 
            BtnFilterConfirm.Anchor = AnchorStyles.Top;
            BtnFilterConfirm.Location = new Point(274, 255);
            BtnFilterConfirm.Name = "BtnFilterConfirm";
            BtnFilterConfirm.Size = new Size(75, 39);
            BtnFilterConfirm.TabIndex = 6;
            BtnFilterConfirm.Text = "Ok";
            BtnFilterConfirm.UseVisualStyleBackColor = true;
            BtnFilterConfirm.Click += BtnFilterOk_Click;
            // 
            // SelOwner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 306);
            Controls.Add(BtnFilterCancel);
            Controls.Add(BtnFilterConfirm);
            Controls.Add(CboFilter);
            Controls.Add(LblFilter);
            Name = "SelOwner";
            Text = "SelOwner";
            ResumeLayout(false);
        }

        #endregion

        private Label LblFilter;
        private ComboBox CboFilter;
        private Button BtnFilterCancel;
        private Button BtnFilterConfirm;
    }
}