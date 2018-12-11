using System;
using System.ComponentModel;
using Open.Data.Goods;
using Open.Domain.Goods;

namespace Open.Domain.ShoppingCart
{
    public class CartItem
    {
        private Good _product;

        public GoodsData Data { get; set; }

        public int Quantity { get; set; }

        public Good Prod => _product ?? (_product = GoodFactory.Create(Data));

        [DisplayName("Product")]
        public string Name => Prod.Data.Name;
        [DisplayName("Price")]
        public decimal UnitPrice => decimal.Parse(Prod.Data.Price);
        [DisplayName("Total Price")]
        public decimal TotalPrice => UnitPrice * Quantity;

        public CartItem(GoodsData data)
        {
            Data = data;
        }

        public bool Equals(CartItem item) => item?.Data == Data;
    }
}