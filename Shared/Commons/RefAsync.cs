using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Commons
{
    public class RefAsync<T>
    {
        
        public T Value { get; set; }

        public RefAsync()
        {
        }

        public RefAsync(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            T value = Value;
            return (value == null) ? "" : value.ToString();
        }

        public static implicit operator T(RefAsync<T> r)
        {
            return r.Value;
        }

        public static implicit operator RefAsync<T>(T value)
        {
            return new RefAsync<T>(value);
        }
    }
}
