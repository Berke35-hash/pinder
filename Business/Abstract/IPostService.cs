using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPostService
    {
        IDataResult<Post> GetById(int Id);
        IDataResult<Post> GetByEmail(string email);
        IDataResult<List<Post>> GetAll();
        IResult Add(Post post);
        IResult Update(Post post);
        IResult Delete(Post post);
    }
}
