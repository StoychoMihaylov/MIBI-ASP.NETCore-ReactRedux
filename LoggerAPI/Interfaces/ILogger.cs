namespace LoggerAPI.Interfaces
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogSuccess(string message);
    }
}
