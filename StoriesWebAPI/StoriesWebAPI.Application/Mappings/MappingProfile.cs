using AutoMapper;
using StoriesWebAPI.Application.DTOs.Follows;
using StoriesWebAPI.Application.DTOs.Genres;
using StoriesWebAPI.Application.DTOs.Stories;
using StoriesWebAPI.Application.DTOs.Users;
using StoriesWebAPI.Domain.Entities;

namespace StoriesWebAPI.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User mappings
            CreateMap<UserRegisterDto, User>();
            CreateMap<UserUpdateDto, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<User, UserDto>();

            // ContributorFollow mappings
            CreateMap<ContributorFollow, ContributorFollowDto>()
                // Lấy thông tin contributor được follow
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Contributor.Username))
                .ForMember(dest => dest.AvatarUrl, opt => opt.MapFrom(src => src.Contributor.AvatarUrl))
                .ForMember(dest => dest.FollowedAt, opt => opt.MapFrom(src => src.FollowedAt));

            // StoryFollow mappings
            CreateMap<StoryFollow, StoryFollowDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.AvatarUrl, opt => opt.MapFrom(src => src.User.AvatarUrl))
                .ForMember(dest => dest.FollowedAt, opt => opt.MapFrom(src => src.FollowedAt))
                .ForMember(dest => dest.StoryId, opt => opt.MapFrom(src => src.StoryId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            // Story mappings
            CreateMap<StoryCreateDto, Story>();
            CreateMap<StoryUpdateDto, Story>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Story, StoryDto>();

            // Genre mappings
            CreateMap<Genre, GenreDto>();

            // StoryGenre mappings
            CreateMap<StoryGenre, GenreDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Genre.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<StoryGenre, StoryDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Story.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Story.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Story.Description))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Story.Type))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Story.Status))
                .ForMember(dest => dest.ContributorId, opt => opt.MapFrom(src => src.Story.ContributorId))
                .ForMember(dest => dest.CoverUrl, opt => opt.MapFrom(src => src.Story.CoverUrl));
        }
    }
}
