using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public User GetById(int userId)
        {
            return _userDal.Get(p => p.Id == userId);
        }

        public void GetByName(string name)
        {
            _userDal.Get(p => p.FirstName == name);
        }

        public List<User> GetList()
        {
            return _userDal.GetAll().ToList();
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
