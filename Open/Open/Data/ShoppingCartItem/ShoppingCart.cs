using System.Collections.Generic;
using Open.Data.Common;

namespace Open.Data.ShoppingCartItem
{
    public class ShoppingCart :NamedData
    {
        public string ShoopingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
