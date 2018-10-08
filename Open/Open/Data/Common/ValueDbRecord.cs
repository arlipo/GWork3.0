using Open.Core;
using System;

namespace Open.Data.Common {
    public abstract class ValueDbRecord : Root { }

    public abstract class ValueDbRecord<TAmount> : ValueDbRecord where TAmount : IConvertible {
        public TAmount Amount { get; set; }
    }
}