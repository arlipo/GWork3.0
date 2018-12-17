using Open.Facade.Common;

namespace Open.Facade.Customers {
    public class CustomerView : EntityView {
        private string name;
        public string Name {
            get => getString(ref name);
            set => name = value;
        }
    }
}
