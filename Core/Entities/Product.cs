using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        
        public string Name { get; set; }
        public string Descraption { get; set; }
        public string PictureURL { get; set; }
        public double  Price { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }

        
    }

    public class ProductBrand : BaseEntity
    {
        public string Name { get; set; }
    }

    public class ProductType :BaseEntity
    {
        public string Name { get; set; }
    }

    public class BaseEntity
    {
        public int Id { get; set; }
    }
}