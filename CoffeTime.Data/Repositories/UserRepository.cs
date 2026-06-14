using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeTime.Core.Entities;
using CoffeeTime.Core.Repositories;
namespace CoffeeTime.Data.Repositories
{
    public class  UserRepository: IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public List<User> GetAll()
        {
            return _context.UsersList.ToList();
        }
        public async Task AddAsync(User user)
        {
            _context.UsersList.Add(user);
            await _context.SaveChangesAsync();
        }
        //חדשים:
        public User GetById(int id)
        {
            return _context.UsersList.ToList().Find(u => u.UserId == id);
        }
        public async Task UpdateAsync(User user)
        {

            User u =  _context.UsersList.ToList().Find(u => u.UserId == user.UserId);
            if(u!=null)
            {
                u.UserName = user.UserName;
           u.Adress = user.Adress;
                u.Phon=user.Phon;
                //חדש
              //הורדתי לבדוק  u.orders = user.orders;
                
            }
           await _context.SaveChangesAsync();
                }
        public async Task DeleteAsync(int id)
        {
            User u = _context.UsersList.ToList().Find(u => u.UserId == id);
            if (u != null)
                _context.UsersList.Remove(u);
            await _context.SaveChangesAsync();

        }

    }
}
