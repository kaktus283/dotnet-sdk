namespace Logdash.Metrics
{
    public interface IMetrics
    {
        void Set(string message, int value);
        void Mutate(string message, int value);
    }
}
