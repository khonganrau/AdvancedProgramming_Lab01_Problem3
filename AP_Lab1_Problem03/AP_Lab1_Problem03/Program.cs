using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;


namespace AP_Lab1_Problem03
{
 
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

            Console.WriteLine("Welcome to BankAccount Sytem");
            Console.WriteLine("Menu Option");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4.Print");
            Console.WriteLine("To Implement the function of this system. Please input the command-line that show in the MenuOption.");
            Console.WriteLine("Input the command: ");
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split();
                int accountId = int.Parse(commandArgs[1]);

                switch (commandArgs[0])
                {
                    case "Create":
                        if (accounts.ContainsKey(accountId))
                        {
                            Console.WriteLine("Account already exists");
                        }
                        else
                        {
                            var account = new BankAccount { Id = accountId };
                            accounts.Add(accountId, account);
                            Console.WriteLine("An account is successfull created.");
                        }
                        break; 
                    case "Deposit":
                        if (!accounts.ContainsKey(accountId))
                        {
                            Console.WriteLine("Account does not exist");
                        }
                        else
                        {
                            decimal amount = decimal.Parse(commandArgs[2]);
                            
                            if (amount > 0)
                            {
                                accounts[accountId].Deposit(amount);
                                Console.WriteLine("Successfull Deposit");

                            }
                            else
                            {
                                Console.WriteLine("Unsuccesfully Deposit");
                            }
                            
                           
                        }
                        break;
                    case "Withdraw":
                        if (!accounts.ContainsKey(accountId))
                        {
                            Console.WriteLine("Account does not exist");
                        }
                        else
                        {
                            decimal amount = decimal.Parse(commandArgs[2]);
                            if (accounts[accountId].Balance < amount)
                            {
                                Console.WriteLine("Insufficient balance");
                            }
                            else
                            {
                                accounts[accountId].Withdraw(amount);
                                Console.WriteLine($"Successfully Withdrawl.");
                            }
                        }
                        break;
                    case "Print":
                        if (!accounts.ContainsKey(accountId))
                        {
                            Console.WriteLine("Account does not exist");
                        }
                        else
                        {
                            Console.WriteLine(accounts[accountId]);
                        }
                        break;
                }
            }
        }
    }
}
