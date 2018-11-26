using System;
using Open.Data.Goods;

namespace Open.Domain.ShoppingCart
{
    public class CartItem : IEquatable<CartItem>
    {
        public int Quantity { get; set; }

        private int _productId;

        public int ProductId
        {
            get => _productId;
            set
            {
                _product = null;
                _productId = value;
            }
        }

        private GoodsData _product = null;

        public GoodsData Prod
        {
            get
            {
                if (_product == null)
                    _product = new GoodsData();
                return _product;
            }
        }

        public string Description => Prod.Description;

        public decimal UnitPrice => decimal.Parse(Prod.Price);

        public decimal TotalPrice => UnitPrice * Quantity;

        public CartItem(int productId)
        {
            ProductId = productId;
        }

        public bool Equals(CartItem item) => item.ProductId == ProductId;
    }
}