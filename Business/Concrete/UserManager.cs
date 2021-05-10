using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
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
        IPostDal _postDal;
        public UserManager(IUserDal userDal,IPostDal postDal)
        {
            _userDal = userDal;
            _postDal = postDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<User> GetByName(string name)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.FirstName == name));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll().ToList());
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
        //postumuzu user maili üzerinden açmamızı sağlıyor
        public Post GetByUserMail(string email)
        {

            return _postDal.Get(u => u.Email == email);
        }
    }
}
