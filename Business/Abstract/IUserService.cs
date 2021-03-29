using Core.Entities.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        List<User> GetList();
        void GetByName(string name);
        User GetByMail(string email);
    }
}
