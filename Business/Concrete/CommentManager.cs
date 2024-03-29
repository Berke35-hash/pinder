﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        IUserDal _userDal;
        public CommentManager(ICommentDal commentDal,IUserDal userDal)
        {
            _commentDal = commentDal;
            _userDal = userDal;
        }
        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult(Messages.CommnetAdded);
        }

        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.CommnetDeleted);
        }

        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessResult(Messages.CommnetUpdated);
        }
        public IDataResult<List<Comment>> GetByPostId(int postId) 
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(p=>p.PostId==postId));
        }
        public IDataResult<User> GetImageByUser(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }
    }
}
