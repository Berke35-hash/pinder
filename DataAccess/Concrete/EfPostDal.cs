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
    public class EfPostDal: EfEntityRepositoryBase<Post, PinderContext>, IPostDal
    {
        public List<PostDTO> GetPostDetails()
        {
            using (PinderContext context = new PinderContext())
            {
                var result = from p in context.Post
                             select new PostDTO
                             {
                                 
                                 PostName = p.PostName,
                                 Email = p.Email,
                                 Prize = p.Prize,
                                 PostDate = p.PostDate,
                                 Comment = p.Comment,
                                 TelNo = p.TelNo,
                                 Description = p.Description
                             };
                return result.ToList();
            }
        }
    }
}
