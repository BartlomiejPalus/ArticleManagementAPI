namespace ArticleManagementAPI.Common.Interfaces
{
	public interface IAppLogger
	{
		void Debug(string message);
		void Error(Exception ex);
		void Error(string message);
		void Info(string message);
		void Warn(string message);
	}
}