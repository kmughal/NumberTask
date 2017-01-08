namespace Task.Domain
{
    using System.Collections.Generic;

    public interface ILogService
    {
        void Log(string message);
        IList<string> GetAllLogs();
    }

}