using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Users
{
    public interface ISvUsers
    {
        //READS
        public List<User> GetAllUsers();
        public User GetUserById(int id);
        //WRITES
        public User AddUser(User User);
        public User UpdateUser(int id, User user);
        public void DeleteUser(int id);
        public User validateUser(string userName, string password);

        public List<User> getUserRoles(int id);


    }
}
