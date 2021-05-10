using Business.Abstract;
using Business.Constants;
using Business.ValidationsRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class PostManager : IPostService
    {
        IPostDal _postDal;
        IUserDal _userDal;
        
        public PostManager(IPostDal postDal,IUserDal userDal)
        {
            _postDal = postDal;
            _userDal = userDal;
        }

        [ValidationAspect(typeof(PostValidator))]
        public IResult Add(Post post)
        {
            IResult result = BusinessRules.Run(CheckIfPostNameExists(post.PostName));
            if (result != null)
            {
                return result;
            }
            _postDal.Add(post);
            return new SuccessResult(Messages.PostAdded);
        }

        public IResult Delete(Post post)
        {
            _postDal.Delete(post);
            return new SuccessResult(Messages.PostDeleted);
        }

        public IDataResult<Post> GetById(int postId)
        {
            return new SuccessDataResult<Post>(_postDal.Get(p => p.Id == postId));
        }
        public IDataResult<List<Post>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<Post>>(_postDal.GetAll(p=>p.UserId==userId).ToList());
        }

        public IDataResult<List<Post>> GetAll()
        {
            return new SuccessDataResult<List<Post>>(_postDal.GetAll().ToList());
        }

        public IResult Update(Post post)
        {
            IResult result = BusinessRules.Run(CheckIfPostNameExists(post.PostName));
            if (result != null)
            {
                return result;
            }
            _postDal.Update(post);
            return new SuccessResult(Messages.PostUpdated);
        }
        public IDataResult<Post> GetByEmail(string email)
        {

            return new SuccessDataResult<Post>(_postDal.Get(u => u.Email == email));
        }
        private IResult CheckIfPostNameExists(string postName)
        {
            var result = _postDal.GetAll(p => p.PostName == postName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
