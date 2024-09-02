using System.Windows.Forms;

namespace BingoManager
{
    partial class StartScreen
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.BingoTitle = new System.Windows.Forms.Label();
            this.StartPanel = new System.Windows.Forms.Panel();
            this.CreationPanel = new System.Windows.Forms.Panel();
            this.btnNewList = new System.Windows.Forms.Button();
            this.btnNewCompany = new System.Windows.Forms.Button();
            this.btnNewCards = new System.Windows.Forms.Button();
            this.btnReturnStart = new System.Windows.Forms.Button();
            this.EditPanel = new System.Windows.Forms.Panel();
            this.EditLists = new System.Windows.Forms.Button();
            this.EditCompany = new System.Windows.Forms.Button();
            this.EditCard = new System.Windows.Forms.Button();
            this.ListEditPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEmpresasCadastradas = new System.Windows.Forms.Label();
            this.ListsList = new System.Windows.Forms.ComboBox();
            this.FindCompany = new System.Windows.Forms.TextBox();
            this.CurrentList = new System.Windows.Forms.DataGridView();
            this.AllCompanyList = new System.Windows.Forms.DataGridView();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.StartPanel.SuspendLayout();
            this.CreationPanel.SuspendLayout();
            this.EditPanel.SuspendLayout();
            this.ListEditPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllCompanyList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreate.Location = new System.Drawing.Point(0, 0);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(402, 540);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Criar";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPlay.Location = new System.Drawing.Point(408, 0);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(402, 540);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "Jogar";
            this.btnPlay.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdit.Location = new System.Drawing.Point(818, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(402, 540);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // BingoTitle
            // 
            this.BingoTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BingoTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BingoTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BingoTitle.Location = new System.Drawing.Point(0, 0);
            this.BingoTitle.Name = "BingoTitle";
            this.BingoTitle.Size = new System.Drawing.Size(1220, 92);
            this.BingoTitle.TabIndex = 0;
            this.BingoTitle.Text = "Bingo Manager";
            this.BingoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartPanel
            // 
            this.StartPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StartPanel.Controls.Add(this.btnPlay);
            this.StartPanel.Controls.Add(this.btnCreate);
            this.StartPanel.Controls.Add(this.btnEdit);
            this.StartPanel.Location = new System.Drawing.Point(0, 95);
            this.StartPanel.Name = "StartPanel";
            this.StartPanel.Size = new System.Drawing.Size(1220, 540);
            this.StartPanel.TabIndex = 4;
            // 
            // CreationPanel
            // 
            this.CreationPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreationPanel.Controls.Add(this.btnNewList);
            this.CreationPanel.Controls.Add(this.btnNewCompany);
            this.CreationPanel.Controls.Add(this.btnNewCards);
            this.CreationPanel.Enabled = false;
            this.CreationPanel.Location = new System.Drawing.Point(0, 95);
            this.CreationPanel.Name = "CreationPanel";
            this.CreationPanel.Size = new System.Drawing.Size(1220, 540);
            this.CreationPanel.TabIndex = 4;
            this.CreationPanel.Visible = false;
            // 
            // btnNewList
            // 
            this.btnNewList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewList.Location = new System.Drawing.Point(0, 0);
            this.btnNewList.Name = "btnNewList";
            this.btnNewList.Size = new System.Drawing.Size(402, 540);
            this.btnNewList.TabIndex = 8;
            this.btnNewList.Text = "Nova Lista";
            this.btnNewList.UseVisualStyleBackColor = true;
            this.btnNewList.Click += new System.EventHandler(this.btnNewList_Click);
            // 
            // btnNewCompany
            // 
            this.btnNewCompany.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewCompany.Location = new System.Drawing.Point(408, 0);
            this.btnNewCompany.Name = "btnNewCompany";
            this.btnNewCompany.Size = new System.Drawing.Size(402, 540);
            this.btnNewCompany.TabIndex = 9;
            this.btnNewCompany.Text = "Nova Empresa";
            this.btnNewCompany.UseVisualStyleBackColor = true;
            this.btnNewCompany.Click += new System.EventHandler(this.btnNewCompany_Click);
            // 
            // btnNewCards
            // 
            this.btnNewCards.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewCards.Location = new System.Drawing.Point(818, 0);
            this.btnNewCards.Name = "btnNewCards";
            this.btnNewCards.Size = new System.Drawing.Size(402, 540);
            this.btnNewCards.TabIndex = 10;
            this.btnNewCards.Text = "Novas Cartelas";
            this.btnNewCards.UseVisualStyleBackColor = true;
            this.btnNewCards.Click += new System.EventHandler(this.btnNewCards_Click);
            // 
            // btnReturnStart
            // 
            this.btnReturnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReturnStart.Location = new System.Drawing.Point(12, 12);
            this.btnReturnStart.Name = "btnReturnStart";
            this.btnReturnStart.Size = new System.Drawing.Size(68, 68);
            this.btnReturnStart.TabIndex = 11;
            this.btnReturnStart.Text = "Fechar";
            this.btnReturnStart.UseVisualStyleBackColor = true;
            this.btnReturnStart.Click += new System.EventHandler(this.btnReturnStart_Click);
            // 
            // EditPanel
            // 
            this.EditPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditPanel.Controls.Add(this.EditLists);
            this.EditPanel.Controls.Add(this.EditCompany);
            this.EditPanel.Controls.Add(this.EditCard);
            this.EditPanel.Enabled = false;
            this.EditPanel.Location = new System.Drawing.Point(0, 95);
            this.EditPanel.Name = "EditPanel";
            this.EditPanel.Size = new System.Drawing.Size(1220, 540);
            this.EditPanel.TabIndex = 11;
            this.EditPanel.Visible = false;
            // 
            // EditLists
            // 
            this.EditLists.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditLists.Location = new System.Drawing.Point(0, 0);
            this.EditLists.Name = "EditLists";
            this.EditLists.Size = new System.Drawing.Size(402, 540);
            this.EditLists.TabIndex = 8;
            this.EditLists.Text = "Editar Listas";
            this.EditLists.UseVisualStyleBackColor = true;
            this.EditLists.Click += new System.EventHandler(this.EditLists_Click);
            // 
            // EditCompany
            // 
            this.EditCompany.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditCompany.Location = new System.Drawing.Point(408, 0);
            this.EditCompany.Name = "EditCompany";
            this.EditCompany.Size = new System.Drawing.Size(402, 540);
            this.EditCompany.TabIndex = 9;
            this.EditCompany.Text = "Editar Empresas";
            this.EditCompany.UseVisualStyleBackColor = true;
            // 
            // EditCard
            // 
            this.EditCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditCard.Enabled = false;
            this.EditCard.Location = new System.Drawing.Point(818, 0);
            this.EditCard.Name = "EditCard";
            this.EditCard.Size = new System.Drawing.Size(402, 540);
            this.EditCard.TabIndex = 10;
            this.EditCard.UseVisualStyleBackColor = true;
            // 
            // ListEditPanel
            // 
            this.ListEditPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ListEditPanel.Controls.Add(this.label1);
            this.ListEditPanel.Controls.Add(this.lblEmpresasCadastradas);
            this.ListEditPanel.Controls.Add(this.ListsList);
            this.ListEditPanel.Controls.Add(this.FindCompany);
            this.ListEditPanel.Controls.Add(this.CurrentList);
            this.ListEditPanel.Controls.Add(this.AllCompanyList);
            this.ListEditPanel.Controls.Add(this.RemoveButton);
            this.ListEditPanel.Controls.Add(this.AddButton);
            this.ListEditPanel.Enabled = false;
            this.ListEditPanel.Location = new System.Drawing.Point(0, 95);
            this.ListEditPanel.Name = "ListEditPanel";
            this.ListEditPanel.Size = new System.Drawing.Size(1220, 540);
            this.ListEditPanel.TabIndex = 4;
            this.ListEditPanel.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(631, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(577, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Empresas na Lista";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmpresasCadastradas
            // 
            this.lblEmpresasCadastradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresasCadastradas.Location = new System.Drawing.Point(12, 9);
            this.lblEmpresasCadastradas.Name = "lblEmpresasCadastradas";
            this.lblEmpresasCadastradas.Size = new System.Drawing.Size(577, 23);
            this.lblEmpresasCadastradas.TabIndex = 5;
            this.lblEmpresasCadastradas.Text = "Empresas Cadastradas";
            this.lblEmpresasCadastradas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListsList
            // 
            this.ListsList.FormattingEnabled = true;
            this.ListsList.Location = new System.Drawing.Point(631, 43);
            this.ListsList.Name = "ListsList";
            this.ListsList.Size = new System.Drawing.Size(577, 21);
            this.ListsList.TabIndex = 4;
            this.ListsList.SelectedIndexChanged += new System.EventHandler(this.ListsList_SelectedIndexChanged);
            // 
            // FindCompany
            // 
            this.FindCompany.Location = new System.Drawing.Point(15, 43);
            this.FindCompany.Name = "FindCompany";
            this.FindCompany.Size = new System.Drawing.Size(574, 20);
            this.FindCompany.TabIndex = 7;
            this.FindCompany.TextChanged += new System.EventHandler(this.FindCompany_TextChanged);
            // 
            // CurrentList
            // 
            this.CurrentList.AllowUserToAddRows = false;
            this.CurrentList.AllowUserToDeleteRows = false;
            this.CurrentList.AllowUserToResizeColumns = false;
            this.CurrentList.AllowUserToResizeRows = false;
            this.CurrentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CurrentList.Location = new System.Drawing.Point(631, 70);
            this.CurrentList.MultiSelect = false;
            this.CurrentList.Name = "CurrentList";
            this.CurrentList.ReadOnly = true;
            this.CurrentList.RowTemplate.Height = 30;
            this.CurrentList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CurrentList.Size = new System.Drawing.Size(577, 452);
            this.CurrentList.TabIndex = 3;
            this.CurrentList.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CurrentList_CellMouseUp);
            this.CurrentList.SelectionChanged += new System.EventHandler(this.CurrentList_SelectionChanged);
            // 
            // AllCompanyList
            // 
            this.AllCompanyList.AllowUserToAddRows = false;
            this.AllCompanyList.AllowUserToDeleteRows = false;
            this.AllCompanyList.AllowUserToResizeColumns = false;
            this.AllCompanyList.AllowUserToResizeRows = false;
            this.AllCompanyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllCompanyList.Location = new System.Drawing.Point(12, 70);
            this.AllCompanyList.MultiSelect = false;
            this.AllCompanyList.Name = "AllCompanyList";
            this.AllCompanyList.ReadOnly = true;
            this.AllCompanyList.RowTemplate.Height = 30;
            this.AllCompanyList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AllCompanyList.Size = new System.Drawing.Size(577, 452);
            this.AllCompanyList.TabIndex = 2;
            this.AllCompanyList.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.AllCompanyList_CellMouseUp);
            this.AllCompanyList.SelectionChanged += new System.EventHandler(this.AllCompanyList_SelectionChanged);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(595, 181);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(30, 30);
            this.RemoveButton.TabIndex = 1;
            this.RemoveButton.Text = "<-";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(595, 145);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(30, 30);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "->";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 639);
            this.Controls.Add(this.ListEditPanel);
            this.Controls.Add(this.EditPanel);
            this.Controls.Add(this.btnReturnStart);
            this.Controls.Add(this.BingoTitle);
            this.Controls.Add(this.StartPanel);
            this.Controls.Add(this.CreationPanel);
            this.Name = "StartScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BingoManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.StartPanel.ResumeLayout(false);
            this.CreationPanel.ResumeLayout(false);
            this.EditPanel.ResumeLayout(false);
            this.ListEditPanel.ResumeLayout(false);
            this.ListEditPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllCompanyList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label BingoTitle;
        private System.Windows.Forms.Panel StartPanel;
        public System.Windows.Forms.Panel CreationPanel;
        private System.Windows.Forms.Button btnNewCards;
        private System.Windows.Forms.Button btnNewCompany;
        private System.Windows.Forms.Button btnNewList;
        public System.Windows.Forms.Button btnReturnStart;
        public System.Windows.Forms.Panel EditPanel;
        private System.Windows.Forms.Button EditCard;
        private System.Windows.Forms.Button EditCompany;
        private System.Windows.Forms.Button EditLists;
        private System.Windows.Forms.Panel ListEditPanel;
        private System.Windows.Forms.Label lblEmpresasCadastradas;
        private System.Windows.Forms.DataGridView CurrentList;
        private System.Windows.Forms.DataGridView AllCompanyList;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FindCompany;
        private ComboBox ListsList;
    }
}

