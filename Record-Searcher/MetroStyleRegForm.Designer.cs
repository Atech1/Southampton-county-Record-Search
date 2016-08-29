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
            this.listView1 = new MetroFramework.Controls.MetroListView();
            this.Btn1 = new System.Windows.Forms.Button();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.progressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.ProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
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
            this.SearchBox.Location = new System.Drawing.Point(23, 79);
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
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BackColor = System.Drawing.Color.FloralWhite;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(23, 122);
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(596, 267);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.UseSelectable = true;
            // 
            // Btn1
            // 
            this.Btn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn1.Location = new System.Drawing.Point(560, 426);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(75, 23);
            this.Btn1.TabIndex = 2;
            this.Btn1.Text = "Search";
            this.metroToolTip1.SetToolTip(this.Btn1, "Click to Search");
            this.Btn1.UseVisualStyleBackColor = true;
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
            this.metroTile1.Location = new System.Drawing.Point(7, 410);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(62, 39);
            this.metroTile1.TabIndex = 3;
            this.metroTile1.Text = "Reload";
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.UseTileImage = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(200, 239);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(244, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // ProgressSpinner1
            // 
            this.ProgressSpinner1.Location = new System.Drawing.Point(287, 165);
            this.ProgressSpinner1.Maximum = 100;
            this.ProgressSpinner1.Name = "ProgressSpinner1";
            this.ProgressSpinner1.Size = new System.Drawing.Size(34, 32);
            this.ProgressSpinner1.TabIndex = 5;
            this.ProgressSpinner1.UseSelectable = true;
            // 
            // MetroStyleRegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 456);
            this.Controls.Add(this.ProgressSpinner1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.Btn1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.SearchBox);
            this.Name = "MetroStyleRegForm";
            this.Text = "Searcher";
            this.Load += new System.EventHandler(this.MetroStyleRegForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox SearchBox;
        private MetroFramework.Controls.MetroListView listView1;
        private System.Windows.Forms.Button Btn1;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroProgressBar progressBar1;
        private MetroFramework.Controls.MetroProgressSpinner ProgressSpinner1;
    }
}