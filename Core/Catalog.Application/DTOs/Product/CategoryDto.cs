using Catalog.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.DTOs.Product
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }

        public long? ParentId { get; set; }

        public CategoryDto Parent { get; set; }

    }
}
