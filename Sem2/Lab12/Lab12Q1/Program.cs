namespace Lab12Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount acc = new BankAccount(
                customerName: "john",
                type: "Current",
                BIC: 123456789,
                number: 999888777,
                balance: 1000,
                PIN: 1234
                );

            Console.WriteLine(acc.balance);

            BankAccount.Withdraw(acc, 500);


            Console.WriteLine(acc.balance);
        }
    }

    public class BankAccount
    {
        public string customerName { get; set; }
        public string type { get; set; }
        public int BIC { get; set; }
        public int number { get; set; }
        public double balance { get; set; }
        public int PIN { get; set; }

        public BankAccount(string customerName, string type, int BIC, int number, double balance, int PIN)
        {
            this.customerName = customerName;
            // add checks for the correct account type
            this.type = type;
            this.BIC = BIC;
            this.number = number;
            this.balance = balance;
            this.PIN = PIN;
        }


        public void Lodge(double amount)
        {
            // what does lodge mean?
        }

        // check return void 

        public static bool CheckPIN(BankAccount owner)
        {
            const int TRIES = 3;

            for (int i = 0; i < TRIES; i++)
            {
                Console.Write("Input PIN: ");
                int input = int.Parse(Console.ReadLine());

                if (input == owner.PIN)
                    return true;
                else
                    Console.WriteLine($"{TRIES - i - 1} tries left.");
            }

            Console.WriteLine("\nno");
            return false;
        }

        // why tf static?
        public static void Withdraw(BankAccount owner, double amount)
        {
            if (!BankAccount.CheckPIN(owner))
                return;

            // actual content
            if (amount > owner.balance)
                Console.WriteLine("Insufficient funds");
            else
                owner.balance -= amount;
        }

        public void Withdraw(double amount)
        {
            // check pin
            // and then

            // do withdrawal stuff
        }

        public void CheckBalance()
        {
            const int TRIES = 3;

            for (int i = 0; i < TRIES; i++)
            {
                Console.Write("Input PIN: ");
                int input = int.Parse(Console.ReadLine());
                if (input == this.PIN)
                {
                    // do a balance check
                    // or do a withdrawal
                    // or do something else
                    //
                    // how do I wrap each method with this for-if-else PIN checking



                    // only this part
                    Console.WriteLine($"Your current balance is: {this.balance}");
                    // is the functionality



                    break;
                }
                else
                    Console.WriteLine($"Invalid PIN | {TRIES - i - 1} tries left");
            }
        }

        public void ChangePIN(int newPIN)
        {
            this.PIN = newPIN;
        }
    }
}