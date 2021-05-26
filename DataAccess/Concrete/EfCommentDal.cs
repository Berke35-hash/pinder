using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfCommentDal :EfEntityRepositoryBase<Comment, PinderContext>, ICommentDal 
    {
        public List<CommentDTO> GetCommentDetails()
        {
            using (PinderContext context = new PinderContext())
            {
                var result = from p in context.Comment
                             select new CommentDTO
                             {

                                 //WriterName = p.WriterName,
                                 PostComment = p.PostComment,
                                 UserId = p.UserId
                             };
                return result.ToList();
            }
        }
    }
}
