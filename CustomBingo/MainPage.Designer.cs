namespace CustomBingo
{
    partial class MainPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PnlGeneralMenu = new Panel();
            BtnStart = new Button();
            BtnCreate = new Button();
            BtnEdit = new Button();
            BtnPlay = new Button();
            PnlContent = new Panel();
            mainPageView = new Views.MainPageView();
            createView = new Views.CreateView();
            editView = new Views.EditView();
            playView = new Views.PlayView();
            PnlGeneralMenu.SuspendLayout();
            PnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // PnlGeneralMenu
            // 
            PnlGeneralMenu.AutoSize = true;
            PnlGeneralMenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PnlGeneralMenu.Controls.Add(BtnStart);
            PnlGeneralMenu.Controls.Add(BtnCreate);
            PnlGeneralMenu.Controls.Add(BtnEdit);
            PnlGeneralMenu.Controls.Add(BtnPlay);
            PnlGeneralMenu.Dock = DockStyle.Left;
            PnlGeneralMenu.Location = new Point(0, 0);
            PnlGeneralMenu.Name = "PnlGeneralMenu";
            PnlGeneralMenu.Padding = new Padding(2);
            PnlGeneralMenu.Size = new Size(142, 650);
            PnlGeneralMenu.TabIndex = 0;
            // 
            // BtnStart
            // 
            BtnStart.Anchor = AnchorStyles.Left;
            BtnStart.Location = new Point(5, 122);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(132, 91);
            BtnStart.TabIndex = 1;
            BtnStart.Text = "Início";
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStart_Click;
            // 
            // BtnCreate
            // 
            BtnCreate.Anchor = AnchorStyles.Left;
            BtnCreate.Location = new Point(5, 227);
            BtnCreate.Name = "BtnCreate";
            BtnCreate.Size = new Size(132, 91);
            BtnCreate.TabIndex = 2;
            BtnCreate.Text = "Criar";
            BtnCreate.UseVisualStyleBackColor = true;
            BtnCreate.Click += BtnCreate_Click;
            // 
            // BtnEdit
            // 
            BtnEdit.Anchor = AnchorStyles.Left;
            BtnEdit.Location = new Point(5, 332);
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(132, 91);
            BtnEdit.TabIndex = 3;
            BtnEdit.Text = "Editar";
            BtnEdit.UseVisualStyleBackColor = true;
            BtnEdit.Click += BtnEdit_Click;
            // 
            // BtnPlay
            // 
            BtnPlay.Anchor = AnchorStyles.Left;
            BtnPlay.Location = new Point(5, 437);
            BtnPlay.Name = "BtnPlay";
            BtnPlay.Size = new Size(132, 91);
            BtnPlay.TabIndex = 4;
            BtnPlay.Text = "Jogar";
            BtnPlay.UseVisualStyleBackColor = true;
            BtnPlay.Click += BtnPlay_Click;
            // 
            // PnlContent
            // 
            PnlContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PnlContent.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PnlContent.Controls.Add(mainPageView);
            PnlContent.Controls.Add(createView);
            PnlContent.Controls.Add(editView);
            PnlContent.Controls.Add(playView);
            PnlContent.Location = new Point(156, 12);
            PnlContent.Name = "PnlContent";
            PnlContent.Size = new Size(934, 626);
            PnlContent.TabIndex = 1;
            // 
            // mainPageView
            // 
            mainPageView.BackColor = Color.FromArgb(0, 0, 192);
            mainPageView.Dock = DockStyle.Fill;
            mainPageView.Location = new Point(0, 0);
            mainPageView.Name = "mainPageView";
            mainPageView.Size = new Size(934, 626);
            mainPageView.TabIndex = 2;
            // 
            // createView
            // 
            createView.BackColor = Color.White;
            createView.Dock = DockStyle.Fill;
            createView.Location = new Point(0, 0);
            createView.Name = "createView";
            createView.Size = new Size(934, 626);
            createView.TabIndex = 0;
            // 
            // editView
            // 
            editView.BackColor = Color.White;
            editView.Dock = DockStyle.Fill;
            editView.Location = new Point(0, 0);
            editView.Name = "editView";
            editView.Size = new Size(934, 626);
            editView.TabIndex = 1;
            // 
            // playView
            // 
            playView.Dock = DockStyle.Fill;
            playView.Location = new Point(0, 0);
            playView.Name = "playView";
            playView.Size = new Size(934, 626);
            playView.TabIndex = 3;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1102, 650);
            Controls.Add(PnlContent);
            Controls.Add(PnlGeneralMenu);
            Name = "MainPage";
            Text = "Custom Bingo Manager";
            WindowState = FormWindowState.Maximized;
            PnlGeneralMenu.ResumeLayout(false);
            PnlContent.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel PnlGeneralMenu;
        public Button BtnPlay;
        public Button BtnEdit;
        public Button BtnCreate;
        public Button BtnStart;
        private Panel PnlContent;
        private Views.PlayView playView;
        private Views.MainPageView mainPageView;
        private Views.EditView editView;
        private Views.CreateView createView;
    }
}
