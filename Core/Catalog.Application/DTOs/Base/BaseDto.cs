namespace Catalog.Application.DTOs.Base
{

    public interface IBaseDto
    {
    }


    public interface IBaseDto<TKey, TDateProperty> : IBaseDto
    {
        public TKey Id { get; set; }

        public TDateProperty? CreateDate { get; set; }
        public TKey? CreateUserId { get; set; }
        public TDateProperty? ModifyDate { get; set; }
        public TKey? ModifyUserId { get; set; }
        public byte[] RowVersion { get; set; }
        public TDateProperty? DeletedDate { get; set; }
        public TKey? DeletedUserId { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public abstract class BaseDto<TKey, TDateProperty> : IBaseDto<TKey, TDateProperty>
    {
        public TKey Id { get; set; }

        public TDateProperty? CreateDate { get; set; }
        public TKey? CreateUserId { get; set; }
        public TDateProperty? ModifyDate { get; set; }
        public TKey? ModifyUserId { get; set; }
        public byte[] RowVersion { get; set; }
        public TDateProperty? DeletedDate { get; set; }
        public TKey? DeletedUserId { get; set; }
        public bool? IsDeleted { get; set; }
    }



    public abstract class BaseDto<TDateProperty> : BaseDto<long, TDateProperty>
    {
    }

    public abstract class BaseDto : BaseDto<long>
    {
    }

}

