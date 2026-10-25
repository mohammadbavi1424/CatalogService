using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.DomainEvents.Product
{
    public class ProductCreateEvent : INotification
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
        public string Sku { get; set; }
        public DateTime CreateAt { get; set; }
        public long? CreateUserId { get; set; }

    }
}
