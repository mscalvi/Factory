using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BingoManager.Banco;
using Microsoft.Data.Sqlite;

namespace BingoManager
{
    public partial class StartScreen : Form
    {
        int ReturnBtnFunc = 1;
        int CellColor = 0;
        private DataTable companyDataTable;
        private DataTable listsDataTable;
        private DataTable companyCurrentDataTable;

        public StartScreen()
        {
            InitializeComponent();
            InitializeDatabase();
            FindCompany.TextChanged += FindCompany_TextChanged; // Adicione o evento
        }

        private void InitializeDatabase()
        {
            string databasePath = Path.Combine(Application.StartupPath, "Banco", "BingoManagement.db");
            if (!File.Exists(databasePath))
            {
                CreateDatabase(databasePath);
            }
        }

        private void CreateDatabase(string databasePath)
        {
            // Criar o diretório do banco de dados se ele não existir
            string directoryPath = Path.GetDirectoryName(databasePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Criar e configurar o banco de dados
            using (SqliteConnection connection = new SqliteConnection($"Data Source={databasePath}"))
            {
                connection.Open();
                using (SqliteCommand command = new SqliteCommand())
                {
                    command.Connection = connection;

                    // Exemplo de criação de tabela
                    command.CommandText = @"
                        CREATE TABLE CompanyTable (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            CardName TEXT NOT NULL,
                            Email TEXT,
                            PhoneNumber TEXT,
                            Logo TEXT
                        );
                    ";
                    command.ExecuteNonQuery();

                    command.CommandText = @"
                        CREATE TABLE ListsTable (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Description TEXT NOT NULL
                        );
                    ";

                    command.ExecuteNonQuery();
                }
            }
        }

        //Botões
        private void btnCreate_Click(object sender, EventArgs e)
        {
            StartPanel.Enabled = false;
            StartPanel.Visible = !StartPanel.Visible;

            CreationPanel.Enabled = true;
            CreationPanel.Visible = !CreationPanel.Visible;

            TitleChange();
        }

        private void btnNewList_Click(object sender, EventArgs e)
        {
            CreationPanel.Enabled = false;

            NewList listCreation = new NewList(this);
            listCreation.Show();

            btnReturnStart.Enabled = false;
        }

        private void btnNewCompany_Click(object sender, EventArgs e)
        {
            CreationPanel.Enabled = false;

            NewCompanyView companyCreation = new NewCompanyView(this);
            companyCreation.Show();

            btnReturnStart.Enabled = false;
        }

        private void btnNewCards_Click(object sender, EventArgs e)
        {
            CreationPanel.Enabled = false;

            NewCardView cardCreation = new NewCardView(this);
            cardCreation.Show();

            btnReturnStart.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            StartPanel.Enabled = false;
            StartPanel.Visible = !StartPanel.Visible;

            EditPanel.Enabled = true;
            EditPanel.Visible = !EditPanel.Visible;

            TitleChange();
        }

        private void EditLists_Click(object sender, EventArgs e)
        {
            EditPanel.Enabled = false;
            EditPanel.Visible = false;

            ListEditPanel.Enabled = true;
            ListEditPanel.Visible = true;

            AttCompleteCompanyList();
            AttListsBox();
        }

        //Atualização da Tabela Completa de Empresas
        public void AttCompleteCompanyList()
        {
            companyDataTable = Banco.CompanyDataAccess.ShowAllCompany();
            AllCompanyList.DataSource = companyDataTable;

            // Configure DataGridView columns
            AllCompanyList.Columns.Clear();

            DataGridViewCheckBoxColumn selectColumn = new DataGridViewCheckBoxColumn();
            selectColumn.Name = "Select";
            selectColumn.HeaderText = "";
            selectColumn.Width = 29; // Largura da coluna de seleção
            AllCompanyList.Columns.Add(selectColumn);

            DataGridViewColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.HeaderText = "Nome";
            nameColumn.DataPropertyName = "Name"; // Ensure it matches the column name in the DataTable
            nameColumn.Width = 275;
            nameColumn.ReadOnly = true;
            AllCompanyList.Columns.Add(nameColumn);

            DataGridViewColumn cardNameColumn = new DataGridViewTextBoxColumn();
            cardNameColumn.Name = "CardName";
            cardNameColumn.HeaderText = "Nome para Cartela";
            cardNameColumn.DataPropertyName = "CardName"; // Ensure it matches the column name in the DataTable
            cardNameColumn.Width = 275;
            cardNameColumn.ReadOnly = true;
            AllCompanyList.Columns.Add(cardNameColumn);

            // Adjust DataGridView properties
            AllCompanyList.AllowUserToAddRows = false;
            AllCompanyList.AllowUserToDeleteRows = false;
            AllCompanyList.AllowUserToResizeColumns = false;
            AllCompanyList.AllowUserToResizeRows = false;
            AllCompanyList.ReadOnly = false;
            AllCompanyList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            AllCompanyList.RowHeadersWidth = 50; // Fix width of row header
            AllCompanyList.RowHeadersVisible = false; // Hide the row header if not needed

            // Event handlers for changing row color based on checkbox state
            AllCompanyList.CellValueChanged += AllCompanyList_CellValueChanged;
            AllCompanyList.CurrentCellDirtyStateChanged += AllCompanyList_CurrentCellDirtyStateChanged;
        }

        private void AllCompanyList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (AllCompanyList.CurrentCell is DataGridViewCheckBoxCell)
            {
                AllCompanyList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void AllCompanyList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == AllCompanyList.Columns["Select"].Index)
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)AllCompanyList.Rows[e.RowIndex].Cells["Select"];
                DataGridViewRow row = AllCompanyList.Rows[e.RowIndex];

