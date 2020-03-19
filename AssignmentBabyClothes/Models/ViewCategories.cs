using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentBabyClothes.Models
{
    public class ViewCategories
    {
        public int CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}