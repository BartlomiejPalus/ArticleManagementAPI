namespace ArticleManagement.Desktop.Controls
{
	partial class LoginControl
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
			tableLayoutPanel2 = new TableLayoutPanel();
			loginButton = new Button();
			panel1 = new Panel();
			textBox1 = new TextBox();
			emailText = new Label();
			panel2 = new Panel();
			textBox2 = new TextBox();
			label2 = new Label();
			label1 = new Label();
			linkLabel1 = new LinkLabel();
			tableLayoutPanel2.SuspendLayout();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 3;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.Controls.Add(loginButton, 1, 3);
			tableLayoutPanel2.Controls.Add(panel1, 1, 1);
			tableLayoutPanel2.Controls.Add(panel2, 1, 2);
			tableLayoutPanel2.Controls.Add(label1, 1, 0);
			tableLayoutPanel2.Controls.Add(linkLabel1, 1, 4);
			tableLayoutPanel2.Dock = DockStyle.Fill;
			tableLayoutPanel2.Location = new Point(0, 0);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 5;
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
			tableLayoutPanel2.Size = new Size(450, 300);
			tableLayoutPanel2.TabIndex = 8;
			// 
			// loginButton
			// 
			loginButton.Anchor = AnchorStyles.None;
			loginButton.AutoSize = true;
			loginButton.Font = new Font("Segoe UI", 12F);
			loginButton.Location = new Point(175, 212);
			loginButton.Margin = new Padding(3, 2, 3, 2);
			loginButton.Name = "loginButton";
			loginButton.Size = new Size(100, 31);
			loginButton.TabIndex = 3;
			loginButton.Text = "Login";
			loginButton.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(emailText);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(128, 103);
			panel1.Name = "panel1";
			panel1.Size = new Size(194, 44);
			panel1.TabIndex = 8;
			// 
			// textBox1
			// 
			textBox1.Dock = DockStyle.Top;
			textBox1.Font = new Font("Segoe UI", 12F);
			textBox1.Location = new Point(0, 21);
			textBox1.Margin = new Padding(3, 2, 3, 2);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(194, 29);
			textBox1.TabIndex = 2;
			// 
			// emailText
			// 
			emailText.AutoSize = true;
			emailText.Dock = DockStyle.Top;
			emailText.Font = new Font("Segoe UI", 12F);
			emailText.Location = new Point(0, 0);
			emailText.Name = "emailText";
			emailText.Size = new Size(57, 21);
			emailText.TabIndex = 1;
			emailText.Text = "E-mail:";
			// 
			// panel2
			// 
			panel2.Controls.Add(textBox2);
			panel2.Controls.Add(label2);
			panel2.Dock = DockStyle.Fill;
			panel2.Location = new Point(128, 153);
			panel2.Name = "panel2";
			panel2.Size = new Size(194, 44);
			panel2.TabIndex = 8;
			// 
			// textBox2
			// 
			textBox2.Dock = DockStyle.Top;
			textBox2.Font = new Font("Segoe UI", 12F);
			textBox2.Location = new Point(0, 21);
			textBox2.Margin = new Padding(3, 2, 3, 2);
			textBox2.Name = "textBox2";
			textBox2.PasswordChar = '●';
			textBox2.Size = new Size(194, 29);
			textBox2.TabIndex = 5;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Dock = DockStyle.Top;
			label2.Font = new Font("Segoe UI", 12F);
			label2.Location = new Point(0, 0);
			label2.Name = "label2";
			label2.Size = new Size(79, 21);
			label2.TabIndex = 4;
			label2.Text = "Password:";
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.None;
			label1.Font = new Font("Segoe UI", 22F);
			label1.Location = new Point(161, 19);
			label1.Name = "label1";
			label1.RightToLeft = RightToLeft.No;
			label1.Size = new Size(127, 61);
			label1.TabIndex = 0;
			label1.Text = "Login";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			label1.Click += label1_Click;
			// 
			// linkLabel1
			// 
			linkLabel1.Anchor = AnchorStyles.Top;
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new Point(137, 255);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new Size(175, 15);
			linkLabel1.TabIndex = 4;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Don't have an account? Sign Up";
			// 
			// LoginControl
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(tableLayoutPanel2);
			Name = "LoginControl";
			Size = new Size(450, 300);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel2;
		private Panel panel1;
		private TextBox textBox1;
		private Label emailText;
		private Panel panel2;
		private TextBox textBox2;
		private Label label2;
		private Label label1;
		private LinkLabel linkLabel1;
		private Button loginButton;
	}
}
