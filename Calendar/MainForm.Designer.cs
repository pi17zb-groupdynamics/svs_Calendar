namespace Calendar {
    partial class MainForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.addBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteBtn = new System.Windows.Forms.ToolStripButton();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.dateTimeEventDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notifyDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isReadedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.notifyTimeStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notifyTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imListSmall = new System.Windows.Forms.ImageList(this.components);
            this.timerEvents = new System.Windows.Forms.Timer(this.components);
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // calendar
            // 
            this.calendar.CalendarDimensions = new System.Drawing.Size(1, 2);
            this.calendar.Location = new System.Drawing.Point(18, 18);
            this.calendar.MaxSelectionCount = 1;
            this.calendar.Name = "calendar";
            this.calendar.ShowWeekNumbers = true;
            this.calendar.TabIndex = 0;
            this.calendar.TabStop = false;
            this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Calendar_DateChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBtn,
            this.deleteBtn});
            this.toolStrip.Location = new System.Drawing.Point(863, 18);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(49, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // addBtn
            // 
            this.addBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addBtn.Image = ((System.Drawing.Image)(resources.GetObject("addBtn.Image")));
            this.addBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(23, 22);
            this.addBtn.Text = "Добавить событие";
            this.addBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteBtn.Image")));
            this.deleteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(23, 22);
            this.deleteBtn.Text = "Удалить событие";
            this.deleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // dgvEvents
            // 
            this.dgvEvents.AllowUserToAddRows = false;
            this.dgvEvents.AllowUserToDeleteRows = false;
            this.dgvEvents.AllowUserToResizeColumns = false;
            this.dgvEvents.AllowUserToResizeRows = false;
            this.dgvEvents.AutoGenerateColumns = false;
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Image,
            this.dateTimeEventDataGridViewTextBoxColumn,
            this.textDataGridViewTextBoxColumn,
            this.notifyDataGridViewCheckBoxColumn,
            this.isReadedDataGridViewCheckBoxColumn,
            this.notifyTimeStringDataGridViewTextBoxColumn,
            this.notifyTimeDataGridViewTextBoxColumn});
            this.dgvEvents.DataSource = this.bindingSource;
            this.dgvEvents.Location = new System.Drawing.Point(216, 46);
            this.dgvEvents.MultiSelect = false;
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.ReadOnly = true;
            this.dgvEvents.RowHeadersVisible = false;
            this.dgvEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvents.Size = new System.Drawing.Size(696, 283);
            this.dgvEvents.TabIndex = 3;
            this.dgvEvents.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEvents_CellDoubleClick);
            // 
            // Image
            // 
            this.Image.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Image.DataPropertyName = "Image";
            this.Image.HeaderText = "";
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            this.Image.Width = 20;
            // 
            // dateTimeEventDataGridViewTextBoxColumn
            // 
            this.dateTimeEventDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dateTimeEventDataGridViewTextBoxColumn.DataPropertyName = "DateTimeEvent";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.Format = "T";
            dataGridViewCellStyle1.NullValue = null;
            this.dateTimeEventDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.dateTimeEventDataGridViewTextBoxColumn.HeaderText = "Время";
            this.dateTimeEventDataGridViewTextBoxColumn.Name = "dateTimeEventDataGridViewTextBoxColumn";
            this.dateTimeEventDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateTimeEventDataGridViewTextBoxColumn.Width = 60;
            // 
            // textDataGridViewTextBoxColumn
            // 
            this.textDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.textDataGridViewTextBoxColumn.DataPropertyName = "Text";
            this.textDataGridViewTextBoxColumn.HeaderText = "Text";
            this.textDataGridViewTextBoxColumn.Name = "textDataGridViewTextBoxColumn";
            this.textDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // notifyDataGridViewCheckBoxColumn
            // 
            this.notifyDataGridViewCheckBoxColumn.DataPropertyName = "Notify";
            this.notifyDataGridViewCheckBoxColumn.HeaderText = "Notify";
            this.notifyDataGridViewCheckBoxColumn.Name = "notifyDataGridViewCheckBoxColumn";
            this.notifyDataGridViewCheckBoxColumn.ReadOnly = true;
            this.notifyDataGridViewCheckBoxColumn.Visible = false;
            // 
            // isReadedDataGridViewCheckBoxColumn
            // 
            this.isReadedDataGridViewCheckBoxColumn.DataPropertyName = "IsReaded";
            this.isReadedDataGridViewCheckBoxColumn.HeaderText = "IsReaded";
            this.isReadedDataGridViewCheckBoxColumn.Name = "isReadedDataGridViewCheckBoxColumn";
            this.isReadedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isReadedDataGridViewCheckBoxColumn.Visible = false;
            // 
            // notifyTimeStringDataGridViewTextBoxColumn
            // 
            this.notifyTimeStringDataGridViewTextBoxColumn.DataPropertyName = "NotifyTimeString";
            this.notifyTimeStringDataGridViewTextBoxColumn.HeaderText = "NotifyTimeString";
            this.notifyTimeStringDataGridViewTextBoxColumn.Name = "notifyTimeStringDataGridViewTextBoxColumn";
            this.notifyTimeStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.notifyTimeStringDataGridViewTextBoxColumn.Visible = false;
            // 
            // notifyTimeDataGridViewTextBoxColumn
            // 
            this.notifyTimeDataGridViewTextBoxColumn.DataPropertyName = "NotifyTime";
            this.notifyTimeDataGridViewTextBoxColumn.HeaderText = "NotifyTime";
            this.notifyTimeDataGridViewTextBoxColumn.Name = "notifyTimeDataGridViewTextBoxColumn";
            this.notifyTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.notifyTimeDataGridViewTextBoxColumn.Visible = false;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Calendar.Event);
            // 
            // imListSmall
            // 
            this.imListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imListSmall.ImageStream")));
            this.imListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imListSmall.Images.SetKeyName(0, "Green tag.ico");
            this.imListSmall.Images.SetKeyName(1, "Black tag.ico");
            this.imListSmall.Images.SetKeyName(2, "Red tag.ico");
            this.imListSmall.Images.SetKeyName(3, "Blue tag.ico");
            this.imListSmall.Images.SetKeyName(4, "Yellow tag.ico");
            // 
            // timerEvents
            // 
            this.timerEvents.Enabled = true;
            this.timerEvents.Interval = 5000;
            this.timerEvents.Tick += new System.EventHandler(this.TimerEvents_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 352);
            this.Controls.Add(this.dgvEvents);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.calendar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Управление заметками";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton addBtn;
        private System.Windows.Forms.ToolStripButton deleteBtn;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Timer timerEvents;
        private System.Windows.Forms.ImageList imListSmall;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeEventDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn textDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn notifyDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReadedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notifyTimeStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notifyTimeDataGridViewTextBoxColumn;
    }
}

