using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class About:IEntity
    {
        public int AboutId { get; set; }
        public string Details1 { get; set; }

        public string Details2 { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string MapLocation { get; set; }
    }
}
