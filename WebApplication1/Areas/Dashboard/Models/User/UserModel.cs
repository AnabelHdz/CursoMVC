using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Areas.Dashboard.Models
{
    public class UserModel
    {
        public UserModel()
        {
            Groups = new List<GroupModel>();
            Roles = new List<RoleModel>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    
        public List<GroupModel> Groups { get; set; }
        public List<RoleModel> Roles { get; set; }
    }
}