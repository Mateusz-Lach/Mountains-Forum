using AutoMapper;
using Mountains_Forum.Entities;
using Mountains_Forum.Models;

namespace Mountains_Forum
{
    public class MountainsMappingProfile : Profile
    {
        public MountainsMappingProfile()
        {
            CreateMap<Category, CategoryDto>();

            CreateMap<Topic, TopicDto>();

            CreateMap<Post, PostDto>();

            CreateMap<CreateCategoryDto, Category>();

            CreateMap<CreateTopicDto, Topic>();
        }
    }
}
