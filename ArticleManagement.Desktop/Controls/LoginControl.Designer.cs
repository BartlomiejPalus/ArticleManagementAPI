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
			loginLabel = new Label();
			emailPanel = new Panel();
			emailTextBox = new TextBox();
			emailLabel = new Label();
			passwordPanel = new Panel();
			passwordTextBox = new TextBox();
			passwordLabel = new Label();
			errorLabel = new Label();
			loginButton = new Button();
			registerLabel = new LinkLabel();
			tableLayoutPanel2.SuspendLayout();
			emailPanel.SuspendLayout();
			passwordPanel.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 3;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.Controls.Add(loginLabel, 1, 0);
			tableLayoutPanel2.Controls.Add(emailPanel, 1, 1);
			tableLayoutPanel2.Controls.Add(passwordPanel, 1, 2);
			tableLayoutPanel2.Controls.Add(errorLabel, 1, 3);
			tableLayoutPanel2.Controls.Add(loginButton, 1, 4);
			tableLayoutPanel2.Controls.Add(registerLabel, 1, 5);
			tableLayoutPanel2.Dock = DockStyle.Fill;
			tableLayoutPanel2.Location = new Point(0, 0);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 6;
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
			tableLayoutPanel2.Size = new Size(450, 400);
			tableLayoutPanel2.TabIndex = 8;
			// 
			// loginLabel
			// 
			loginLabel.Anchor = AnchorStyles.None;
			loginLabel.Font = new Font("Segoe UI", 22F);
			loginLabel.Location = new Point(161, 9);
			loginLabel.Name = "loginLabel";
			loginLabel.RightToLeft = RightToLeft.No;
			loginLabel.Size = new Size(127, 61);
			loginLabel.TabIndex = 0;
			loginLabel.Text = "Login";
			loginLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// emailPanel
			// 
			emailPanel.Controls.Add(emailTextBox);
			emailPanel.Controls.Add(emailLabel);
			emailPanel.Dock = DockStyle.Fill;
			emailPanel.Location = new Point(128, 83);
			emailPanel.Name = "emailPanel";
			emailPanel.Size = new Size(194, 97);
			emailPanel.TabIndex = 8;
			// 
			// emailTextBox
			// 
			emailTextBox.Dock = DockStyle.Top;
			emailTextBox.Font = new Font("Segoe UI", 12F);
			emailTextBox.Location = new Point(0, 21);
			emailTextBox.Margin = new Padding(3, 2, 3, 2);
			emailTextBox.Name = "emailTextBox";
			emailTextBox.Size = new Size(194, 29);
			emailTextBox.TabIndex = 2;
			// 
			// emailLabel
			// 
			emailLabel.AutoSize = true;
			emailLabel.Dock = DockStyle.Top;
			emailLabel.Font = new Font("Segoe UI", 12F);
			emailLabel.Location = new Point(0, 0);
			emailLabel.Name = "emailLabel";
			emailLabel.Size = new Size(57, 21);
			emailLabel.TabIndex = 1;
			emailLabel.Text = "E-mail:";
			// 
			// passwordPanel
			// 
			passwordPanel.Controls.Add(passwordTextBox);
			passwordPanel.Controls.Add(passwordLabel);
			passwordPanel.Dock = DockStyle.Fill;
			passwordPanel.Location = new Point(128, 186);
			passwordPanel.Name = "passwordPanel";
			passwordPanel.Size = new Size(194, 97);
			passwordPanel.TabIndex = 8;
			// 
			// passwordTextBox
			// 
			passwordTextBox.Dock = DockStyle.Top;
			passwordTextBox.Font = new Font("Segoe UI", 12F);
			passwordTextBox.Location = new Point(0, 21);
			passwordTextBox.Margin = new Padding(3, 2, 3, 2);
			passwordTextBox.Name = "passwordTextBox";
			passwordTextBox.PasswordChar = '●';
			passwordTextBox.Size = new Size(194, 29);
			passwordTextBox.TabIndex = 5;
			// 
			// passwordLabel
			// 
			passwordLabel.AutoSize = true;
			passwordLabel.Dock = DockStyle.Top;
			passwordLabel.Font = new Font("Segoe UI", 12F);
			passwordLabel.Location = new Point(0, 0);
			passwordLabel.Name = "passwordLabel";
			passwordLabel.Size = new Size(79, 21);
			passwordLabel.TabIndex = 4;
			passwordLabel.Text = "Password:";
			// 
			// errorLabel
			// 
			errorLabel.Anchor = AnchorStyles.None;
			errorLabel.AutoSize = true;
			errorLabel.Font = new Font("Segoe UI", 10F);
			errorLabel.ForeColor = Color.Red;
			errorLabel.Location = new Point(205, 286);
			errorLabel.Name = "errorLabel";
			errorLabel.Size = new Size(39, 19);
			errorLabel.TabIndex = 9;
			errorLabel.Text = "error";
			// 
			// loginButton
			// 
			loginButton.Anchor = AnchorStyles.None;
			loginButton.AutoSize = true;
			loginButton.Font = new Font("Segoe UI", 12F);
			loginButton.Location = new Point(175, 317);
			loginButton.Margin = new Padding(3, 2, 3, 2);
			loginButton.Name = "loginButton";
			loginButton.Size = new Size(100, 31);
			loginButton.TabIndex = 3;
			loginButton.Text = "Login";
			loginButton.UseVisualStyleBackColor = true;
			loginButton.Click += loginButton_Click;
			// 
			// registerLabel
			// 
			registerLabel.Anchor = AnchorStyles.Top;
			registerLabel.AutoSize = true;
			registerLabel.Location = new Point(137, 360);
			registerLabel.Name = "registerLabel";
			registerLabel.Size = new Size(175, 15);
			registerLabel.TabIndex = 4;
			registerLabel.TabStop = true;
			registerLabel.Text = "Don't have an account? Sign Up";
			// 
			// LoginControl
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(tableLayoutPanel2);
			Name = "LoginControl";
			Size = new Size(450, 400);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			emailPanel.ResumeLayout(false);
			emailPanel.PerformLayout();
			passwordPanel.ResumeLayout(false);
			passwordPanel.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel2;
		private Panel emailPanel;
		private TextBox emailTextBox;
		private Label emailLabel;
		private Panel passwordPanel;
		private TextBox passwordTextBox;
		private Label passwordLabel;
		private Label loginLabel;
		private LinkLabel registerLabel;
		private Button loginButton;
		private Label errorLabel;
	}
}
