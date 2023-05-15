using NLog;
using NLog.Conditions;
using NLog.Config;
using NLog.Fluent;
using NLog.Layouts;
using NLog.Targets;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace Ex._2
{
    internal class Program2
    {
        public static Logger Logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
           Console.Title = "Генерация фейковых пользователей";

            #region NLog Initializator

            var config = new NLog.Config.LoggingConfiguration();

            var consoleTarget = new ColoredConsoleTarget()
            {
                Layout = @"${counter}|[${date:format=yyyy-MM-dd HH\:mm\:ss}] [${logger}/${uppercase: ${level}}] >> ${message} ${exception: format=ToString}"
            };

            config.AddRule(LogLevel.Trace, LogLevel.Fatal, consoleTarget);

            var logfile = new FileTarget();
            config.AddRule(LogLevel.Error, LogLevel.Fatal, logfile);
            logfile.CreateDirs = true;
            logfile.FileName = $"logs{Path.DirectorySeparatorChar}lastlog2.log";

            logfile.Layout = @"${counter}|[${date:format=yyyy-MM-dd HH\:mm\:ss}] [${logger}/${uppercase: ${level}}] >> ${message} ${exception: format=ToString}";

            logfile.KeepFileOpen = true;

            NLog.LogManager.Configuration = config;

            #endregion NLog Initializator
            //Log.Information("Старт генерации фейковых пользователей");

            for (int i = 0; i < 10; i++)
            {
                var fakeUser = new User
                {
                    FirstName = Name.First(),
                    LastName = Name.Last(),
                    Phone = Phone.Number(),
                    Email = Internet.Email(),
                    Address = Address.FullAddress()
                };

                Logger.Debug("Сгенерирован фейковый пользователь: {@User}", fakeUser);
            }

            //Logger.Info("Генерация фейковых пользователей завершена");

            Console.ReadLine();
        }
        
    }
    public class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}