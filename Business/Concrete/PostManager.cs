using Business.Abstract;
using Business.ValidationsRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
            _postDal.Add(post);
            return new SuccessResult();
        }

        public IResult Delete(Post post)
        {
            _postDal.Delete(post);
            return new SuccessResult("post başarıyla silindi");
        }

        public IDataResult<Post> GetById(int postId)
        {
            return new SuccessDataResult<Post>(_postDal.Get(p => p.Id == postId));
        }

        public IDataResult<List<Post>> GetAll()
        {
            return new SuccessDataResult<List<Post>>(_postDal.GetAll().ToList());
        }

        public IResult Update(Post post)
        {
            _postDal.Update(post);
            return new SuccessResult("post başarıyla güncellendi");
        }
        public IDataResult<Post> GetByEmail(string email)
        {

            return new SuccessDataResult<Post>(_postDal.Get(u => u.Email == email));
        }
    }
}
