using System;

namespace ProductAPI.Common
{
    public class BaseModel<T>
    {
        public T Id { get; set; }
        public string Name { get; set; }
    }
}