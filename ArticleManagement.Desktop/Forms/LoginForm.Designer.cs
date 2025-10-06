namespace ArticleManagement.Desktop.Forms
{
	partial class LoginForm
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
			loginControl1 = new ArticleManagement.Desktop.Controls.LoginControl();
			SuspendLayout();
			// 
			// loginControl1
			// 
			loginControl1.Dock = DockStyle.Fill;
			loginControl1.Location = new Point(0, 0);
			loginControl1.Name = "loginControl1";
			loginControl1.Size = new Size(484, 311);
			loginControl1.TabIndex = 0;
			// 
			// LoginForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(484, 311);
			Controls.Add(loginControl1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Margin = new Padding(3, 2, 3, 2);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "LoginForm";
			Text = "Login";
			Load += LoginForm_Load;
			ResumeLayout(false);
		}

		#endregion

		private Controls.LoginControl loginControl1;
	}
}