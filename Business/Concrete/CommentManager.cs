using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CommentManager:ICommentService
    {
        private ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public List<Comment> GetAllComment(int id)
        {
            return _commentDal.GetList(x=>x.ArticleId==id);
        }

        public void AddComment(Comment comment)
        {
            _commentDal.Add(comment);
        }
    }
}
