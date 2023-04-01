using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Ex._3
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            CreditCard card = new (222111555, "Oliver Hendels", "21.02.2026", new Account(100,500, 1414));
            //user1.account.Notify += DisplayMessage; // ответ банка Добавляем обработчик для события Notify          
            //user1.AccountAction += DisplayUserMessage; // действие пользователя Добавляем обработчик для события Notify
            card.account.MoneyNotify += (object? sender, AccoutEventArgs e) =>
            {
                Console.WriteLine(" Ответ банка:\n " + e.Message + e.Sum + ".\n Баланс средств: " + e.Balance);
                Console.WriteLine("---------------------------------------------------------------------");
                Console.ResetColor();
            };           
            card.MoneyAction += delegate (object? sender, AccoutEventArgs e)
            {
                if (sender is CreditCard card)
                {
                    Console.WriteLine(e.Message + e.Sum + " клиентом: " + card.holderName);
                }
            };
            card.account.PinNotify += (object? sender, AccoutEventArgs2 e) =>
            {
                Console.WriteLine(" Ответ банка:\n " + e.Message);
                Console.WriteLine("---------------------------------------------------------------------");
                Console.ResetColor();
            };
            card.PinAction += delegate (object? sender, AccoutEventArgs2 e)
            {
                if (sender is CreditCard card)
                {
                    Console.WriteLine(e.Message + " клиентом: " + card.holderName);
                }
            };
            card.account.GoalNotify += (object? sender, AccoutEventArgs2 e) =>
            {
                Console.WriteLine(" Ответ банка:\n " + e.Message);
                Console.WriteLine("---------------------------------------------------------------------");
                Console.ResetColor();
            };
            

            card.Put(100);
            card.Take(120);
            card.Take(100);
            //card.Put(100);
            card.Take(500);
            card.ChangePin();
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
            public EventHandler<AccoutEventArgs2>? GoalNotify;

            public float Balance { get; set; } = 0; // текущий баланс
            public float Limit { get; set; } // кредитный лимит
            public float Debt { get; set; }       // долг по кредиту
            public float CopyL;              // копия кредитного лимита
            public int pinCode { get; set; }
            public Account(float sum, float cl,int pin)
            { 
                this.Balance = sum; 
                this.Limit = cl;
                this.Debt = 0;
                this.CopyL = this.Limit;
                this.pinCode = pin;

            }
            public void Put(float top_up)
            {
                if(Debt == 0)
                {
                    Balance += top_up;
                }
                else if (top_up >= Debt)                        // если сумма пополнения больше либо равна задолженности
                {
                    Balance = top_up - Debt;
                    Limit = CopyL;
                    Debt = 0;
                }
                else if (top_up < Debt)
                {
                    Limit += top_up;
                    Balance = 0;
                    Debt = CopyL - Limit;
                }

                MoneyNotify?.Invoke(this, new AccoutEventArgs("Положено на счет ", top_up, Balance)); // 2. Raise Event

                if(Balance >= 100)
                {
                    GoalNotify?.Invoke(this, new AccoutEventArgs2(" Ура! Ваш баланс больше 100 грн"));
                }
            }
            public void Take(float sum)
            {
                if (sum <= Balance)                         // если сумма снятия меньше или равна текущему балансу  
                {                                           // уменьшаем баланс на сумму затраты  
                    Balance -= sum;
                    MoneyNotify?.Invoke(this, new AccoutEventArgs("Снято со счета ", sum, Balance)); // 2. Raise Event
                }
                else if ((sum > Balance) &&                 // если сумма снятия больше текущего баланса И
                    (sum <= Balance + Limit))               // сумма снятия меньше либо равна сумме баланса с кред. лимитом
                {                                          
                    Limit = Balance + Limit - sum;          // кред. лимит уменьшается
                    Balance = 0;                            // баланс текущий обнуляется
                    Debt = CopyL - Limit;                   // задолженность вычисляется
                    MoneyNotify?.Invoke(this, new AccoutEventArgs($"Снято со счета {sum} " +
                        $"Current credit funds {CopyL - Debt}" +
                        $" Current credit card debt ", Debt, Balance)); // 2. Raise Event
                }
                else if (sum > Balance + Limit)             // если сумма снятия больше суммы баланса с лимитом,
                {                                           // выводим сообщение
                    Console.ForegroundColor = ConsoleColor.Red;
                    MoneyNotify?.Invoke(this, new AccoutEventArgs("Недостаточно денег для снятия!\n" +
                        $" Current credit funds {CopyL - Debt}\n" +
                        $" Current credit card debt ", Debt, Balance)); // 2. Raise Event
                }               
            }
            public void ChangePin()
            {
                Console.WriteLine(" Введите новый пин-код:");
                pinCode = int.Parse(Console.ReadLine()!);
                PinNotify?.Invoke(this, new AccoutEventArgs2(" Пин-код успешно изменен")); // 2. Raise Event
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
            public void Take(float sum)
            {                                   // новое событие вызов
                MoneyAction?.Invoke(this, new AccoutEventArgs("Попытка снятия со счета суммы в размере ", sum, account.Balance));
                account?.Take(sum);
            }
            public void Put(float sum)
            {
                MoneyAction?.Invoke(this, new AccoutEventArgs("Попытка положить на счет суммы в размере ", sum, account.Balance));
                account?.Put(sum);
            }
            public void ChangePin()
            {
                PinAction?.Invoke(this, new AccoutEventArgs2("Попытка смены пин-кода "));
                account?.ChangePin();
            }

        }
    }
}