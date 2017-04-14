namespace Hunting
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
            this.board = new System.Windows.Forms.Panel();
            this.levlabel = new System.Windows.Forms.Label();
            this.prey = new System.Windows.Forms.PictureBox();
            this.note = new System.Windows.Forms.Label();
            this.cat = new System.Windows.Forms.PictureBox();
            this.showScore = new System.Windows.Forms.Label();
            this.showescapes = new System.Windows.Forms.Label();
            this.gotIt = new System.Windows.Forms.Label();
            this.hole1 = new System.Windows.Forms.PictureBox();
            this.hole2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.axWindowsMediaPlayer2 = new AxWMPLib.AxWindowsMediaPlayer();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.laser = new System.Windows.Forms.PictureBox();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.laslab = new System.Windows.Forms.Label();
            this.board.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hole1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hole2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laser)).BeginInit();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.Color.Transparent;
            this.board.Controls.Add(this.laslab);
            this.board.Controls.Add(this.laser);
            this.board.Controls.Add(this.levlabel);
            this.board.Controls.Add(this.prey);
            this.board.Controls.Add(this.note);
            this.board.Controls.Add(this.cat);
            this.board.Controls.Add(this.showScore);
            this.board.Controls.Add(this.showescapes);
            this.board.Controls.Add(this.gotIt);
            this.board.Controls.Add(this.hole1);
            this.board.Controls.Add(this.hole2);
            this.board.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.board.Location = new System.Drawing.Point(0, 47);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(704, 347);
            this.board.TabIndex = 0;
            // 
            // levlabel
            // 
            this.levlabel.AutoSize = true;
            this.levlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levlabel.ForeColor = System.Drawing.Color.White;
            this.levlabel.Location = new System.Drawing.Point(306, 177);
            this.levlabel.Name = "levlabel";
            this.levlabel.Size = new System.Drawing.Size(96, 25);
            this.levlabel.TabIndex = 14;
            this.levlabel.Text = "Level 2!";
            this.levlabel.Visible = false;
            // 
            // prey
            // 
            this.prey.Image = ((System.Drawing.Image)(resources.GetObject("prey.Image")));
            this.prey.Location = new System.Drawing.Point(97, 87);
            this.prey.Name = "prey";
            this.prey.Size = new System.Drawing.Size(50, 41);
            this.prey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.prey.TabIndex = 2;
            this.prey.TabStop = false;
            // 
            // note
            // 
            this.note.AutoSize = true;
            this.note.BackColor = System.Drawing.Color.Transparent;
            this.note.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.note.ForeColor = System.Drawing.Color.White;
            this.note.Location = new System.Drawing.Point(316, 310);
            this.note.Name = "note";
            this.note.Size = new System.Drawing.Size(59, 20);
            this.note.TabIndex = 13;
            this.note.Text = "Got it!";
            this.note.Visible = false;
            // 
            // cat
            // 
            this.cat.Image = ((System.Drawing.Image)(resources.GetObject("cat.Image")));
            this.cat.Location = new System.Drawing.Point(362, 30);
            this.cat.Name = "cat";
            this.cat.Size = new System.Drawing.Size(154, 98);
            this.cat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cat.TabIndex = 1;
            this.cat.TabStop = false;
            // 
            // showScore
            // 
            this.showScore.AutoSize = true;
            this.showScore.BackColor = System.Drawing.Color.Transparent;
            this.showScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showScore.ForeColor = System.Drawing.Color.Red;
            this.showScore.Location = new System.Drawing.Point(604, 3);
            this.showScore.Name = "showScore";
            this.showScore.Size = new System.Drawing.Size(76, 20);
            this.showScore.TabIndex = 3;
            this.showScore.Text = "Score: 0";
            // 
            // showescapes
            // 
            this.showescapes.AutoSize = true;
            this.showescapes.BackColor = System.Drawing.Color.Transparent;
            this.showescapes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showescapes.ForeColor = System.Drawing.Color.Red;
            this.showescapes.Location = new System.Drawing.Point(541, 23);
            this.showescapes.Name = "showescapes";
            this.showescapes.Size = new System.Drawing.Size(139, 20);
            this.showescapes.TabIndex = 5;
            this.showescapes.Text = "Escaped Prey: 0";
            this.showescapes.Click += new System.EventHandler(this.label1_Click);
            // 
            // gotIt
            // 
            this.gotIt.AutoSize = true;
            this.gotIt.BackColor = System.Drawing.Color.Transparent;
            this.gotIt.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gotIt.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gotIt.Location = new System.Drawing.Point(71, 160);
            this.gotIt.Name = "gotIt";
            this.gotIt.Size = new System.Drawing.Size(0, 33);
            this.gotIt.TabIndex = 0;
            this.gotIt.Visible = false;
            this.gotIt.Click += new System.EventHandler(this.gotIt_Click);
            // 
            // hole1
            // 
            this.hole1.Location = new System.Drawing.Point(122, 160);
            this.hole1.Name = "hole1";
            this.hole1.Size = new System.Drawing.Size(56, 51);
            this.hole1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hole1.TabIndex = 5;
            this.hole1.TabStop = false;
            // 
            // hole2
            // 
            this.hole2.Location = new System.Drawing.Point(535, 240);
            this.hole2.Name = "hole2";
            this.hole2.Size = new System.Drawing.Size(53, 58);
            this.hole2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hole2.TabIndex = 6;
            this.hole2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 7);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(75, 23);
            this.axWindowsMediaPlayer1.TabIndex = 5;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // axWindowsMediaPlayer2
            // 
            this.axWindowsMediaPlayer2.Enabled = true;
            this.axWindowsMediaPlayer2.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer2.Name = "axWindowsMediaPlayer2";
            this.axWindowsMediaPlayer2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer2.OcxState")));
            this.axWindowsMediaPlayer2.Size = new System.Drawing.Size(75, 23);
            this.axWindowsMediaPlayer2.TabIndex = 6;
            this.axWindowsMediaPlayer2.Visible = false;
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick_1);
            // 
            // laser
            // 
            this.laser.Image = ((System.Drawing.Image)(resources.GetObject("laser.Image")));
            this.laser.Location = new System.Drawing.Point(143, 325);
            this.laser.Name = "laser";
            this.laser.Size = new System.Drawing.Size(154, 10);
            this.laser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.laser.TabIndex = 15;
            this.laser.TabStop = false;
            this.laser.Visible = false;
            // 
            // timer4
            // 
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // laslab
            // 
            this.laslab.AutoSize = true;
            this.laslab.BackColor = System.Drawing.Color.Transparent;
            this.laslab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laslab.ForeColor = System.Drawing.Color.Red;
            this.laslab.Location = new System.Drawing.Point(673, 318);
            this.laslab.Name = "laslab";
            this.laslab.Size = new System.Drawing.Size(19, 20);
            this.laslab.TabIndex = 16;
            this.laslab.Text = "0";
            this.laslab.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(704, 394);
            this.Controls.Add(this.axWindowsMediaPlayer2);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.board);
            this.Name = "Form1";
            this.Text = "Critter Chase";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.board.ResumeLayout(false);
            this.board.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hole1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hole2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel board;
        private System.Windows.Forms.PictureBox prey;
        private System.Windows.Forms.PictureBox cat;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label showScore;
        private System.Windows.Forms.Label gotIt;
        private System.Windows.Forms.PictureBox hole2;
        private System.Windows.Forms.PictureBox hole1;
        private System.Windows.Forms.Label showescapes;
        private System.Windows.Forms.Label note;
        private System.Windows.Forms.Timer timer2;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label levlabel;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.PictureBox laser;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Label laslab;
    }
}

