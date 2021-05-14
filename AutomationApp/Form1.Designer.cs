
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutomationApp
{
    partial class Form1
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
            this.btn_1 = new System.Windows.Forms.Button();
            this.lbl_1 = new System.Windows.Forms.Label();
            this.box_0108 = new System.Windows.Forms.TextBox();
            this.box_0102 = new System.Windows.Forms.TextBox();
            this.box_0103 = new System.Windows.Forms.TextBox();
            this.box_0104 = new System.Windows.Forms.TextBox();
            this.box_0105 = new System.Windows.Forms.TextBox();
            this.box_0106 = new System.Windows.Forms.TextBox();
            this.box_0107 = new System.Windows.Forms.TextBox();
            this.box_0101 = new System.Windows.Forms.TextBox();
            this.btn_2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_8 = new System.Windows.Forms.Label();
            this.label_7 = new System.Windows.Forms.Label();
            this.label_6 = new System.Windows.Forms.Label();
            this.label_5 = new System.Windows.Forms.Label();
            this.label_4 = new System.Windows.Forms.Label();
            this.label_3 = new System.Windows.Forms.Label();
            this.label_2 = new System.Windows.Forms.Label();
            this.label_1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.warningLabel = new System.Windows.Forms.Label();
            this.textWarning1 = new System.Windows.Forms.Label();
            this.textWarning2 = new System.Windows.Forms.Label();
            this.textWarning3 = new System.Windows.Forms.Label();
            this.textWarning4 = new System.Windows.Forms.Label();
            this.textWarning5 = new System.Windows.Forms.Label();
            this.textWarning6 = new System.Windows.Forms.Label();
            this.textWarning7 = new System.Windows.Forms.Label();
            this.textWarning8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_1
            // 
            this.btn_1.Location = new System.Drawing.Point(70, 37);
            this.btn_1.Name = "btn_1";
            this.btn_1.Size = new System.Drawing.Size(127, 59);
            this.btn_1.TabIndex = 0;
            this.btn_1.Text = "Select Files";
            this.btn_1.UseVisualStyleBackColor = true;
            this.btn_1.Click += new System.EventHandler(this.btn_1_Click);
            // 
            // lbl_1
            // 
            this.lbl_1.AutoSize = true;
            this.lbl_1.Location = new System.Drawing.Point(319, 60);
            this.lbl_1.Name = "lbl_1";
            this.lbl_1.Size = new System.Drawing.Size(100, 13);
            this.lbl_1.TabIndex = 1;
            this.lbl_1.Text = "Please Select a File";
            // 
            // box_0108
            // 
            this.box_0108.Location = new System.Drawing.Point(322, 322);
            this.box_0108.MaxLength = 15;
            this.box_0108.Name = "box_0108";
            this.box_0108.Size = new System.Drawing.Size(100, 20);
            this.box_0108.TabIndex = 3;
            this.box_0108.TextChanged += new System.EventHandler(this.box_0108_TextChanged);
            // 
            // box_0102
            // 
            this.box_0102.Location = new System.Drawing.Point(322, 163);
            this.box_0102.MaxLength = 15;
            this.box_0102.Name = "box_0102";
            this.box_0102.Size = new System.Drawing.Size(100, 20);
            this.box_0102.TabIndex = 4;
            this.box_0102.TextChanged += new System.EventHandler(this.box_0102_TextChanged);
            // 
            // box_0103
            // 
            this.box_0103.Location = new System.Drawing.Point(322, 189);
            this.box_0103.MaxLength = 15;
            this.box_0103.Name = "box_0103";
            this.box_0103.Size = new System.Drawing.Size(100, 20);
            this.box_0103.TabIndex = 5;
            this.box_0103.TextChanged += new System.EventHandler(this.box_0103_TextChanged);
            // 
            // box_0104
            // 
            this.box_0104.Location = new System.Drawing.Point(322, 215);
            this.box_0104.MaxLength = 15;
            this.box_0104.Name = "box_0104";
            this.box_0104.Size = new System.Drawing.Size(100, 20);
            this.box_0104.TabIndex = 6;
            this.box_0104.TextChanged += new System.EventHandler(this.box_0104_TextChanged);
            // 
            // box_0105
            // 
            this.box_0105.Location = new System.Drawing.Point(322, 241);
            this.box_0105.MaxLength = 15;
            this.box_0105.Name = "box_0105";
            this.box_0105.Size = new System.Drawing.Size(100, 20);
            this.box_0105.TabIndex = 7;
            this.box_0105.TextChanged += new System.EventHandler(this.box_0105_TextChanged);
            // 
            // box_0106
            // 
            this.box_0106.Location = new System.Drawing.Point(322, 270);
            this.box_0106.MaxLength = 15;
            this.box_0106.Name = "box_0106";
            this.box_0106.Size = new System.Drawing.Size(100, 20);
            this.box_0106.TabIndex = 8;
            this.box_0106.TextChanged += new System.EventHandler(this.box_0106_TextChanged);
            // 
            // box_0107
            // 
            this.box_0107.Location = new System.Drawing.Point(322, 296);
            this.box_0107.MaxLength = 15;
            this.box_0107.Name = "box_0107";
            this.box_0107.Size = new System.Drawing.Size(100, 20);
            this.box_0107.TabIndex = 9;
            this.box_0107.TextChanged += new System.EventHandler(this.box_0107_TextChanged);
            // 
            // box_0101
            // 
            this.box_0101.Location = new System.Drawing.Point(322, 137);
            this.box_0101.MaxLength = 15;
            this.box_0101.Name = "box_0101";
            this.box_0101.Size = new System.Drawing.Size(100, 20);
            this.box_0101.TabIndex = 10;
            this.box_0101.Visible = false;
            this.box_0101.TextChanged += new System.EventHandler(this.box_0101_TextChanged);
            // 
            // btn_2
            // 
            this.btn_2.Location = new System.Drawing.Point(308, 365);
            this.btn_2.Name = "btn_2";
            this.btn_2.Size = new System.Drawing.Size(127, 59);
            this.btn_2.TabIndex = 11;
            this.btn_2.Text = "Submit";
            this.btn_2.UseVisualStyleBackColor = true;
            this.btn_2.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(335, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "HODS Codes";
            // 
            // label_8
            // 
            this.label_8.AutoSize = true;
            this.label_8.Location = new System.Drawing.Point(243, 325);
            this.label_8.Name = "label_8";
            this.label_8.Size = new System.Drawing.Size(77, 13);
            this.label_8.TabIndex = 14;
            this.label_8.Text = "IonCode_0108";
            // 
            // label_7
            // 
            this.label_7.AutoSize = true;
            this.label_7.Location = new System.Drawing.Point(243, 300);
            this.label_7.Name = "label_7";
            this.label_7.Size = new System.Drawing.Size(77, 13);
            this.label_7.TabIndex = 15;
            this.label_7.Text = "IonCode_0107";
            // 
            // label_6
            // 
            this.label_6.AutoSize = true;
            this.label_6.Location = new System.Drawing.Point(243, 273);
            this.label_6.Name = "label_6";
            this.label_6.Size = new System.Drawing.Size(77, 13);
            this.label_6.TabIndex = 16;
            this.label_6.Text = "IonCode_0106";
            // 
            // label_5
            // 
            this.label_5.AutoSize = true;
            this.label_5.Location = new System.Drawing.Point(243, 244);
            this.label_5.Name = "label_5";
            this.label_5.Size = new System.Drawing.Size(77, 13);
            this.label_5.TabIndex = 17;
            this.label_5.Text = "IonCode_0105";
            // 
            // label_4
            // 
            this.label_4.AutoSize = true;
            this.label_4.Location = new System.Drawing.Point(243, 219);
            this.label_4.Name = "label_4";
            this.label_4.Size = new System.Drawing.Size(77, 13);
            this.label_4.TabIndex = 18;
            this.label_4.Text = "IonCode_0104";
            // 
            // label_3
            // 
            this.label_3.AutoSize = true;
            this.label_3.Location = new System.Drawing.Point(243, 192);
            this.label_3.Name = "label_3";
            this.label_3.Size = new System.Drawing.Size(77, 13);
            this.label_3.TabIndex = 19;
            this.label_3.Text = "IonCode_0103";
            // 
            // label_2
            // 
            this.label_2.AutoSize = true;
            this.label_2.Location = new System.Drawing.Point(243, 166);
            this.label_2.Name = "label_2";
            this.label_2.Size = new System.Drawing.Size(77, 13);
            this.label_2.TabIndex = 20;
            this.label_2.Text = "IonCode_0102";
            this.label_2.Click += new System.EventHandler(this.label9_Click);
            // 
            // label_1
            // 
            this.label_1.AutoSize = true;
            this.label_1.Location = new System.Drawing.Point(243, 140);
            this.label_1.Name = "label_1";
            this.label_1.Size = new System.Drawing.Size(77, 13);
            this.label_1.TabIndex = 21;
            this.label_1.Text = "IonCode_0101";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(115, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(535, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Select a file first, enter HODS codes in the relevant boxes, then click \'Submit\'";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Location = new System.Drawing.Point(481, 388);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(0, 13);
            this.warningLabel.TabIndex = 23;
            // 
            // textWarning1
            // 
            this.textWarning1.AutoSize = true;
            this.textWarning1.Location = new System.Drawing.Point(481, 137);
            this.textWarning1.Name = "textWarning1";
            this.textWarning1.Size = new System.Drawing.Size(0, 13);
            this.textWarning1.TabIndex = 24;
            // 
            // textWarning2
            // 
            this.textWarning2.AutoSize = true;
            this.textWarning2.Location = new System.Drawing.Point(481, 163);
            this.textWarning2.Name = "textWarning2";
            this.textWarning2.Size = new System.Drawing.Size(0, 13);
            this.textWarning2.TabIndex = 25;
            // 
            // textWarning3
            // 
            this.textWarning3.AutoSize = true;
            this.textWarning3.Location = new System.Drawing.Point(481, 189);
            this.textWarning3.Name = "textWarning3";
            this.textWarning3.Size = new System.Drawing.Size(0, 13);
            this.textWarning3.TabIndex = 26;
            // 
            // textWarning4
            // 
            this.textWarning4.AutoSize = true;
            this.textWarning4.Location = new System.Drawing.Point(481, 215);
            this.textWarning4.Name = "textWarning4";
            this.textWarning4.Size = new System.Drawing.Size(0, 13);
            this.textWarning4.TabIndex = 27;
            // 
            // textWarning5
            // 
            this.textWarning5.AutoSize = true;
            this.textWarning5.Location = new System.Drawing.Point(481, 241);
            this.textWarning5.Name = "textWarning5";
            this.textWarning5.Size = new System.Drawing.Size(0, 13);
            this.textWarning5.TabIndex = 28;
            // 
            // textWarning6
            // 
            this.textWarning6.AutoSize = true;
            this.textWarning6.Location = new System.Drawing.Point(481, 270);
            this.textWarning6.Name = "textWarning6";
            this.textWarning6.Size = new System.Drawing.Size(0, 13);
            this.textWarning6.TabIndex = 29;
            // 
            // textWarning7
            // 
            this.textWarning7.AutoSize = true;
            this.textWarning7.Location = new System.Drawing.Point(481, 296);
            this.textWarning7.Name = "textWarning7";
            this.textWarning7.Size = new System.Drawing.Size(0, 13);
            this.textWarning7.TabIndex = 30;
            // 
            // textWarning8
            // 
            this.textWarning8.AutoSize = true;
            this.textWarning8.Location = new System.Drawing.Point(481, 322);
            this.textWarning8.Name = "textWarning8";
            this.textWarning8.Size = new System.Drawing.Size(0, 13);
            this.textWarning8.TabIndex = 31;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBox1.Location = new System.Drawing.Point(559, 75);
            this.comboBox1.MaxDropDownItems = 12;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(175, 21);
            this.comboBox1.TabIndex = 32;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(556, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Number of samples";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textWarning8);
            this.Controls.Add(this.textWarning7);
            this.Controls.Add(this.textWarning6);
            this.Controls.Add(this.textWarning5);
            this.Controls.Add(this.textWarning4);
            this.Controls.Add(this.textWarning3);
            this.Controls.Add(this.textWarning2);
            this.Controls.Add(this.textWarning1);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_1);
            this.Controls.Add(this.label_2);
            this.Controls.Add(this.label_3);
            this.Controls.Add(this.label_4);
            this.Controls.Add(this.label_5);
            this.Controls.Add(this.label_6);
            this.Controls.Add(this.label_7);
            this.Controls.Add(this.label_8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_2);
            this.Controls.Add(this.box_0101);
            this.Controls.Add(this.box_0107);
            this.Controls.Add(this.box_0106);
            this.Controls.Add(this.box_0105);
            this.Controls.Add(this.box_0104);
            this.Controls.Add(this.box_0103);
            this.Controls.Add(this.box_0102);
            this.Controls.Add(this.box_0108);
            this.Controls.Add(this.lbl_1);
            this.Controls.Add(this.btn_1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_1;
        private System.Windows.Forms.Label lbl_1;

        private System.Windows.Forms.TextBox box_0101;
        private System.Windows.Forms.TextBox box_0102;
        private System.Windows.Forms.TextBox box_0103;
        private System.Windows.Forms.TextBox box_0104;
        private System.Windows.Forms.TextBox box_0105;
        private System.Windows.Forms.TextBox box_0106;
        private System.Windows.Forms.TextBox box_0107;
        private System.Windows.Forms.TextBox box_0108;

        private System.Windows.Forms.Button btn_2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_8;
        private System.Windows.Forms.Label label_7;
        private System.Windows.Forms.Label label_6;
        private System.Windows.Forms.Label label_5;
        private System.Windows.Forms.Label label_4;
        private System.Windows.Forms.Label label_3;
        private System.Windows.Forms.Label label_2;
        private System.Windows.Forms.Label label_1;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Label textWarning1;
        private System.Windows.Forms.Label textWarning2;
        private System.Windows.Forms.Label textWarning3;
        private System.Windows.Forms.Label textWarning4;
        private System.Windows.Forms.Label textWarning5;
        private System.Windows.Forms.Label textWarning6;
        private System.Windows.Forms.Label textWarning7;
        private System.Windows.Forms.Label textWarning8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label11;

    }
}

