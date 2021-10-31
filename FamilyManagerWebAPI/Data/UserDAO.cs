using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace FamilyManagerWebAPI.Data {
    public class UserDao : IUserDao {
        private UserFileContext _fileContext;

        public UserDao() {
            _fileContext = new UserFileContext();
        }

        public async Task<User> GetUserAsync(string username, string password) {
            User user = _fileContext.Users.FirstOrDefault(
                u => u.Username.Equals(username) && u.Password.Equals(password));
            if (user == null)
                throw new NullReferenceException("No user found");
            return user;
        }

        public async Task<User> AddUserAsync(User user) {
            User first = _fileContext.Users.FirstOrDefault(u => u.Username.Equals(user.Username, StringComparison.CurrentCultureIgnoreCase));
            if (first!=null && first.Equals(user))
                throw new Exception("User already exists");
            _fileContext.Users.Add(user);
            _fileContext.WriteUsersToFile();
            return first;
        }
    }
}