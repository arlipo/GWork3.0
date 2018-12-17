using System;
using System.ComponentModel;
using Open.Data.Goods;
using Open.Domain.Goods;

namespace Open.Domain.ShoppingCart
{
    public class CartItem
    {
        public readonly CartData Data;

        public CartItem(CartData data)
        {
            Data = data;
        }

        public bool Equals(CartItem item) => item?.Data?.ID == Data?.ID;
    }
}