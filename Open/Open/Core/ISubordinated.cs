namespace Open.Core {
    public interface ISubordinated<out T> : ISubordinatedId {
        T GetMaster();
    }
}