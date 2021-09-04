using System;
using System.IO;
using System.Collections.Generic;
using SuperBank.utils;
namespace SuperBank.model
{
    public class Account
    {
        private int id;
        private string firstName;
        private string lastName;
        private string address;
        private int phone;
        private string email;
        private int balance;
        private List<Transaction> history;

        public Account() { }

        public Account(string id, string firstName, string lastName, string address, string phone, string email, string balance, List<Transaction> history)
        {
            this.id = Convert.ToInt32(id);
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phone = Convert.ToInt32(phone);
            this.email = email;
            this.balance = Convert.ToInt32(balance);
            this.history = history;
        }

        public Account(string firstName, string lastName, string address, string phone, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phone = Convert.ToInt32(phone);
            this.email = email;
        }

        public Transaction Deposit(int amount)
        {
            DateTime date = DateTime.Today;
            string action = "DEPOSIT";
            balance += amount;
            Transaction newTrans = new Transaction(date, action, amount, balance);
            history.Add(newTrans);
            UpdateAccount();
            return newTrans;
        }

        public Transaction Withdraw(int amount)
        {
            if (balance < amount)
            {
                throw new Exception();
            } else
            {
                DateTime date = DateTime.Today;
                string action = "WITHDRAW";
                balance -= amount;
                Transaction newTrans = new Transaction(date, action, amount, balance);
                history.Add(newTrans);
                UpdateAccount();
                return newTrans;
            }
             
        }

        public int SaveNewAccount()
        {
            Random rnd = new Random();
            int accountNumber = rnd.Next(100000, 99999999);
            try
            {
                string path = FileHelpers.GetAccountFilePath(Convert.ToString(accountNumber));

                if (File.Exists(path))
                {
                    SaveNewAccount();
                }
                id = accountNumber;
                balance = 0;
                WriteInformation(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
            return accountNumber;
        }

        public int UpdateAccount()
        {
            string path = FileHelpers.GetAccountFilePath(Convert.ToString(id));
            if (File.Exists(path))
            {
                WriteInformation(path);
                WriteHistory(path);
            }
            return id;
        }

        private void WriteInformation(string path)
        {
            try
            {
                StreamWriter streamwriter = new StreamWriter(path);
                streamwriter.WriteLine($"AccountNo|{id}");
                streamwriter.WriteLine($"FirstName|{firstName}");
                streamwriter.WriteLine($"LastName|{lastName}");
                streamwriter.WriteLine($"Address|{address}");
                streamwriter.WriteLine($"Phone|{phone}");
                streamwriter.WriteLine($"Email|{email}");
                streamwriter.WriteLine($"Balance|{balance}");
                streamwriter.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Fail to write to file");
            }
        }

        private void WriteHistory(string path)
        {
            try
            {
                StreamWriter streamwriter = File.AppendText(path);
                if (history.Count > 0)
                {
                    List<Transaction> tmp = history;
                    if (history.Count > 5)
                    {
                        tmp = history.GetRange(history.Count - 5, 5);
                    }

                    foreach (Transaction trans in tmp)
                    {
                        string sDateTime = trans.date.ToString("d");
                        streamwriter.WriteLine($"{sDateTime}|{trans.action}|{trans.amount}|{trans.remainAmount}");
                    }
                }
                streamwriter.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Fail to write to file");
            }
        }

        public string GetMailContent()
        {
            return $"Account Statement\n\nAccountNo: {id}\nFirst Name: {firstName}\nLast Name: {lastName}\nAddress: {address}\nPhone: {phone}\nEmail: {email}\nBalance: {balance} USD\n";
        }

        public void PrintToConsole()
        {
            string sID = Convert.ToString(id);
            string sPhone = Convert.ToString(phone);
            string sBalance = Convert.ToString(balance);

            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\t\t|                ACCOUNT DETAILS                 |");
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\t\t|                                                |");
            Console.Write($"\t\t|    Account No: {sID}");
            UIHelpers.PrintRemainSpace(new Cursor());
            Console.Write($"\t\t|    First Name: {firstName}");
            UIHelpers.PrintRemainSpace(new Cursor());
            Console.Write($"\t\t|    Last Name: {lastName}");
            UIHelpers.PrintRemainSpace(new Cursor());
            Console.Write($"\t\t|    Address: {address}");
            UIHelpers.PrintRemainSpace(new Cursor());
            Console.Write($"\t\t|    Phone: {sPhone}");
            UIHelpers.PrintRemainSpace(new Cursor());
            Console.Write($"\t\t|    Email: {email}");
            UIHelpers.PrintRemainSpace(new Cursor());
            Console.Write($"\t\t|    Balance: {sBalance}");
            UIHelpers.PrintRemainSpace(new Cursor());
            Console.WriteLine("\t\t==================================================");
        }
    }
}
