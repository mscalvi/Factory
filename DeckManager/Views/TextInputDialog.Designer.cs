namespace DeckManager.Views
{
    partial class TextInputDialog
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
            LblCat = new Label();
            BoxCatName = new TextBox();
            BtnCatConfirm = new Button();
            BtnCatCancel = new Button();
            SuspendLayout();
            // 
            // LblCat
            // 
            LblCat.Anchor = AnchorStyles.Top;
            LblCat.Location = new Point(39, 25);
            LblCat.Name = "LblCat";
            LblCat.Size = new Size(364, 86);
            LblCat.TabIndex = 0;
            LblCat.Text = "Digite o nome da Categoria";
            LblCat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BoxCatName
            // 
            BoxCatName.Anchor = AnchorStyles.Top;
            BoxCatName.Location = new Point(48, 156);
            BoxCatName.Name = "BoxCatName";
            BoxCatName.Size = new Size(336, 23);
            BoxCatName.TabIndex = 1;
            // 
            // BtnCatConfirm
            // 
            BtnCatConfirm.Anchor = AnchorStyles.Top;
            BtnCatConfirm.Location = new Point(236, 246);
            BtnCatConfirm.Name = "BtnCatConfirm";
            BtnCatConfirm.Size = new Size(75, 23);
            BtnCatConfirm.TabIndex = 2;
            BtnCatConfirm.Text = "Ok";
            BtnCatConfirm.UseVisualStyleBackColor = true;
            BtnCatConfirm.Click += BtnCatOk_Click;
            // 
            // BtnCatCancel
            // 
            BtnCatCancel.Anchor = AnchorStyles.Top;
            BtnCatCancel.Location = new Point(328, 246);
            BtnCatCancel.Name = "BtnCatCancel";
            BtnCatCancel.Size = new Size(75, 23);
            BtnCatCancel.TabIndex = 3;
            BtnCatCancel.Text = "Cancelar";
            BtnCatCancel.UseVisualStyleBackColor = true;
            BtnCatCancel.Click += BtnCatCancel_Click;
            // 
            // TextInputDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 306);
            Controls.Add(BtnCatCancel);
            Controls.Add(BtnCatConfirm);
            Controls.Add(BoxCatName);
            Controls.Add(LblCat);
            Name = "TextInputDialog";
            Text = "TextInputDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblCat;
        private TextBox BoxCatName;
        private Button BtnCatConfirm;
        private Button BtnCatCancel;
    }
}