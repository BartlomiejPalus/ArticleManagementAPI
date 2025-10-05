using ArticleManagementAPI.DTOs.Comment;
using ArticleManagementAPI.Models;
using AutoMapper;

namespace ArticleManagementAPI.Profiles
{
	public class CommentProfile : Profile
	{
		public CommentProfile()
		{
			CreateMap<Comment, GetCommentDto>();
		}
	}
}
