using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        User GetById(int userId);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        List<User> GetList();
        void GetByName(string name);
    }
}
