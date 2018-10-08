using System;
using Open.Facade.Common;
namespace Open.Facade.Quantity {
    public abstract class PaymentMethodView : EntityView {
        public string Content => ToString();

        public string PaymentType {
            get {
                var name = GetType().Name;
                var idx = name.IndexOf("View", StringComparison.Ordinal);
                if (idx >= 0)
                    name = name.Substring(0, idx);
                return name;
            }
        }
    }
}