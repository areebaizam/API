using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    //public class MayBe() {
        
    //}
    public class Maybe<TEntity>(TEntity? value)
    {
        private readonly TEntity? _value = value;
        public bool HasValue => _value is not null;

        public TEntity Value => HasValue
            ? _value!
            : throw new InvalidOperationException("The value of a failure result can not be accessed.");

        public static implicit operator Maybe<TEntity>(TEntity? value) => new(value);
    }
}
