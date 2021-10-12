using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IArticleService
    {
        void Add(Article article);
        void Update(Article article);
        void Delete(Article article);
        List<Article> GetList();
        List<Article> GetBlogById(int id);
        Article GetArticle(int id);
        List<Article> GetArticleWithCategory();
        List<Article> GetArticleWithAuthor(int id);
    }
}
