namespace PietExecutor.State
{
    public interface IRollingStack
    {
        int Count { get; }

        int Pop();
        void Push(int value);
        void Roll(int numberOfRolls, int rollDepth);
    }
}