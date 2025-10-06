using ArticleManagement.Desktop.Services.Interfaces;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Desktop.Services
{
	public class AuthService : IAuthService
	{
		private readonly HttpClient _httpClient;

		public AuthService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<string> LoginAsync(string email, string password)
		{
			await Task.Delay(200);

			return "abc";
		}
	}
}
