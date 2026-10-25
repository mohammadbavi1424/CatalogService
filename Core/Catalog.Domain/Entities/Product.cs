using Catalog.Domain.Entities.Base;
using Catalog.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Entities
{
    public class Product : BaseEntity<DateTime>
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public Money Price { get; set; }
        public SKU SKU { get; set; }
        public Category Category { get; set; }

    }
}
