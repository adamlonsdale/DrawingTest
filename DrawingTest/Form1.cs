using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace DrawingTest
{
    public partial class Form1 : Form
    {
        #region Global Variables
        static Properties.Settings settings = Properties.Settings.Default;
        List<pathEvent> path = new List<pathEvent>();
        DateTime start;
        Graphics g;
        Bitmap saveImg;
        Pen pen = new Pen(settings.penColor, settings.penSize);
        bool doDraw = false;
        bool alreadyDrawn = false;
        bool stop = false;
        bool isDrawing = false;
        bool mouseUp = false;
        Point lastPoint;
        Point thisPoint;
        Size beforeMove;
        #endregion

        #region Help Text
        Dictionary<string, string> helpText = new Dictionary<string, string>()
        {
            {"open", "Open a saved .draw file."},
            {"save", "Save the current drawing to a .draw file."},
            {"savepng", "Saves the current drawing to a PNG image."},
            {"exit", "Close the program."},
            {"clear", "Clear the current drawing and start over."},
            {"list", "Shows or hides the coordinate list."},
            {"fastdraw", "Enables or disables fast (untimed) redrawing."},
            {"altpensize", "Shows or hides alternative pen sizing buttons for computers without scroll wheels."},
            {"antialias", "Enables or disables smooth rendering of the lines."},
            {"savebgpng", "Enables and disables saving the background color in the PNG image."},
            {"redraw", "Redraw the current drawing."},
            {"stop", "Stops the drawing in its current state"},
            {"pensizeplus", "Increase the size of the pen by 1 pixel."},
            {"pensizeminus", "Decrease the size of the pen by 1 pixel."}
        };

        /// <summary>
        /// Shows or hides a help string about the current menu item
        /// </summary>
        /// <param name="index">Which help sting to show (can be blank when hiding)</param>
        /// <param name="show">True to show the help text, false to restore pen size text</param>
        private void doHelp(string index, bool show) // true to show, false to hide
        {
            tslblPenSize.Visible = (show) ? false : true;
            tslblHelpText.Visible = (show) ? true : false;
            try
            {
                tslblHelpText.Text = (show) ? helpText[index] : "";
            }
            catch (Exception e)
            {
                tslblHelpText.Text = "Error: Help text not found";
            }
        }
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Generates a Unix Timestamp
        /// </summary>
        /// <returns>An unsigned int32 containing the current timestamp</returns>
        public int UnixTimeNow()
        {
            TimeSpan _ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (int)_ts.TotalSeconds;
        }

        /// <summary>
        /// Save the current drawing to a PNG image
        /// </summary>
        /// <param name="filename">The filepath where the PNG should be saved</param>
        private void saveToPNG(string filename)
        {
            saveImg = new Bitmap((int)g.VisibleClipBounds.Width, (int)g.VisibleClipBounds.Height);
            Graphics tempg = Graphics.FromImage(saveImg);

            if (settings.saveBgPNG)
                tempg.Clear(this.BackColor);

            tempg.SmoothingMode = (settings.antiAlias) ? SmoothingMode.AntiAlias : SmoothingMode.None;

            for (int i = 0; i < path.Count; i++)
            {
                pathEvent point = path[i];
                if (point.eventType == 0)
                {
                    pen.Color = Color.FromArgb(point.penColor); // We just needed the pen color from this first point
                    continue;
                }

                lastPoint = path[i - 1].coor;
                thisPoint = point.coor;
                pen.Width = point.penSize;

                if (point.eventType == 2)
                    tempg.DrawLine(pen, lastPoint, thisPoint);
            }

            saveImg.Save(filename);
        }

        /// <summary>
        /// Saves the current drawing to a DRAW file
        /// </summary>
        /// <param name="saveFile">The filepath where the DRAW file should be saved</param>
        private void saveDrawing(string saveFile)
        {
            FileStream fs = new FileStream(saveFile, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            // Write header
            bw.Write((int)1463898692); // string "DRAW"
            bw.Write((byte)2); // version
            bw.Write((byte)12); // entry length
            bw.Write((short)path.Count); // numEntries
            bw.Write((int)this.BackColor.ToArgb());
            bw.Flush();

            // Write entries
            // Identifiers: 0 = mousedown, 1 = mouseup, 2 = pathpoint
            foreach (pathEvent point in path)
            {
                switch (point.eventType)
                {
                    case 0: // mousedown
                        bw.Write((byte)point.eventType);
                        bw.Write((short)point.coor.X);
                        bw.Write((short)point.coor.Y);
                        bw.Write((short)point.wait);
                        bw.Write((byte)point.penSize);
                        bw.Write((int)point.penColor);
                        break;
                    case 1: // mouseup
                        bw.Write((byte)point.eventType);
                        bw.Write((short)point.coor.X);
                        bw.Write((short)point.coor.Y);
                        bw.Write((short)point.wait);
                        bw.Write((byte)point.penSize);
                        bw.Write((int)0);
                        break;
                    case 2: // pathpoint
                        bw.Write((byte)point.eventType);
                        bw.Write((short)point.coor.X);
                        bw.Write((short)point.coor.Y);
                        bw.Write((short)point.wait);
                        bw.Write((byte)point.penSize);
                        bw.Write((int)0);
                        break;
                }
                bw.Flush();
            }

            bw.Write((int)1718576479); // string "_eof"
            bw.Close();
            fs.Close();
        }

        /// <summary>
        /// Opens a DRAW file
        /// </summary>
        /// <param name="filename">The filepath of the DRAW file to be opened</param>
        private void openDrawing(string filename)
        {
            path.Clear();
            listBox1.Items.Clear();
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            // Read header
            if (br.ReadInt32() != 1463898692) // Confirm DRAW header
            {
                MessageBox.Show("Error: Not a valid DRAW file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte version = br.ReadByte(); // Read the version
           

            if (br.ReadByte() != 12) // read the entry length
            {
                MessageBox.Show("Error: Invalid entry length", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            short numEntries = br.ReadInt16(); // self explanatory
            int backColor = br.ReadInt32();
            settings.backColor = backColor;
            settings.Save();
            this.BackColor = Color.FromArgb(backColor);

            // Read entries
            listBox1.BeginUpdate();
            for (short i = 0; i < numEntries; i++)
            {
                byte eventType = br.ReadByte();
                pathEvent point = new pathEvent()
                {
                    eventType = eventType,
                    coor = new Point(br.ReadInt16(), br.ReadInt16()),
                    wait = br.ReadInt16(),
                    penSize = br.ReadByte(),
                    penColor = (eventType == 0) ? br.ReadInt32() : pen.Color.ToArgb()
                };

                if (eventType != 0)
                    br.BaseStream.Position += 4;

                path.Add(point);
                listBox1.Items.Add(point.coor.X + "x" + point.coor.Y + ", " + point.wait + ", " + point.penSize);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
            listBox1.EndUpdate();

            br.Close();
            fs.Close();

            isDrawing = true;
            reDraw(backColor, settings.fastRedraw);
            isDrawing = false;
        }

   
        /// <summary>
        /// Redraws the current drawing
        /// </summary>
        /// <param name="backColor">Background color for the drawing</param>
        /// <param name="fastDraw">True to do an instant draw, false to wait between points</param>
        private void reDraw(int backColor, bool fastDraw)
        {
            stopDrawingToolStripMenuItem.Visible = true;
            redrawToolStripMenuItem.Visible = false;
            this.ContextMenuStrip = null;
            stop = false;
            g.Clear(Color.FromArgb(backColor));
            for (int i = 0; i < path.Count; i++)
            {
                if (!stop)
                {
                    pathEvent point = path[i];
                    if (point.eventType == 0)
                    {
                        pen.Color = Color.FromArgb(point.penColor); // We just needed the pen color from this first point
                        if(!fastDraw)
                            System.Threading.Thread.Sleep(point.wait);
                        continue;
                    }

                    lastPoint = path[i - 1].coor;
                    thisPoint = point.coor;
                    pen.Width = point.penSize;
                    tslblPenSize.Text = "Pen Size: " + pen.Width;
                    listBox1.SelectedIndex = i;

                    if (point.eventType == 2)
                        g.DrawLine(pen, lastPoint, thisPoint);

                    if(!fastDraw)
                        System.Threading.Thread.Sleep(point.wait);

                    Application.DoEvents();
                }
            }
            stopDrawingToolStripMenuItem.Visible = false;
            redrawToolStripMenuItem.Visible = true;
            this.ContextMenuStrip = contextMenuStrip1;
            stop = true;

            if (!saveToolStripMenuItem.Enabled)
                saveToolStripMenuItem.Enabled = true;

            if (!saveToPNGToolStripMenuItem.Enabled)
                saveToPNGToolStripMenuItem.Enabled = true;

            if (!redrawToolStripMenuItem.Enabled)
                redrawToolStripMenuItem.Enabled = true;

            if (!clearToolStripMenuItem.Enabled)
                clearToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Provides a simple way to change the pen size
        /// </summary>
        /// <param name="changeAmount">Usually (always) 1, the amount to change the pen size by</param>
        /// <param name="delta">Positive to increase pen size, negative to decrease</param>
        private void changePenSize(int changeAmount, int delta)
        {
            if (pen.Width <= 255)
            {
                if (delta < 0)
                {
                    changeAmount *= -1;
                }
                if (pen.Width + changeAmount > 0 && pen.Width + changeAmount <= 255)
                {
                    pen.Width += (float)changeAmount;
                }

                if (!tslblPenSize.Visible)
                {
                    tslblHelpText.Visible = false;
                    tslblPenSize.Visible = true;
                }
                tslblPenSize.Text = "Pen Size: " + pen.Width;
                settings.penSize = (byte)pen.Width;
            }
        }

        #region Event Handlers
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!alreadyDrawn)
            {
                this.BackColor = Color.FromArgb(settings.backColor);
                g = this.CreateGraphics();
                g.Clear(Color.FromArgb(settings.backColor));
                g.SmoothingMode = (settings.antiAlias) ? SmoothingMode.AntiAlias : SmoothingMode.None;
                alreadyDrawn = true;
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
            }
        }

        #region Context Menu
        private void changeBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isDrawing)
            {
                colorDialog1.Color = Color.FromArgb(settings.backColor);
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    settings.backColor = colorDialog1.Color.ToArgb();
                    settings.Save();
                    this.BackColor = Color.FromArgb(settings.backColor);
                    reDraw(settings.backColor, settings.fastRedraw);
                }
            }
        }

        private void changePenColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isDrawing)
            {
                colorDialog1.Color = settings.penColor;
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    settings.penColor = colorDialog1.Color;
                    settings.Save();
                    pen.Color = settings.penColor;
                }
            }
        }
        #endregion

        #region Mouse Events
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && doDraw == false && !isDrawing)
            {
                short waitTime = 0;
                if (mouseUp)
                {
                    TimeSpan ts = (DateTime.Now - start);
                    waitTime = (short)ts.TotalMilliseconds;
                    if (waitTime > 1500)
                    {
                        waitTime = 1500;
                    }
                }
                start = DateTime.Now;
                pathEvent point = new pathEvent()
                {
                    eventType = 0,
                    coor = e.Location,
                    wait = waitTime,
                    penSize = (byte)pen.Width,
                    penColor = pen.Color.ToArgb()
                };
                path.Add(point);
                listBox1.Items.Add("0: " + e.X + "x" + e.Y + ", " + waitTime + ", " + pen.Width);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                thisPoint = e.Location;
                doDraw = true;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && doDraw == true)
            {
                pathEvent point = new pathEvent()
                {
                    eventType = 1,
                    coor = e.Location,
                    wait = 0,
                    penSize = (byte)pen.Width
                };
                path.Add(point);
                listBox1.Items.Add("1: " + e.X + "x" + e.Y + ", 0, " + pen.Width);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                doDraw = false;
                mouseUp = true;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (doDraw)
            {
                lastPoint = thisPoint;
                thisPoint = new Point(e.X, e.Y);
                g.DrawLine(pen, lastPoint, thisPoint);
                TimeSpan ts = (DateTime.Now - start);
                start = DateTime.Now;
                pathEvent spot = new pathEvent()
                {
                    eventType = 2,
                    coor = e.Location,
                    wait = (short)ts.TotalMilliseconds,
                    penSize = (byte)pen.Width
                };
                path.Add(spot);
                listBox1.Items.Add("2: " + e.X + "x" + e.Y + ", " + ts.TotalMilliseconds + ", " + pen.Width);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;

                if (!saveToolStripMenuItem.Enabled)
                    saveToolStripMenuItem.Enabled = true;

                if (!saveToPNGToolStripMenuItem.Enabled)
                    saveToPNGToolStripMenuItem.Enabled = true;

                if (!redrawToolStripMenuItem.Enabled)
                    redrawToolStripMenuItem.Enabled = true;

                if (!clearToolStripMenuItem.Enabled)
                    clearToolStripMenuItem.Enabled = true;
            }
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            int changeAmount = e.Delta / e.Delta;
            changePenSize(changeAmount, e.Delta);
        }
        #endregion

        #region Form Events
        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(settings.backColor);
            beforeMove = this.Size;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (beforeMove != this.Size)
            {
                g = this.CreateGraphics();
                reDraw(settings.backColor, settings.fastRedraw);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.formSize = this.Size;
            settings.formLoc = this.Location;
            settings.Save();
            stop = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = settings.formLoc;
            this.Size = settings.formSize;
            tslblPenSize.Text = "Pen Size: " + settings.penSize;
        }
        #endregion

        #region Toolstrip Events
        #region File
        #region Open
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult doOpen = DialogResult.No;
            if (path.Count > 0)
                doOpen = MessageBox.Show("You have a current drawing, would you like to save it before opening a new one?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (doOpen == DialogResult.Cancel)
            {
                return;
            }
            else if (doOpen == DialogResult.Yes)
            {
                saveToolStripMenuItem_Click((object)new ToolStripMenuItem(), new EventArgs());

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    openDrawing(ofd.FileName);
                }
            }
            else if (doOpen == DialogResult.No)
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    openDrawing(ofd.FileName);
                }
            }
        }

        private void openToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            doHelp("open", true);
        }

        private void openToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            doHelp("", false);
        }
        #endregion

        #region Save
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                saveDrawing(sfd.FileName);
            }
        }

        private void saveToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            doHelp("save", true);
        }

        private void saveToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            doHelp("", false);
        }
        #endregion

        #region Save To PNG
        private void saveToPNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdPng.ShowDialog() == DialogResult.OK)
            {
                saveToPNG(sfdPng.FileName);
            }
        }

        private void saveToPNGToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            doHelp("savepng", true);
        }

        private void saveToPNGToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            doHelp("", false);
        }
        #endregion

        #region Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stop = true;
            this.Close();
        }

        private void exitToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            doHelp("exit", true);
        }

        private void exitToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            doHelp("", false);
        }
        #endregion
        #endregion

        #region Clear
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            path.Clear();
            listBox1.Items.Clear();
            redrawToolStripMenuItem.Enabled = false;
            clearToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            saveToPNGToolStripMenuItem.Enabled = false;
            g.Clear(Color.FromArgb(settings.backColor));
            mouseUp = false;
        }

        private void clearToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            doHelp("clear", true);
        }

        private void clearToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            doHelp("", false);
        }
        #endregion

        #region Options
        #region Show List
        private void showListToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            settings.showList = showListToolStripMenuItem.Checked;
            listBox1.Visible = showListToolStripMenuItem.Checked;
            if (!showListToolStripMenuItem.Checked)
                reDraw(this.BackColor.ToArgb(), true);
        }

        private void showListToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            doHelp("list", true);
        }

        private void showListToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            doHelp("", false);
        }
        #endregion

        #region Fast Draw
        private void fastRedrawToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            settings.fastRedraw = fastRedrawToolStripMenuItem.Checked;
            settings.Save();
        }

        private void fastRedrawToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            doHelp("fastdraw", true);
        }

        private void fastRedrawToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            doHelp("", false);
        }
        #endregion

        #region Alternate Pen Sizing
        private void penSizeButtonsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            settings.altPenSize = penSizeButtonsToolStripMenuItem.Checked;
            penSizePlus.Visible = penSizeButtonsToolStripMenuItem.Checked;
            penSizeMinus.Visible = penSizeButtonsToolStripMenuItem.Checked;
        }

        private void penSizeButtonsToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            doHelp("altpensize", true);
        }

        private void penSizeButtonsToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            doHelp("", false);
        }
        #endregion

        #region Antialias
        private void antialiasingToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            settings.antiAlias = antialiasingToolStripMenuItem.Checked;

            if (antialiasingToolStripMenuItem.Checked)
                g.SmoothingMode = SmoothingMode.AntiAlias;
            else
                g.SmoothingMode = SmoothingMode.None;

            isDrawing = true;
            reDraw(this.BackColor.ToArgb(), settings.fastRedraw);
            isDrawing = false;
        }

        private void antialiasingToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            doHelp("antialias", true);
        }

        private void antialiasingToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            doHelp("", false);
        }
        #endregion

        #region Save BG Color in PNG
        private void saveBGColorInPNGToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            settings.saveBgPNG = saveBGColorInPNGToolStripMenuItem.Checked;
            settings.Save();
        }

        private void saveBGColorInPNGToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            doHelp("savebgpng", true);
        }

        private void saveBGColorInPNGToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            doHelp("", false);
        }
        #endregion
        #endregion

        #region Redraw
        private void redrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDrawing = true;
            
            //drawTimed(this.BackColor.ToArgb());
            reDraw(this.BackColor.ToArgb(), settings.fastRedraw);
            isDrawing = false;
        }

        private void redrawToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            doHelp("redraw", true);
        }

        private void redrawToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            doHelp("", false);
        }
        #endregion

        #region Stop Drawing
        private void stopDrawingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDrawing = false;
            stop = true;
            stopDrawingToolStripMenuItem.Visible = false;
            redrawToolStripMenuItem.Visible = true;
        }

        private void stopDrawingToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            doHelp("stop", true);
        }

        private void stopDrawingToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            doHelp("", false);
        }
        #endregion

        #region Pen Size +
        private void penSizePlus_Click(object sender, EventArgs e)
        {
            changePenSize(1, 1);
        }

        private void penSizePlus_MouseEnter(object sender, EventArgs e)
        {
            //doHelp("pensizeplus", true);
        }

        private void penSizePlus_MouseLeave(object sender, EventArgs e)
        {
            //doHelp("", false);
        }
        #endregion

        #region Pen Size -
        private void penSizeMinus_Click(object sender, EventArgs e)
        {
            changePenSize(1, -1);
        }

        private void penSizeMinus_MouseEnter(object sender, EventArgs e)
        {
            //doHelp("pensizeminus", true);
        }

        private void penSizeMinus_MouseLeave(object sender, EventArgs e)
        {
            //doHelp("", false);
        }
    #endregion

    #endregion

    #endregion

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
  }

  class pathEvent
    {
        public byte eventType { get; set; }
        public Point coor { get; set; }
        public short wait { get; set; }
        public byte penSize { get; set; }
        public int penColor { get; set; } // Only needs to be set in mousedown events
    }
}