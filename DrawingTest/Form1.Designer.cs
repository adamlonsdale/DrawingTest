namespace DrawingTest
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.colorDialog1 = new System.Windows.Forms.ColorDialog();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.showListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.fastRedrawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.penSizeButtonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.antialiasingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveBGColorInPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.redrawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.stopDrawingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.penSizePlus = new System.Windows.Forms.ToolStripMenuItem();
      this.penSizeMinus = new System.Windows.Forms.ToolStripMenuItem();
      this.sfd = new System.Windows.Forms.SaveFileDialog();
      this.ofd = new System.Windows.Forms.OpenFileDialog();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.changeBackgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.changePenColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.tslblPenSize = new System.Windows.Forms.ToolStripStatusLabel();
      this.tslblHelpText = new System.Windows.Forms.ToolStripStatusLabel();
      this.sfdPng = new System.Windows.Forms.SaveFileDialog();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.menuStrip1.SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // colorDialog1
      // 
      this.colorDialog1.AnyColor = true;
      this.colorDialog1.FullOpen = true;
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.redrawToolStripMenuItem,
            this.stopDrawingToolStripMenuItem,
            this.penSizePlus,
            this.penSizeMinus});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
      this.menuStrip1.Size = new System.Drawing.Size(1612, 44);
      this.menuStrip1.TabIndex = 3;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveToPNGToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.Size = new System.Drawing.Size(248, 38);
      this.openToolStripMenuItem.Text = "Open";
      this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
      this.openToolStripMenuItem.MouseEnter += new System.EventHandler(this.openToolStripMenuItem_MouseEnter);
      this.openToolStripMenuItem.MouseLeave += new System.EventHandler(this.openToolStripMenuItem_MouseLeave);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Enabled = false;
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(248, 38);
      this.saveToolStripMenuItem.Text = "Save";
      this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
      this.saveToolStripMenuItem.MouseEnter += new System.EventHandler(this.saveToolStripMenuItem_MouseEnter);
      this.saveToolStripMenuItem.MouseLeave += new System.EventHandler(this.saveToolStripMenuItem_MouseLeave);
      // 
      // saveToPNGToolStripMenuItem
      // 
      this.saveToPNGToolStripMenuItem.Enabled = false;
      this.saveToPNGToolStripMenuItem.Name = "saveToPNGToolStripMenuItem";
      this.saveToPNGToolStripMenuItem.Size = new System.Drawing.Size(248, 38);
      this.saveToPNGToolStripMenuItem.Text = "Save to PNG";
      this.saveToPNGToolStripMenuItem.Click += new System.EventHandler(this.saveToPNGToolStripMenuItem_Click);
      this.saveToPNGToolStripMenuItem.MouseEnter += new System.EventHandler(this.saveToPNGToolStripMenuItem_MouseEnter);
      this.saveToPNGToolStripMenuItem.MouseLeave += new System.EventHandler(this.saveToPNGToolStripMenuItem_MouseLeave);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(245, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(248, 38);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      this.exitToolStripMenuItem.MouseEnter += new System.EventHandler(this.exitToolStripMenuItem_MouseEnter);
      this.exitToolStripMenuItem.MouseLeave += new System.EventHandler(this.exitToolStripMenuItem_MouseLeave);
      // 
      // clearToolStripMenuItem
      // 
      this.clearToolStripMenuItem.Enabled = false;
      this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
      this.clearToolStripMenuItem.Size = new System.Drawing.Size(81, 36);
      this.clearToolStripMenuItem.Text = "Clear";
      this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
      this.clearToolStripMenuItem.MouseEnter += new System.EventHandler(this.clearToolStripMenuItem_MouseEnter);
      this.clearToolStripMenuItem.MouseLeave += new System.EventHandler(this.clearToolStripMenuItem_MouseLeave);
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.Checked = true;
      this.optionsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showListToolStripMenuItem,
            this.fastRedrawToolStripMenuItem,
            this.penSizeButtonsToolStripMenuItem,
            this.antialiasingToolStripMenuItem,
            this.saveBGColorInPNGToolStripMenuItem});
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(111, 36);
      this.optionsToolStripMenuItem.Text = "Options";
      // 
      // showListToolStripMenuItem
      // 
      this.showListToolStripMenuItem.Checked = global::DrawingTest.Properties.Settings.Default.showList;
      this.showListToolStripMenuItem.CheckOnClick = true;
      this.showListToolStripMenuItem.Name = "showListToolStripMenuItem";
      this.showListToolStripMenuItem.Size = new System.Drawing.Size(347, 38);
      this.showListToolStripMenuItem.Text = "Show List";
      this.showListToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showListToolStripMenuItem_CheckedChanged);
      this.showListToolStripMenuItem.MouseEnter += new System.EventHandler(this.showListToolStripMenuItem_MouseEnter);
      this.showListToolStripMenuItem.MouseLeave += new System.EventHandler(this.showListToolStripMenuItem_MouseLeave);
      // 
      // fastRedrawToolStripMenuItem
      // 
      this.fastRedrawToolStripMenuItem.Checked = global::DrawingTest.Properties.Settings.Default.fastRedraw;
      this.fastRedrawToolStripMenuItem.CheckOnClick = true;
      this.fastRedrawToolStripMenuItem.Name = "fastRedrawToolStripMenuItem";
      this.fastRedrawToolStripMenuItem.Size = new System.Drawing.Size(347, 38);
      this.fastRedrawToolStripMenuItem.Text = "Fast Redraw";
      this.fastRedrawToolStripMenuItem.CheckedChanged += new System.EventHandler(this.fastRedrawToolStripMenuItem_CheckedChanged);
      this.fastRedrawToolStripMenuItem.MouseEnter += new System.EventHandler(this.fastRedrawToolStripMenuItem_MouseEnter);
      this.fastRedrawToolStripMenuItem.MouseLeave += new System.EventHandler(this.fastRedrawToolStripMenuItem_MouseLeave);
      // 
      // penSizeButtonsToolStripMenuItem
      // 
      this.penSizeButtonsToolStripMenuItem.Checked = global::DrawingTest.Properties.Settings.Default.altPenSize;
      this.penSizeButtonsToolStripMenuItem.CheckOnClick = true;
      this.penSizeButtonsToolStripMenuItem.Name = "penSizeButtonsToolStripMenuItem";
      this.penSizeButtonsToolStripMenuItem.Size = new System.Drawing.Size(347, 38);
      this.penSizeButtonsToolStripMenuItem.Text = "Alternate Pen Sizing";
      this.penSizeButtonsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.penSizeButtonsToolStripMenuItem_CheckedChanged);
      this.penSizeButtonsToolStripMenuItem.MouseEnter += new System.EventHandler(this.penSizeButtonsToolStripMenuItem_MouseEnter);
      this.penSizeButtonsToolStripMenuItem.MouseLeave += new System.EventHandler(this.penSizeButtonsToolStripMenuItem_MouseLeave);
      // 
      // antialiasingToolStripMenuItem
      // 
      this.antialiasingToolStripMenuItem.Checked = global::DrawingTest.Properties.Settings.Default.antiAlias;
      this.antialiasingToolStripMenuItem.CheckOnClick = true;
      this.antialiasingToolStripMenuItem.Name = "antialiasingToolStripMenuItem";
      this.antialiasingToolStripMenuItem.Size = new System.Drawing.Size(347, 38);
      this.antialiasingToolStripMenuItem.Text = "Antialiasing";
      this.antialiasingToolStripMenuItem.CheckedChanged += new System.EventHandler(this.antialiasingToolStripMenuItem_CheckedChanged);
      this.antialiasingToolStripMenuItem.MouseEnter += new System.EventHandler(this.antialiasingToolStripMenuItem_MouseEnter);
      this.antialiasingToolStripMenuItem.MouseLeave += new System.EventHandler(this.antialiasingToolStripMenuItem_MouseLeave);
      // 
      // saveBGColorInPNGToolStripMenuItem
      // 
      this.saveBGColorInPNGToolStripMenuItem.Checked = global::DrawingTest.Properties.Settings.Default.saveBgPNG;
      this.saveBGColorInPNGToolStripMenuItem.CheckOnClick = true;
      this.saveBGColorInPNGToolStripMenuItem.Name = "saveBGColorInPNGToolStripMenuItem";
      this.saveBGColorInPNGToolStripMenuItem.Size = new System.Drawing.Size(347, 38);
      this.saveBGColorInPNGToolStripMenuItem.Text = "Save BG Color in PNG";
      this.saveBGColorInPNGToolStripMenuItem.CheckedChanged += new System.EventHandler(this.saveBGColorInPNGToolStripMenuItem_CheckedChanged);
      this.saveBGColorInPNGToolStripMenuItem.MouseEnter += new System.EventHandler(this.saveBGColorInPNGToolStripMenuItem_MouseEnter);
      this.saveBGColorInPNGToolStripMenuItem.MouseLeave += new System.EventHandler(this.saveBGColorInPNGToolStripMenuItem_MouseLeave);
      // 
      // redrawToolStripMenuItem
      // 
      this.redrawToolStripMenuItem.Enabled = false;
      this.redrawToolStripMenuItem.Name = "redrawToolStripMenuItem";
      this.redrawToolStripMenuItem.Size = new System.Drawing.Size(104, 36);
      this.redrawToolStripMenuItem.Text = "Redraw";
      this.redrawToolStripMenuItem.Click += new System.EventHandler(this.redrawToolStripMenuItem_Click);
      this.redrawToolStripMenuItem.MouseEnter += new System.EventHandler(this.redrawToolStripMenuItem_MouseEnter);
      this.redrawToolStripMenuItem.MouseLeave += new System.EventHandler(this.redrawToolStripMenuItem_MouseLeave);
      // 
      // stopDrawingToolStripMenuItem
      // 
      this.stopDrawingToolStripMenuItem.Name = "stopDrawingToolStripMenuItem";
      this.stopDrawingToolStripMenuItem.Size = new System.Drawing.Size(170, 36);
      this.stopDrawingToolStripMenuItem.Text = "Stop Drawing";
      this.stopDrawingToolStripMenuItem.Visible = false;
      this.stopDrawingToolStripMenuItem.Click += new System.EventHandler(this.stopDrawingToolStripMenuItem_Click);
      this.stopDrawingToolStripMenuItem.MouseEnter += new System.EventHandler(this.stopDrawingToolStripMenuItem_MouseEnter);
      this.stopDrawingToolStripMenuItem.MouseLeave += new System.EventHandler(this.stopDrawingToolStripMenuItem_MouseLeave);
      // 
      // penSizePlus
      // 
      this.penSizePlus.Name = "penSizePlus";
      this.penSizePlus.Size = new System.Drawing.Size(43, 36);
      this.penSizePlus.Text = "+";
      this.penSizePlus.Visible = global::DrawingTest.Properties.Settings.Default.altPenSize;
      this.penSizePlus.Click += new System.EventHandler(this.penSizePlus_Click);
      this.penSizePlus.MouseEnter += new System.EventHandler(this.penSizePlus_MouseEnter);
      this.penSizePlus.MouseLeave += new System.EventHandler(this.penSizePlus_MouseLeave);
      // 
      // penSizeMinus
      // 
      this.penSizeMinus.Name = "penSizeMinus";
      this.penSizeMinus.Size = new System.Drawing.Size(37, 36);
      this.penSizeMinus.Text = "-";
      this.penSizeMinus.Visible = global::DrawingTest.Properties.Settings.Default.altPenSize;
      this.penSizeMinus.Click += new System.EventHandler(this.penSizeMinus_Click);
      this.penSizeMinus.MouseEnter += new System.EventHandler(this.penSizeMinus_MouseEnter);
      this.penSizeMinus.MouseLeave += new System.EventHandler(this.penSizeMinus_MouseLeave);
      // 
      // sfd
      // 
      this.sfd.DefaultExt = "draw";
      this.sfd.Filter = "Draw Files (*.draw)|*.draw";
      // 
      // ofd
      // 
      this.ofd.DefaultExt = "draw";
      this.ofd.Filter = "Draw Files (*.draw)|*.draw";
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeBackgroundColorToolStripMenuItem,
            this.changePenColorToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(308, 80);
      // 
      // changeBackgroundColorToolStripMenuItem
      // 
      this.changeBackgroundColorToolStripMenuItem.Name = "changeBackgroundColorToolStripMenuItem";
      this.changeBackgroundColorToolStripMenuItem.Size = new System.Drawing.Size(307, 38);
      this.changeBackgroundColorToolStripMenuItem.Text = "Change BG Color";
      this.changeBackgroundColorToolStripMenuItem.Click += new System.EventHandler(this.changeBackgroundColorToolStripMenuItem_Click);
      // 
      // changePenColorToolStripMenuItem
      // 
      this.changePenColorToolStripMenuItem.Name = "changePenColorToolStripMenuItem";
      this.changePenColorToolStripMenuItem.Size = new System.Drawing.Size(307, 38);
      this.changePenColorToolStripMenuItem.Text = "Change Pen Color";
      this.changePenColorToolStripMenuItem.Click += new System.EventHandler(this.changePenColorToolStripMenuItem_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblPenSize,
            this.tslblHelpText});
      this.statusStrip1.Location = new System.Drawing.Point(0, 1048);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
      this.statusStrip1.Size = new System.Drawing.Size(1612, 37);
      this.statusStrip1.TabIndex = 4;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // tslblPenSize
      // 
      this.tslblPenSize.BackColor = System.Drawing.SystemColors.Control;
      this.tslblPenSize.Name = "tslblPenSize";
      this.tslblPenSize.Size = new System.Drawing.Size(116, 32);
      this.tslblPenSize.Text = "Pen Size: ";
      // 
      // tslblHelpText
      // 
      this.tslblHelpText.BackColor = System.Drawing.SystemColors.Control;
      this.tslblHelpText.Name = "tslblHelpText";
      this.tslblHelpText.Size = new System.Drawing.Size(0, 32);
      this.tslblHelpText.Visible = false;
      // 
      // sfdPng
      // 
      this.sfdPng.DefaultExt = "png";
      this.sfdPng.Filter = "Draw Files (*.png)|*.png";
      // 
      // listBox1
      // 
      this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listBox1.FormattingEnabled = true;
      this.listBox1.IntegralHeight = false;
      this.listBox1.ItemHeight = 25;
      this.listBox1.Location = new System.Drawing.Point(1272, 52);
      this.listBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(330, 981);
      this.listBox1.TabIndex = 2;
      this.listBox1.TabStop = false;
      this.listBox1.Visible = global::DrawingTest.Properties.Settings.Default.showList;
      this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1612, 1085);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Controls.Add(this.listBox1);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.Text = "Drawing Test";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
      this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
      this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseWheel);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.contextMenuStrip1.ResumeLayout(false);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem changeBackgroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePenColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redrawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopDrawingToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslblPenSize;
        private System.Windows.Forms.ToolStripMenuItem fastRedrawToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tslblHelpText;
        private System.Windows.Forms.ToolStripMenuItem penSizeButtonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penSizePlus;
        private System.Windows.Forms.ToolStripMenuItem penSizeMinus;
        private System.Windows.Forms.ToolStripMenuItem antialiasingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToPNGToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfdPng;
        private System.Windows.Forms.ToolStripMenuItem saveBGColorInPNGToolStripMenuItem;

    }
}

