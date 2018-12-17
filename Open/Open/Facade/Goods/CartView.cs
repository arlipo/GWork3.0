using System.ComponentModel;
using Open.Core;
using Open.Data.Goods;

namespace Open.Facade.Goods
{
    public class CartView : Archetype
    {
        public GoodsData GoodsData { get; set; }

        public string ID
        {
            get => GoodsData.ID;
            set => GoodsData.ID = value;
        }

        public int Quantity { get; set; }
        [DisplayName("Product")]
        public string Name => GoodsData.Name;
        [DisplayName("Price")]
        public decimal UnitPrice => decimal.Parse(GoodsData.Price);
        [DisplayName("Total Price")]
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}