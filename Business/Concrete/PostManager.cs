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
        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
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
            return new SuccessResult();
        }

        public IDataResult<Post> GetById(int postId)
        {
            return new SuccessDataResult<Post>(_postDal.Get(p => p.Id == postId));
        }

        public IDataResult<List<Post>> GetList()
        {
            return new SuccessDataResult<List<Post>>(_postDal.GetAll().ToList());
        }

        public IResult Update(Post post)
        {
            _postDal.Update(post);
            return new SuccessResult();
        }
    }
}
