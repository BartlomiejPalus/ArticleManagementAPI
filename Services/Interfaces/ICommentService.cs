using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Comment;

namespace ArticleManagementAPI.Services.Interfaces
{
	public interface ICommentService
	{
		Task<Result<GetCommentDto>> GetCommentByIdAsync(int id);
	}
}