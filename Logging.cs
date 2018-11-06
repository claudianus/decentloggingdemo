using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace 로깅
{
    public class Logging
    {
        public enum Level
        {
            Log,
            Info,
            Warn,
            Error
        }

        public string LogFilePath { get; }

        public Logging(string logFilePath)
        {
            LogFilePath = logFilePath;
        }

        public void Log(string message, Level logLevel = Level.Log)
        {
            var stackTrace = new StackTrace();
            var nowTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            var callingMethodName = stackTrace.GetFrame(1).GetMethod().Name;
            ConsoleColor messageColor = ConsoleColor.Gray;

            switch (logLevel)
            {
                case Level.Log:
                    messageColor = ConsoleColor.White;
                    message = $"(..Log) {message}";
                    break;
                case Level.Info:
                    messageColor = ConsoleColor.Cyan;
                    message = $"(.Info) {message}";
                    break;
                case Level.Warn:
                    messageColor = ConsoleColor.Yellow;
                    message = $"(.Warn) {message}";
                    break;
                case Level.Error:
                    messageColor = ConsoleColor.Red;
                    message = $"(Error) {message}";
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"[{nowTime}] ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"({callingMethodName}) => ");
            Console.ForegroundColor = messageColor;
            Console.Write($"{message}");
            Console.WriteLine();

            var content = $"[{nowTime}] ({callingMethodName}) => {message}";
            LogOnFile(content);
        }

        private void LogOnFile(string content)
        {
            using (var sw = new StreamWriter("log.txt", true))
                sw.WriteLine(content);
        }
    }
}