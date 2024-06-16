using AutoMapper;
using Mountains_Forum.Entities;
using Mountains_Forum.Exceptions;
using Mountains_Forum.Models;

namespace Mountains_Forum.Services
{
    public class PostService
    {
        private readonly ForumDbContext dbContext;
        private readonly IMapper mapper;

        public PostService(ForumDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
/*        public IEnumerable<PostDto> GetAlGetAllPostsByTopicId(int topicId)
        {

        }*/
    }
}
