using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Product.DTO
{
    public class BrandDTO
    {
        public string _Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public CompanyDTO Company { get; set;}
        public ColorDTO Color { get; set; }
    }
}
