using System.Threading.Tasks;
using Logdash.Logger;

namespace Logdash
{
    public interface ILogSync
    {
        Task SendAsync(string message, LogLevel level, string timestamp);
    }
}
