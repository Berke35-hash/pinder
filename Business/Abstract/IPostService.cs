using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPostService
    {
        Post GetById(int postId);
        List<Post> GetList();
        void Add(Post post);
        void Update(Post post);
        void Delete(Post post);
    }
}
