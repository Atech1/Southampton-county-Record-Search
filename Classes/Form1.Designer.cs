namespace Record_Searcher
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.Click = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ModeSet = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // Click
            // 
            this.Click.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Click.Location = new System.Drawing.Point(739, 443);
            this.Click.Name = "Click";
            this.Click.Size = new System.Drawing.Size(75, 23);
            this.Click.TabIndex = 1;
            this.Click.Text = "Search";
            this.toolTip1.SetToolTip(this.Click, "Click to Search!");
            this.Click.UseVisualStyleBackColor = true;
            this.Click.Click += new System.EventHandler(this.Search_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(343, 20);
            this.textBox1.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBox1, "Put the Person\'s name in that you are searching for...\r\nwhole names will be faste" +
        "r than first or last");
            // 
            // ModeSet
            // 
            this.ModeSet.BackColor = System.Drawing.SystemColors.Control;
            this.ModeSet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ModeSet.Location = new System.Drawing.Point(12, 12);
            this.ModeSet.Name = "ModeSet";
            this.ModeSet.Size = new System.Drawing.Size(75, 23);
            this.ModeSet.TabIndex = 3;
            this.ModeSet.Text = "Deeds";
            this.toolTip1.SetToolTip(this.ModeSet, "Click to Change the Type of info you are searching.");
            this.ModeSet.UseVisualStyleBackColor = false;
            this.ModeSet.MouseEnter += new System.EventHandler(this.Highlight);
            this.ModeSet.MouseLeave += new System.EventHandler(this.DeLight);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Location = new System.Drawing.Point(12, 58);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(802, 369);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 478);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ModeSet);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Click);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.Loading);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Click;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ModeSet;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListView listView1;

    }
}

