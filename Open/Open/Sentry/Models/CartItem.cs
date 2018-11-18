﻿using System.ComponentModel.DataAnnotations;
using Open.Data.Goods;

namespace Open.Sentry.Models
{
    public class CartItem
    {
        public int ShoppingCartItemId { get; set; }
        public GoodsData Goods { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
