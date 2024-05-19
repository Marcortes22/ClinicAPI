using Entities;
using Microsoft.EntityFrameworkCore;
using Services.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Users
{
    public class SvUsers : ISvUsers
    {

        private MyContext myDbContext = default!;
        public SvUsers()
        {
            myDbContext = new MyContext();
        }
        public User AddUser(User User)
        {
            myDbContext.users.Add(User);
            myDbContext.SaveChanges();
            return User;
        }

        public void DeleteUser(int id)
        {
            User userToDelete = myDbContext.users.Find(id);

            if (userToDelete != null)
            {
                myDbContext.users.Remove(userToDelete);

            }
        }

        public List<User> GetAllUsers()
        {
            return myDbContext.users.ToList();
        }


        public User GetUserById(int id)
        {
            return myDbContext.users.Find(id);

        }

        public User UpdateUser(int id, User user)
        {
            User userToUpdate = myDbContext.users.Find(id);
            if (userToUpdate != null)
            {
                userToUpdate.Name = user.Name;
                userToUpdate.Email = user.Email;
                userToUpdate.CellPhone = user.CellPhone;
                userToUpdate.UserName = user.UserName;
                userToUpdate.Password = user.Password;
                myDbContext.users.Update(userToUpdate);
                myDbContext.SaveChanges();
               
            }
            return userToUpdate;
        }

        public List<User> getUserRoles(int id)
        {
            return myDbContext.users.Include(x => x.roles).Where(i => i.Id == id).ToList();
        }

        public User validateUser(string userName, string password)
        {
            
            User existingUser = myDbContext.users.FirstOrDefault(u => u.UserName == userName);

            if (existingUser != null)
            {
             
                if (existingUser.Password == password)
                {
                    return existingUser;
                }
            }
            return null;
        }
    }
}
