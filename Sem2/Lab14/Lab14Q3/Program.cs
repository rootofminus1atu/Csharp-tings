﻿namespace Lab14Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account bankAccount = new Account("hi", 1000, "1234");

            bankAccount.PinDepositMoney(100);
        }
    }

    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Pin { get; set; }

        public Account(string name, double balance, string pin)
        {
            Name = name;
            Balance = balance;
            Pin = pin;
        }

        public void CheckBalance()
        {
            Console.WriteLine("Checking balance begins");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Input PIN: ");
                string pin = Console.ReadLine();

                if (pin == "secretpin")
                {
                    // actual CheckBalance code is here
                    Console.WriteLine($"You have {Balance}");
                    return;
                    // and ends here
                }
                else
                    Console.WriteLine("Try again");
            }
            Console.WriteLine("Go away");
            
        }

        public void DepositMoney(int amount)
        {
            // the same pin check from above, except now we nest:

            // this.Balance += amount;
            Console.WriteLine($"You have {amount} more money");
        }

        public void GetMoney(int amount)
        {
            Console.WriteLine($"You now have {amount} less money");
        }

        private static Action AnnoyingPinDecorator(Action action)
        {
            Action wrapper = () =>
            {
                Console.WriteLine("Started procedure with PIN");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("Input PIN: ");
                    string pin = Console.ReadLine();

                    if (pin == "secretpin")
                    {
                        action();
                        break;
                    }
                    else if (i == 2)
                    {
                        Console.WriteLine("That was the last chance");
                    }
                    else
                    {
                        Console.WriteLine("Try again");
                    }
                }
                Console.WriteLine("Ended procedure with PIN");
            };
            return wrapper;
        }

        public void PinDepositMoney(int amount)
        {
            AnnoyingPinDecorator(() => DepositMoney(amount))();
        }

        public void PinGetMoney(int amount)
        {
            AnnoyingPinDecorator(() => GetMoney(amount))();
        }

        // these get the job done, but aren't they awkward? 
        // the decorator was also relatively simple when dealing with Actions
        // when dealing with Functions that return something things get more complicated
        // besides that these aren't true decorators, we create new methods anyway

    }
}