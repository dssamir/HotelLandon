using System;

namespace HotelLandon.Models
{
    public abstract class EntityBase<T> where T : IEquatable<T>
    {
        public T Id { get; set; }
    }

    public abstract class EntityBase : EntityBase<string>
    {
        public new string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
