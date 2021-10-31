using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

namespace FamilyManagerWebAPI.Data {
    public class UserFileContext {
        private const string UsersFile = "Data/users.json";
        public IList<User> Users { get; private set; }
        
        public UserFileContext() {
            if (!File.Exists(UsersFile)) {
                Seed();
                WriteUsersToFile();
            }
            else {
                string content = File.ReadAllText(UsersFile);
                Users = JsonSerializer.Deserialize<List<User>>(content);
            }
        }

        private void Seed() {
            Users = new List<User>();
            Users.Add(new User() {
                Username = "Adriana",
                Password = "1234",
                Role = Role.Admin
            });
        }
        
        public void WriteUsersToFile() {
            string usersAsJson = JsonSerializer.Serialize(Users, new JsonSerializerOptions() {
                WriteIndented = true
            });
            File.WriteAllText(UsersFile, usersAsJson);
        }
    }
}