namespace DeckManager.Views
{
    partial class NewFilter
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
            BoxFilterName = new TextBox();
            BtnFilterConfirm = new Button();
            BtnFilterCancel = new Button();
            CboFilter = new ComboBox();
            SuspendLayout();
            // 
            // LblFilter
            // 
            LblFilter.Dock = DockStyle.Top;
            LblFilter.Font = new Font("Segoe UI", 18F);
            LblFilter.Location = new Point(0, 0);
            LblFilter.Name = "LblFilter";
            LblFilter.Size = new Size(442, 86);
            LblFilter.TabIndex = 0;
            LblFilter.Text = "Novo Filtro";
            LblFilter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BoxFilterName
            // 
            BoxFilterName.Anchor = AnchorStyles.Top;
            BoxFilterName.Location = new Point(53, 151);
            BoxFilterName.Name = "BoxFilterName";
            BoxFilterName.Size = new Size(336, 23);
            BoxFilterName.TabIndex = 1;
            // 
            // BtnFilterConfirm
            // 
            BtnFilterConfirm.Anchor = AnchorStyles.Top;
            BtnFilterConfirm.Location = new Point(274, 255);
            BtnFilterConfirm.Name = "BtnFilterConfirm";
            BtnFilterConfirm.Size = new Size(75, 39);
            BtnFilterConfirm.TabIndex = 2;
            BtnFilterConfirm.Text = "Ok";
            BtnFilterConfirm.UseVisualStyleBackColor = true;
            BtnFilterConfirm.Click += BtnCatOk_Click;
            // 
            // BtnFilterCancel
            // 
            BtnFilterCancel.Anchor = AnchorStyles.Top;
            BtnFilterCancel.Location = new Point(355, 255);
            BtnFilterCancel.Name = "BtnFilterCancel";
            BtnFilterCancel.Size = new Size(75, 39);
            BtnFilterCancel.TabIndex = 3;
            BtnFilterCancel.Text = "Cancelar";
            BtnFilterCancel.UseVisualStyleBackColor = true;
            BtnFilterCancel.Click += BtnCatCancel_Click;
            // 
            // CboFilter
            // 
            CboFilter.FormattingEnabled = true;
            CboFilter.Location = new Point(53, 106);
            CboFilter.Name = "CboFilter";
            CboFilter.Size = new Size(336, 23);
            CboFilter.TabIndex = 4;
            // 
            // NewFilter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 306);
            Controls.Add(CboFilter);
            Controls.Add(BtnFilterCancel);
            Controls.Add(BtnFilterConfirm);
            Controls.Add(BoxFilterName);
            Controls.Add(LblFilter);
            Name = "NewFilter";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Filtro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblFilter;
        private TextBox BoxFilterName;
        private Button BtnFilterConfirm;
        private Button BtnFilterCancel;
        private ComboBox CboFilter;
    }
}