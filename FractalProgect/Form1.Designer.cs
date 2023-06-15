namespace FractalProgect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuContainer = new System.Windows.Forms.GroupBox();
            this.testContainer = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Wind = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.svaeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.fractalsContainer = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.krug = new System.Windows.Forms.RadioButton();
            this.serpinski = new System.Windows.Forms.RadioButton();
            this.pifagor = new System.Windows.Forms.RadioButton();
            this.koh = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuContainer.SuspendLayout();
            this.testContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.fractalsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuContainer
            // 
            this.menuContainer.BackColor = System.Drawing.Color.White;
            this.menuContainer.Controls.Add(this.testContainer);
            this.menuContainer.Controls.Add(this.fractalsContainer);
            this.menuContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.menuContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuContainer.Location = new System.Drawing.Point(360, 0);
            this.menuContainer.Name = "menuContainer";
            this.menuContainer.Size = new System.Drawing.Size(440, 450);
            this.menuContainer.TabIndex = 0;
            this.menuContainer.TabStop = false;
            // 
            // testContainer
            // 
            this.testContainer.BackColor = System.Drawing.Color.Black;
            this.testContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.testContainer.Controls.Add(this.button2);
            this.testContainer.Controls.Add(this.Wind);
            this.testContainer.Controls.Add(this.button1);
            this.testContainer.Controls.Add(this.svaeButton);
            this.testContainer.Controls.Add(this.label2);
            this.testContainer.Controls.Add(this.trackBar1);
            this.testContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testContainer.Location = new System.Drawing.Point(3, 131);
            this.testContainer.Name = "testContainer";
            this.testContainer.Size = new System.Drawing.Size(434, 316);
            this.testContainer.TabIndex = 1;
            this.testContainer.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightCoral;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(120, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 38);
            this.button2.TabIndex = 5;
            this.button2.Text = "Стоп ветер";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Wind
            // 
            this.Wind.BackColor = System.Drawing.Color.LightGreen;
            this.Wind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Wind.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Wind.ForeColor = System.Drawing.Color.Black;
            this.Wind.Location = new System.Drawing.Point(7, 106);
            this.Wind.Name = "Wind";
            this.Wind.Size = new System.Drawing.Size(107, 38);
            this.Wind.TabIndex = 4;
            this.Wind.Text = "Старт";
            this.Wind.UseVisualStyleBackColor = false;
            this.Wind.Click += new System.EventHandler(this.Wind_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(120, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 47);
            this.button1.TabIndex = 3;
            this.button1.Text = "Заставка";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // svaeButton
            // 
            this.svaeButton.BackColor = System.Drawing.Color.Black;
            this.svaeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.svaeButton.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.svaeButton.ForeColor = System.Drawing.Color.White;
            this.svaeButton.Location = new System.Drawing.Point(3, 223);
            this.svaeButton.Name = "svaeButton";
            this.svaeButton.Size = new System.Drawing.Size(111, 47);
            this.svaeButton.TabIndex = 2;
            this.svaeButton.Text = "Создать Gif";
            this.svaeButton.UseVisualStyleBackColor = false;
            this.svaeButton.Click += new System.EventHandler(this.svaeButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 16.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ветер";
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.Black;
            this.trackBar1.Location = new System.Drawing.Point(7, 55);
            this.trackBar1.Maximum = 9;
            this.trackBar1.Minimum = -9;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(300, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TabStop = false;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // fractalsContainer
            // 
            this.fractalsContainer.BackColor = System.Drawing.Color.Black;
            this.fractalsContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fractalsContainer.Controls.Add(this.radioButton1);
            this.fractalsContainer.Controls.Add(this.trackBar2);
            this.fractalsContainer.Controls.Add(this.label1);
            this.fractalsContainer.Controls.Add(this.krug);
            this.fractalsContainer.Controls.Add(this.serpinski);
            this.fractalsContainer.Controls.Add(this.pifagor);
            this.fractalsContainer.Controls.Add(this.koh);
            this.fractalsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.fractalsContainer.Location = new System.Drawing.Point(3, 16);
            this.fractalsContainer.Name = "fractalsContainer";
            this.fractalsContainer.Size = new System.Drawing.Size(434, 115);
            this.fractalsContainer.TabIndex = 0;
            this.fractalsContainer.TabStop = false;
            this.fractalsContainer.Text = "groupBox1";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 116);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            // 
            // trackBar2
            // 
            this.trackBar2.BackColor = System.Drawing.Color.Black;
            this.trackBar2.Location = new System.Drawing.Point(120, 40);
            this.trackBar2.Maximum = 12;
            this.trackBar2.Minimum = 1;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(187, 45);
            this.trackBar2.TabIndex = 7;
            this.trackBar2.Value = 1;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(120, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Поколение";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // krug
            // 
            this.krug.AutoSize = true;
            this.krug.BackColor = System.Drawing.Color.Black;
            this.krug.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.krug.ForeColor = System.Drawing.Color.White;
            this.krug.Location = new System.Drawing.Point(7, 92);
            this.krug.Name = "krug";
            this.krug.Size = new System.Drawing.Size(107, 21);
            this.krug.TabIndex = 3;
            this.krug.Text = "radioButton4";
            this.krug.UseVisualStyleBackColor = false;
            this.krug.CheckedChanged += new System.EventHandler(this.krug_CheckedChanged);
            // 
            // serpinski
            // 
            this.serpinski.AutoSize = true;
            this.serpinski.BackColor = System.Drawing.Color.Black;
            this.serpinski.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serpinski.ForeColor = System.Drawing.Color.White;
            this.serpinski.Location = new System.Drawing.Point(7, 68);
            this.serpinski.Name = "serpinski";
            this.serpinski.Size = new System.Drawing.Size(107, 21);
            this.serpinski.TabIndex = 2;
            this.serpinski.Text = "radioButton3";
            this.serpinski.UseVisualStyleBackColor = false;
            this.serpinski.CheckedChanged += new System.EventHandler(this.serpinski_CheckedChanged);
            // 
            // pifagor
            // 
            this.pifagor.AutoSize = true;
            this.pifagor.BackColor = System.Drawing.Color.Black;
            this.pifagor.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pifagor.ForeColor = System.Drawing.Color.White;
            this.pifagor.Location = new System.Drawing.Point(7, 44);
            this.pifagor.Name = "pifagor";
            this.pifagor.Size = new System.Drawing.Size(107, 21);
            this.pifagor.TabIndex = 1;
            this.pifagor.Text = "radioButton2";
            this.pifagor.UseVisualStyleBackColor = false;
            this.pifagor.CheckedChanged += new System.EventHandler(this.pifagor_CheckedChanged);
            // 
            // koh
            // 
            this.koh.AutoSize = true;
            this.koh.BackColor = System.Drawing.Color.Black;
            this.koh.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.koh.ForeColor = System.Drawing.Color.White;
            this.koh.Location = new System.Drawing.Point(7, 20);
            this.koh.Name = "koh";
            this.koh.Size = new System.Drawing.Size(107, 21);
            this.koh.TabIndex = 0;
            this.koh.Text = "radioButton1";
            this.koh.UseVisualStyleBackColor = false;
            this.koh.CheckedChanged += new System.EventHandler(this.koh_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Size = new System.Drawing.Size(360, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Фракталы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuContainer.ResumeLayout(false);
            this.testContainer.ResumeLayout(false);
            this.testContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.fractalsContainer.ResumeLayout(false);
            this.fractalsContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox menuContainer;
        private System.Windows.Forms.GroupBox fractalsContainer;
        private System.Windows.Forms.GroupBox testContainer;
        private System.Windows.Forms.RadioButton koh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton krug;
        private System.Windows.Forms.RadioButton serpinski;
        private System.Windows.Forms.RadioButton pifagor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button svaeButton;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Wind;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

