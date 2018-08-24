namespace Pacman
{
    partial class ControllerMainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControllerMainForm));
            this.StartPause_btn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxLevel0 = new System.Windows.Forms.Label();
            this.pictureBoxLevel1 = new System.Windows.Forms.Label();
            this.pictureBoxLives0 = new System.Windows.Forms.Label();
            this.pictureBoxLives1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxLives2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxLives3 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLives1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLives2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLives3)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartPause_btn
            // 
            this.StartPause_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartPause_btn.ForeColor = System.Drawing.Color.Red;
            this.StartPause_btn.Location = new System.Drawing.Point(564, 451);
            this.StartPause_btn.Name = "StartPause_btn";
            this.StartPause_btn.Size = new System.Drawing.Size(130, 51);
            this.StartPause_btn.TabIndex = 0;
            this.StartPause_btn.Text = "Старт / Пауза";
            this.StartPause_btn.UseVisualStyleBackColor = true;
            this.StartPause_btn.Click += new System.EventHandler(this.StartPause_btn_Click);
            this.StartPause_btn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartPause_btn_KeyDown);
            this.StartPause_btn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.StartPause_btn_PreviewKeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.играToolStripMenuItem,
            this.информацияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(704, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGameToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExitToolStripMenuItem});
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.играToolStripMenuItem.Text = "Игра";
            // 
            // NewGameToolStripMenuItem
            // 
            this.NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem";
            this.NewGameToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.NewGameToolStripMenuItem.Text = "Новая игра";
            this.NewGameToolStripMenuItem.Click += new System.EventHandler(this.NewGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // информацияToolStripMenuItem
            // 
            this.информацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
            this.информацияToolStripMenuItem.Name = "информацияToolStripMenuItem";
            this.информацияToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.информацияToolStripMenuItem.Text = "Информация";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.AboutToolStripMenuItem.Text = "Об игре";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Pacman.Properties.Resources.line2;
            this.pictureBox4.Location = new System.Drawing.Point(550, 54);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(4, 520);
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Pacman.Properties.Resources.line2;
            this.pictureBox3.Location = new System.Drawing.Point(26, 54);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(4, 520);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Pacman.Properties.Resources.line1;
            this.pictureBox2.Location = new System.Drawing.Point(26, 574);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(528, 4);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Pacman.Properties.Resources.line1;
            this.pictureBox1.Location = new System.Drawing.Point(26, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(528, 4);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxLevel0
            // 
            this.pictureBoxLevel0.AutoSize = true;
            this.pictureBoxLevel0.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pictureBoxLevel0.ForeColor = System.Drawing.Color.Aqua;
            this.pictureBoxLevel0.Location = new System.Drawing.Point(567, 69);
            this.pictureBoxLevel0.Name = "pictureBoxLevel0";
            this.pictureBoxLevel0.Size = new System.Drawing.Size(127, 31);
            this.pictureBoxLevel0.TabIndex = 7;
            this.pictureBoxLevel0.Text = "Уровень:";
            // 
            // pictureBoxLevel1
            // 
            this.pictureBoxLevel1.AutoSize = true;
            this.pictureBoxLevel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pictureBoxLevel1.ForeColor = System.Drawing.Color.Aqua;
            this.pictureBoxLevel1.Location = new System.Drawing.Point(607, 105);
            this.pictureBoxLevel1.Name = "pictureBoxLevel1";
            this.pictureBoxLevel1.Size = new System.Drawing.Size(42, 46);
            this.pictureBoxLevel1.TabIndex = 8;
            this.pictureBoxLevel1.Text = "1";
            // 
            // pictureBoxLives0
            // 
            this.pictureBoxLives0.AutoSize = true;
            this.pictureBoxLives0.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pictureBoxLives0.ForeColor = System.Drawing.Color.Aqua;
            this.pictureBoxLives0.Location = new System.Drawing.Point(580, 194);
            this.pictureBoxLives0.Name = "pictureBoxLives0";
            this.pictureBoxLives0.Size = new System.Drawing.Size(105, 31);
            this.pictureBoxLives0.TabIndex = 9;
            this.pictureBoxLives0.Text = "Жизни:";
            // 
            // pictureBoxLives1
            // 
            this.pictureBoxLives1.Image = global::Pacman.Properties.Resources.BodyPacman;
            this.pictureBoxLives1.Location = new System.Drawing.Point(591, 241);
            this.pictureBoxLives1.Name = "pictureBoxLives1";
            this.pictureBoxLives1.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxLives1.TabIndex = 10;
            this.pictureBoxLives1.TabStop = false;
            // 
            // pictureBoxLives2
            // 
            this.pictureBoxLives2.Image = global::Pacman.Properties.Resources.BodyPacman;
            this.pictureBoxLives2.Location = new System.Drawing.Point(617, 241);
            this.pictureBoxLives2.Name = "pictureBoxLives2";
            this.pictureBoxLives2.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxLives2.TabIndex = 11;
            this.pictureBoxLives2.TabStop = false;
            // 
            // pictureBoxLives3
            // 
            this.pictureBoxLives3.Image = global::Pacman.Properties.Resources.BodyPacman;
            this.pictureBoxLives3.Location = new System.Drawing.Point(643, 241);
            this.pictureBoxLives3.Name = "pictureBoxLives3";
            this.pictureBoxLives3.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxLives3.TabIndex = 12;
            this.pictureBoxLives3.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 602);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(704, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // ControllerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(704, 624);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBoxLives3);
            this.Controls.Add(this.pictureBoxLives2);
            this.Controls.Add(this.pictureBoxLives1);
            this.Controls.Add(this.pictureBoxLives0);
            this.Controls.Add(this.pictureBoxLevel1);
            this.Controls.Add(this.pictureBoxLevel0);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.StartPause_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(720, 662);
            this.MinimumSize = new System.Drawing.Size(720, 662);
            this.Name = "ControllerMainForm";
            this.Text = "Pacman";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControllerMainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLives1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLives2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLives3)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartPause_btn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label pictureBoxLevel0;
        private System.Windows.Forms.Label pictureBoxLevel1;
        private System.Windows.Forms.Label pictureBoxLives0;
        private System.Windows.Forms.PictureBox pictureBoxLives1;
        private System.Windows.Forms.PictureBox pictureBoxLives2;
        private System.Windows.Forms.PictureBox pictureBoxLives3;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem информацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

