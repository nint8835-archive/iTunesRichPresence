namespace iTunesRichPresence {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pollTimer = new System.Windows.Forms.Timer(this.components);
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.RightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideButton = new System.Windows.Forms.Button();
            this.detailsTextBox = new System.Windows.Forms.TextBox();
            this.stateTextBox = new System.Windows.Forms.TextBox();
            this.formatLabel = new System.Windows.Forms.Label();
            this.tokenHeadingLabel = new System.Windows.Forms.Label();
            this.tokenDetailsTextBox = new System.Windows.Forms.TextBox();
            this.RightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pollTimer
            // 
            this.pollTimer.Interval = 15000;
            this.pollTimer.Tick += new System.EventHandler(this.pollTimer_Tick);
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.RightClickMenu;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "iTunesRichPresence";
            this.TrayIcon.Visible = true;
            this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // RightClickMenu
            // 
            this.RightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.RightClickMenu.Name = "contextMenuStrip1";
            this.RightClickMenu.Size = new System.Drawing.Size(98, 26);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // hideButton
            // 
            this.hideButton.Location = new System.Drawing.Point(12, 253);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(288, 23);
            this.hideButton.TabIndex = 1;
            this.hideButton.Text = "Hide to System Tray";
            this.hideButton.UseVisualStyleBackColor = true;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            // 
            // detailsTextBox
            // 
            this.detailsTextBox.Location = new System.Drawing.Point(12, 29);
            this.detailsTextBox.Name = "detailsTextBox";
            this.detailsTextBox.Size = new System.Drawing.Size(288, 20);
            this.detailsTextBox.TabIndex = 2;
            this.detailsTextBox.TextChanged += new System.EventHandler(this.detailsTextBox_TextChanged);
            // 
            // stateTextBox
            // 
            this.stateTextBox.Location = new System.Drawing.Point(12, 55);
            this.stateTextBox.Name = "stateTextBox";
            this.stateTextBox.Size = new System.Drawing.Size(288, 20);
            this.stateTextBox.TabIndex = 3;
            this.stateTextBox.TextChanged += new System.EventHandler(this.stateTextBox_TextChanged);
            // 
            // formatLabel
            // 
            this.formatLabel.AutoSize = true;
            this.formatLabel.Location = new System.Drawing.Point(13, 13);
            this.formatLabel.Name = "formatLabel";
            this.formatLabel.Size = new System.Drawing.Size(67, 13);
            this.formatLabel.TabIndex = 4;
            this.formatLabel.Text = "Line Formats";
            // 
            // tokenHeadingLabel
            // 
            this.tokenHeadingLabel.AutoSize = true;
            this.tokenHeadingLabel.Location = new System.Drawing.Point(13, 78);
            this.tokenHeadingLabel.Name = "tokenHeadingLabel";
            this.tokenHeadingLabel.Size = new System.Drawing.Size(98, 13);
            this.tokenHeadingLabel.TabIndex = 5;
            this.tokenHeadingLabel.Text = "Formatting Tokens:";
            // 
            // tokenDetailsTextBox
            // 
            this.tokenDetailsTextBox.Location = new System.Drawing.Point(12, 94);
            this.tokenDetailsTextBox.Multiline = true;
            this.tokenDetailsTextBox.Name = "tokenDetailsTextBox";
            this.tokenDetailsTextBox.ReadOnly = true;
            this.tokenDetailsTextBox.Size = new System.Drawing.Size(288, 153);
            this.tokenDetailsTextBox.TabIndex = 6;
            this.tokenDetailsTextBox.Text = "%artist: Current artist\r\n%title: Current track\r\n%playlist_type: Type of current p" +
    "laylist (Playlist, Album, etc.)\r\n%playlist_name: Name of current playlist";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 288);
            this.Controls.Add(this.tokenDetailsTextBox);
            this.Controls.Add(this.tokenHeadingLabel);
            this.Controls.Add(this.formatLabel);
            this.Controls.Add(this.stateTextBox);
            this.Controls.Add(this.detailsTextBox);
            this.Controls.Add(this.hideButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "iTunesRichPresence";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.RightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer pollTimer;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip RightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Button hideButton;
        private System.Windows.Forms.TextBox detailsTextBox;
        private System.Windows.Forms.TextBox stateTextBox;
        private System.Windows.Forms.Label formatLabel;
        private System.Windows.Forms.Label tokenHeadingLabel;
        private System.Windows.Forms.TextBox tokenDetailsTextBox;
    }
}

