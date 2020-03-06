namespace Test_CSharp
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сепияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.точечныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.матричныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сепияToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.полутонToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инверсияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.собельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.блюрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.собельToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.резкостьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тиснениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.моушенБлюрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.щаррToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.щаррToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.прюиттToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прюиттToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(28, 34);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(432, 262);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(321, 200);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(626, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 89);
            this.button1.TabIndex = 1;
            this.button1.Text = "Точечный фильтр";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(28, 271);
            this.pictureBox2.MaximumSize = new System.Drawing.Size(432, 262);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(321, 198);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(387, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 354);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(585, 351);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(222, 78);
            this.button2.TabIndex = 6;
            this.button2.Text = "Увеличить яркость ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(476, 377);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 26);
            this.numericUpDown1.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(576, 94);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(254, 92);
            this.button3.TabIndex = 8;
            this.button3.Text = "Матричный фильтр";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сепияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1030, 33);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сепияToolStripMenuItem
            // 
            this.сепияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.точечныеToolStripMenuItem,
            this.матричныеToolStripMenuItem});
            this.сепияToolStripMenuItem.Name = "сепияToolStripMenuItem";
            this.сепияToolStripMenuItem.Size = new System.Drawing.Size(96, 29);
            this.сепияToolStripMenuItem.Text = "Фильтры";
            // 
            // точечныеToolStripMenuItem
            // 
            this.точечныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сепияToolStripMenuItem1,
            this.полутонToolStripMenuItem,
            this.инверсияToolStripMenuItem});
            this.точечныеToolStripMenuItem.Name = "точечныеToolStripMenuItem";
            this.точечныеToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.точечныеToolStripMenuItem.Text = "Точечные";
            // 
            // матричныеToolStripMenuItem
            // 
            this.матричныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.собельToolStripMenuItem,
            this.собельToolStripMenuItem1,
            this.блюрToolStripMenuItem,
            this.резкостьToolStripMenuItem,
            this.тиснениеToolStripMenuItem,
            this.моушенБлюрToolStripMenuItem,
            this.щаррToolStripMenuItem,
            this.щаррToolStripMenuItem1,
            this.прюиттToolStripMenuItem,
            this.прюиттToolStripMenuItem1});
            this.матричныеToolStripMenuItem.Name = "матричныеToolStripMenuItem";
            this.матричныеToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.матричныеToolStripMenuItem.Text = "Матричные";
            // 
            // сепияToolStripMenuItem1
            // 
            this.сепияToolStripMenuItem1.Name = "сепияToolStripMenuItem1";
            this.сепияToolStripMenuItem1.Size = new System.Drawing.Size(210, 30);
            this.сепияToolStripMenuItem1.Text = "Сепия";
            this.сепияToolStripMenuItem1.Click += new System.EventHandler(this.сепияToolStripMenuItem1_Click);
            // 
            // полутонToolStripMenuItem
            // 
            this.полутонToolStripMenuItem.Name = "полутонToolStripMenuItem";
            this.полутонToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.полутонToolStripMenuItem.Text = "Полутон";
            this.полутонToolStripMenuItem.Click += new System.EventHandler(this.полутонToolStripMenuItem_Click);
            // 
            // инверсияToolStripMenuItem
            // 
            this.инверсияToolStripMenuItem.Name = "инверсияToolStripMenuItem";
            this.инверсияToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.инверсияToolStripMenuItem.Text = "Инверсия";
            this.инверсияToolStripMenuItem.Click += new System.EventHandler(this.инверсияToolStripMenuItem_Click);
            // 
            // собельToolStripMenuItem
            // 
            this.собельToolStripMenuItem.Name = "собельToolStripMenuItem";
            this.собельToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.собельToolStripMenuItem.Text = "Собель \\/";
            this.собельToolStripMenuItem.Click += new System.EventHandler(this.собельToolStripMenuItem_Click);
            // 
            // блюрToolStripMenuItem
            // 
            this.блюрToolStripMenuItem.Name = "блюрToolStripMenuItem";
            this.блюрToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.блюрToolStripMenuItem.Text = "Блюр";
            this.блюрToolStripMenuItem.Click += new System.EventHandler(this.блюрToolStripMenuItem_Click);
            // 
            // собельToolStripMenuItem1
            // 
            this.собельToolStripMenuItem1.Name = "собельToolStripMenuItem1";
            this.собельToolStripMenuItem1.Size = new System.Drawing.Size(210, 30);
            this.собельToolStripMenuItem1.Text = "Собель ->";
            this.собельToolStripMenuItem1.Click += new System.EventHandler(this.собельToolStripMenuItem1_Click);
            // 
            // резкостьToolStripMenuItem
            // 
            this.резкостьToolStripMenuItem.Name = "резкостьToolStripMenuItem";
            this.резкостьToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.резкостьToolStripMenuItem.Text = "Резкость";
            this.резкостьToolStripMenuItem.Click += new System.EventHandler(this.резкостьToolStripMenuItem_Click);
            // 
            // тиснениеToolStripMenuItem
            // 
            this.тиснениеToolStripMenuItem.Name = "тиснениеToolStripMenuItem";
            this.тиснениеToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.тиснениеToolStripMenuItem.Text = "Тиснение";
            this.тиснениеToolStripMenuItem.Click += new System.EventHandler(this.тиснениеToolStripMenuItem_Click);
            // 
            // моушенБлюрToolStripMenuItem
            // 
            this.моушенБлюрToolStripMenuItem.Name = "моушенБлюрToolStripMenuItem";
            this.моушенБлюрToolStripMenuItem.Size = new System.Drawing.Size(215, 30);
            this.моушенБлюрToolStripMenuItem.Text = "Моушен Блюр";
            this.моушенБлюрToolStripMenuItem.Click += new System.EventHandler(this.моушенБлюрToolStripMenuItem_Click);
            // 
            // щаррToolStripMenuItem
            // 
            this.щаррToolStripMenuItem.Name = "щаррToolStripMenuItem";
            this.щаррToolStripMenuItem.Size = new System.Drawing.Size(215, 30);
            this.щаррToolStripMenuItem.Text = "Щарр \\/";
            this.щаррToolStripMenuItem.Click += new System.EventHandler(this.щаррToolStripMenuItem_Click);
            // 
            // щаррToolStripMenuItem1
            // 
            this.щаррToolStripMenuItem1.Name = "щаррToolStripMenuItem1";
            this.щаррToolStripMenuItem1.Size = new System.Drawing.Size(215, 30);
            this.щаррToolStripMenuItem1.Text = "Щарр ->";
            this.щаррToolStripMenuItem1.Click += new System.EventHandler(this.щаррToolStripMenuItem1_Click);
            // 
            // прюиттToolStripMenuItem
            // 
            this.прюиттToolStripMenuItem.Name = "прюиттToolStripMenuItem";
            this.прюиттToolStripMenuItem.Size = new System.Drawing.Size(215, 30);
            this.прюиттToolStripMenuItem.Text = "Прюитт \\/";
            this.прюиттToolStripMenuItem.Click += new System.EventHandler(this.прюиттToolStripMenuItem_Click);
            // 
            // прюиттToolStripMenuItem1
            // 
            this.прюиттToolStripMenuItem1.Name = "прюиттToolStripMenuItem1";
            this.прюиттToolStripMenuItem1.Size = new System.Drawing.Size(215, 30);
            this.прюиттToolStripMenuItem1.Text = "Прюитт ->";
            this.прюиттToolStripMenuItem1.Click += new System.EventHandler(this.прюиттToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 509);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "окошко";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сепияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem точечныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сепияToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem полутонToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem матричныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инверсияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem собельToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem блюрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem собельToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem резкостьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тиснениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem моушенБлюрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem щаррToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem щаррToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem прюиттToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прюиттToolStripMenuItem1;
    }
}

