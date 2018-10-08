//TODO
namespace Open.Core {

    public interface IActivityType //: IUnique, IPeriod, IRuleSet
    { }

    public interface IActivityType<out TActivityType> //: IActivityType, 
        //ILinked<TActivityType>, IBaseType<TActivityType> 
        //where TActivityType : IActivityType
    { }

}