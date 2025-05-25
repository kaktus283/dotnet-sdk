namespace Logdash.Metrics
{
    public interface IMetrics
    {
        void Error(string message);
        void Set(string message, int value);
        void Mutate(string message, int value);
    }
}
