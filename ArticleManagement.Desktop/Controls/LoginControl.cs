using ArticleManagement.Desktop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArticleManagement.Desktop.Controls
{
	public partial class LoginControl : UserControl
	{
		private readonly IAuthService _authService;

		public LoginControl(IAuthService authService)
		{
			InitializeComponent();
			_authService = authService;
		}

		private async void loginButton_Click(object sender, EventArgs e)
		{
			string email = emailTextBox.Text;
			string password = passwordTextBox.Text;

			if (string.IsNullOrEmpty(email))
			{
				errorLabel.Text = "You must enter an e-mail";
				return;
			}
			if (string.IsNullOrEmpty(password))
			{
				errorLabel.Text = "You must enter a password";
				return;
			}

			var result = await _authService.LoginAsync(email, password);

			errorLabel.Text = result;
		}
	}
}
