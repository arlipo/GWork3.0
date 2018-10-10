using Open.Data.Goods;
using Open.Domain.Common;

namespace Open.Domain.Goods
{
    public class Good : NamedEntity<GoodsData>
    {
        public Good(GoodsData r) : base(r) { }
    }
}