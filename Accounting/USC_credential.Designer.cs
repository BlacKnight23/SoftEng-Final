namespace Accounting
{
    partial class USC_credential
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USC_credential));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_update2 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.textBox_newp = new System.Windows.Forms.TextBox();
            this.textBox_conp = new System.Windows.Forms.TextBox();
            this.textBox_oldp = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_update = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.textBox_user = new System.Windows.Forms.TextBox();
            this.labelcredential_name = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_update2);
            this.groupBox2.Controls.Add(this.textBox_newp);
            this.groupBox2.Controls.Add(this.textBox_conp);
            this.groupBox2.Controls.Add(this.textBox_oldp);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(46, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(695, 190);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "";
            this.groupBox2.Text = "Password Settings";
            // 
            // button_update2
            // 
            this.button_update2.ActiveBorderThickness = 1;
            this.button_update2.ActiveCornerRadius = 20;
            this.button_update2.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(187)))), ((int)(((byte)(214)))));
            this.button_update2.ActiveForecolor = System.Drawing.Color.White;
            this.button_update2.ActiveLineColor = System.Drawing.Color.White;
            this.button_update2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.button_update2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_update2.BackgroundImage")));
            this.button_update2.ButtonText = "Update";
            this.button_update2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_update2.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_update2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(202)))), ((int)(((byte)(254)))));
            this.button_update2.IdleBorderThickness = 1;
            this.button_update2.IdleCornerRadius = 20;
            this.button_update2.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.button_update2.IdleForecolor = System.Drawing.Color.Black;
            this.button_update2.IdleLineColor = System.Drawing.Color.Black;
            this.button_update2.Location = new System.Drawing.Point(436, 30);
            this.button_update2.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.button_update2.Name = "button_update2";
            this.button_update2.Size = new System.Drawing.Size(249, 141);
            this.button_update2.TabIndex = 31;
            this.button_update2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button_update2.Click += new System.EventHandler(this.button_update2_Click);
            // 
            // textBox_newp
            // 
            this.textBox_newp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_newp.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox_newp.Location = new System.Drawing.Point(9, 83);
            this.textBox_newp.Name = "textBox_newp";
            this.textBox_newp.Size = new System.Drawing.Size(417, 38);
            this.textBox_newp.TabIndex = 4;
            this.textBox_newp.Text = "Enter New Password";
            // 
            // textBox_conp
            // 
            this.textBox_conp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_conp.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox_conp.Location = new System.Drawing.Point(9, 133);
            this.textBox_conp.Name = "textBox_conp";
            this.textBox_conp.Size = new System.Drawing.Size(417, 38);
            this.textBox_conp.TabIndex = 5;
            this.textBox_conp.Text = "Confirm New Password";
            // 
            // textBox_oldp
            // 
            this.textBox_oldp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_oldp.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox_oldp.Location = new System.Drawing.Point(9, 32);
            this.textBox_oldp.Name = "textBox_oldp";
            this.textBox_oldp.Size = new System.Drawing.Size(417, 38);
            this.textBox_oldp.TabIndex = 3;
            this.textBox_oldp.Text = "Enter Old Password";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox1.Controls.Add(this.button_update);
            this.groupBox1.Controls.Add(this.bunifuFlatButton1);
            this.groupBox1.Controls.Add(this.textBox_user);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(46, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(695, 104);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Username Settings";
            // 
            // button_update
            // 
            this.button_update.ActiveBorderThickness = 1;
            this.button_update.ActiveCornerRadius = 20;
            this.button_update.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(187)))), ((int)(((byte)(214)))));
            this.button_update.ActiveForecolor = System.Drawing.Color.White;
            this.button_update.ActiveLineColor = System.Drawing.Color.White;
            this.button_update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.button_update.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_update.BackgroundImage")));
            this.button_update.ButtonText = "Update";
            this.button_update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_update.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_update.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(202)))), ((int)(((byte)(254)))));
            this.button_update.IdleBorderThickness = 1;
            this.button_update.IdleCornerRadius = 20;
            this.button_update.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.button_update.IdleForecolor = System.Drawing.Color.Black;
            this.button_update.IdleLineColor = System.Drawing.Color.Black;
            this.button_update.Location = new System.Drawing.Point(430, 30);
            this.button_update.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(255, 43);
            this.button_update.TabIndex = 30;
            this.button_update.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "bunifuFlatButton1";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton1.Iconimage")));
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 90D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(984, 59);
            this.bunifuFlatButton1.Margin = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(202, 81);
            this.bunifuFlatButton1.TabIndex = 2;
            this.bunifuFlatButton1.Text = "bunifuFlatButton1";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // textBox_user
            // 
            this.textBox_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_user.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox_user.Location = new System.Drawing.Point(9, 35);
            this.textBox_user.Name = "textBox_user";
            this.textBox_user.Size = new System.Drawing.Size(417, 38);
            this.textBox_user.TabIndex = 1;
            this.textBox_user.Text = "Change Username";
            // 
            // labelcredential_name
            // 
            this.labelcredential_name.AutoSize = true;
            this.labelcredential_name.ForeColor = System.Drawing.SystemColors.Control;
            this.labelcredential_name.Location = new System.Drawing.Point(68, 49);
            this.labelcredential_name.Name = "labelcredential_name";
            this.labelcredential_name.Size = new System.Drawing.Size(35, 13);
            this.labelcredential_name.TabIndex = 17;
            this.labelcredential_name.Text = "label2";
            this.labelcredential_name.Click += new System.EventHandler(this.labelcredential_name_Click);
            // 
            // USC_credential
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.Controls.Add(this.labelcredential_name);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "USC_credential";
            this.Size = new System.Drawing.Size(891, 552);
            this.Load += new System.EventHandler(this.USC_credential_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_newp;
        private System.Windows.Forms.TextBox textBox_conp;
        private System.Windows.Forms.TextBox textBox_oldp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_user;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private Bunifu.Framework.UI.BunifuThinButton2 button_update2;
        private Bunifu.Framework.UI.BunifuThinButton2 button_update;
        private System.Windows.Forms.Label labelcredential_name;
    }
}
