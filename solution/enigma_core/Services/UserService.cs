using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using enigma_core.Models;
using enigma_core.Repository;

namespace enigma_core.Services
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();

        public User GetUser(int id)
        {
            return userRepository.GetItemById(id);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await userRepository.GetItemByIdAsync(id);
        }

        public async Task<List<User>> GetAllUsersAsync(int limitrecords)
        {
            return await userRepository.GetAllAsync(limitrecords);
        }

    }
}
