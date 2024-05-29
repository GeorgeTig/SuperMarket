using SuperMarket.Models.DataAccessLayer;
using SuperMarket.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models.BusinessLogicLayer
{
    public class UserBLL
    {
        private UserDAL userDAL = new UserDAL();
        
        public User FindUser(string username , string password)
        {
            
            List<User> users = userDAL.GetUsers();
            foreach (User user in users)
            {
                if (user.Username == username && user.Password == password && user.IsActive==true)
                {
                    return user;
                }
            }
            return null;
        }

        public void UpdateUser(User user)
        {
            userDAL.UpdateUser(user.UserId, user.Username, user.Password, user.UserType, user.IsActive);
        }

        public User FindUser(string username)
        {
            List<User> users = userDAL.GetUsers();
            foreach (User user in users)
            {
                if (user.Username == username )
                {
                    return user;
                }
            }
            return null;
        }

        public void DeleteUser(int userId)
        {
            userDAL.DeleteUser(userId);
        }

        public void AddUser(User user)
        {
            userDAL.AddUser(user);
        }

        public List<User> GetUsers()
        {
            return userDAL.GetUsers();
        }


    }
}
