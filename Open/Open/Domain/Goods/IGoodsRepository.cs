using System.Threading.Tasks;
using Open.Core;
using Open.Data.Goods;

namespace Open.Domain.Goods
{
    public interface IGoodsRepository : IRepository<Good, GoodsData>
    {
        Task<PaginatedList<Good>> GetWithSpecificType(GoodTypes type);
    }
}