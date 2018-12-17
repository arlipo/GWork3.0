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

        public string Name => GoodsData.Name;

        public decimal UnitPrice => decimal.Parse(GoodsData.Price);

        public decimal TotalPrice => UnitPrice * Quantity;
    }
}