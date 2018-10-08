//TODO

namespace Open.Core {
    public interface IActivity //: IUnique, IPeriod, IRuleContext
    { }
    public interface IActivity<out TActivity, out TActivityType> //: IActivity, ILinked<TActivity>,
    //    IBaseEntity<TActivityType> where TActivity : IActivity where TActivityType : IActivityType
    { }
}