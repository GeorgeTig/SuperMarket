using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models.Entity
{
    public enum UserTypeEnum
    {
        Admin,
        User
    }
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserTypeEnum UserType { get; set; }
        public bool IsActive { get; set; }
    }
}
