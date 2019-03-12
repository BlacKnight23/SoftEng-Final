namespace Accounting
{
    partial class adddeduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adddeduct));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.button_ok = new Bunifu.Framework.UI.BunifuThinButton2();
            this.textBox_noitem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_cancel = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.combo_description = new System.Windows.Forms.ComboBox();
            this.patient_name = new System.Windows.Forms.Label();
            this.appointment_id = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // button_ok
            // 
            this.button_ok.ActiveBorderThickness = 1;
            this.button_ok.ActiveCornerRadius = 20;
            this.button_ok.ActiveFillColor = System.Drawing.Color.Aquamarine;
            this.button_ok.ActiveForecolor = System.Drawing.Color.Black;
            this.button_ok.ActiveLineColor = System.Drawing.Color.White;
            this.button_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(187)))), ((int)(((byte)(214)))));
            this.button_ok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_ok.BackgroundImage")));
            this.button_ok.ButtonText = "Ok";
            this.button_ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ok.Font = new System.Drawing.Font("Lucida Console", 9.25F);
            this.button_ok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(202)))), ((int)(((byte)(254)))));
            this.button_ok.IdleBorderThickness = 1;
            this.button_ok.IdleCornerRadius = 20;
            this.button_ok.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(187)))), ((int)(((byte)(214)))));
            this.button_ok.IdleForecolor = System.Drawing.Color.Black;
            this.button_ok.IdleLineColor = System.Drawing.Color.Black;
            this.button_ok.Location = new System.Drawing.Point(32, 112);
            this.button_ok.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(59, 31);
            this.button_ok.TabIndex = 319;
            this.button_ok.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // textBox_noitem
            // 
            this.textBox_noitem.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_noitem.Location = new System.Drawing.Point(25, 35);
            this.textBox_noitem.Name = "textBox_noitem";
            this.textBox_noitem.Size = new System.Drawing.Size(157, 26);
            this.textBox_noitem.TabIndex = 321;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(29, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 320;
            this.label4.Text = "No. Items";
            // 
            // button_cancel
            // 
            this.button_cancel.ActiveBorderThickness = 1;
            this.button_cancel.ActiveCornerRadius = 20;
            this.button_cancel.ActiveFillColor = System.Drawing.Color.Aquamarine;
            this.button_cancel.ActiveForecolor = System.Drawing.Color.Black;
            this.button_cancel.ActiveLineColor = System.Drawing.Color.White;
            this.button_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(187)))), ((int)(((byte)(214)))));
            this.button_cancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_cancel.BackgroundImage")));
            this.button_cancel.ButtonText = "Cancel";
            this.button_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_cancel.Font = new System.Drawing.Font("Lucida Console", 9.25F);
            this.button_cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(202)))), ((int)(((byte)(254)))));
            this.button_cancel.IdleBorderThickness = 1;
            this.button_cancel.IdleCornerRadius = 20;
            this.button_cancel.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(187)))), ((int)(((byte)(214)))));
            this.button_cancel.IdleForecolor = System.Drawing.Color.Black;
            this.button_cancel.IdleLineColor = System.Drawing.Color.Black;
            this.button_cancel.Location = new System.Drawing.Point(102, 112);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(63, 31);
            this.button_cancel.TabIndex = 322;
            this.button_cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(187)))), ((int)(((byte)(214)))));
            this.label1.Location = new System.Drawing.Point(114, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 323;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(187)))), ((int)(((byte)(214)))));
            this.label2.Location = new System.Drawing.Point(22, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 324;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(187)))), ((int)(((byte)(214)))));
            this.label3.Location = new System.Drawing.Point(73, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 325;
            this.label3.Text = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // combo_description
            // 
            this.combo_description.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_description.FormattingEnabled = true;
            this.combo_description.Location = new System.Drawing.Point(25, 67);
            this.combo_description.Name = "combo_description";
            this.combo_description.Size = new System.Drawing.Size(157, 27);
            this.combo_description.TabIndex = 326;
            this.combo_description.SelectedIndexChanged += new System.EventHandler(this.combo_description_SelectedIndexChanged);
            // 
            // patient_name
            // 
            this.patient_name.AutoSize = true;
            this.patient_name.Location = new System.Drawing.Point(51, 153);
            this.patient_name.Name = "patient_name";
            this.patient_name.Size = new System.Drawing.Size(16, 13);
            this.patient_name.TabIndex = 327;
            this.patient_name.Text = "pr";
            this.patient_name.Click += new System.EventHandler(this.label5_Click);
            // 
            // appointment_id
            // 
            this.appointment_id.AutoSize = true;
            this.appointment_id.Location = new System.Drawing.Point(114, 153);
            this.appointment_id.Name = "appointment_id";
            this.appointment_id.Size = new System.Drawing.Size(35, 13);
            this.appointment_id.TabIndex = 328;
            this.appointment_id.Text = "label6";
            // 
            // adddeduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(187)))), ((int)(((byte)(214)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(209, 175);
            this.Controls.Add(this.appointment_id);
            this.Controls.Add(this.patient_name);
            this.Controls.Add(this.combo_description);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.textBox_noitem);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adddeduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "adddeduct";
            this.Load += new System.EventHandler(this.adddeduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuThinButton2 button_cancel;
        private Bunifu.Framework.UI.BunifuThinButton2 button_ok;
        private System.Windows.Forms.TextBox textBox_noitem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combo_description;
        private System.Windows.Forms.Label appointment_id;
        private System.Windows.Forms.Label patient_name;
    }
}