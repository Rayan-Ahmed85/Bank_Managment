using System;

namespace Bank_Management
{
    class Account
    {
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public double Balance { get; set; }
    }

    class Program
    {
        static Account[] accounts = new Account[10];
        static int accountCount = 0;

        static void Main(string[] args)
        {
            if (!Login()) return;

            int choice;
            do
            {
            
                Console.WriteLine(" *Bank Management System*");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. View Accounts");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Withdraw");      
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: CreateAccount(); break;
                    case 2: ViewAccounts(); break;
                    case 3: Deposit(); break;
                    case 4: Withdraw(); break;
                    case 5: Console.WriteLine("Thank you Visit Again."); break;
                    default: Console.WriteLine("Invalid choice."); break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();

            } while (choice != 5);
        }

        static bool Login()
        {
            const string USERNAME = "admin";
            const string PASSWORD = "1234";

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter username: ");
                string user = Console.ReadLine();
                Console.Write("Enter password:   ");
                string pass = Console.ReadLine();

                if (user == USERNAME && pass == PASSWORD)
                {
                    Console.WriteLine("Login successful!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Incorrect credentials. Attempts left: " + (2 - i));
                }
            }

            Console.WriteLine("Too many failed attempts. Exiting...");
            return false;
        }

        static void CreateAccount()
        {
            if (accountCount >= 10)
            {
                Console.WriteLine("Maximum account limit reached.");
                return;
            }

            Account acc = new Account();

            Console.Write("Enter Account Number: ");
            acc.AccountNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Customer Name: ");
            acc.CustomerName = Console.ReadLine();

            Console.Write("Enter Initial Balance: ");
            acc.Balance = Convert.ToDouble(Console.ReadLine());

            accounts[accountCount++] = acc;
            Console.WriteLine("Account created successfully.");
        }

        static void ViewAccounts()
        {
            if (accountCount == 0)
            {
                Console.WriteLine("No accounts to display.");
                return;
            }

            Console.WriteLine("\n--- Account List ---");
            for (int i = 0; i < accountCount; i++)
            {
                Console.WriteLine($"Account #{i + 1}");
                Console.WriteLine($"Account Number: {accounts[i].AccountNumber}");
                Console.WriteLine($"Customer Name: {accounts[i].CustomerName}");
                Console.WriteLine($"Balance Rs.: {accounts[i].Balance}");
                Console.WriteLine("-------------------------");
            }
        }
        static void Deposit()
        {
            Console.Write("Enter Account Number: ");
            int accNum = Convert.ToInt32(Console.ReadLine());

            Account acc = FindAccount(accNum);
            if (acc != null)
            {
                Console.Write("Enter Amount to Deposit: ");
                double amount = Convert.ToDouble(Console.ReadLine());
                acc.Balance += amount;
                Console.WriteLine("Deposit successful.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        static void Withdraw()
        {
            Console.Write("Enter Account Number: ");
            int accNum = Convert.ToInt32(Console.ReadLine());

            Account acc = FindAccount(accNum);
            if (acc != null)
            {
                Console.Write("Enter Amount to Withdraw: ");
                double amount = Convert.ToDouble(Console.ReadLine());

                if (acc.Balance >= amount)
                {
                    acc.Balance -= amount;
                    Console.WriteLine("Withdraw successful.");
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        static Account FindAccount(int accountNumber)
        {
            for (int i = 0; i < accountCount; i++)
            {
                if (accounts[i].AccountNumber == accountNumber)
                    return accounts[i];
            }
            return null;
        }
    }
}
