﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Logic.Model;

namespace WebApplication1.Areas.Dashboard.Models
{
    public class GroupModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Name:")]
        public string Name { get; set; }
    }

    public static class GroupExtensions
    {
        public static GroupModel ToViewModel(this Group model)
        {
            return new GroupModel { Id = model.Id, Name = model.Name };
        }

        public static Group ToDomainModel(this GroupModel model)
        {
            return new Group { Id = model.Id, Name = model.Name };
        }
    }
}