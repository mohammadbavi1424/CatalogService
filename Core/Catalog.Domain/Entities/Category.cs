using Catalog.Domain.Entities.Base;

namespace Catalog.Domain.Entities
{
    public class Category : BaseEntity<DateTime>
    {
        public string Name { get; set; }

        public long? ParentId { get; set; }
        public Category? Parent { get; set; }


        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Category>? ChildsCategory { get; set; }

        //private Categories()
        //{
        //}

        //private Categories(string name,long? parentId)
        //{
        //    if (!string.IsNullOrWhiteSpace(name))
        //    {
        //        throw new ArgumentException($"{nameof(name)} cannot be null or empty.");
        //    }
        //    Name = name.Trim();
        //    ParentId = parentId;
        //}


        //public static Categories CreateCategories(string name,long? parentId)
        //{
        //    return new Categories(name,parentId);
        //}


        //public void Update(string name,long? parentId)
        //{
        //    if (!string.IsNullOrWhiteSpace(name))
        //    {
        //        throw new ArgumentException($"{nameof(name)} cannot be null or empty.");
        //    }
        //    name = name.Trim();
        //    ParentId = parentId;
        //}

    }
}
