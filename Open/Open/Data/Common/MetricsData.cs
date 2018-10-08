
namespace Open.Data.Common {
    public abstract class MetricsData : NamedData {
        private string definition;
        public string Definition
        {
            get => getString(ref definition);
            set => definition = value;
        }
    }
}

