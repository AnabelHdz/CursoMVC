using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Logic.Model;

namespace Logic.Services
{
    public class RoleService : BaseService
    {
        public List<Role> Get()
        {
            var context = new CursoEntities();
            return context.Role.ToList();
        }

        public Role Find(int id)
        {
            return _context.Role.Find(id);
        }

        public bool Save(Role role)
        {
            try
            {
                if (role.Id == 0)
                {
                    _context.Role.Add(role);
                }
                else
                {
                    var oldUser = _context.Role.Find(role.Id);
                    _context.Entry(oldUser).CurrentValues.SetValues(role);
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
            try
            {
                var user = Find(id);
                _context.Role.Remove(user);

                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
