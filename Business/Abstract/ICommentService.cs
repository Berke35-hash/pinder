using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IResult Add(Comment comment);
        IResult Update(Comment comment);
        IResult Delete(Comment comment);
        IDataResult<List<Comment>> GetByPostId(int PostId);
        IDataResult<User> GetImageByUser(int UserId);

    }
}
