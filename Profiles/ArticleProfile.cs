using ArticleManagementAPI.DTOs.Article;
using ArticleManagementAPI.Models;
using AutoMapper;

namespace ArticleManagementAPI.Profiles
{
	public class ArticleProfile : Profile
	{
		public ArticleProfile()
		{
			CreateMap<Article, ArticleListDto>()
				.ForMember(dest => dest.AuthorName,
				opt => opt.MapFrom(src => src.User.Name))
				.ForMember(dest => dest.AuthorId,
				opt => opt.MapFrom(src => src.UserId));

			CreateMap<Article, ArticleDetailsDto>()
				.IncludeBase<Article, ArticleListDto>();

			CreateMap<Category, CategoryDto>();
		}
	}
}
