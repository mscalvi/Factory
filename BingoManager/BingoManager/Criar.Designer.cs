namespace BingoManager
{
    partial class Criar
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
            this.btnNewTable = new System.Windows.Forms.Button();
            this.btnNewCompany = new System.Windows.Forms.Button();
            this.btnNewList = new System.Windows.Forms.Button();
            this.CreateTitle = new System.Windows.Forms.Label();
            this.btnReturnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewTable
            // 
            this.btnNewTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewTable.Location = new System.Drawing.Point(818, 97);
            this.btnNewTable.Name = "btnNewTable";
            this.btnNewTable.Size = new System.Drawing.Size(402, 540);
            this.btnNewTable.TabIndex = 7;
            this.btnNewTable.Text = "Novas Cartelas";
            this.btnNewTable.UseVisualStyleBackColor = true;
            // 
            // btnNewCompany
            // 
            this.btnNewCompany.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewCompany.Location = new System.Drawing.Point(408, 97);
            this.btnNewCompany.Name = "btnNewCompany";
            this.btnNewCompany.Size = new System.Drawing.Size(402, 540);
            this.btnNewCompany.TabIndex = 6;
            this.btnNewCompany.Text = "Nova Empresa";
            this.btnNewCompany.UseVisualStyleBackColor = true;
            // 
            // btnNewList
            // 
            this.btnNewList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewList.Location = new System.Drawing.Point(0, 97);
            this.btnNewList.Name = "btnNewList";
            this.btnNewList.Size = new System.Drawing.Size(402, 540);
            this.btnNewList.TabIndex = 5;
            this.btnNewList.Text = "Nova Lista";
            this.btnNewList.UseVisualStyleBackColor = true;
            // 
            // CreateTitle
            // 
            this.CreateTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CreateTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTitle.Location = new System.Drawing.Point(0, 2);
            this.CreateTitle.Name = "CreateTitle";
            this.CreateTitle.Size = new System.Drawing.Size(1220, 92);
            this.CreateTitle.TabIndex = 4;
            this.CreateTitle.Text = "Painel de Criação";
            this.CreateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReturnStart
            // 
            this.btnReturnStart.Location = new System.Drawing.Point(12, 12);
            this.btnReturnStart.Name = "btnReturnStart";
            this.btnReturnStart.Size = new System.Drawing.Size(68, 68);
            this.btnReturnStart.TabIndex = 8;
            this.btnReturnStart.Text = "Voltar";
            this.btnReturnStart.UseVisualStyleBackColor = true;
            // 
            // Criar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 639);
            this.Controls.Add(this.btnReturnStart);
            this.Controls.Add(this.btnNewTable);
            this.Controls.Add(this.btnNewCompany);
            this.Controls.Add(this.btnNewList);
            this.Controls.Add(this.CreateTitle);
            this.Name = "Criar";
            this.Text = "Criar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewTable;
        private System.Windows.Forms.Button btnNewCompany;
        private System.Windows.Forms.Button btnNewList;
        private System.Windows.Forms.Label CreateTitle;
        private System.Windows.Forms.Button btnReturnStart;
    }
}