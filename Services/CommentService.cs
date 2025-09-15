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

		public async Task<Result<GetCommentDto>> AddCommentAsync(Guid userId, int articleId, CommentRequestDto dto)
		{
			var comment = new Comment
			{
				Content = dto.Content,
				UserId = userId,
				ArticleId = articleId,
			};

			await _commentRepository.AddAsync(comment);

			var addedComment = await _commentRepository.GetByIdAsync(comment.Id);

			if (addedComment == null)
				return Result<GetCommentDto>.Failure(Enums.ErrorType.NotFound, "Failed to retrieve added comment");

			var commentDto = new GetCommentDto
			{
				Id = addedComment.Id,
				Content = addedComment.Content,
				CreatedAt = addedComment.CreatedAt,
				UserId = addedComment.UserId,
				UserName = addedComment.User.Name,
				ArticleId = addedComment.ArticleId
			};

			return Result<GetCommentDto>.Success(commentDto);
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
				ArticleId = comment.ArticleId
			};

			return Result<GetCommentDto>.Success(commentDto);
		}
	}
}
