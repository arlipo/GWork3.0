
namespace Open.Data.Common {
    public abstract class IdentifiedData : PeriodData {

        protected string id;

        public virtual string ID {
            get => getString(ref id);
            set => setValue(ref id, value);
        }
    }
}


