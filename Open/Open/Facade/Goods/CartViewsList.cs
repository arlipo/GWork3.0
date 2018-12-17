using System.Collections.Generic;
using Open.Domain.ShoppingCart;

namespace Open.Facade.Goods
{
    public class CartViewsList : List<CartView>
    {
        public CartViewsList(ShoppingCart list)
        {
            if (list is null) return;
            foreach (var o in list)
            {
                Add(CartViewFactory.Create(o));
            }
        }
    }
}