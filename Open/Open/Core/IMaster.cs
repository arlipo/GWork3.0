//TODO

namespace Open.Core
{
    public interface IMaster<out TSet, TElement, TBaseElement>
        //where TBaseElement : UniqueEntity, IActivity, ILinkedId, ISubordinatedId
        //where TElement : TBaseElement
        //where TSet: Set<TBaseElement>
    {
    TElement StartActivity(TElement e);
    TSet GetActivities();

    }
}
