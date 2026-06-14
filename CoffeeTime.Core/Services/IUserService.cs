using CoffeeTime.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeTime.Core.DTOs;
namespace CoffeeTime.Core.Services
{
    public interface IUserService
    {
        public List<UserDTO> GetList();
        public  Task AddUserAsync(User user);
        //חדשים:
        public UserDTO GetUser(int id);
        public Task UpdateUserAsync(User user);
        public Task DeleteUserAsync(int id);

    }
}
