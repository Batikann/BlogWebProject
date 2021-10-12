using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Article
{
    public class AuthorLastArticle:ViewComponent
    {
        private ArticleManager authorManager = new ArticleManager(new EfArticleDal());

        public IViewComponentResult Invoke()
        {
            var values = authorManager.GetArticleWithAuthor(1);
            return View(values);
        }

    }
}
