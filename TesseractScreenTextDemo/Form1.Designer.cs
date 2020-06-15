namespace TesseractScreenTextDemo
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.ddlScale = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.ddlLanguage = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnRecognize = new System.Windows.Forms.Button();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.lblRect = new System.Windows.Forms.Label();
			this.chkDenoise = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Location = new System.Drawing.Point(15, 25);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(683, 94);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Captured:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 189);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Recognized:";
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.textBox1.Location = new System.Drawing.Point(18, 205);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(680, 94);
			this.textBox1.TabIndex = 2;
			// 
			// ddlScale
			// 
			this.ddlScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlScale.FormattingEnabled = true;
			this.ddlScale.Items.AddRange(new object[] {
            "1x",
            "2x",
            "4x"});
			this.ddlScale.Location = new System.Drawing.Point(15, 150);
			this.ddlScale.Name = "ddlScale";
			this.ddlScale.Size = new System.Drawing.Size(167, 21);
			this.ddlScale.TabIndex = 4;
			this.ddlScale.SelectedIndexChanged += new System.EventHandler(this.ddlScale_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 134);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Image scale:";
			// 
			// ddlLanguage
			// 
			this.ddlLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlLanguage.FormattingEnabled = true;
			this.ddlLanguage.Items.AddRange(new object[] {
            "English",
            "Chinese Simplified"});
			this.ddlLanguage.Location = new System.Drawing.Point(203, 150);
			this.ddlLanguage.Name = "ddlLanguage";
			this.ddlLanguage.Size = new System.Drawing.Size(167, 21);
			this.ddlLanguage.TabIndex = 6;
			this.ddlLanguage.SelectedIndexChanged += new System.EventHandler(this.ddlLanguage_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(203, 134);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Language:";
			// 
			// btnRecognize
			// 
			this.btnRecognize.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRecognize.Enabled = false;
			this.btnRecognize.Location = new System.Drawing.Point(583, 144);
			this.btnRecognize.Name = "btnRecognize";
			this.btnRecognize.Size = new System.Drawing.Size(115, 30);
			this.btnRecognize.TabIndex = 7;
			this.btnRecognize.Text = "Recognize";
			this.btnRecognize.Click += new System.EventHandler(this.btnRecognize_Click);
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(525, 9);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(139, 13);
			this.linkLabel1.TabIndex = 10;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Click to capture from screen";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// lblRect
			// 
			this.lblRect.AutoSize = true;
			this.lblRect.Location = new System.Drawing.Point(71, 9);
			this.lblRect.Name = "lblRect";
			this.lblRect.Size = new System.Drawing.Size(45, 13);
			this.lblRect.TabIndex = 11;
			this.lblRect.Text = "<None>";
			// 
			// chkDenoise
			// 
			this.chkDenoise.AutoSize = true;
			this.chkDenoise.Location = new System.Drawing.Point(385, 152);
			this.chkDenoise.Name = "chkDenoise";
			this.chkDenoise.Size = new System.Drawing.Size(80, 17);
			this.chkDenoise.TabIndex = 12;
			this.chkDenoise.Text = "Binarisation";
			this.chkDenoise.UseVisualStyleBackColor = true;
			this.chkDenoise.CheckedChanged += new System.EventHandler(this.chkDenoise_CheckedChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(717, 311);
			this.Controls.Add(this.chkDenoise);
			this.Controls.Add(this.lblRect);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.btnRecognize);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ddlLanguage);
			this.Controls.Add(this.ddlScale);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "TesseractScreenText Demo";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ComboBox ddlScale;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox ddlLanguage;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnRecognize;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label lblRect;
		private System.Windows.Forms.CheckBox chkDenoise;
	}
}

