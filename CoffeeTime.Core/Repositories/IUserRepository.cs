using CoffeeTime.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeTime.Core.DTOs;
namespace CoffeeTime.Core.Repositories
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public Task AddAsync(User user);


        //חדשים:
        public User GetById(int id);
        public Task UpdateAsync(User user);
        public Task DeleteAsync(int id);

    }
}
