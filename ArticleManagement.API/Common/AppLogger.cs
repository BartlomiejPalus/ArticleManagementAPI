using ArticleManagementAPI.Common.Interfaces;
using NLog;

namespace ArticleManagementAPI.Common
{
	public class AppLogger : IAppLogger
	{
		private readonly NLog.ILogger logger = LogManager.GetCurrentClassLogger();

		public void Info(string message)
		{
			logger.Info(message);
		}

		public void Warn(string message)
		{
			logger.Warn(message);
		}

		public void Debug(string message)
		{
			logger.Debug(message);
		}

		public void Error(string message)
		{
			logger.Error(message);
		}

		public void Error(Exception ex)
		{
			logger.Error(ex);
		}
	}
}
