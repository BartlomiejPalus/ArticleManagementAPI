using ArticleManagement.Desktop.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArticleManagement.Desktop.Forms
{
	public partial class LoginForm : Form
	{
		public LoginForm(LoginControl loginControl)
		{
			InitializeComponent();

			loginControl.Dock = DockStyle.Fill;
			Controls.Add(loginControl);
		}
	}
}
