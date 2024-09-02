namespace BingoManager
{
    partial class NewCompanyView
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
            this.TitleNewList = new System.Windows.Forms.Label();
            this.btnReturnCreate = new System.Windows.Forms.Button();
            this.btnNewCompReady = new System.Windows.Forms.Button();
            this.NewCompName = new System.Windows.Forms.TextBox();
            this.NewCompEmail = new System.Windows.Forms.TextBox();
            this.lblCompEmail = new System.Windows.Forms.Label();
            this.NewCompPhone = new System.Windows.Forms.TextBox();
            this.lblCompPhone = new System.Windows.Forms.Label();
            this.NewCompTableName = new System.Windows.Forms.TextBox();
            this.lblCompTableName = new System.Windows.Forms.Label();
            this.lblCompLogo = new System.Windows.Forms.Label();
            this.lblCompName = new System.Windows.Forms.Label();
            this.NewCompLogo = new System.Windows.Forms.PictureBox();
            this.lblResultComp = new System.Windows.Forms.Label();
            this.NewCompLogoFind = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NewCompLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleNewList
            // 
            this.TitleNewList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TitleNewList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitleNewList.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleNewList.Location = new System.Drawing.Point(0, 2);
            this.TitleNewList.Name = "TitleNewList";
            this.TitleNewList.Size = new System.Drawing.Size(1220, 92);
            this.TitleNewList.TabIndex = 5;
            this.TitleNewList.Text = "Nova Empresa";
            this.TitleNewList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReturnCreate
            // 
            this.btnReturnCreate.Location = new System.Drawing.Point(12, 12);
            this.btnReturnCreate.Name = "btnReturnCreate";
            this.btnReturnCreate.Size = new System.Drawing.Size(68, 68);
            this.btnReturnCreate.TabIndex = 6;
            this.btnReturnCreate.Text = "Fechar";
            this.btnReturnCreate.UseVisualStyleBackColor = true;
            this.btnReturnCreate.Click += new System.EventHandler(this.btnReturnCreate_Click);
            // 
            // btnNewCompReady
            // 
            this.btnNewCompReady.Location = new System.Drawing.Point(548, 520);
            this.btnNewCompReady.Name = "btnNewCompReady";
            this.btnNewCompReady.Size = new System.Drawing.Size(124, 57);
            this.btnNewCompReady.TabIndex = 7;
            this.btnNewCompReady.Text = "Criar";
            this.btnNewCompReady.UseVisualStyleBackColor = true;
            this.btnNewCompReady.Click += new System.EventHandler(this.btnNewCompReady_Click);
            // 
            // NewCompName
            // 
            this.NewCompName.Location = new System.Drawing.Point(100, 183);
            this.NewCompName.Name = "NewCompName";
            this.NewCompName.Size = new System.Drawing.Size(465, 20);
            this.NewCompName.TabIndex = 10;
            // 
            // NewCompEmail
            // 
            this.NewCompEmail.Location = new System.Drawing.Point(100, 383);
            this.NewCompEmail.Name = "NewCompEmail";
            this.NewCompEmail.Size = new System.Drawing.Size(465, 20);
            this.NewCompEmail.TabIndex = 13;
            // 
            // lblCompEmail
            // 
            this.lblCompEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompEmail.Location = new System.Drawing.Point(95, 345);
            this.lblCompEmail.Name = "lblCompEmail";
            this.lblCompEmail.Size = new System.Drawing.Size(111, 35);
            this.lblCompEmail.TabIndex = 12;
            this.lblCompEmail.Text = "E-mail";
            // 
            // NewCompPhone
            // 
            this.NewCompPhone.Location = new System.Drawing.Point(673, 183);
            this.NewCompPhone.Name = "NewCompPhone";
            this.NewCompPhone.Size = new System.Drawing.Size(465, 20);
            this.NewCompPhone.TabIndex = 15;
            // 
            // lblCompPhone
            // 
            this.lblCompPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompPhone.Location = new System.Drawing.Point(668, 145);
            this.lblCompPhone.Name = "lblCompPhone";
            this.lblCompPhone.Size = new System.Drawing.Size(111, 35);
            this.lblCompPhone.TabIndex = 14;
            this.lblCompPhone.Text = "Telefone";
            // 
            // NewCompTableName
            // 
            this.NewCompTableName.Location = new System.Drawing.Point(100, 285);
            this.NewCompTableName.Name = "NewCompTableName";
            this.NewCompTableName.Size = new System.Drawing.Size(465, 20);
            this.NewCompTableName.TabIndex = 17;
            // 
            // lblCompTableName
            // 
            this.lblCompTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompTableName.Location = new System.Drawing.Point(95, 247);
            this.lblCompTableName.Name = "lblCompTableName";
            this.lblCompTableName.Size = new System.Drawing.Size(234, 35);
            this.lblCompTableName.TabIndex = 16;
            this.lblCompTableName.Text = "Nome para a Cartela";
            // 
            // lblCompLogo
            // 
            this.lblCompLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompLogo.Location = new System.Drawing.Point(668, 247);
            this.lblCompLogo.Name = "lblCompLogo";
            this.lblCompLogo.Size = new System.Drawing.Size(234, 35);
            this.lblCompLogo.TabIndex = 18;
            this.lblCompLogo.Text = "Logo para Apresentação";
            // 
            // lblCompName
            // 
            this.lblCompName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompName.Location = new System.Drawing.Point(95, 145);
            this.lblCompName.Name = "lblCompName";
            this.lblCompName.Size = new System.Drawing.Size(111, 35);
            this.lblCompName.TabIndex = 20;
            this.lblCompName.Text = "Nome";
            // 
            // NewCompLogo
            // 
            this.NewCompLogo.Location = new System.Drawing.Point(754, 285);
            this.NewCompLogo.Name = "NewCompLogo";
            this.NewCompLogo.Size = new System.Drawing.Size(220, 220);
            this.NewCompLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.NewCompLogo.TabIndex = 21;
            this.NewCompLogo.TabStop = false;
            // 
            // lblResultComp
            // 
            this.lblResultComp.Location = new System.Drawing.Point(91, 594);
            this.lblResultComp.Name = "lblResultComp";
            this.lblResultComp.Size = new System.Drawing.Size(1038, 36);
            this.lblResultComp.TabIndex = 22;
            this.lblResultComp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NewCompLogoFind
            // 
            this.NewCompLogoFind.Location = new System.Drawing.Point(673, 285);
            this.NewCompLogoFind.Name = "NewCompLogoFind";
            this.NewCompLogoFind.Size = new System.Drawing.Size(75, 23);
            this.NewCompLogoFind.TabIndex = 23;
            this.NewCompLogoFind.Text = "Procurar";
            this.NewCompLogoFind.UseVisualStyleBackColor = true;
            this.NewCompLogoFind.Click += new System.EventHandler(this.NewCompLogoFind_Click);
            // 
            // NewCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 639);
            this.Controls.Add(this.NewCompLogoFind);
            this.Controls.Add(this.lblResultComp);
            this.Controls.Add(this.NewCompLogo);
            this.Controls.Add(this.lblCompName);
            this.Controls.Add(this.lblCompLogo);
            this.Controls.Add(this.NewCompTableName);
            this.Controls.Add(this.lblCompTableName);
            this.Controls.Add(this.NewCompPhone);
            this.Controls.Add(this.lblCompPhone);
            this.Controls.Add(this.NewCompEmail);
            this.Controls.Add(this.lblCompEmail);
            this.Controls.Add(this.NewCompName);
            this.Controls.Add(this.btnNewCompReady);
            this.Controls.Add(this.btnReturnCreate);
            this.Controls.Add(this.TitleNewList);
            this.Name = "NewCompany";
            this.Text = "NewCompany";
            ((System.ComponentModel.ISupportInitialize)(this.NewCompLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleNewList;
        private System.Windows.Forms.Button btnReturnCreate;
        private System.Windows.Forms.Button btnNewCompReady;
        private System.Windows.Forms.TextBox NewCompName;
        private System.Windows.Forms.TextBox NewCompEmail;
        private System.Windows.Forms.Label lblCompEmail;
        private System.Windows.Forms.TextBox NewCompPhone;
        private System.Windows.Forms.Label lblCompPhone;
        private System.Windows.Forms.TextBox NewCompTableName;
        private System.Windows.Forms.Label lblCompTableName;
        private System.Windows.Forms.Label lblCompLogo;
        private System.Windows.Forms.Label lblCompName;
        private System.Windows.Forms.PictureBox NewCompLogo;
        private System.Windows.Forms.Label lblResultComp;
        private System.Windows.Forms.Button NewCompLogoFind;
    }
}