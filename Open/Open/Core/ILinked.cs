namespace Open.Core {
    public interface ILinked<out T>: ILinkedId {
        T GetNext();
        T GetPrevious();
    }
}