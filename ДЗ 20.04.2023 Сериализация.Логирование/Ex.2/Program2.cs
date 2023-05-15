﻿using NLog;
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

            List<User> FakeUsers = new List<User>()
            {
                new User("Sam", "Smith", "+90 (532)-106-89-15", "smith94@gmail.com", "Istanbul"),
                new User("Briana", "Tart", "+90 (546)-215-14-32", "tart05bri@gmail.com", "Izmir"),
                new User("Mitch", "Dewitt", "+90 (532)-954-71-44", "dewitt2435@gmail.com", "Sakarya"),
                new User("Jane", "Ostin", "+90 (546)-887-12-84", "ostinJ78@gmail.com", "Ankara")
            };

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

            logfile.KeepFileOpen = true; // файл для записи постоянно открыт

            NLog.LogManager.Configuration = config;

            #endregion NLog Initializator

            Console.WriteLine(" Генерация фейковых пользователей!");
            try
            {               
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($" Сгенерирован фейковый пользователь {FakeUsers[i].FirstName} {FakeUsers[i].LastName}");
                    Logger.Info($"Фейковый пользователь {FakeUsers[i].FirstName} {FakeUsers[i].LastName}");
                    Logger.Warn($"Фейковый пользователь {FakeUsers[i].FirstName} {FakeUsers[i].LastName}");
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Error " + ex.Message);
                Logger.Fatal("Fatal Error! " + ex);
            }


            Console.WriteLine(" Генерация фейковых пользователей завершена!");

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

        public User() { }
        public User(string fname, string lname, string phone, string email, string address)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;
        }
    }
}