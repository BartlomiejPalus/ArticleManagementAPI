using ArticleManagement.Desktop.Common;

namespace ArticleManagement.Desktop.Services.Interfaces
{
	public interface IAuthService
	{
		Task<Result> LoginAsync(string username, string password);
	}
}