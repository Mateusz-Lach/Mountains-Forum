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
        int CreatePost(int categoryId, int topicId, CreatePostDto dto);
        bool DeletePost(int categoryId, int topicId, int postId);
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
        public int CreatePost(int categoryId, int topicId, CreatePostDto dto)
        {
            var topic = dbContext.Topics.FirstOrDefault(t => t.Id == topicId && t.CategoryId == categoryId);

            if(topic == null)
            {
                throw new NotFoundException("topic or category with this id doesn't exists");
            }

            var post = mapper.Map<Post>(dto);

            post.TopicId = topicId;

            dbContext.Posts.Add(post);
            dbContext.SaveChanges();

            return post.Id;
        }
        public bool DeletePost(int categoryId, int topicId, int postId)
        {
            var post = dbContext.Posts.FirstOrDefault(p => p.TopicId == topicId && p.Topic.CategoryId == categoryId && p.Id == postId);

            if(post == null){
                return false;
            }

            dbContext.Posts.Remove(post);
            dbContext.SaveChanges();

            return true;
        }
    }
}
