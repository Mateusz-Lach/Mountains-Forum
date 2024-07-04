using AutoMapper;
using Mountains_Forum.Entities;
using Mountains_Forum.Models;

namespace Mountains_Forum.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
    }

    public class AccountService : IAccountService
    {
        private readonly IMapper mapper;
        private readonly ForumDbContext context;
        public AccountService(IMapper mapper, ForumDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = mapper.Map<User>(dto);

            context.Users.Add(newUser);
            context.SaveChanges();


        }
    }
}
