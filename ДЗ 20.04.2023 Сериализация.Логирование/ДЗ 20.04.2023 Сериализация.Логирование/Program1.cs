using NLog;
using NLog.Conditions;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;
using System.Text;

namespace ДЗ_20._04._2023_Сериализация.Логирование
{
    internal class Program1
    {
        public static Logger Logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            Console.Title = "Поиск информации в файле";
            Console.WriteLine(" p.s. Если ввести неверное название файла,\n" +
                " то сработает логирование.\n Есть сохранённый файл Text.txt\n");
            #region NLog Initializator

            var config = new NLog.Config.LoggingConfiguration(); // создаем новую конфигурацию для логирования

            var consoleTarget = new ColoredConsoleTarget() // для консоли
            {
                Layout = @"${counter}|[${date:format=yyyy-MM-dd HH\:mm\:ss}] [${uppercase:${level}}] >> ${message} ${exception: format=ToString}"
            };

            config.AddRule(LogLevel.Trace, LogLevel.Fatal, consoleTarget);       // добавляем правило - будем ловить все возможные ошибки

            var logfile = new FileTarget(); // для файла
            config.AddRule(LogLevel.Error, LogLevel.Fatal, logfile);             // добавляем правило - будем записывать Ошибки и Фатальные ошибки

            logfile.CreateDirs = true;      // создание директории
            logfile.FileName = $"logs{Path.DirectorySeparatorChar}lastlog2.log"; // наш файл с записями об ошибках

            logfile.Layout = @"${counter}|[${date:format=yyyy-MM-dd HH\:mm\:ss}] [${logger}/${uppercase: ${level}}] >> ${message} ${exception: format=ToString}";

            logfile.KeepFileOpen = true;    // файл для записи постоянно открыт для быстродействия программы

            NLog.LogManager.Configuration = config;  // устанавливаем нашу конфигурацию

            #endregion NLog Initializator

            #region NLog Colors

            var Trace = new ConsoleRowHighlightingRule();
            Trace.Condition = ConditionParser.ParseExpression("level == LogLevel.Trace");
            Trace.ForegroundColor = ConsoleOutputColor.Yellow;
            consoleTarget.RowHighlightingRules.Add(Trace);
            var Debug = new ConsoleRowHighlightingRule();
            Debug.Condition = ConditionParser.ParseExpression("level == LogLevel.Debug");
            Debug.ForegroundColor = ConsoleOutputColor.DarkCyan;
            consoleTarget.RowHighlightingRules.Add(Debug);
            var Info = new ConsoleRowHighlightingRule();
            Info.Condition = ConditionParser.ParseExpression("level == LogLevel.Info");
            Info.ForegroundColor = ConsoleOutputColor.Green;
            consoleTarget.RowHighlightingRules.Add(Info);
            var Warn = new ConsoleRowHighlightingRule();
            Warn.Condition = ConditionParser.ParseExpression("level == LogLevel.Warn");
            Warn.ForegroundColor = ConsoleOutputColor.DarkYellow;
            consoleTarget.RowHighlightingRules.Add(Warn);
            var Error = new ConsoleRowHighlightingRule();
            Error.Condition = ConditionParser.ParseExpression("level == LogLevel.Error");
            Error.ForegroundColor = ConsoleOutputColor.DarkRed;
            consoleTarget.RowHighlightingRules.Add(Error);
            var Fatal = new ConsoleRowHighlightingRule();
            Fatal.Condition = ConditionParser.ParseExpression("level == LogLevel.Fatal");
            Fatal.ForegroundColor = ConsoleOutputColor.Black;
            Fatal.BackgroundColor = ConsoleOutputColor.DarkRed;
            consoleTarget.RowHighlightingRules.Add(Fatal);

            #endregion NLog Colors

            Search();
           
        }
        static void Search()
        {
            Console.WriteLine("\t\t-Начало поиска-\n");
            try
            {
                string[] text = ReadFile();
                SentenсeLowerLetter(text);
                SentenсeNumber(text);
                SentenсeUpperLetter(text);
            }
            catch (Exception ex)
            {
                Logger.Error("Error " + ex.Message);
                Logger.Fatal("Fatal Error! " + ex);
            }
            Console.WriteLine("\t\t-Конец поиска-\n");
        }
        static string[] ReadFile()
        {   
            Console.WriteLine("Введите название файла: ");
            string filename = Console.ReadLine()!;
            string[] text = File.ReadAllLines(filename); // считываем построчно в массив

            return text;
        }
        static void SentenсeLowerLetter(string[] text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n Все предложения, содержащие хотя бы одну маленькую английскую букву:");
            Console.ResetColor();

            var Res1 = text.Where(u => u.Any(char.IsLower));
            foreach (var s in Res1)
            {
                Console.WriteLine(s);
                Logger.Info($"Предложение \"{s}\"");
            }          
        }
        static void SentenсeNumber(string[] text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n Все предложения, содержащие хотя бы одну цифру:");
            Console.ResetColor();

            var Res2 = text.Where(u => u.Any(char.IsDigit));        
            foreach (var s in Res2)
            {
                Console.WriteLine(s);
                Logger.Info($"Предложение \"{s}\"");
            }
        }
        static void SentenсeUpperLetter(string[] text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n Все предложения, содержащие хотя бы одну большую, английскую букву:");
            Console.ResetColor();

            var Res3 = text.Where(u => u.Any(char.IsUpper));
            foreach (var s in Res3)
            {
                Console.WriteLine(s);
                Logger.Info($"Предложение \"{s}\"");
            }
        }
    }
}