                if ((bool)checkBoxCell.Value)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.BackColor = Color.Empty; // Remove a cor de fundo
                        cell.Style.SelectionBackColor = Color.Empty; // Remove a cor de fundo na seleção
                        cell.Style.ForeColor = Color.Empty; // Remove a cor do texto
                    }
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                    CellColor = 1;
                }
                else
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.BackColor = Color.Empty; // Remove a cor de fundo
                        cell.Style.SelectionBackColor = Color.Empty; // Remove a cor de fundo na seleção
                        cell.Style.ForeColor = Color.Empty; // Remove a cor do texto
                    }
                    row.DefaultCellStyle.BackColor = Color.White;
                    CellColor = 0;
                }
            }
        }

        private void AllCompanyList_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in ((DataGridView)sender).SelectedCells)
            {
                if (CellColor == 1)
                {
                    cell.Style = new DataGridViewCellStyle()
                    {
                        BackColor = Color.LightBlue,
                        SelectionBackColor = Color.LightBlue,
                        SelectionForeColor = Color.Black
                    };
                } else
                {
                    cell.Style = new DataGridViewCellStyle()
                    {
                        BackColor = Color.White,
                        SelectionBackColor = Color.White,
                        SelectionForeColor = Color.Black
                    };
                }
            }
        }

        private void AllCompanyList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewCell cell in ((DataGridView)sender).SelectedCells)
            {
                if (CellColor == 1)
                {
                    cell.Style = new DataGridViewCellStyle()
                    {
                        BackColor = Color.LightBlue,
                        SelectionBackColor = Color.LightBlue,
                        SelectionForeColor = Color.Black
                    };
                }
                else
                {
                    cell.Style = new DataGridViewCellStyle()
                    {
                        BackColor = Color.White,
                        SelectionBackColor = Color.White,
                        SelectionForeColor = Color.Black
                    };
                }
            }
        }

        private void FindCompany_TextChanged(object sender, EventArgs e)
        {
            string filterText = FindCompany.Text;
            FilterData(filterText);
        }

        private void FilterData(string filterText)
        {
            if (companyDataTable != null)
            {
                DataView dv = companyDataTable.DefaultView;
                dv.RowFilter = string.Format("Name LIKE '%{0}%' OR CardName LIKE '%{0}%'", filterText);
                AllCompanyList.DataSource = dv;
            }
        }

        //Atualização da Lista de Listas
        public void AttListsBox()
        {
            listsDataTable = Banco.ListDataAccess.ShowAllLists();
            ListsList.DataSource = listsDataTable;

            ListsList.DisplayMember = "Name";
            ListsList.ValueMember = "Name";

            DataRow emptyRow = listsDataTable.NewRow();
            emptyRow["Name"] = "";
            listsDataTable.Rows.InsertAt(emptyRow, 0);
            ListsList.SelectedIndex = 0;
        }

        //Atualização da Lista Selecionada
        private void ListsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obter a lista selecionada
            string selectedListName = ListsList.Text;

            // Buscar e exibir as empresas associadas a esta lista
            AttCurrentCompanyList(selectedListName);
        }

        private void AttCurrentCompanyList(string ActualList)
        {
            companyDataTable = Banco.CompanyDataAccess.ShowAllCompany();
            AllCompanyList.DataSource = companyDataTable;

            // Configure DataGridView columns
            CurrentList.Columns.Clear();

            DataGridViewCheckBoxColumn selectColumn = new DataGridViewCheckBoxColumn();
            selectColumn.Name = "Select";
            selectColumn.HeaderText = "";
            selectColumn.Width = 29; // Largura da coluna de seleção
            CurrentList.Columns.Add(selectColumn);

            DataGridViewColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.HeaderText = "Nome";
            nameColumn.DataPropertyName = "Name"; // Ensure it matches the column name in the DataTable
            nameColumn.Width = 275;
            nameColumn.ReadOnly = true;
            CurrentList.Columns.Add(nameColumn);

            DataGridViewColumn cardNameColumn = new DataGridViewTextBoxColumn();
            cardNameColumn.Name = "CardName";
            cardNameColumn.HeaderText = "Nome para Cartela";
            cardNameColumn.DataPropertyName = "CardName"; // Ensure it matches the column name in the DataTable
            cardNameColumn.Width = 275;
            cardNameColumn.ReadOnly = true;
            CurrentList.Columns.Add(cardNameColumn);

            // Adjust DataGridView properties
            CurrentList.AllowUserToAddRows = false;
            CurrentList.AllowUserToDeleteRows = false;
            CurrentList.AllowUserToResizeColumns = false;
            CurrentList.AllowUserToResizeRows = false;
            CurrentList.ReadOnly = false;
            CurrentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            CurrentList.RowHeadersWidth = 50; // Fix width of row header
            CurrentList.RowHeadersVisible = false; // Hide the row header if not needed

            // Event handlers for changing row color based on checkbox state
            CurrentList.CellValueChanged += CurrentList_CellValueChanged;
            CurrentList.CurrentCellDirtyStateChanged += CurrentList_CurrentCellDirtyStateChanged;
        }

        private void CurrentList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (CurrentList.CurrentCell is DataGridViewCheckBoxCell)
            {
                CurrentList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void CurrentList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == CurrentList.Columns["Select"].Index)
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)CurrentList.Rows[e.RowIndex].Cells["Select"];
                DataGridViewRow row = CurrentList.Rows[e.RowIndex];

                if ((bool)checkBoxCell.Value)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.BackColor = Color.Empty; // Remove a cor de fundo
                        cell.Style.SelectionBackColor = Color.Empty; // Remove a cor de fundo na seleção
                        cell.Style.ForeColor = Color.Empty; // Remove a cor do texto
                    }
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                    CellColor = 1;
                }
                else
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.BackColor = Color.Empty; // Remove a cor de fundo
                        cell.Style.SelectionBackColor = Color.Empty; // Remove a cor de fundo na seleção
                        cell.Style.ForeColor = Color.Empty; // Remove a cor do texto
                    }
                    row.DefaultCellStyle.BackColor = Color.White;
                    CellColor = 0;
                }
            }
        }

        private void CurrentList_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in ((DataGridView)sender).SelectedCells)
            {
                if (CellColor == 1)
                {
                    cell.Style = new DataGridViewCellStyle()
                    {
                        BackColor = Color.LightBlue,
                        SelectionBackColor = Color.LightBlue,
                        SelectionForeColor = Color.Black
                    };
                }
                else
                {
                    cell.Style = new DataGridViewCellStyle()
                    {
                        BackColor = Color.White,
                        SelectionBackColor = Color.White,
                        SelectionForeColor = Color.Black
                    };
                }
            }
        }

        private void CurrentList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewCell cell in ((DataGridView)sender).SelectedCells)
            {
                if (CellColor == 1)
                {
                    cell.Style = new DataGridViewCellStyle()
                    {
                        BackColor = Color.LightBlue,
                        SelectionBackColor = Color.LightBlue,
                        SelectionForeColor = Color.Black
                    };
                }
                else
                {
                    cell.Style = new DataGridViewCellStyle()
                    {
                        BackColor = Color.White,
                        SelectionBackColor = Color.White,
                        SelectionForeColor = Color.Black
                    };
                }
            }
        }

        //Adicionar e Remover empresas de Lista
        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {

        }

        //Return and Close Button
        private void btnReturnStart_Click(object sender, EventArgs e)
        {
            if (ReturnBtnFunc == 1)
            {
                this.Close();
            }
            if (ReturnBtnFunc == 2)
            {
                CreationPanel.Enabled = false;
                CreationPanel.Visible = false;

                EditPanel.Enabled = false;
                EditPanel.Visible = false;

                ListEditPanel.Enabled = false;
                ListEditPanel.Visible = false;

                StartPanel.Enabled = true;
                StartPanel.Visible = true;

                TitleChange();
            }
        }

        public void TitleChange()
        {
            if (StartPanel.Visible)
            {
                BingoTitle.Text = "Bingo Manager";
                btnReturnStart.Text = "Fechar";
                ReturnBtnFunc = 1;
            }
            if (CreationPanel.Visible)
            {
                BingoTitle.Text = "Bingo Manager";
                btnReturnStart.Text = "Voltar";
                ReturnBtnFunc = 2;
            }
            if (EditPanel.Visible)
            {
                BingoTitle.Text = "Bingo Manager";
                btnReturnStart.Text = "Voltar";
                ReturnBtnFunc = 2;
            }
            if (ListEditPanel.Visible)
            {
                BingoTitle.Text = "Editar Listas";
                btnReturnStart.Text = "Voltar";
                ReturnBtnFunc = 2;
            }
        }

    }
}
