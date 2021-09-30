using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace BlogProject.Controllers
{
    public class Category : Controller
    {
        private CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            var values = categoryManager.GetList();
            return View(values);
        }
    }
}
