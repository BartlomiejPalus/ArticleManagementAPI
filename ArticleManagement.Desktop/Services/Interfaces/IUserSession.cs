namespace ArticleManagement.Desktop.Services.Interfaces
{
	public interface IUserSession
	{
		string? AccessToken { get; }
		string? RefreshToken { get; }
		bool IsLoggedIn { get; }

		void Login(string accessToken, string refreshToken);
		void Logout();
	}
}