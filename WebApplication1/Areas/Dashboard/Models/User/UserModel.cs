using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Logic.Model;

namespace WebApplication1.Areas.Dashboard.Models
{
    public class UserModel
    {
        public UserModel()
        {
            Groups = new List<GroupModel>();
            Roles = new List<RoleModel>();
        }

        public UserModel(User model)
        {
            Groups = new List<GroupModel>();
            Roles = new List<RoleModel>();

            Id = model.Id;
            FirstName = model.FirstName;
            LastName = model.LastName;
            Email = model.Email;
            Password = model.Password;
            UserName = model.UserName;
            BirthDate = model.BirthDate.ToShortDateString();

            foreach (var group in model.Groups)
            {
                Groups.Add(new GroupModel { Id = group.GroupId, Name = group.Group.Name });
            }

            foreach (var role in model.Roles)
            {
                Roles.Add(new RoleModel { Id = role.RoleId, Name = role.Role.Name });
            }
        }

        public int Id { get; set; }
        
        [Required]
        [DisplayName("First Name:")]
        public string FirstName { get; set; }
        
        [Required]
        [DisplayName("Last Name:")]
        public string LastName { get; set; }
        
        [Required]
        [DisplayName("User Name:")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Password:")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Re-enter Password")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string PasswordConfirm { get; set; }

        [Required]
        [DisplayName("Date of birth:")]
        [DataType(DataType.DateTime)]
        public string BirthDate { get; set; }

        [Required]
        [DisplayName("Email Address:")]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+[A-Za-z0-9.-]+\.[A-Za-z] {2,4}", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        public List<GroupModel> Groups { get; set; }
        public List<RoleModel> Roles { get; set; }
    }

    public static class UserExtensions
    {
        public static UserModel ToViewModel(this User model)
        {
            return new UserModel(model);
        }

        public static User ToDomainModel(this UserModel model)
        {
            return new User
            {
                Id= model.Id,
                FirstName =model.FirstName,
                LastName =  model.LastName,
                UserName = model.UserName,
                Password = model.Password,
                BirthDate = DateTime.Parse(model.BirthDate),
                Email = model.Email
            };
        }
    }
}