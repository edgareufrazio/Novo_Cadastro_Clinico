using System;
using System.IO;

namespace Cadastro_Clinico
{
    internal static class Logger
    {
        private static readonly object _lock = new object();
        private static readonly string logDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Cadastro_Clinico");
        private static readonly string logFile = Path.Combine(logDir, "logs.txt");

        public static void LogError(string message)
        {
            try
            {
                lock (_lock)
                {
                    if (!Directory.Exists(logDir)) Directory.CreateDirectory(logDir);
                    File.AppendAllText(logFile, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {message}{Environment.NewLine}");
                }
            }
            catch
            {
                // Não lançar exceções ao loggar
            }
        }
    }
}
