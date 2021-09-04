using System;
using System.IO;
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
        private double balance;

        public Account() { }

        public Account(string id, string firstName, string lastName, string address, string phone, string email, string balance)
        {
            this.id = Convert.ToInt32(id);
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phone = Convert.ToInt32(phone);
            this.email = email;
            this.balance = Convert.ToDouble(balance);
        }

        public Account(string firstName, string lastName, string address, string phone, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phone = Convert.ToInt32(phone);
            this.email = email;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public string GetAddress()
        {
            return address;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }

        public int GetPhone()
        {
            return phone;
        }

        public void SetPhone(int phone)
        {
            this.phone = phone;
        }

        public string GetEmail()
        {
            return email;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public double GetBalance()
        {
            return balance;
        }

        public void SetBalance(double balance)
        {
            this.balance = balance;
        }

        public int SaveOnDisk()
        {
            Random rnd = new Random();
            int accountNumber = rnd.Next(100000, 99999999);
            try
            {
                string path = FileHelpers.GetAccountFilePath(Convert.ToString(accountNumber));

                if (File.Exists(path))
                {
                    SaveOnDisk();
                }
                id = accountNumber;
                balance = 0.0;
                WriteToFile(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
            return accountNumber;
        }

        private void WriteToFile(string path)
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
