
using Open.Data.Common;

namespace Open.Data.Goods
{
    public class GoodsType : NamedData
    {
        private string id;
        private string name;

        public string ID
        {
            get => getString(ref id);
            set => id = value;
        }

        public string Name
        {
            get => getString(ref name);
            set => name = value;
        }
    }
}
