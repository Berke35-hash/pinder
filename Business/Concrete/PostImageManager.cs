using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Hepler;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PostImageManager : IPostImageService
    {
        IPostImageDal _postImageDal;

        public PostImageManager(IPostImageDal postImageDal)
        {
            _postImageDal = postImageDal;
        }

        public IResult Add(PostImage postImage)
        {
            _postImageDal.Add(postImage);
            return new SuccessResult("salak");
        }

        public IResult Delete(PostImage postImage)
        {
            //FileHelper.Delete(postImage.ImagePath);
            //_postImageDal.Delete(postImage);
            return new SuccessResult();
        }

        public IDataResult<PostImage> Get(int id)
        {
            return new SuccessDataResult<PostImage>(_postImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<PostImage>> GetAll()
        {
            return new SuccessDataResult<List<PostImage>>(_postImageDal.GetAll());
        }


        private IResult CheckImageLimitExceeded(int postId)
        {
            //var postImageCount = _postImageDal.GetAll(p => p.PostId == postId).Count;
            //if (postImageCount >= 5)
            //{
            //    return new ErrorResult();
            //}
            return new SuccessResult();
        }
    }
}
