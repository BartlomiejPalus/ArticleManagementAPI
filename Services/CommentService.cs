using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Comment;
using ArticleManagementAPI.Models;
using ArticleManagementAPI.Repositories.Interfaces;
using ArticleManagementAPI.Services.Interfaces;

namespace ArticleManagementAPI.Services
{
	public class CommentService : ICommentService
	{
		private readonly ICommentRepository _commentRepository;

		public CommentService(ICommentRepository commentRepository)
		{
			_commentRepository = commentRepository;
		}
		
		public async Task<Result<GetCommentDto>> GetCommentByIdAsync(int id)
		{
			var comment = await _commentRepository.GetByIdAsync(id);

			if (comment == null)
				return Result<GetCommentDto>.Failure(Enums.ErrorType.NotFound, "Comment not found");

			var commentDto = new GetCommentDto
			{
				Id = comment.Id,
				Content = comment.Content,
				CreatedAt = comment.CreatedAt,
				UserId = comment.UserId,
				UserName = comment.User.Name,
			};

			return Result<GetCommentDto>.Success(commentDto);
		}
	}
}
