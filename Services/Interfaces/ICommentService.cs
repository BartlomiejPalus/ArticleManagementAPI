using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Comment;
using ArticleManagementAPI.DTOs.Common;

namespace ArticleManagementAPI.Services.Interfaces
{
	public interface ICommentService
	{
		Task<Result<GetCommentDto>> AddCommentAsync(Guid userId, int articleId, CommentRequestDto dto);
		Task<Result<GetCommentDto>> GetCommentByIdAsync(int id);
		Task<Result<PagedResultDto<GetCommentDto>>> GetCommentsByArticleId(int articleId, CommentFilterDto dto);
		Task<Result> RemoveCommentAsync(Guid userId, bool isAdmin, int commentId);
	}
}