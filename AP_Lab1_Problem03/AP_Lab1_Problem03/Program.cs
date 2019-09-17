using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;


namespace AP_Lab1_Problem03
{
    public class BankAccount
    {
        private int id;
        private decimal balance;

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            set
            {
                this.balance = value;
            }
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }

        public override string ToString()
        {
            return $"Account ID{this.Id}, balance {this.Balance}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

            Console.WriteLine("Enter command line:");
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
                            accounts[accountId].Deposit(amount);
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
