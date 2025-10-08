using ArticleManagement.Desktop.Services.Interfaces;

namespace ArticleManagement.Desktop.Services
{
	public class UserSession : IUserSession
	{
		public string? AccessToken { get; private set; }
		public string? RefreshToken { get; private set; }
		public bool IsLoggedIn => !String.IsNullOrEmpty(AccessToken);

		public void Login(string accessToken, string refreshToken)
		{
			AccessToken = accessToken;
			RefreshToken = refreshToken;
		}
		
		public void Logout()
		{
			AccessToken = null;
			RefreshToken = null;
		}
	}
}
