namespace Accounting
{
    partial class form_viewsched
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtsrc = new System.Windows.Forms.TextBox();
            this.fnd_btn = new System.Windows.Forms.Button();
            this.to_dtpkr = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.frm_dtpkr = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_stat = new System.Windows.Forms.ComboBox();
            this.fltr_cmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sched_dgv = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sched_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtsrc);
            this.panel1.Controls.Add(this.fnd_btn);
            this.panel1.Controls.Add(this.to_dtpkr);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.frm_dtpkr);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmb_stat);
            this.panel1.Location = new System.Drawing.Point(15, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 202);
            this.panel1.TabIndex = 12;
            // 
            // txtsrc
            // 
            this.txtsrc.Location = new System.Drawing.Point(38, 21);
            this.txtsrc.Name = "txtsrc";
            this.txtsrc.Size = new System.Drawing.Size(155, 20);
            this.txtsrc.TabIndex = 6;
            this.txtsrc.TextChanged += new System.EventHandler(this.txtsrc_TextChanged);
            // 
            // fnd_btn
            // 
            this.fnd_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fnd_btn.Location = new System.Drawing.Point(54, 133);
            this.fnd_btn.Name = "fnd_btn";
            this.fnd_btn.Size = new System.Drawing.Size(119, 23);
            this.fnd_btn.TabIndex = 5;
            this.fnd_btn.Text = "Find";
            this.fnd_btn.UseVisualStyleBackColor = true;
            this.fnd_btn.Click += new System.EventHandler(this.fnd_btn_Click);
            // 
            // to_dtpkr
            // 
            this.to_dtpkr.CustomFormat = "yyyy-MM-dd";
            this.to_dtpkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.to_dtpkr.Location = new System.Drawing.Point(38, 95);
            this.to_dtpkr.Name = "to_dtpkr";
            this.to_dtpkr.Size = new System.Drawing.Size(155, 20);
            this.to_dtpkr.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "To";
            // 
            // frm_dtpkr
            // 
            this.frm_dtpkr.CustomFormat = "yyyy-MM-dd";
            this.frm_dtpkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.frm_dtpkr.Location = new System.Drawing.Point(38, 47);
            this.frm_dtpkr.Name = "frm_dtpkr";
            this.frm_dtpkr.Size = new System.Drawing.Size(155, 20);
            this.frm_dtpkr.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search:";
            // 
            // cmb_stat
            // 
            this.cmb_stat.FormattingEnabled = true;
            this.cmb_stat.Items.AddRange(new object[] {
            "Finished",
            "Appointed",
            "Cancelled Schedule"});
            this.cmb_stat.Location = new System.Drawing.Point(38, 19);
            this.cmb_stat.Name = "cmb_stat";
            this.cmb_stat.Size = new System.Drawing.Size(155, 21);
            this.cmb_stat.TabIndex = 7;
            this.cmb_stat.SelectedIndexChanged += new System.EventHandler(this.cmb_stat_SelectedIndexChanged);
            // 
            // fltr_cmb
            // 
            this.fltr_cmb.FormattingEnabled = true;
            this.fltr_cmb.Items.AddRange(new object[] {
            "All Fields",
            "Doctor",
            "Patient Name",
            "Status",
            "Date"});
            this.fltr_cmb.Location = new System.Drawing.Point(69, 19);
            this.fltr_cmb.Name = "fltr_cmb";
            this.fltr_cmb.Size = new System.Drawing.Size(156, 21);
            this.fltr_cmb.TabIndex = 11;
            this.fltr_cmb.SelectedIndexChanged += new System.EventHandler(this.fltr_cmb_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Show All:";
            // 
            // sched_dgv
            // 
            this.sched_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sched_dgv.Location = new System.Drawing.Point(231, 19);
            this.sched_dgv.Name = "sched_dgv";
            this.sched_dgv.Size = new System.Drawing.Size(435, 229);
            this.sched_dgv.TabIndex = 13;
            this.sched_dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sched_dgv_CellContentClick);
            // 
            // form_viewsched
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(678, 267);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fltr_cmb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sched_dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "form_viewsched";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View All Schedules";
            this.Load += new System.EventHandler(this.USC_viewsched_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sched_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button fnd_btn;
        private System.Windows.Forms.DateTimePicker to_dtpkr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker frm_dtpkr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox fltr_cmb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView sched_dgv;
        private System.Windows.Forms.TextBox txtsrc;
        private System.Windows.Forms.ComboBox cmb_stat;
    }
}