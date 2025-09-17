using ArticleManagementAPI.Common;
using ArticleManagementAPI.DTOs.Comment;
using ArticleManagementAPI.DTOs.Common;
using ArticleManagementAPI.Enums;
using ArticleManagementAPI.Models;
using ArticleManagementAPI.Repositories.Interfaces;
using ArticleManagementAPI.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ArticleManagementAPI.Services
{
	public class CommentService : ICommentService
	{
		private readonly ICommentRepository _commentRepository;
		private readonly IMapper _mapper;

		public CommentService(ICommentRepository commentRepository, IMapper mapper)
		{
			_commentRepository = commentRepository;
			_mapper = mapper;
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
				return Result<GetCommentDto>.Failure(ErrorType.NotFound, "Failed to retrieve added comment");

			var commentDto = _mapper.Map<GetCommentDto>(comment);

			return Result<GetCommentDto>.Success(commentDto);
		}
		
		public async Task<Result<GetCommentDto>> GetCommentByIdAsync(int id)
		{
			var comment = await _commentRepository.GetByIdAsync(id);

			if (comment == null)
				return Result<GetCommentDto>.Failure(ErrorType.NotFound, "Comment not found");

			var commentDto = _mapper.Map<GetCommentDto>(comment);

			return Result<GetCommentDto>.Success(commentDto);
		}

		public async Task<Result<PagedResultDto<GetCommentDto>>> GetCommentsAsync(Guid? userId, int? articleId, CommentFilterDto dto)
		{
			var query = _commentRepository.GetAll();

			if (userId.HasValue)
				query = query.Where(c => c.UserId == userId.Value);
			else if (articleId.HasValue)
				query = query.Where(c => c.ArticleId == articleId.Value);
			else
				return Result<PagedResultDto<GetCommentDto>>.Failure(ErrorType.BadRequest, "Missing filter");

			query = ApplySorting(query, dto);

			var totalComments = await query.CountAsync();

			query = ApplyPagination(query, dto);

			var items = await query
				.Select(comment => _mapper.Map<GetCommentDto>(comment))
				.ToListAsync();

			var pagedResult = new PagedResultDto<GetCommentDto>
			{
				Items = items,
				TotalCount = totalComments,
				PageNumber = dto.PageNumber,
				PageSize = dto.PageSize
			};

			return Result<PagedResultDto<GetCommentDto>>.Success(pagedResult);
		}

		private IQueryable<Comment> ApplySorting(IQueryable<Comment> query, CommentFilterDto dto)
		{
			return dto.SortDescending ? query.OrderByDescending(c => c.CreatedAt) : query.OrderBy(c => c.CreatedAt);
		}

		private IQueryable<Comment> ApplyPagination(IQueryable<Comment> query, CommentFilterDto dto)
		{
			return query.Skip(dto.PageSize * (dto.PageNumber - 1)).Take(dto.PageSize);
		}

		public async Task<Result> RemoveCommentAsync(Guid userId, bool isAdmin, int commentId)
		{
			var comment = await _commentRepository.GetByIdAsync(commentId);

			if (comment == null)
				return Result.Failure(ErrorType.NotFound, "Comment not found");

			if (comment.UserId != userId && !isAdmin)
				return Result.Failure(ErrorType.Forbidden, "You can only delete your own comments");

			await _commentRepository.RemoveAsync(comment);

			return Result.Success();
		}
	}
}
