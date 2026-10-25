using Catalog.Domain.DomainEvents.Product;
using Catalog.Domain.Entities;
using Catalog.Domain.ValueObject;

namespace Catalog.Domain.Aggregates.ProductAggregate
{
    public class ProductAggregate
    {

        public Product Product { get; set; }
        private readonly List<object> _domainEvent = new();
        public IReadOnlyCollection<object> DomainEvent => _domainEvent;

        private ProductAggregate()
        {
            
        }
        public ProductAggregate(Product product)
        {
            Product = product;
            RaiseDomainEvent(new ProductCreateEvent()
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Price = product.Price.Amount,
                Sku = product.SKU.Value,
                CategoryId = product.CategoryId,
                CreateAt = product.CreateDate,
                CreateUserId = product.CreateUserId,
            });
            

        }


        public void UpdateProcudePrice(Money price)
        {
            var oldPrice = Product.Price;
            Product.Price = price;
            RaiseDomainEvent(new ProductUpdatePriceEvent()
            {
                ProductId = Product.Id,
                OldPrice = oldPrice.Amount,
                NewPrice = Product.Price.Amount,
                UpdateAt = DateTime.UtcNow,
                UpdateUserId = Product.ModifyUserId
            });
        }



        public void ClearDomainEvent() => _domainEvent.Clear();

        private void RaiseDomainEvent(object eventItem)
        {
            _domainEvent.Add(eventItem);
        }


    }
}
