﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using Logic.Model;

namespace Logic.Services
{
    public class UserService : BaseService
    {
        public List<User> Get()
        {
            return _context.User.ToList();
        }

        public User Find(int id)
        {
            return _context.User.Find(id);
        }

        public bool Save(User user)
        {
            try
            {
                if (user.Id == 0)
                {
                    _context.User.Add(user);
                }
                else
                {
                    var oldUser = _context.User.Find(user.Id);
                    _context.Entry(oldUser).CurrentValues.SetValues(user);
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                _context.SaveChanges();
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var user = Find(id);
                _context.User.Remove(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddGroup(int userId, int groupId)
        {
            var user = Find(userId);

            if (user.Groups.All(x => x.GroupId != groupId))
            {
                user.Groups.Add(new UserGroup{UserId = userId, GroupId = groupId});
                return true;
            }

            return false;
        }

        public bool AddRole(int userId, int roleId)
        {
            //var user = Find(userId);

            //if (user.Groups.All(x => x.GroupId != roleId))
            //{
            //    user.Roles.Add(new UserRole { UserId = userId, RoleId = roleId });
            //    return true;
            //}

            return false;
        }
    }
}
