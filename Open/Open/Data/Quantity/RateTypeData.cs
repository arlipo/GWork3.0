using Open.Data.Common;
namespace Open.Data.Quantity {
    public class RateTypeData : NamedData {
        private string description;
        public string Description
        {
            get => getString(ref description);
            set => description = value;
        }

    }
}