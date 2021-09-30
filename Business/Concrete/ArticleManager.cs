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
    public class ArticleManager:IArticleService
    {
        private IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public void Add(Article article)
        {
            _articleDal.Add(article);
        }

        public void Update(Article article)
        {
            _articleDal.Update(article);
        }

        public void Delete(Article article)
        {
            _articleDal.Delete(article);
        }

        public List<Article> GetList()
        {
            return _articleDal.GetList();
        }

        public List<Article> GetBlogById(int id)
        {
            return _articleDal.GetList(x => x.ArticleId == id);
        }

        public Article GetArticle(int id)
        {
            return _articleDal.Get(a=>a.ArticleId==id);
        }

        public List<Article> GetArticleWithCategory()
        {
            return _articleDal.GetArticleWithCategory();
        }
    }
}
