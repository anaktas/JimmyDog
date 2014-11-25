namespace JimmyDog
{
    partial class MainConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainConfigForm));
            this.notifyTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.submittButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.maxConnectionBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyTrayIcon
            // 
            this.notifyTrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyTrayIcon.BalloonTipText = "Η εφαρμογή JimmyDog ξεκίνησε. Κάντε διπλό κλικ στο εικονίδιο για τις σχετικές ρυθ" +
                "μίσεις.";
            this.notifyTrayIcon.BalloonTipTitle = "JimmyDog";
            this.notifyTrayIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyTrayIcon.Icon")));
            this.notifyTrayIcon.Text = "notifyTrayIcon";
            this.notifyTrayIcon.Visible = true;
            this.notifyTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyTrayIcon_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripSeparator1,
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 148);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("configToolStripMenuItem.Image")));
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.configToolStripMenuItem.Text = "config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.aboutToolStripMenuItem.Text = "about";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(105, 6);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("startToolStripMenuItem.Image")));
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.startToolStripMenuItem.Text = "start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stopToolStripMenuItem.Image")));
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.stopToolStripMenuItem.Text = "stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("restartToolStripMenuItem.Image")));
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.restartToolStripMenuItem.Text = "restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(105, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.exitToolStripMenuItem.Text = "exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Διεύθυνση IP(π.χ. 127.0.0.1):";
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(17, 38);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(206, 20);
            this.ipTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Διαδρομή φακέλου root(π.χ. c:\\example\\):";
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(17, 77);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(206, 20);
            this.pathTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Θύρα:";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(17, 116);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(73, 20);
            this.portTextBox.TabIndex = 6;
            // 
            // submittButton
            // 
            this.submittButton.Location = new System.Drawing.Point(17, 191);
            this.submittButton.Name = "submittButton";
            this.submittButton.Size = new System.Drawing.Size(206, 27);
            this.submittButton.TabIndex = 7;
            this.submittButton.Text = "Αποθήκευση Ρυθμίσεων";
            this.submittButton.UseVisualStyleBackColor = true;
            this.submittButton.Click += new System.EventHandler(this.submittButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Μέγιστος Αριθμός Συνδέσεων:";
            // 
            // maxConnectionBox
            // 
            this.maxConnectionBox.Location = new System.Drawing.Point(17, 155);
            this.maxConnectionBox.Name = "maxConnectionBox";
            this.maxConnectionBox.Size = new System.Drawing.Size(73, 20);
            this.maxConnectionBox.TabIndex = 9;
            // 
            // MainConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 230);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.maxConnectionBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.submittButton);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainConfigForm";
            this.ShowInTaskbar = false;
            this.Text = "JimmyDog";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.MainConfigForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainConfigForm_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyTrayIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button submittButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox maxConnectionBox;
    }
}

