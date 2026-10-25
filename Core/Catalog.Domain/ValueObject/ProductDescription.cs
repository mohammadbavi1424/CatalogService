using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.ValueObject
{
    public class ProductDescription
    {
        public string ShortDescription { get; init; }

        public string LongDescription { get; init; }


        private ProductDescription(string shortDescription,string? longDescription)
        {
            if (string.IsNullOrWhiteSpace(shortDescription)||shortDescription.Length > 200)
                throw new ArgumentNullException($"{shortDescription} can not be null or grater then 200 charecter");
            if (string.IsNullOrWhiteSpace(longDescription) || longDescription.Length < 200)
                throw new ArgumentNullException($"{longDescription} can not be null or less then 200 charecter");
            ShortDescription = shortDescription;
            LongDescription = longDescription;

        }

    }
}
