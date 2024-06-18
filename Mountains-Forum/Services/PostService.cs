using AutoMapper;
using Mountains_Forum.Entities;
using Mountains_Forum.Exceptions;
using Mountains_Forum.Models;

namespace Mountains_Forum.Services
{
    public interface IPostService
    {
        IEnumerable<PostDto> GetAlGetAllPosts(int categoryId, int topicId);
        PostDto GetPostById(int categoryId, int topicId, int postId);
    }

    public class PostService : IPostService
    {
        private readonly ForumDbContext dbContext;
        private readonly IMapper mapper;

        public PostService(ForumDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public IEnumerable<PostDto> GetAlGetAllPosts(int categoryId, int topicId)
        {
            var posts = dbContext.Posts.Where(p => p.TopicId == topicId && p.Topic.CategoryId == categoryId).ToList();

            var result = mapper.Map<List<PostDto>>(posts);

            return result;
        }
        public PostDto GetPostById(int categoryId, int topicId, int postId)
        {
            var post = dbContext.Posts.FirstOrDefault(p => p.TopicId == topicId && p.Topic.CategoryId == categoryId && p.Id == postId);

            var result = mapper.Map<PostDto>(post);

            return result;
        }
    }
}
