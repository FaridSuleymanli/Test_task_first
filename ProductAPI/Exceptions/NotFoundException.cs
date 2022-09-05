using System;

namespace ProductAPI.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message = "Item not found") : base(message)
        {
            
        }
    }
}