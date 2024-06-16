using AutoMapper;
using Mountains_Forum.Entities;
using Mountains_Forum.Exceptions;
using Mountains_Forum.Models;

namespace Mountains_Forum.Services
{
    public interface ITopicService
    {
        IEnumerable<TopicDto> GetAllTopicsById(int categoryId);
        TopicDto GetTopicById(int categoryId, int id);
        IEnumerable<TopicDto> GetAllTopicsByCategoryName(string categoryName);
        int CreateTopic(int categoryId, CreateTopicDto dto);
    }

    public class TopicService : ITopicService
    {
        private readonly ForumDbContext dbContext;
        private readonly IMapper mapper;
        public TopicService(ForumDbContext forumDbContext, IMapper mapper)
        {
            dbContext = forumDbContext;
            this.mapper = mapper;
        }
        public IEnumerable<TopicDto> GetAllTopicsById(int categoryId)
        {
            var topics = dbContext.Topics.Where(t => t.CategoryId == categoryId).ToList();

            var result = mapper.Map<List<TopicDto>>(topics);

            return result;
        }
        public TopicDto GetTopicById(int categoryId, int id)
        {
            var topic = dbContext.Topics.FirstOrDefault(t => t.CategoryId == categoryId && t.Id == id);

            var result = mapper.Map<TopicDto>(topic);

            return result;
        }
        public IEnumerable<TopicDto> GetAllTopicsByCategoryName(string categoryName)
        {
            var categoryId = dbContext.Categories.FirstOrDefault(c => c.Name.ToLower() == categoryName.ToLower()).Id;

            var topics = dbContext.Topics.Where(t => t.CategoryId == categoryId).ToList();

            var result = mapper.Map<List<TopicDto>>(topics);

            return result;
        }
        public int CreateTopic(int categoryId, CreateTopicDto dto)
        {
            var category = dbContext.Categories.FirstOrDefault(c => c.Id== categoryId);

            if (category == null)
            {
                throw new NotFoundException("category with this id doesn't exists");
            }

            var topic = mapper.Map<Topic>(dto);

            topic.CategoryId = categoryId;

            dbContext.Topics.Add(topic);
            dbContext.SaveChanges();

            return topic.Id;
        }
    }
}
