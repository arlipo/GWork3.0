//TODO
namespace Open.Core {

    public interface ISuperior<TElement, out TSet> //where TSet : Set<TElement>
    {
        TSet GetMembers();
    }

}