using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogProject.ViewComponents.Category
{
    public class CategoryList:ViewComponent
    {
        private CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public IViewComponentResult Invoke()
        {
            var categories = categoryManager.GetList();
            return View(categories);
        }
    }
}
