namespace ArticleManagement.Desktop.Common
{
	public class Result
	{
		public bool IsSuccess { get; }
		public string? ErrorMessage { get; }

		protected Result(bool isSuccess, string? message)
		{
			IsSuccess = isSuccess;
			ErrorMessage = message;
		}

		public static Result Success() => new(true, null);

		public static Result Failure(string message) => new(false, message);
	}

	public class Result<T> : Result
	{
		public T? Value { get; }

		protected Result(bool isSuccess, string? message, T? value) : base(isSuccess, message)
		{
			Value = value;
		}

		public static Result<T> Success(T value) => new(true, null, value);

		public static new Result<T> Failure(string message) => new(false, message, default);
	}
}
