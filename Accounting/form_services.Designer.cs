namespace Accounting
{
    partial class form_services
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
            this.AvailSer = new System.Windows.Forms.GroupBox();
            this.trt_grid = new System.Windows.Forms.DataGridView();
            this.Search = new System.Windows.Forms.Label();
            this.cmb_src = new System.Windows.Forms.ComboBox();
            this.S1 = new System.Windows.Forms.Label();
            this.S2 = new System.Windows.Forms.TextBox();
            this.srv_dt = new System.Windows.Forms.GroupBox();
            this.crt = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.src_id = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.Label();
            this.adschp = new System.Windows.Forms.Panel();
            this.DeleteS = new System.Windows.Forms.Button();
            this.AddS = new System.Windows.Forms.Button();
            this.EditS = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.prc = new System.Windows.Forms.TextBox();
            this.Price = new System.Windows.Forms.Label();
            this.src_nme = new System.Windows.Forms.TextBox();
            this.nm = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AvailSer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trt_grid)).BeginInit();
            this.srv_dt.SuspendLayout();
            this.adschp.SuspendLayout();
            this.SuspendLayout();
            // 
            // AvailSer
            // 
            this.AvailSer.Controls.Add(this.trt_grid);
            this.AvailSer.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvailSer.Location = new System.Drawing.Point(26, 219);
            this.AvailSer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AvailSer.Name = "AvailSer";
            this.AvailSer.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AvailSer.Size = new System.Drawing.Size(829, 336);
            this.AvailSer.TabIndex = 0;
            this.AvailSer.TabStop = false;
            this.AvailSer.Text = "Available Services";
            // 
            // trt_grid
            // 
            this.trt_grid.AllowUserToAddRows = false;
            this.trt_grid.AllowUserToDeleteRows = false;
            this.trt_grid.AllowUserToResizeColumns = false;
            this.trt_grid.AllowUserToResizeRows = false;
            this.trt_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.trt_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trt_grid.Location = new System.Drawing.Point(45, 34);
            this.trt_grid.Name = "trt_grid";
            this.trt_grid.ReadOnly = true;
            this.trt_grid.RowHeadersVisible = false;
            this.trt_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.trt_grid.Size = new System.Drawing.Size(730, 280);
            this.trt_grid.TabIndex = 28;
            this.trt_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.trt_grid_CellContentClick);
            // 
            // Search
            // 
            this.Search.AutoSize = true;
            this.Search.Font = new System.Drawing.Font("Lucida Console", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search.Location = new System.Drawing.Point(49, 82);
            this.Search.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(97, 15);
            this.Search.TabIndex = 1;
            this.Search.Text = "Search By:";
            // 
            // cmb_src
            // 
            this.cmb_src.FormattingEnabled = true;
            this.cmb_src.Items.AddRange(new object[] {
            "All Fields",
            "Treatment Name",
            "Price"});
            this.cmb_src.Location = new System.Drawing.Point(142, 78);
            this.cmb_src.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmb_src.Name = "cmb_src";
            this.cmb_src.Size = new System.Drawing.Size(175, 21);
            this.cmb_src.TabIndex = 2;
            this.cmb_src.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // S1
            // 
            this.S1.AutoSize = true;
            this.S1.Font = new System.Drawing.Font("Lucida Console", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.S1.Location = new System.Drawing.Point(49, 106);
            this.S1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.S1.Name = "S1";
            this.S1.Size = new System.Drawing.Size(70, 15);
            this.S1.TabIndex = 3;
            this.S1.Text = "Search:";
            // 
            // S2
            // 
            this.S2.Location = new System.Drawing.Point(142, 103);
            this.S2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.S2.Name = "S2";
            this.S2.Size = new System.Drawing.Size(175, 20);
            this.S2.TabIndex = 4;
            this.S2.TextChanged += new System.EventHandler(this.S2_TextChanged);
            // 
            // srv_dt
            // 
            this.srv_dt.Controls.Add(this.crt);
            this.srv_dt.Controls.Add(this.label3);
            this.srv_dt.Controls.Add(this.src_id);
            this.srv_dt.Controls.Add(this.ID);
            this.srv_dt.Controls.Add(this.adschp);
            this.srv_dt.Controls.Add(this.prc);
            this.srv_dt.Controls.Add(this.Price);
            this.srv_dt.Controls.Add(this.src_nme);
            this.srv_dt.Controls.Add(this.nm);
            this.srv_dt.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srv_dt.Location = new System.Drawing.Point(346, 26);
            this.srv_dt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.srv_dt.Name = "srv_dt";
            this.srv_dt.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.srv_dt.Size = new System.Drawing.Size(508, 190);
            this.srv_dt.TabIndex = 5;
            this.srv_dt.TabStop = false;
            this.srv_dt.Text = "Service Information";
            // 
            // crt
            // 
            this.crt.FormattingEnabled = true;
            this.crt.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.crt.Location = new System.Drawing.Point(128, 145);
            this.crt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.crt.Name = "crt";
            this.crt.Size = new System.Drawing.Size(95, 24);
            this.crt.TabIndex = 63;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Console", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 152);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 15);
            this.label3.TabIndex = 62;
            this.label3.Text = "Tooth Chart:";
            // 
            // src_id
            // 
            this.src_id.Location = new System.Drawing.Point(128, 26);
            this.src_id.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.src_id.Name = "src_id";
            this.src_id.Size = new System.Drawing.Size(224, 23);
            this.src_id.TabIndex = 61;
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Font = new System.Drawing.Font("Lucida Console", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.Location = new System.Drawing.Point(9, 32);
            this.ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(106, 15);
            this.ID.TabIndex = 60;
            this.ID.Text = "Service ID:";
            // 
            // adschp
            // 
            this.adschp.Controls.Add(this.DeleteS);
            this.adschp.Controls.Add(this.AddS);
            this.adschp.Controls.Add(this.EditS);
            this.adschp.Controls.Add(this.Reset);
            this.adschp.Location = new System.Drawing.Point(359, 21);
            this.adschp.Name = "adschp";
            this.adschp.Size = new System.Drawing.Size(142, 146);
            this.adschp.TabIndex = 59;
            // 
            // DeleteS
            // 
            this.DeleteS.BackColor = System.Drawing.SystemColors.Control;
            this.DeleteS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeleteS.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteS.Location = new System.Drawing.Point(8, 80);
            this.DeleteS.Name = "DeleteS";
            this.DeleteS.Size = new System.Drawing.Size(126, 20);
            this.DeleteS.TabIndex = 58;
            this.DeleteS.Text = "Delete Service";
            this.DeleteS.UseVisualStyleBackColor = false;
            this.DeleteS.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddS
            // 
            this.AddS.BackColor = System.Drawing.SystemColors.Control;
            this.AddS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddS.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddS.Location = new System.Drawing.Point(8, 20);
            this.AddS.Name = "AddS";
            this.AddS.Size = new System.Drawing.Size(126, 20);
            this.AddS.TabIndex = 57;
            this.AddS.Text = "Add Service";
            this.AddS.UseVisualStyleBackColor = false;
            this.AddS.Click += new System.EventHandler(this.AddS_Click);
            // 
            // EditS
            // 
            this.EditS.BackColor = System.Drawing.SystemColors.Control;
            this.EditS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EditS.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditS.Location = new System.Drawing.Point(8, 50);
            this.EditS.Name = "EditS";
            this.EditS.Size = new System.Drawing.Size(126, 20);
            this.EditS.TabIndex = 18;
            this.EditS.Text = "Edit Service";
            this.EditS.UseVisualStyleBackColor = false;
            this.EditS.Click += new System.EventHandler(this.EditS_Click);
            // 
            // Reset
            // 
            this.Reset.BackColor = System.Drawing.SystemColors.Control;
            this.Reset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Reset.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset.Location = new System.Drawing.Point(8, 106);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(126, 20);
            this.Reset.TabIndex = 56;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = false;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // prc
            // 
            this.prc.Location = new System.Drawing.Point(128, 107);
            this.prc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.prc.Name = "prc";
            this.prc.Size = new System.Drawing.Size(95, 23);
            this.prc.TabIndex = 9;
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Font = new System.Drawing.Font("Lucida Console", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price.Location = new System.Drawing.Point(9, 114);
            this.Price.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(61, 15);
            this.Price.TabIndex = 8;
            this.Price.Text = "Price:";
            // 
            // src_nme
            // 
            this.src_nme.Location = new System.Drawing.Point(128, 65);
            this.src_nme.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.src_nme.Name = "src_nme";
            this.src_nme.Size = new System.Drawing.Size(224, 23);
            this.src_nme.TabIndex = 7;
            // 
            // nm
            // 
            this.nm.AutoSize = true;
            this.nm.Font = new System.Drawing.Font("Lucida Console", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nm.Location = new System.Drawing.Point(9, 72);
            this.nm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nm.Name = "nm";
            this.nm.Size = new System.Drawing.Size(124, 15);
            this.nm.TabIndex = 6;
            this.nm.Text = "Service Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(98, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // form_services
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 574);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.srv_dt);
            this.Controls.Add(this.S2);
            this.Controls.Add(this.S1);
            this.Controls.Add(this.cmb_src);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.AvailSer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "form_services";
            this.Text = "form_services";
            this.Load += new System.EventHandler(this.form_services_Load);
            this.AvailSer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trt_grid)).EndInit();
            this.srv_dt.ResumeLayout(false);
            this.srv_dt.PerformLayout();
            this.adschp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox AvailSer;
        private System.Windows.Forms.DataGridView trt_grid;
        private System.Windows.Forms.Label Search;
        private System.Windows.Forms.ComboBox cmb_src;
        private System.Windows.Forms.Label S1;
        private System.Windows.Forms.TextBox S2;
        private System.Windows.Forms.GroupBox srv_dt;
        private System.Windows.Forms.TextBox src_nme;
        private System.Windows.Forms.Label nm;
        private System.Windows.Forms.TextBox prc;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Panel adschp;
        private System.Windows.Forms.Button EditS;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox src_id;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Button AddS;
        private System.Windows.Forms.Button DeleteS;
        private System.Windows.Forms.ComboBox crt;
        private System.Windows.Forms.Label label3;
    }
}