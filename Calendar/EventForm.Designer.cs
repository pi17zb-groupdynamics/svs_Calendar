namespace Calendar {
    partial class EventForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventForm));
            this.dateTimeEvent = new System.Windows.Forms.DateTimePicker();
            this.text = new System.Windows.Forms.TextBox();
            this.notify = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimeEvent
            // 
            this.dateTimeEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimeEvent.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dateTimeEvent.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeEvent.Location = new System.Drawing.Point(291, 12);
            this.dateTimeEvent.Name = "dateTimeEvent";
            this.dateTimeEvent.Size = new System.Drawing.Size(200, 20);
            this.dateTimeEvent.TabIndex = 0;
            this.dateTimeEvent.ValueChanged += new System.EventHandler(this.DateTimeEvent_ValueChanged);
            // 
            // text
            // 
            this.text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text.Location = new System.Drawing.Point(12, 38);
            this.text.Multiline = true;
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(479, 110);
            this.text.TabIndex = 1;
            this.text.TextChanged += new System.EventHandler(this.Text_TextChanged);
            // 
            // notify
            // 
            this.notify.AutoSize = true;
            this.notify.Location = new System.Drawing.Point(12, 15);
            this.notify.Name = "notify";
            this.notify.Size = new System.Drawing.Size(144, 17);
            this.notify.TabIndex = 2;
            this.notify.TabStop = false;
            this.notify.Text = "Уведомлять о событии";
            this.notify.UseVisualStyleBackColor = true;
            this.notify.CheckedChanged += new System.EventHandler(this.Notify_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(328, 154);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(163, 54);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(159, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(163, 54);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // EventForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(503, 220);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.notify);
            this.Controls.Add(this.text);
            this.Controls.Add(this.dateTimeEvent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EventForm";
            this.Text = "Редактирование заметки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimeEvent;
        private System.Windows.Forms.TextBox text;
        private System.Windows.Forms.CheckBox notify;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}