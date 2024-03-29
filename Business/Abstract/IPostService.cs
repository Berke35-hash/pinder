﻿using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPostService
    {
        IDataResult<Post> GetById(int Id);
       // IDataResult<Post> GetByEmail(string email);
        IDataResult<List<Post>> GetByUserId(int UserId);
        IDataResult<List<Post>> GetAll();
        IDataResult<List<Post>> GetByPostName(string name);
        IDataResult<User> GetImageByUser(int UserId);
        IResult Add(Post post);
        IResult Update(Post post);
        IResult Delete(Post post);
    }
}
