using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeTime.Core.Entities;
using CoffeeTime.Core.Repositories;
using CoffeeTime.Core.Services;
using CoffeeTime.Core.DTOs;
using AutoMapper;
namespace CoffeeTime.Service
{
    public class UserService : IUserService
    {
      private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
       public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public List<UserDTO> GetList()
        {
            var users= _userRepository.GetAll();
            return _mapper.Map<List<UserDTO>>(users);
        }
        public async Task AddUserAsync(User user)
        {
           await _userRepository.AddAsync(user);
        }
        //חדשים
        public UserDTO GetUser(int id)
        {
            //TODO
            var user= _userRepository.GetById(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            //TODO
           await _userRepository.UpdateAsync(user);
        }
        public async Task DeleteUserAsync(int id)
        {
            //TODO
            await _userRepository.DeleteAsync(id);
        }

    }
}
