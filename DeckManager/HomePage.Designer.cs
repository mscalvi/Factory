namespace DeckManager
{
    partial class HomePage
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
            tabControl1 = new TabControl();
            TabHome = new TabPage();
            TabFinder = new TabPage();
            PnlFinder = new Panel();
            TxtFinder = new Label();
            FlwFinder = new FlowLayoutPanel();
            BoxFinder = new TextBox();
            tabControl1.SuspendLayout();
            TabFinder.SuspendLayout();
            PnlFinder.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(TabHome);
            tabControl1.Controls.Add(TabFinder);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1904, 1041);
            tabControl1.TabIndex = 0;
            // 
            // TabHome
            // 
            TabHome.Location = new Point(4, 24);
            TabHome.Name = "TabHome";
            TabHome.Padding = new Padding(3);
            TabHome.Size = new Size(1896, 1013);
            TabHome.TabIndex = 0;
            TabHome.Text = "tabPage1";
            TabHome.UseVisualStyleBackColor = true;
            // 
            // TabFinder
            // 
            TabFinder.Controls.Add(PnlFinder);
            TabFinder.Location = new Point(4, 24);
            TabFinder.Name = "TabFinder";
            TabFinder.Padding = new Padding(3);
            TabFinder.Size = new Size(1896, 1013);
            TabFinder.TabIndex = 1;
            TabFinder.Text = "tabPage2";
            TabFinder.UseVisualStyleBackColor = true;
            // 
            // PnlFinder
            // 
            PnlFinder.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PnlFinder.Controls.Add(TxtFinder);
            PnlFinder.Controls.Add(FlwFinder);
            PnlFinder.Controls.Add(BoxFinder);
            PnlFinder.Dock = DockStyle.Fill;
            PnlFinder.Location = new Point(3, 3);
            PnlFinder.Name = "PnlFinder";
            PnlFinder.Size = new Size(1890, 1007);
            PnlFinder.TabIndex = 0;
            // 
            // TxtFinder
            // 
            TxtFinder.Dock = DockStyle.Top;
            TxtFinder.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtFinder.Location = new Point(0, 0);
            TxtFinder.Name = "TxtFinder";
            TxtFinder.Size = new Size(1890, 128);
            TxtFinder.TabIndex = 2;
            TxtFinder.Text = "Card Finder";
            TxtFinder.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FlwFinder
            // 
            FlwFinder.AutoScroll = true;
            FlwFinder.Dock = DockStyle.Bottom;
            FlwFinder.Location = new Point(0, 201);
            FlwFinder.Name = "FlwFinder";
            FlwFinder.Size = new Size(1890, 806);
            FlwFinder.TabIndex = 1;
            // 
            // BoxFinder
            // 
            BoxFinder.Location = new Point(582, 149);
            BoxFinder.Name = "BoxFinder";
            BoxFinder.Size = new Size(727, 23);
            BoxFinder.TabIndex = 0;
            BoxFinder.TextChanged += BoxFinder_TextChanged;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(tabControl1);
            Name = "HomePage";
            Text = "Deck Manager";
            tabControl1.ResumeLayout(false);
            TabFinder.ResumeLayout(false);
            PnlFinder.ResumeLayout(false);
            PnlFinder.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage TabHome;
        private TabPage TabFinder;
        private Panel PnlFinder;
        private Label TxtFinder;
        private FlowLayoutPanel FlwFinder;
        private TextBox BoxFinder;
    }
}
