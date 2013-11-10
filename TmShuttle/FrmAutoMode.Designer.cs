namespace TmShuttle
{
    partial class FrmAutoMode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btn_Add = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.gv_RingBell = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeKey = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn();
            this.Duaration = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Choose = new System.Windows.Forms.DataGridViewButtonColumn();
            this.删除 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.timer_BgMusic = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_RingBell)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btn_Add);
            this.kryptonPanel1.Controls.Add(this.gv_RingBell);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.TabOneNote;
            this.kryptonPanel1.Size = new System.Drawing.Size(668, 437);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(564, 388);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(90, 25);
            this.btn_Add.TabIndex = 2;
            this.btn_Add.Values.Text = "添加新曲目";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // gv_RingBell
            // 
            this.gv_RingBell.AllowUserToAddRows = false;
            this.gv_RingBell.AllowUserToResizeColumns = false;
            this.gv_RingBell.AllowUserToResizeRows = false;
            this.gv_RingBell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gv_RingBell.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv_RingBell.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gv_RingBell.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_RingBell.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Alias,
            this.TimeKey,
            this.Duaration,
            this.FilePath,
            this.FileName,
            this.Choose,
            this.删除});
            this.gv_RingBell.Location = new System.Drawing.Point(12, 14);
            this.gv_RingBell.Name = "gv_RingBell";
            this.gv_RingBell.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv_RingBell.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gv_RingBell.RowHeadersVisible = false;
            this.gv_RingBell.RowHeadersWidth = 20;
            this.gv_RingBell.RowTemplate.Height = 23;
            this.gv_RingBell.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_RingBell.Size = new System.Drawing.Size(642, 364);
            this.gv_RingBell.TabIndex = 1;
            this.gv_RingBell.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_RingBell_CellClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Alias
            // 
            this.Alias.DataPropertyName = "Alias";
            this.Alias.HeaderText = "名称";
            this.Alias.Name = "Alias";
            this.Alias.ReadOnly = true;
            this.Alias.Width = 160;
            // 
            // TimeKey
            // 
            this.TimeKey.CalendarTodayDate = new System.DateTime(2013, 10, 23, 0, 0, 0, 0);
            this.TimeKey.Checked = false;
            this.TimeKey.DataPropertyName = "RingTime";
            this.TimeKey.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimeKey.HeaderText = "时间";
            this.TimeKey.Name = "TimeKey";
            this.TimeKey.ReadOnly = true;
            this.TimeKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TimeKey.ShowUpDown = true;
            this.TimeKey.Width = 60;
            // 
            // Duaration
            // 
            this.Duaration.DataPropertyName = "Duaration";
            this.Duaration.HeaderText = "时长";
            this.Duaration.Name = "Duaration";
            this.Duaration.ReadOnly = true;
            this.Duaration.Width = 40;
            // 
            // FilePath
            // 
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.HeaderText = "FilePath";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FilePath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FilePath.Visible = false;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "播放曲目文件名";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 268;
            // 
            // Choose
            // 
            this.Choose.HeaderText = "编辑";
            this.Choose.Name = "Choose";
            this.Choose.ReadOnly = true;
            this.Choose.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Choose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Choose.Text = "编辑";
            this.Choose.ToolTipText = "点击打开文件";
            this.Choose.UseColumnTextForButtonValue = true;
            this.Choose.Width = 55;
            // 
            // 删除
            // 
            this.删除.HeaderText = "删除";
            this.删除.Name = "删除";
            this.删除.ReadOnly = true;
            this.删除.Text = "删除";
            this.删除.UseColumnTextForButtonValue = true;
            this.删除.Width = 55;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "打开音乐文件";
            this.openFileDialog.Filter = "MP3文件|*.mp3|WAV文件|*.wav";
            this.openFileDialog.InitialDirectory = "C:\\\\";
            this.openFileDialog.Title = "打开音乐文件";
            // 
            // timer_BgMusic
            // 
            this.timer_BgMusic.Interval = 1000;
            this.timer_BgMusic.Tick += new System.EventHandler(this.timer_BgMusic_Tick);
            // 
            // FrmAutoMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 437);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmAutoMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AutoMode";
            this.Load += new System.EventHandler(this.FrmAutoMode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_RingBell)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Add;
        private System.Windows.Forms.DataGridView gv_RingBell;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Timer timer_BgMusic;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alias;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn TimeKey;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn Duaration;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewButtonColumn Choose;
        private System.Windows.Forms.DataGridViewButtonColumn 删除;

    }
}