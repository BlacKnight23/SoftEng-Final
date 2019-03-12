namespace Accounting
{
    partial class form_sales
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
            System.Windows.Forms.Label label7;
            this.dgv_sales = new System.Windows.Forms.DataGridView();
            this.button_go = new System.Windows.Forms.GroupBox();
            this.button_search1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label_view11 = new System.Windows.Forms.Label();
            this.date_to = new System.Windows.Forms.DateTimePicker();
            this.label_view1 = new System.Windows.Forms.Label();
            this.date_from = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.text_total = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sales)).BeginInit();
            this.button_go.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.ForeColor = System.Drawing.Color.Black;
            label7.Location = new System.Drawing.Point(475, 81);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(78, 17);
            label7.TabIndex = 321;
            label7.Text = "Total: ";
            // 
            // dgv_sales
            // 
            this.dgv_sales.AllowUserToAddRows = false;
            this.dgv_sales.AllowUserToDeleteRows = false;
            this.dgv_sales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_sales.BackgroundColor = System.Drawing.Color.White;
            this.dgv_sales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sales.Location = new System.Drawing.Point(28, 196);
            this.dgv_sales.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_sales.Name = "dgv_sales";
            this.dgv_sales.ReadOnly = true;
            this.dgv_sales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_sales.Size = new System.Drawing.Size(1095, 412);
            this.dgv_sales.TabIndex = 334;
            this.dgv_sales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_sales_CellClick);
            this.dgv_sales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_sales_CellContentClick);
            // 
            // button_go
            // 
            this.button_go.Controls.Add(this.label15);
            this.button_go.Controls.Add(this.text_total);
            this.button_go.Controls.Add(label7);
            this.button_go.Controls.Add(this.button_search1);
            this.button_go.Controls.Add(this.label_view11);
            this.button_go.Controls.Add(this.date_to);
            this.button_go.Controls.Add(this.label_view1);
            this.button_go.Controls.Add(this.date_from);
            this.button_go.Location = new System.Drawing.Point(28, 63);
            this.button_go.Margin = new System.Windows.Forms.Padding(4);
            this.button_go.Name = "button_go";
            this.button_go.Padding = new System.Windows.Forms.Padding(4);
            this.button_go.Size = new System.Drawing.Size(704, 112);
            this.button_go.TabIndex = 333;
            this.button_go.TabStop = false;
            this.button_go.Text = "Details";
            // 
            // button_search1
            // 
            this.button_search1.Activecolor = System.Drawing.Color.Teal;
            this.button_search1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(187)))), ((int)(((byte)(214)))));
            this.button_search1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_search1.BorderRadius = 0;
            this.button_search1.ButtonText = "Go";
            this.button_search1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_search1.DisabledColor = System.Drawing.Color.Gray;
            this.button_search1.Iconcolor = System.Drawing.Color.Transparent;
            this.button_search1.Iconimage = null;
            this.button_search1.Iconimage_right = null;
            this.button_search1.Iconimage_right_Selected = null;
            this.button_search1.Iconimage_Selected = null;
            this.button_search1.IconMarginLeft = 0;
            this.button_search1.IconMarginRight = 0;
            this.button_search1.IconRightVisible = true;
            this.button_search1.IconRightZoom = 0D;
            this.button_search1.IconVisible = true;
            this.button_search1.IconZoom = 70D;
            this.button_search1.IsTab = false;
            this.button_search1.Location = new System.Drawing.Point(355, 47);
            this.button_search1.Margin = new System.Windows.Forms.Padding(5);
            this.button_search1.Name = "button_search1";
            this.button_search1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(187)))), ((int)(((byte)(214)))));
            this.button_search1.OnHovercolor = System.Drawing.Color.Teal;
            this.button_search1.OnHoverTextColor = System.Drawing.Color.White;
            this.button_search1.selected = false;
            this.button_search1.Size = new System.Drawing.Size(72, 28);
            this.button_search1.TabIndex = 324;
            this.button_search1.Text = "Go";
            this.button_search1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button_search1.Textcolor = System.Drawing.Color.Black;
            this.button_search1.TextFont = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_search1.Click += new System.EventHandler(this.button_search1_Click);
            // 
            // label_view11
            // 
            this.label_view11.AutoSize = true;
            this.label_view11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_view11.Location = new System.Drawing.Point(199, 25);
            this.label_view11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_view11.Name = "label_view11";
            this.label_view11.Size = new System.Drawing.Size(30, 18);
            this.label_view11.TabIndex = 7;
            this.label_view11.Text = "To:";
            // 
            // date_to
            // 
            this.date_to.CustomFormat = "dd/MMM/yyyy";
            this.date_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_to.Location = new System.Drawing.Point(203, 47);
            this.date_to.Margin = new System.Windows.Forms.Padding(4);
            this.date_to.Name = "date_to";
            this.date_to.Size = new System.Drawing.Size(140, 24);
            this.date_to.TabIndex = 6;
            // 
            // label_view1
            // 
            this.label_view1.AutoSize = true;
            this.label_view1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_view1.Location = new System.Drawing.Point(35, 25);
            this.label_view1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_view1.Name = "label_view1";
            this.label_view1.Size = new System.Drawing.Size(48, 18);
            this.label_view1.TabIndex = 5;
            this.label_view1.Text = "From:";
            // 
            // date_from
            // 
            this.date_from.CustomFormat = "dd/MMM/yyyy";
            this.date_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_from.Location = new System.Drawing.Point(39, 47);
            this.date_from.Margin = new System.Windows.Forms.Padding(4);
            this.date_from.Name = "date_from";
            this.date_from.Size = new System.Drawing.Size(140, 24);
            this.date_from.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 47);
            this.label1.TabIndex = 330;
            this.label1.Text = "SALES INVOICE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(475, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 18);
            this.label6.TabIndex = 336;
            // 
            // text_total
            // 
            this.text_total.AutoSize = true;
            this.text_total.BackColor = System.Drawing.SystemColors.Control;
            this.text_total.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_total.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.text_total.Location = new System.Drawing.Point(577, 81);
            this.text_total.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.text_total.Name = "text_total";
            this.text_total.Size = new System.Drawing.Size(68, 17);
            this.text_total.TabIndex = 388;
            this.text_total.Text = "232323";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(539, 81);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 17);
            this.label15.TabIndex = 389;
            this.label15.Text = "Php";
            // 
            // form_sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 679);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgv_sales);
            this.Controls.Add(this.button_go);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "form_sales";
            this.Text = "form_sales";
            this.Load += new System.EventHandler(this.form_sales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sales)).EndInit();
            this.button_go.ResumeLayout(false);
            this.button_go.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_sales;
        private System.Windows.Forms.GroupBox button_go;
        private Bunifu.Framework.UI.BunifuFlatButton button_search1;
        private System.Windows.Forms.Label label_view11;
        private System.Windows.Forms.DateTimePicker date_to;
        private System.Windows.Forms.Label label_view1;
        private System.Windows.Forms.DateTimePicker date_from;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label text_total;
        private System.Windows.Forms.Label label15;
    }
}