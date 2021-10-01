using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace BlogProject.Controllers
{
    public class ArticleController : Controller
    {
        private ArticleManager articleManager = new ArticleManager(new EfArticleDal()); 
        public IActionResult Index()
        {
            var results = articleManager.GetArticleWithCategory();
            return View(results);
        }

        public IActionResult ArticleDetails(int id)
        {
            ViewBag.id = id;
            var result = articleManager.GetBlogById(id);
            return View(result);
        }
    }
}
