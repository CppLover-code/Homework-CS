using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ex._3
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            Console.Title = " Credit Card";
            Console.WriteLine(" -Enter your credit card details-");
            CreditCard card = new();
            Thread.Sleep(1000);
            Console.Clear();
            //CreditCard card = new(2221115551458796, "Julia Roberts", "21.02.2028", new Account(100, 500, 1414));
            //user1.account.Notify += DisplayMessage; // ответ банка Добавляем обработчик для события Notify          
            //user1.AccountAction += DisplayUserMessage; // действие пользователя Добавляем обработчик для события Notify
            card.account!.MoneyNotify += (object? sender, AccoutEventArgs e) =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" Bank message:\n " + e.Message + e.Sum + " UAH" +
                    ".\n Current balance: " + e.Balance + " UAH");
                Console.ResetColor();
            };           
            card.MoneyAction += delegate (object? sender, AccoutEventArgs e)
            {
                if (sender is CreditCard card)
                {
                    Console.WriteLine(e.Message + e.Sum + " UAH" + " by the client: " + card.holderName);
                }
            };
            card.account.PinNotify += (object? sender, AccoutEventArgs2 e) =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" Bank message:\n " + e.Message);
                Console.ResetColor();
            };
            card.PinAction += delegate (object? sender, AccoutEventArgs2 e)
            {
                if (sender is CreditCard card)
                {
                    Console.WriteLine(e.Message + " by the client: " + card.holderName);
                }
            };
            card.account.AchievementNotify += (object? sender, AccoutEventArgs2 e) =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" Bank message:\n " + e.Message + " UAH");
                Console.ResetColor();
            };
            
            
            ConsoleKey key;

            while (true)
            {
                Console.WriteLine("-Credit Card Menu-\n\n" +
                    " 1 - Put money\n" +
                    " 2 - Withdraw money\n" +
                    " 3 - Change pin code\n" +
                    " 4 - Card info\n" +
                    " Esc - exit\n");
                Console.Write(" Make a choice on NumPad: ");

                ConsoleKeyInfo info = Console.ReadKey();
                Console.WriteLine();

                key = info.Key;

                switch (key)
                {
                    case ConsoleKey.NumPad1:
                        float put = CheckAmount("to top up card");
                        card.Put(put);
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case ConsoleKey.NumPad2:
                        float take = CheckAmount("to withdraw money");                                               
                        card.Take(take);
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case ConsoleKey.NumPad3:
                        card.ChangePin();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case ConsoleKey.NumPad4:
                        card.Info();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case ConsoleKey.Escape:
                        Console.WriteLine(" Bye! Bye!");
                        return;

                    default:
                        Console.WriteLine("\n Incorrect input!\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }

        
        public class AccoutEventArgs : EventArgs // данные события
        {
            public AccoutEventArgs(string? message, float sum, float balance)
            {
                Message = message;
                Sum = sum;
                Balance = balance;
            }
            public string? Message { get; set; }
            public float Sum { get; set; }
            public float Balance { get; set; }
            
        }
        public class AccoutEventArgs2 : EventArgs // данные события
        {
            public AccoutEventArgs2(string? message)
            {
                Message = message;
            }
            public string? Message { get; set; }
        }
        public class Account  // действия для обработки события
        {
            public EventHandler<AccoutEventArgs>? MoneyNotify; // 1. Define an event// унифицированный обработчик событий
                                                          // ДЕЛЕГАТ для события
            public EventHandler<AccoutEventArgs2>? PinNotify;
            public EventHandler<AccoutEventArgs2>? AchievementNotify;

            public float Balance { get; set; } = 0; // текущий баланс
            public float Limit { get; set; }        // кредитный лимит
            public float Debt { get; set; }         // долг по кредиту
            public float CopyL;                     // копия кредитного лимита
            public int pinCode { get; set; }        // пин код
            public float achievement { get; set; }  // достижение по сумме
            public static int counter = 0;          // статическая переменная для сравнения с числом увеличения increase
            public Account(float sum, float cl,int pin)
            { 
                this.Balance = sum; 
                this.Limit = cl;
                this.Debt = 0;
                this.CopyL = this.Limit;
                this.pinCode = pin;
                this.achievement = 10000;
            }
            public Account()
            {
                this.Balance = CheckAmount("of the account balance");
                this.Limit = CheckAmount("of the credit limit");
                this.Debt = 0;
                this.CopyL = this.Limit;
                this.pinCode = CheckPin("");
                this.achievement = 0;
            }
            public void Put(float top_up)
            {
                if(Debt == 0)                   // если нет задолженности
                {
                    Balance += top_up;
                }
                else if (top_up >= Debt)        // если сумма пополнения больше либо равна задолженности
                {
                    Balance = top_up - Debt;
                    Limit = CopyL;
                    Debt = 0;
                }
                else if (top_up < Debt)         // если сумма пополнения меньше задолженности
                {
                    Limit += top_up;
                    Balance = 0;
                    Debt = CopyL - Limit;
                }

                MoneyNotify!.Invoke(this, new AccoutEventArgs("Account topped up with ", top_up, Balance)); // вызов события

                // counter должен быть статическим, чтоб сохранять состояние до достижения очередного шага Balance,
                // когда increase будет увеличиваться
                int increase = (int)Balance / 50000;    // число для увеличения суммы достижения, где 50 000 - первое достижение
                if (increase > counter)                 // increase будет больше counter только тогда, когда Balance >= 50 000, потом >= 100 000 и тд
                {                                       // то есть с шагом 50 000
                    achievement = 50000 * increase;     // увеличение достижения
                    AchievementNotify?.Invoke(this, new AccoutEventArgs2($"Great achievement! Your balance has reached {achievement}")); // вызов события
                    counter = 0;
                    counter += increase;                // теперь counter равен increase и условие выше не сработает, пока Balance не сделает очередной шаг в 50 000
                }           
            }
            public void Take(float sum)
            {
                if (sum <= Balance)                                         // если сумма снятия меньше или равна текущему балансу  
                {                                                           // уменьшаем баланс на сумму затраты  
                    Balance -= sum;
                    MoneyNotify?.Invoke(this, new AccoutEventArgs("Withdrawn from account ", sum, Balance)); // вызов события
                }
                else if ((sum > Balance) &&                                 // если сумма снятия больше текущего баланса И
                    (sum <= Balance + Limit))                               // сумма снятия меньше либо равна сумме баланса с кред. лимитом
                {                                          
                    Limit = Balance + Limit - sum;                          // кред. лимит уменьшается
                    Balance = 0;                                            // баланс текущий обнуляется
                    Debt = CopyL - Limit;                                   // задолженность вычисляется
                    MoneyNotify?.Invoke(this, new AccoutEventArgs($"Withdrawn from account {sum} UAH\n" +
                        $" Current credit funds: {CopyL - Debt} UAH\n" +
                        $" Current credit card debt: ", Debt, Balance));    // вызов события
                }
                else if (sum > Balance + Limit)                             // если сумма снятия больше суммы баланса с лимитом,
                {                                                           // выводим сообщение
                    Console.ForegroundColor = ConsoleColor.Red;
                    MoneyNotify?.Invoke(this, new AccoutEventArgs("Not enough money to withdraw!\n" +
                        $" Current credit funds: {CopyL - Debt} UAH\n" +
                        $" Current credit card debt: ", Debt, Balance));    // вызов события
                }               
            }
            public void ChangePin()
            {
                pinCode = CheckPin("new");
                PinNotify?.Invoke(this, new AccoutEventArgs2(" PIN code has been successfully changed!")); // вызов события
            }
        }
        public class CreditCard // издатель события
        {
            public EventHandler<AccoutEventArgs>? MoneyAction;
            public EventHandler<AccoutEventArgs2>? PinAction;
            public long cardNumber { get; set; }
            public string? holderName { get; set; }
            public string? expDate { get; set; }           
           
            public Account? account { get; set; }
            public CreditCard(long cn, string? holderName, string? ed, Account account)
            {
                this.cardNumber = cn;
                this.holderName = holderName;
                this.expDate = ed;
                this.account = account;
            }
            public CreditCard()
            {
                this.cardNumber = CheckNumber();
                Console.Write("\n Enter сardholder name: ");
                this.holderName = Console.ReadLine();
                this.expDate = CheckDate();
                this.account = new Account();
            }
            public void Take(float sum)
            {                                   // новое событие вызов
                MoneyAction?.Invoke(this, new AccoutEventArgs(" Attempt to withdraw from the account an amount of ", sum, account!.Balance));
                account?.Take(sum);
            }
            public void Put(float sum)
            {
                MoneyAction?.Invoke(this, new AccoutEventArgs(" Attempt to deposit an amount of ", sum, account!.Balance));
                account?.Put(sum);
            }
            public void ChangePin()
            {
                PinAction?.Invoke(this, new AccoutEventArgs2(" Попытка смены пин-кода "));
                account?.ChangePin();
            }
            public void Info()
            {
                Console.WriteLine("\n\t-Credit card-");
                Console.WriteLine($" Owner: \t{holderName}");
                Console.WriteLine($" Number: \t{cardNumber}");
                Console.WriteLine($" Exp. d.: \t{expDate}");
                Console.WriteLine($" Balance: \t{account?.Balance} UAH");
                Console.WriteLine($" Credit funds: \t{account?.Limit} UAH");
                Console.WriteLine($" Credit debt: \t{account?.Debt} UAH");
            }
        }
        static long CheckNumber()                    // проверка номера счета
        {
            long numb;

            while (true)
            {
                Console.Write("\n Enter card number: ");
                try
                {
                    numb = long.Parse(Console.ReadLine()!);

                    long temp = numb;
                    int i = 0;

                    for (; temp > 0; i++) { temp /= 10; } // считаем кол-во цифр в числе

                    if (numb < 0 || i != 16)
                    {
                        throw new Exception(" Incorrect number!");
                    }
                    break;
                }
                catch (FormatException ex) { Console.WriteLine(" Incorrect number!", ex); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            
            return numb;
        }
        static float CheckAmount(string s)           // проверка вводимых сумм
        {
            float sum;
            while (true)
            {
                Console.Write($"\n Enter the amount {s}: ");
                try
                {
                    sum = float.Parse(Console.ReadLine()!);
                    if (sum < 0)               
                    {
                        throw new Exception(" Incorrect amount!");
                    }
                    break;
                }
                catch (FormatException ex) { Console.WriteLine(" Incorrect amount!", ex); }
            }
            return sum;
        }
        static string CheckDate()                    // проверка даты 
        {
            DateTime date;
            string str;
            while (true)
            {
                Console.Write("\n Enter the date (dd.mm.yyyy): ");
                try
                {
                    date = DateTime.Parse(Console.ReadLine()!);                  
                    break;
                }
                catch (FormatException ex) { Console.WriteLine(" Incorrect amount!", ex); }
            }

            string[] subs = date.ToString().Split(" ");
            str = subs[0];

            return str;
        }
        static int CheckPin(string s)                // проверка пин кода
        {
            int pin;
            while (true)
            {
                Console.Write($"\n Enter {s} pin code (four digits): ");
                try
                {
                    pin = int.Parse(Console.ReadLine()!);

                    int temp = pin;
                    int i = 0;

                    for (; temp > 0; i++) { temp /= 10; } // считаем кол-во цифр в числе

                    if (pin < 0 || i != 4)
                    {
                        throw new Exception(" Incorrect pin!");
                    }
                    break;
                }
                catch (FormatException ex) { Console.WriteLine(" Incorrect pin!", ex); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            return pin;
        }
    }
}