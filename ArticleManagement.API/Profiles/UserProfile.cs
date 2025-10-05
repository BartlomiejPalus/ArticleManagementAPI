using ArticleManagementAPI.DTOs.User;
using ArticleManagementAPI.Models;
using AutoMapper;

namespace ArticleManagementAPI.Profiles
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<User, GetUserResponseDto>();

			CreateMap<User, RegisterResponseDto>();
		}
	}
}
