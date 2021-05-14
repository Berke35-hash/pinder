using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult <User> GetByName(string name);
        //postumuzu user maili üzerinden açmamızı sağlıyor
        //Post GetByUserMail(string userMail);
        User GetByMail(string email);
        User GetById(int Id);
    }
}
