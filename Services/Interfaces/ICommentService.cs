using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Comment;

namespace ArticleManagementAPI.Services.Interfaces
{
	public interface ICommentService
	{
		Task<Result<GetCommentDto>> AddCommentAsync(Guid userId, int articleId, CommentRequestDto dto);
		Task<Result<GetCommentDto>> GetCommentByIdAsync(int id);
	}
}