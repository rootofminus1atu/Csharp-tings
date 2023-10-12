namespace Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Create a class called Bank Account with the following properties – Account Number, Account Holder, Balance.  
             * Use shorthand properties.  
             * Create a constructor which takes all properties as parameters. 
             * Create two bank account objects and display the bank details in your program.  
             * Add methods to deposit and withdraw money from the bank accounts.  
             * Add a method to display account details and make use of all of these methods using the Console to display the changes.  
             */

            // so that the euro symbol works
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            BankAccount acc1 = new(129874928, "Tom Smith", 1000);
            BankAccount acc2 = new(999888777, "Mary Mills", 2000);
            Console.WriteLine(acc1.ToString());
            Console.WriteLine(acc2.ToString());


            acc1.Deposit(100);
            Console.WriteLine(acc1.ToString());

            acc2.Withdraw(500);
            Console.WriteLine(acc2.ToString());
        }
    }

    public class BankAccount
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        
        public double Balance { get; set; } 

        public BankAccount(int number, string holder, double balance)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"Account Number: {Number}\nAccount Holder: {Holder}\nAccount Balance: {Balance:c}";
        }

        public void Deposit(int amount)
        {
            Console.WriteLine($"Adding {amount:c} to account {Number}");
            Balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine($"Can't withdraw {amount:c} since account {Number} only have {Balance:C}");
                return;
            }

            Console.WriteLine($"Withdrawing {amount:c} from account {Number}");
            Balance -= amount;
        }
    }

}