namespace Open.Core {
    public interface ILinkedId
    {
        string NextId { get; set; }
        string PreviousId { get; set; }
    }
}