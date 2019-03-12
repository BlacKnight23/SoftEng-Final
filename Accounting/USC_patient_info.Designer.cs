namespace Accounting
{
    partial class USC_patient_info
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USC_patient_info));
            this.textBox_search = new Bunifu.Framework.UI.BunifuTextbox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.patientlabel_id = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_contact1 = new System.Windows.Forms.TextBox();
            this.birth_date = new System.Windows.Forms.DateTimePicker();
            this.textBox_age = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.combo_gender = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_lastname = new System.Windows.Forms.TextBox();
            this.textBox_firstname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_update = new Bunifu.Framework.UI.BunifuThinButton2();
            this.button_reset = new Bunifu.Framework.UI.BunifuThinButton2();
            this.button_create = new Bunifu.Framework.UI.BunifuThinButton2();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_search
            // 
            this.textBox_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.textBox_search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("textBox_search.BackgroundImage")));
            this.textBox_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.textBox_search.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_search.ForeColor = System.Drawing.Color.Black;
            this.textBox_search.Icon = ((System.Drawing.Image)(resources.GetObject("textBox_search.Icon")));
            this.textBox_search.Location = new System.Drawing.Point(615, 22);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(259, 33);
            this.textBox_search.TabIndex = 142;
            this.textBox_search.text = "";
            this.textBox_search.OnTextChange += new System.EventHandler(this.textBox_search_OnTextChange);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(348, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(526, 363);
            this.dataGridView1.TabIndex = 141;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // patientlabel_id
            // 
            this.patientlabel_id.AutoSize = true;
            this.patientlabel_id.Location = new System.Drawing.Point(565, 22);
            this.patientlabel_id.Name = "patientlabel_id";
            this.patientlabel_id.Size = new System.Drawing.Size(35, 13);
            this.patientlabel_id.TabIndex = 140;
            this.patientlabel_id.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(16, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 138;
            this.label8.Text = "Contact #1";
            // 
            // textBox_contact1
            // 
            this.textBox_contact1.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_contact1.Location = new System.Drawing.Point(19, 336);
            this.textBox_contact1.Name = "textBox_contact1";
            this.textBox_contact1.Size = new System.Drawing.Size(323, 26);
            this.textBox_contact1.TabIndex = 137;
            // 
            // birth_date
            // 
            this.birth_date.CustomFormat = "MMMM dd, yyyy";
            this.birth_date.Font = new System.Drawing.Font("Arial", 12.25F);
            this.birth_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.birth_date.Location = new System.Drawing.Point(19, 143);
            this.birth_date.Name = "birth_date";
            this.birth_date.Size = new System.Drawing.Size(323, 26);
            this.birth_date.TabIndex = 136;
            // 
            // textBox_age
            // 
            this.textBox_age.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_age.Location = new System.Drawing.Point(19, 267);
            this.textBox_age.Name = "textBox_age";
            this.textBox_age.Size = new System.Drawing.Size(137, 26);
            this.textBox_age.TabIndex = 135;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(13, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 134;
            this.label7.Text = "Birthdate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(159, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 133;
            this.label6.Text = "Gender";
            // 
            // combo_gender
            // 
            this.combo_gender.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_gender.FormattingEnabled = true;
            this.combo_gender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.combo_gender.Location = new System.Drawing.Point(162, 267);
            this.combo_gender.Name = "combo_gender";
            this.combo_gender.Size = new System.Drawing.Size(180, 27);
            this.combo_gender.TabIndex = 132;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(16, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 131;
            this.label5.Text = "Age";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 130;
            this.label3.Text = "Address";
            // 
            // textBox_address
            // 
            this.textBox_address.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_address.Location = new System.Drawing.Point(19, 205);
            this.textBox_address.Name = "textBox_address";
            this.textBox_address.Size = new System.Drawing.Size(323, 26);
            this.textBox_address.TabIndex = 129;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(159, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 128;
            this.label2.Text = "Lastname";
            // 
            // textBox_lastname
            // 
            this.textBox_lastname.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_lastname.Location = new System.Drawing.Point(162, 71);
            this.textBox_lastname.Name = "textBox_lastname";
            this.textBox_lastname.Size = new System.Drawing.Size(180, 26);
            this.textBox_lastname.TabIndex = 127;
            // 
            // textBox_firstname
            // 
            this.textBox_firstname.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_firstname.Location = new System.Drawing.Point(19, 71);
            this.textBox_firstname.Name = "textBox_firstname";
            this.textBox_firstname.Size = new System.Drawing.Size(137, 26);
            this.textBox_firstname.TabIndex = 126;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 125;
            this.label1.Text = "Firstname";
            // 
            // button_update
            // 
            this.button_update.ActiveBorderThickness = 1;
            this.button_update.ActiveCornerRadius = 20;
            this.button_update.ActiveFillColor = System.Drawing.Color.Aquamarine;
            this.button_update.ActiveForecolor = System.Drawing.Color.Black;
            this.button_update.ActiveLineColor = System.Drawing.Color.White;
            this.button_update.BackColor = System.Drawing.SystemColors.Control;
            this.button_update.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_update.BackgroundImage")));
            this.button_update.ButtonText = "Update";
            this.button_update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_update.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_update.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(202)))), ((int)(((byte)(254)))));
            this.button_update.IdleBorderThickness = 1;
            this.button_update.IdleCornerRadius = 20;
            this.button_update.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.button_update.IdleForecolor = System.Drawing.Color.Black;
            this.button_update.IdleLineColor = System.Drawing.Color.Black;
            this.button_update.Location = new System.Drawing.Point(146, 369);
            this.button_update.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(76, 39);
            this.button_update.TabIndex = 147;
            this.button_update.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_reset
            // 
            this.button_reset.ActiveBorderThickness = 1;
            this.button_reset.ActiveCornerRadius = 20;
            this.button_reset.ActiveFillColor = System.Drawing.Color.Aquamarine;
            this.button_reset.ActiveForecolor = System.Drawing.Color.Black;
            this.button_reset.ActiveLineColor = System.Drawing.Color.White;
            this.button_reset.BackColor = System.Drawing.SystemColors.Control;
            this.button_reset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_reset.BackgroundImage")));
            this.button_reset.ButtonText = "Reset";
            this.button_reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_reset.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_reset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(202)))), ((int)(((byte)(254)))));
            this.button_reset.IdleBorderThickness = 1;
            this.button_reset.IdleCornerRadius = 20;
            this.button_reset.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.button_reset.IdleForecolor = System.Drawing.Color.Black;
            this.button_reset.IdleLineColor = System.Drawing.Color.Black;
            this.button_reset.Location = new System.Drawing.Point(232, 369);
            this.button_reset.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(76, 39);
            this.button_reset.TabIndex = 146;
            this.button_reset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // button_create
            // 
            this.button_create.ActiveBorderThickness = 1;
            this.button_create.ActiveCornerRadius = 20;
            this.button_create.ActiveFillColor = System.Drawing.Color.Aquamarine;
            this.button_create.ActiveForecolor = System.Drawing.Color.Black;
            this.button_create.ActiveLineColor = System.Drawing.Color.White;
            this.button_create.BackColor = System.Drawing.SystemColors.Control;
            this.button_create.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_create.BackgroundImage")));
            this.button_create.ButtonText = "Create";
            this.button_create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_create.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_create.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(202)))), ((int)(((byte)(254)))));
            this.button_create.IdleBorderThickness = 1;
            this.button_create.IdleCornerRadius = 20;
            this.button_create.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.button_create.IdleForecolor = System.Drawing.Color.Black;
            this.button_create.IdleLineColor = System.Drawing.Color.Black;
            this.button_create.Location = new System.Drawing.Point(60, 369);
            this.button_create.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(76, 39);
            this.button_create.TabIndex = 145;
            this.button_create.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // USC_patient_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.patientlabel_id);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_contact1);
            this.Controls.Add(this.birth_date);
            this.Controls.Add(this.textBox_age);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.combo_gender);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_address);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_lastname);
            this.Controls.Add(this.textBox_firstname);
            this.Controls.Add(this.label1);
            this.Name = "USC_patient_info";
            this.Size = new System.Drawing.Size(891, 448);
            this.Load += new System.EventHandler(this.USC_patient_info_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuTextbox textBox_search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label patientlabel_id;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_contact1;
        private System.Windows.Forms.DateTimePicker birth_date;
        private System.Windows.Forms.TextBox textBox_age;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combo_gender;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_lastname;
        private System.Windows.Forms.TextBox textBox_firstname;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuThinButton2 button_update;
        private Bunifu.Framework.UI.BunifuThinButton2 button_reset;
        private Bunifu.Framework.UI.BunifuThinButton2 button_create;
    }
}
