using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SnakeTheGame
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.playButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.recordsButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.GamePanel = new System.Windows.Forms.Panel();
            this.textPoints = new System.Windows.Forms.TextBox();
            this.pause = new System.Windows.Forms.Button();
            this.menuBack = new System.Windows.Forms.Button();
            this.timer1 = new System.Timers.Timer();
            this.SettingPanel = new System.Windows.Forms.Panel();
            this.nickInput = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.defaultSettingsButton = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.mapType = new System.Windows.Forms.ComboBox();
            this.snakeSkin = new System.Windows.Forms.ComboBox();
            this.difficulty = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.RecordsTablePanel = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.MenuPanel.SuspendLayout();
            this.GamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
            this.SettingPanel.SuspendLayout();
            this.RecordsTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.Font = new System.Drawing.Font("Karlo Cham Brush", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playButton.Location = new System.Drawing.Point(62, 201);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(443, 123);
            this.playButton.TabIndex = 1;
            this.playButton.TabStop = false;
            this.playButton.Text = "Играть";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Font = new System.Drawing.Font("Karlo Cham Brush", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingsButton.Location = new System.Drawing.Point(62, 330);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(443, 123);
            this.settingsButton.TabIndex = 2;
            this.settingsButton.TabStop = false;
            this.settingsButton.Text = "Настройки";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // recordsButton
            // 
            this.recordsButton.Font = new System.Drawing.Font("Karlo Cham Brush", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recordsButton.Location = new System.Drawing.Point(62, 459);
            this.recordsButton.Name = "recordsButton";
            this.recordsButton.Size = new System.Drawing.Size(443, 123);
            this.recordsButton.TabIndex = 3;
            this.recordsButton.TabStop = false;
            this.recordsButton.Text = "Рекорды";
            this.recordsButton.UseVisualStyleBackColor = true;
            this.recordsButton.Click += new System.EventHandler(this.recordsButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Karlo Cham Brush", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitButton.Location = new System.Drawing.Point(62, 588);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(443, 123);
            this.exitButton.TabIndex = 0;
            this.exitButton.TabStop = false;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MenuPanel.BackgroundImage")));
            this.MenuPanel.Controls.Add(this.exitButton);
            this.MenuPanel.Controls.Add(this.playButton);
            this.MenuPanel.Controls.Add(this.settingsButton);
            this.MenuPanel.Controls.Add(this.recordsButton);
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(1600, 900);
            this.MenuPanel.TabIndex = 1;
            this.MenuPanel.Visible = false;
            // 
            // GamePanel
            // 
            this.GamePanel.Controls.Add(this.textPoints);
            this.GamePanel.Controls.Add(this.pause);
            this.GamePanel.Controls.Add(this.menuBack);
            this.GamePanel.Location = new System.Drawing.Point(0, 0);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(1590, 900);
            this.GamePanel.TabIndex = 0;
            this.GamePanel.Visible = false;
            this.GamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GamePanel_Paint);
            // 
            // textPoints
            // 
            this.textPoints.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textPoints.Location = new System.Drawing.Point(621, 780);
            this.textPoints.Name = "textPoints";
            this.textPoints.ReadOnly = true;
            this.textPoints.Size = new System.Drawing.Size(272, 31);
            this.textPoints.TabIndex = 2;
            this.textPoints.TabStop = false;
            this.textPoints.WordWrap = false;
            // 
            // pause
            // 
            this.pause.Font = new System.Drawing.Font("Karlo Cham Brush", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pause.Location = new System.Drawing.Point(1338, 780);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(194, 69);
            this.pause.TabIndex = 0;
            this.pause.TabStop = false;
            this.pause.Text = "Пауза";
            this.pause.UseVisualStyleBackColor = true;
            this.pause.Click += new System.EventHandler(this.pause_Click);
            // 
            // menuBack
            // 
            this.menuBack.Font = new System.Drawing.Font("Karlo Cham Brush", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuBack.Location = new System.Drawing.Point(12, 780);
            this.menuBack.Name = "menuBack";
            this.menuBack.Size = new System.Drawing.Size(194, 69);
            this.menuBack.TabIndex = 1;
            this.menuBack.TabStop = false;
            this.menuBack.Text = "Меню";
            this.menuBack.UseVisualStyleBackColor = true;
            this.menuBack.Click += new System.EventHandler(this.menuBack_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500D;
            this.timer1.SynchronizingObject = this;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            // 
            // SettingPanel
            // 
            this.SettingPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SettingPanel.BackgroundImage")));
            this.SettingPanel.Controls.Add(this.button3);
            this.SettingPanel.Controls.Add(this.nickInput);
            this.SettingPanel.Controls.Add(this.textBox5);
            this.SettingPanel.Controls.Add(this.button1);
            this.SettingPanel.Controls.Add(this.defaultSettingsButton);
            this.SettingPanel.Controls.Add(this.textBox4);
            this.SettingPanel.Controls.Add(this.textBox3);
            this.SettingPanel.Controls.Add(this.textBox2);
            this.SettingPanel.Controls.Add(this.mapType);
            this.SettingPanel.Controls.Add(this.snakeSkin);
            this.SettingPanel.Controls.Add(this.difficulty);
            this.SettingPanel.Controls.Add(this.textBox1);
            this.SettingPanel.Location = new System.Drawing.Point(0, 0);
            this.SettingPanel.Name = "SettingPanel";
            this.SettingPanel.Size = new System.Drawing.Size(1590, 900);
            this.SettingPanel.TabIndex = 2;
            this.SettingPanel.Visible = false;
            // 
            // nickInput
            // 
            this.nickInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nickInput.Location = new System.Drawing.Point(72, 634);
            this.nickInput.MaxLength = 30;
            this.nickInput.Name = "nickInput";
            this.nickInput.Size = new System.Drawing.Size(704, 47);
            this.nickInput.TabIndex = 12;
            this.nickInput.TabStop = false;
            this.nickInput.WordWrap = false;
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox5.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox5.Location = new System.Drawing.Point(72, 588);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(821, 40);
            this.textBox5.TabIndex = 11;
            this.textBox5.TabStop = false;
            this.textBox5.Text = "Никнейм: Player1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Karlo Cham Brush", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 780);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 69);
            this.button1.TabIndex = 10;
            this.button1.TabStop = false;
            this.button1.Text = "Меню";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.menuBack_Click);
            // 
            // defaultSettingsButton
            // 
            this.defaultSettingsButton.Font = new System.Drawing.Font("Karlo Cham Brush", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.defaultSettingsButton.Location = new System.Drawing.Point(1354, 752);
            this.defaultSettingsButton.Name = "defaultSettingsButton";
            this.defaultSettingsButton.Size = new System.Drawing.Size(194, 97);
            this.defaultSettingsButton.TabIndex = 9;
            this.defaultSettingsButton.TabStop = false;
            this.defaultSettingsButton.Text = "Сброс настроек";
            this.defaultSettingsButton.UseVisualStyleBackColor = true;
            this.defaultSettingsButton.Click += new System.EventHandler(this.defaultSettingsButton_Click);
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox4.Location = new System.Drawing.Point(920, 256);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(364, 40);
            this.textBox4.TabIndex = 8;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "Тип карты";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox3.Location = new System.Drawing.Point(496, 256);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(364, 40);
            this.textBox3.TabIndex = 7;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "Скин змейки";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox2.Location = new System.Drawing.Point(72, 256);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(364, 40);
            this.textBox2.TabIndex = 6;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "Сложность";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mapType
            // 
            this.mapType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapType.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mapType.FormattingEnabled = true;
            this.mapType.Items.AddRange(new object[] { "Коробка", "Стены слева-справа", "Стены сверху-снизу", "Без стен" });
            this.mapType.Location = new System.Drawing.Point(920, 313);
            this.mapType.Margin = new System.Windows.Forms.Padding(30);
            this.mapType.MaxDropDownItems = 4;
            this.mapType.Name = "mapType";
            this.mapType.Size = new System.Drawing.Size(364, 39);
            this.mapType.TabIndex = 5;
            this.mapType.TabStop = false;
            this.mapType.SelectedIndexChanged += new System.EventHandler(this.mapType_SelectedIndexChanged);
            // 
            // snakeSkin
            // 
            this.snakeSkin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.snakeSkin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.snakeSkin.FormattingEnabled = true;
            this.snakeSkin.Items.AddRange(new object[] { "Зелёная", "Красная", "Синяя" });
            this.snakeSkin.Location = new System.Drawing.Point(496, 313);
            this.snakeSkin.Margin = new System.Windows.Forms.Padding(30);
            this.snakeSkin.MaxDropDownItems = 4;
            this.snakeSkin.Name = "snakeSkin";
            this.snakeSkin.Size = new System.Drawing.Size(364, 39);
            this.snakeSkin.TabIndex = 4;
            this.snakeSkin.TabStop = false;
            this.snakeSkin.SelectedIndexChanged += new System.EventHandler(this.snakeSkin_SelectedIndexChanged);
            // 
            // difficulty
            // 
            this.difficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.difficulty.FormattingEnabled = true;
            this.difficulty.Items.AddRange(new object[] { "Легкая", "Средняя", "Сложная", "БОГ" });
            this.difficulty.Location = new System.Drawing.Point(72, 313);
            this.difficulty.Margin = new System.Windows.Forms.Padding(30);
            this.difficulty.MaxDropDownItems = 4;
            this.difficulty.Name = "difficulty";
            this.difficulty.Size = new System.Drawing.Size(364, 39);
            this.difficulty.TabIndex = 3;
            this.difficulty.TabStop = false;
            this.difficulty.SelectedIndexChanged += new System.EventHandler(this.difficulty_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(621, 780);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(272, 31);
            this.textBox1.TabIndex = 2;
            this.textBox1.TabStop = false;
            this.textBox1.WordWrap = false;
            // 
            // RecordsTablePanel
            // 
            this.RecordsTablePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RecordsTablePanel.BackgroundImage")));
            this.RecordsTablePanel.Controls.Add(this.dataGridView1);
            this.RecordsTablePanel.Controls.Add(this.button2);
            this.RecordsTablePanel.Location = new System.Drawing.Point(0, 0);
            this.RecordsTablePanel.Name = "RecordsTablePanel";
            this.RecordsTablePanel.Size = new System.Drawing.Size(1590, 900);
            this.RecordsTablePanel.TabIndex = 3;
            this.RecordsTablePanel.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dataGridView1.Location = new System.Drawing.Point(100, 200);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 50;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(900, 500);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Karlo Cham Brush", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(12, 780);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 69);
            this.button2.TabIndex = 10;
            this.button2.TabStop = false;
            this.button2.Text = "Меню";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.menuBack_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(72, 687);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 33);
            this.button3.TabIndex = 13;
            this.button3.Text = "Подтвердить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1560, 861);
            this.Controls.Add(this.SettingPanel);
            this.Controls.Add(this.RecordsTablePanel);
            this.Controls.Add(this.GamePanel);
            this.Controls.Add(this.MenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра Змейка";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MenuPanel.ResumeLayout(false);
            this.GamePanel.ResumeLayout(false);
            this.GamePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
            this.SettingPanel.ResumeLayout(false);
            this.SettingPanel.PerformLayout();
            this.RecordsTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.Panel RecordsTablePanel;
        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.TextBox nickInput;

        private System.Windows.Forms.TextBox textBox5;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Button defaultSettingsButton;

        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;

        private System.Windows.Forms.TextBox textBox2;

        private System.Windows.Forms.ComboBox difficulty;

        private System.Windows.Forms.ComboBox mapType;

        private System.Windows.Forms.ComboBox snakeSkin;

        private System.Windows.Forms.Panel SettingPanel;
        
        private System.Windows.Forms.TextBox textPoints;

        private System.Windows.Forms.TextBox textBox1;

        private System.Timers.Timer timer1;

        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.Button menuBack;
        private System.Windows.Forms.Button pause;
        
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button recordsButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button playButton;

        #endregion
    }
}