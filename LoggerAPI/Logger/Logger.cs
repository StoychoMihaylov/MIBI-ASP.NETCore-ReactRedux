namespace LoggerAPI.Logger
{
    using System;
    using System.IO;
    using LoggerAPI.Interfaces;

    public class Logger : ILogger
    {
        private string path = @"C:\Users\stmih\source\repos\MIBI\LoggerAPI\Files\logFile.txt";

        public void LogInfo(string message)
        {
            LogMessage(message, "INFO");
        }

        public void LogSuccess(string message)
        {
            LogMessage(message, "SUCCESS");
        }

        public void LogError(string message)
        {
            LogMessage(message, "ERROR");
        }

        private void LogMessage(string message, string messageType)
        {
            if (!File.Exists(this.path))
            {
                using (StreamWriter logFile = File.CreateText(this.path))
                {
                    if (messageType == "INFO")
                    {
                        logFile.WriteLine($"{DateTime.Now.ToString()} | INFO | {message}");
                    }
                    else if (messageType == "SUCCESS")
                    {
                        logFile.WriteLine($"{DateTime.Now.ToString()} | SUCCESS | {message}");
                    }
                    else if (messageType == "ERROR")
                    {
                        logFile.WriteLine($"{DateTime.Now.ToString()} | ERROR | {message}");
                    }
                }
            }
            else
            {
                using (StreamWriter logFile = new StreamWriter(this.path, true))
                {
                    if (messageType == "INFO")
                    {
                        logFile.WriteLine($"{DateTime.Now.ToString()} | INFO | {message}");
                    }
                    else if (messageType == "SUCCESS")
                    {
                        logFile.WriteLine($"{DateTime.Now.ToString()} | SUCCESS | {message}");
                    }
                    else if (messageType == "ERROR")
                    {
                        logFile.WriteLine($"{DateTime.Now.ToString()} | ERROR | {message}");
                    }
                }
            }
        }
    }
}
