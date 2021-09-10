using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Article:IEntity
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public string ArticleThumbNailImage { get; set; }
        public string ArticleImage { get; set; }
        public DateTime ArticleCreateDate { get; set; }
        public bool ArticleStatus { get; set; }
    }
}
