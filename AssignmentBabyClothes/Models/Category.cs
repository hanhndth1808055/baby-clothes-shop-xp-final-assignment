using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AssignmentBabyClothes.Models
{
    public class Category
    {
        public int Id { get; set; }
        [DisplayName("Category")]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> ProductList { get; set; }
    }
}