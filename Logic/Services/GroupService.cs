using System;
using System.Collections.Generic;
using System.Linq;
using Logic.Model;

namespace Logic.Services
{
    public class GroupService : BaseService
    {
        public List<Group> Get()
        {
            return _context.Group.ToList();
        }

        public Group Find(int id)
        {
            return _context.Group.Find(id);
        }

        public bool Save(Group group)
        {
            try
            {
                if (group.Id == 0)
                {
                    _context.Group.Add(group);
                }
                else
                {
                    var oldUser = _context.Group.Find(group.Id);
                    _context.Entry(oldUser).CurrentValues.SetValues(group);
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var user = Find(id);
            _context.Group.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }
}
