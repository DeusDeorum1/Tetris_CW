namespace Tetris_CW
{
    partial class leaderboardForm
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
            this.dataLeader = new System.Windows.Forms.DataGridView();
            this.addPlayerButton = new System.Windows.Forms.Button();
            this.selectPlayerButton = new System.Windows.Forms.Button();
            this.deletePlayerButton = new System.Windows.Forms.Button();
            this.playerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataLeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLeader
            // 
            this.dataLeader.AllowUserToAddRows = false;
            this.dataLeader.AllowUserToDeleteRows = false;
            this.dataLeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataLeader.AutoGenerateColumns = false;
            this.dataLeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataLeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.scoreDataGridViewTextBoxColumn});
            this.dataLeader.DataSource = this.playerBindingSource;
            this.dataLeader.Location = new System.Drawing.Point(12, 12);
            this.dataLeader.Name = "dataLeader";
            this.dataLeader.ReadOnly = true;
            this.dataLeader.Size = new System.Drawing.Size(260, 206);
            this.dataLeader.TabIndex = 0;
            // 
            // addPlayerButton
            // 
            this.addPlayerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addPlayerButton.Location = new System.Drawing.Point(12, 224);
            this.addPlayerButton.Name = "addPlayerButton";
            this.addPlayerButton.Size = new System.Drawing.Size(83, 23);
            this.addPlayerButton.TabIndex = 1;
            this.addPlayerButton.Text = "Add";
            this.addPlayerButton.UseVisualStyleBackColor = true;
            this.addPlayerButton.Click += new System.EventHandler(this.addPlayerButton_Click);
            // 
            // selectPlayerButton
            // 
            this.selectPlayerButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.selectPlayerButton.Location = new System.Drawing.Point(101, 224);
            this.selectPlayerButton.Name = "selectPlayerButton";
            this.selectPlayerButton.Size = new System.Drawing.Size(83, 23);
            this.selectPlayerButton.TabIndex = 2;
            this.selectPlayerButton.Text = "Select";
            this.selectPlayerButton.UseVisualStyleBackColor = true;
            this.selectPlayerButton.Click += new System.EventHandler(this.selectPlayerButton_Click);
            // 
            // deletePlayerButton
            // 
            this.deletePlayerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deletePlayerButton.Location = new System.Drawing.Point(190, 224);
            this.deletePlayerButton.Name = "deletePlayerButton";
            this.deletePlayerButton.Size = new System.Drawing.Size(83, 23);
            this.deletePlayerButton.TabIndex = 3;
            this.deletePlayerButton.Text = "Delete";
            this.deletePlayerButton.UseVisualStyleBackColor = true;
            this.deletePlayerButton.Click += new System.EventHandler(this.deletePlayerButton_Click);
            // 
            // playerBindingSource
            // 
            this.playerBindingSource.DataSource = typeof(Tetris_CW.Player);
            this.playerBindingSource.CurrentChanged += new System.EventHandler(this.playerBindingSource_CurrentChanged);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // scoreDataGridViewTextBoxColumn
            // 
            this.scoreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.scoreDataGridViewTextBoxColumn.DataPropertyName = "Score";
            this.scoreDataGridViewTextBoxColumn.HeaderText = "Score";
            this.scoreDataGridViewTextBoxColumn.Name = "scoreDataGridViewTextBoxColumn";
            this.scoreDataGridViewTextBoxColumn.ReadOnly = true;
            this.scoreDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // liderboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.deletePlayerButton);
            this.Controls.Add(this.selectPlayerButton);
            this.Controls.Add(this.addPlayerButton);
            this.Controls.Add(this.dataLeader);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "liderboardForm";
            this.Text = "Liderboard";
            this.Load += new System.EventHandler(this.liderboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataLeader;
        private System.Windows.Forms.Button addPlayerButton;
        private System.Windows.Forms.Button selectPlayerButton;
        private System.Windows.Forms.Button deletePlayerButton;
        public  System.Windows.Forms.BindingSource playerBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scoreDataGridViewTextBoxColumn;
    }
}