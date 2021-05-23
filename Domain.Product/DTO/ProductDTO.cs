using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Product.DTO
{
    public class ProductDTO
    {
        public string _Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public BrandDTO Brand { get; set; }
        public List<LocationDTO> Locations { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }
    }
}
