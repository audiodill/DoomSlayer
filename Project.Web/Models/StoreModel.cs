using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Web.Models
{
    public class StoreModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public string ImageName { get; set; }
    }
}