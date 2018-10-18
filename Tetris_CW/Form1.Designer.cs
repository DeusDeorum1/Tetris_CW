namespace Tetris_CW
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.play = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.newGameButton = new System.Windows.Forms.Button();
            this.liderboardButton = new System.Windows.Forms.Button();
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.nextFigureGrid = new System.Windows.Forms.DataGridView();
            this.C1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextFigureGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.CausesValidation = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14});
            this.dataGridView1.Location = new System.Drawing.Point(51, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(214, 397);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellStyleChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellStyleChanged);
            this.dataGridView1.CellStyleContentChanged += new System.Windows.Forms.DataGridViewCellStyleContentChangedEventHandler(this.dataGridView1_CellStyleContentChanged);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 15;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 15;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 15;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 15;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 15;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 15;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 15;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Column8";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 15;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Column9";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 15;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Column10";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 15;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Column11";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 15;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Column12";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 15;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Column13";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 15;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "Column14";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(271, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Rotate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(271, 409);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Skip";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // play
            // 
            this.play.Location = new System.Drawing.Point(271, 72);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(120, 23);
            this.play.TabIndex = 3;
            this.play.Text = "PLAY";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Next figure:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Score:";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(335, 222);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(13, 13);
            this.scoreLabel.TabIndex = 18;
            this.scoreLabel.Text = "0";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(271, 322);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(120, 23);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(271, 351);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(120, 23);
            this.loadButton.TabIndex = 20;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(271, 43);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(120, 23);
            this.newGameButton.TabIndex = 21;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // liderboardButton
            // 
            this.liderboardButton.Location = new System.Drawing.Point(271, 238);
            this.liderboardButton.Name = "liderboardButton";
            this.liderboardButton.Size = new System.Drawing.Size(120, 23);
            this.liderboardButton.TabIndex = 22;
            this.liderboardButton.Text = "Leaderboard";
            this.liderboardButton.UseVisualStyleBackColor = true;
            this.liderboardButton.Click += new System.EventHandler(this.liderboardButton_Click);
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.AutoSize = true;
            this.playerNameLabel.Location = new System.Drawing.Point(48, 9);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(89, 13);
            this.playerNameLabel.TabIndex = 23;
            this.playerNameLabel.Text = "playerNameLabel";
            // 
            // nextFigureGrid
            // 
            this.nextFigureGrid.AllowUserToAddRows = false;
            this.nextFigureGrid.AllowUserToDeleteRows = false;
            this.nextFigureGrid.AllowUserToResizeColumns = false;
            this.nextFigureGrid.AllowUserToResizeRows = false;
            this.nextFigureGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.nextFigureGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.nextFigureGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nextFigureGrid.ColumnHeadersVisible = false;
            this.nextFigureGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C1,
            this.C2,
            this.C3});
            this.nextFigureGrid.Location = new System.Drawing.Point(288, 126);
            this.nextFigureGrid.MultiSelect = false;
            this.nextFigureGrid.Name = "nextFigureGrid";
            this.nextFigureGrid.ReadOnly = true;
            this.nextFigureGrid.RowHeadersVisible = false;
            this.nextFigureGrid.Size = new System.Drawing.Size(67, 83);
            this.nextFigureGrid.TabIndex = 24;
            this.nextFigureGrid.TabStop = false;
            // 
            // C1
            // 
            this.C1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.C1.HeaderText = "";
            this.C1.Name = "C1";
            this.C1.ReadOnly = true;
            this.C1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // C2
            // 
            this.C2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.C2.HeaderText = "";
            this.C2.Name = "C2";
            this.C2.ReadOnly = true;
            this.C2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // C3
            // 
            this.C3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.C3.HeaderText = "";
            this.C3.Name = "C3";
            this.C3.ReadOnly = true;
            this.C3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 452);
            this.Controls.Add(this.nextFigureGrid);
            this.Controls.Add(this.playerNameLabel);
            this.Controls.Add(this.liderboardButton);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.play);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Name = "Form1";
            this.Text = "Tetris";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextFigureGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button liderboardButton;
        public System.Windows.Forms.Label playerNameLabel;
        private System.Windows.Forms.DataGridView nextFigureGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn C1;
        private System.Windows.Forms.DataGridViewTextBoxColumn C2;
        private System.Windows.Forms.DataGridViewTextBoxColumn C3;
    }
}

