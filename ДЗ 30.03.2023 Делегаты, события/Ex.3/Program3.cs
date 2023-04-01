namespace Ex._3
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public class CreditCard
        {
            long cardNumber { get; set; }
            string? holderName { get; set; }
            DateTime? expDate { get; set; }
            int pinCode { get; set; }
            double creditLimit { get; set; }
            double sum { get; set; }
        }
        public class AccoutEventArgs : EventArgs // событие
        {
            public AccoutEventArgs(string? message, int sum, int balance)
            {
                Message = message;
                Sum = sum;
                Balance = balance;
            }
            public string? Message { get; set; }
            public int Sum { get; set; }
            public int Balance { get; set; }
        }
        public class Account  // обработка событий
        {
            public EventHandler<AccoutEventArgs>? Notify; // 1. Define an event// унифицированный обработчик событий ДЕЛЕГАТ для события
            public int Balance { get; set; } = 0;
            public Account(int sum) { this.Balance = sum; }
            public void Put(int sum)
            {
                Balance += sum;
                Notify?.Invoke(this, new AccoutEventArgs("Положено на счет ", sum, Balance)); // 2. Raise Event
            }
            public void Take(int sum)
            {
                if (Balance >= sum)
                {
                    Balance -= sum;
                    Notify?.Invoke(this, new AccoutEventArgs("Снято со счета ", sum, Balance)); // 2. Raise Event
                }
                else
                {
                    //AccoutEventArgs args = new AccoutEventArgs();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Notify?.Invoke(this, new AccoutEventArgs("Недостаточно денег для снятия ", sum, Balance)); // 2. Raise Event

                }
            }
            public override string ToString()
            {
                return "Accoutn object";
            }

        }
    }
}