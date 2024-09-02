namespace BingoManager
{
    partial class NewList
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
            this.NewListDescription = new System.Windows.Forms.TextBox();
            this.NewListName = new System.Windows.Forms.TextBox();
            this.lblListDescription = new System.Windows.Forms.Label();
            this.lblListName = new System.Windows.Forms.Label();
            this.btnNewListReady = new System.Windows.Forms.Button();
            this.btnReturnCreate = new System.Windows.Forms.Button();
            this.TitleNewCompany = new System.Windows.Forms.Label();
            this.lblResultList = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NewListDescription
            // 
            this.NewListDescription.Location = new System.Drawing.Point(87, 299);
            this.NewListDescription.Multiline = true;
            this.NewListDescription.Name = "NewListDescription";
            this.NewListDescription.Size = new System.Drawing.Size(1046, 155);
            this.NewListDescription.TabIndex = 18;
            // 
            // NewListName
            // 
            this.NewListName.Location = new System.Drawing.Point(87, 181);
            this.NewListName.Name = "NewListName";
            this.NewListName.Size = new System.Drawing.Size(1046, 20);
            this.NewListName.TabIndex = 17;
            // 
            // lblListDescription
            // 
            this.lblListDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListDescription.Location = new System.Drawing.Point(91, 261);
            this.lblListDescription.Name = "lblListDescription";
            this.lblListDescription.Size = new System.Drawing.Size(111, 35);
            this.lblListDescription.TabIndex = 16;
            this.lblListDescription.Text = "Descrição";
            // 
            // lblListName
            // 
            this.lblListName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListName.Location = new System.Drawing.Point(91, 143);
            this.lblListName.Name = "lblListName";
            this.lblListName.Size = new System.Drawing.Size(111, 35);
            this.lblListName.TabIndex = 15;
            this.lblListName.Text = "Nome";
            // 
            // btnNewListReady
            // 
            this.btnNewListReady.Location = new System.Drawing.Point(548, 518);
            this.btnNewListReady.Name = "btnNewListReady";
            this.btnNewListReady.Size = new System.Drawing.Size(124, 57);
            this.btnNewListReady.TabIndex = 14;
            this.btnNewListReady.Text = "Criar";
            this.btnNewListReady.UseVisualStyleBackColor = true;
            this.btnNewListReady.Click += new System.EventHandler(this.btnNewListReady_Click);
            // 
            // btnReturnCreate
            // 
            this.btnReturnCreate.Location = new System.Drawing.Point(12, 12);
            this.btnReturnCreate.Name = "btnReturnCreate";
            this.btnReturnCreate.Size = new System.Drawing.Size(68, 68);
            this.btnReturnCreate.TabIndex = 13;
            this.btnReturnCreate.Text = "Fechar";
            this.btnReturnCreate.UseVisualStyleBackColor = true;
            this.btnReturnCreate.Click += new System.EventHandler(this.btnReturnCreate_Click);
            // 
            // TitleNewCompany
            // 
            this.TitleNewCompany.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TitleNewCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitleNewCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleNewCompany.Location = new System.Drawing.Point(0, 2);
            this.TitleNewCompany.Name = "TitleNewCompany";
            this.TitleNewCompany.Size = new System.Drawing.Size(1220, 92);
            this.TitleNewCompany.TabIndex = 12;
            this.TitleNewCompany.Text = "Nova Lista";
            this.TitleNewCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResultList
            // 
            this.lblResultList.Location = new System.Drawing.Point(87, 588);
            this.lblResultList.Name = "lblResultList";
            this.lblResultList.Size = new System.Drawing.Size(1046, 42);
            this.lblResultList.TabIndex = 19;
            this.lblResultList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NewList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 639);
            this.Controls.Add(this.lblResultList);
            this.Controls.Add(this.NewListDescription);
            this.Controls.Add(this.NewListName);
            this.Controls.Add(this.lblListDescription);
            this.Controls.Add(this.lblListName);
            this.Controls.Add(this.btnNewListReady);
            this.Controls.Add(this.btnReturnCreate);
            this.Controls.Add(this.TitleNewCompany);
            this.Name = "NewList";
            this.Text = "NewList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NewListDescription;
        private System.Windows.Forms.TextBox NewListName;
        private System.Windows.Forms.Label lblListDescription;
        private System.Windows.Forms.Label lblListName;
        private System.Windows.Forms.Button btnNewListReady;
        private System.Windows.Forms.Button btnReturnCreate;
        private System.Windows.Forms.Label TitleNewCompany;
        private System.Windows.Forms.Label lblResultList;
    }
}