using HealthCareAPI.Interfaces;
using HealthCareAPI.Models;
using HealthCareAPI.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace HealthCareAPI.Services
{
    public class UserRepo : IUserRepo<User,string>
    {
        private readonly HealthCareContext _healthCareContext;
        private readonly ILogger<UserRepo> _logger;

        public UserRepo(HealthCareContext healthCareContext, ILogger<UserRepo> logger) 
        { 
            _healthCareContext = healthCareContext;
            _logger = logger;
        }
        public async Task<User?> Add(User user)
        {
            try
            {
                _healthCareContext.Add(user);
                await _healthCareContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }
        public async Task<User?> GetIDByEmail(string email)
        {
            var user = await _healthCareContext.Users.FirstOrDefaultAsync(d => d.EmailID == email);
            if (user != null)
                return user;
            return null;
        }
        public async Task<User?> Get(string id)
        {
            var users = await _healthCareContext.Users.FirstOrDefaultAsync(d => d.UserId == id);
            if (users != null)
                return users;
            return null;
        }

        public async Task<User?> Update(User user)
        {
            var users = _healthCareContext.Users.FirstOrDefault(d => d.UserId == user.UserId);
            if(users != null)
            {
                users.Status = user.Status;
                _healthCareContext.Update(users);
                await _healthCareContext.SaveChangesAsync();
                return users;
            }
            return null;
        }
    }
}
