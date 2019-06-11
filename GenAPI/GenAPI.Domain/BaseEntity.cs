using System;
namespace GenAPI.Domain
{
    public abstract class BaseEntity<T>
    {
        public T ID { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
