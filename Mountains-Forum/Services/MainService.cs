using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mountains_Forum.Entities;
using Mountains_Forum.Exceptions;
using Mountains_Forum.Models;

namespace Mountains_Forum.Services
{
    public interface IMainService
    {
        IEnumerable<CategoryDto> GetAllCategories();
        CategoryDto GetCategoryById(int id);
        int CreateCategory(CreateCategoryDto dto);
    }

    public class MainService : IMainService
    {
        private readonly ForumDbContext dbContext;
        private readonly IMapper mapper;

        public MainService(ForumDbContext forumDbContext, IMapper mapper)
        {
            dbContext = forumDbContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = dbContext.Categories.ToList();

            var categoriesDtos = mapper.Map<List<CategoryDto>>(categories);

            return categoriesDtos;
        }
        [HttpGet]
        public CategoryDto GetCategoryById(int id)
        {
            var category = dbContext.Categories.FirstOrDefault(f => f.Id== id);

            if(category==null)
            {
                throw new NotFoundException("category not found");
            }

            var result = mapper.Map<CategoryDto>(category);

            return(result);
        }
        [HttpPost]
        public int CreateCategory(CreateCategoryDto dto)
        {
            var category = mapper.Map<Category>(dto);

            dbContext.Categories.Add(category);
            dbContext.SaveChanges();

            return category.Id;
        }

    }
}
