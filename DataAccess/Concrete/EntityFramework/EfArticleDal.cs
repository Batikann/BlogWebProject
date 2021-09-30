using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfArticleDal:EfEntityRepositoryBase<Article,BlogWebDbContext>,IArticleDal
    {
        public List<Article> GetArticleWithCategory()
        {
            using (BlogWebDbContext context=new BlogWebDbContext())
            {
                return context.Articles.Include(x => x.Category).ToList();
            }
        }
    }
}
