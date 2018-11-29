using System;
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

        public string Name => Prod.Data.Name;

        public decimal UnitPrice => decimal.Parse(Prod.Data.Price);

        public decimal TotalPrice => UnitPrice * Quantity;

        public CartItem(GoodsData db)
        {
            Data = db;
        }

        public bool Equals(CartItem item) => item?.Data == Data;
    }
}