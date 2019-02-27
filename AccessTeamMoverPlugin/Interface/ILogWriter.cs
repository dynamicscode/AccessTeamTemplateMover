namespace DynamicsCode.AccessTeamTemplateMoverPlugin.Interface
{
    public interface ILogWriter
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogWarning(string message);
        void Open();
    }
}
