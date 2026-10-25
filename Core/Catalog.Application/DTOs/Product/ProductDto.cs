using Catalog.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.DTOs.Product
{
    public class ProductDto : BaseDto
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public string SKU { get; set; }


        public CategoryDto Category { get; set; }


    }
}
