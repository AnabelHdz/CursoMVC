using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Logic.Model;

namespace WebApplication1.Areas.Dashboard.Models
{
    public class RoleModel
    {
        public int Id { get; set; }

        [Required]
        [Description("Name:")]
        public string Name { get; set; }

    }

    public static class RoleExtensions
    {
        public static RoleModel ToViewModel(this Role model)
        {
            return new RoleModel { Id = model.Id, Name = model.Name };
        }

        public static Role ToDomainModel(this RoleModel model)
        {
            return new Role { Id = model.Id, Name = model.Name };
        }
    }
}