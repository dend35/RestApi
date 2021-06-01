using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(int id);

        Task<List<User>> List();
        
        Task<User> Create(User user);

        Task<User> Update(User user);

        Task<bool?> Delete(int id);
    }
    
    public class UserService : IUserService
    {
        private readonly Context _context;
        
        public UserService(Context context)
        {
            _context = context;
        }
        
        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.User.SingleOrDefaultAsync(i => i.Id == id);
        }
        
        public async Task<List<User>> List()
        {
            return await _context.User.ToListAsync();
        }
        
        public async Task<User> Create(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        
        public async Task<User> Update(User user)
        {
            var model = await _context.User.SingleOrDefaultAsync(i => i.Id == user.Id);
            if (model == null)
            {
                return null;
            }
            model.Name = user.Name;
            model.BirthDate = user.BirthDate;
            model.Score = user.Score;
            await _context.SaveChangesAsync();
            return user;
        }
        
        public async Task<bool?> Delete(int id)
        {
            var model = await _context.User.SingleOrDefaultAsync(i => i.Id == id);
            if (model == null)
            {
                return null;
            }
            _context.User.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}