namespace Record_Searcher
{
    partial class MetroStyleRegForm
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
            this.SearchBox = new MetroFramework.Controls.MetroTextBox();
            this.Btn1 = new System.Windows.Forms.Button();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.progressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.lis = new System.Windows.Forms.ListView();
            this.ListView1 = new MetroFramework.Controls.MetroListView();
            this.SuspendLayout();
            // 
            // SearchBox
            // 
            // 
            // 
            // 
            this.SearchBox.CustomButton.Image = null;
            this.SearchBox.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.SearchBox.CustomButton.Name = "";
            this.SearchBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SearchBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SearchBox.CustomButton.TabIndex = 1;
            this.SearchBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SearchBox.CustomButton.UseSelectable = true;
            this.SearchBox.CustomButton.Visible = false;
            this.SearchBox.Lines = new string[0];
            this.SearchBox.Location = new System.Drawing.Point(7, 79);
            this.SearchBox.MaxLength = 32767;
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.PasswordChar = '\0';
            this.SearchBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SearchBox.SelectedText = "";
            this.SearchBox.SelectionLength = 0;
            this.SearchBox.SelectionStart = 0;
            this.SearchBox.ShortcutsEnabled = true;
            this.SearchBox.Size = new System.Drawing.Size(175, 23);
            this.SearchBox.TabIndex = 0;
            this.metroToolTip1.SetToolTip(this.SearchBox, "Put who you want to search for here.");
            this.SearchBox.UseSelectable = true;
            this.SearchBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SearchBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Btn1
            // 
            this.Btn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn1.Location = new System.Drawing.Point(544, 436);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(111, 23);
            this.Btn1.TabIndex = 2;
            this.Btn1.Text = "Search";
            this.metroToolTip1.SetToolTip(this.Btn1, "Click to Search");
            this.Btn1.UseVisualStyleBackColor = true;
            this.Btn1.Click += new System.EventHandler(this.Search_Click);
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroTile1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroTile1.Location = new System.Drawing.Point(7, 420);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(62, 39);
            this.metroTile1.TabIndex = 3;
            this.metroTile1.Text = "Reload";
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.UseTileImage = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(135, 420);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.Size = new System.Drawing.Size(403, 39);
            this.progressBar1.Style = MetroFramework.MetroColorStyle.Green;
            this.progressBar1.TabIndex = 4;
            // 
            // lis
            // 
            this.lis.Location = new System.Drawing.Point(10, 50);
            this.lis.Name = "lis";
            this.lis.Size = new System.Drawing.Size(121, 97);
            this.lis.TabIndex = 0;
            this.lis.UseCompatibleStateImageBehavior = false;
            // 
            // ListView1
            // 
            this.ListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ListView1.FullRowSelect = true;
            this.ListView1.Location = new System.Drawing.Point(7, 121);
            this.ListView1.Name = "ListView1";
            this.ListView1.Size = new System.Drawing.Size(648, 293);
            this.ListView1.TabIndex = 6;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.UseSelectable = true;
            // 
            // MetroStyleRegForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(662, 466);
            this.Controls.Add(this.ListView1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.Btn1);
            this.Controls.Add(this.SearchBox);
            this.Name = "MetroStyleRegForm";
            this.Text = "Searcher";
            this.Load += new System.EventHandler(this.MetroStyleRegForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox SearchBox;
        private System.Windows.Forms.Button Btn1;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroProgressBar progressBar1;
        private MetroFramework.Controls.MetroListView listView;
        private System.Windows.Forms.ListView lis;
        private MetroFramework.Controls.MetroListView ListView1;
    }
}