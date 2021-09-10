using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class About:IEntity
    {
        public int AboutId { get; set; }

        public string AboutDetails1 { get; set; }

        public string AboutDetails2 { get; set; }

        public string AboutImage1 { get; set; }

        public string AboutImage2 { get; set; }

        public string AboutMapLocation { get; set; }

        public bool AboutStatus { get; set; }
    }
}
