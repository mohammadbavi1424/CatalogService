using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.DomainEvents.Product
{
    public class ProductUpdatePriceEvent:INotification
    {
        public long ProductId { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }

        public DateTime UpdateAt { get; set; }
        public long? UpdateUserId { get; set; }

    }
}
