using System;
using System.IO;

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

        public Account(string firstName, string lastName, string address, string phone, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phone = Convert.ToInt32(phone);
            this.email = email;
            this.balance = 0.0;
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
                string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string sFolder = Path.Combine(sCurrentDirectory, @"../../../data/accounts");
                string sFolderPath = Path.GetFullPath(sFolder);
                string sFilePath = sFolderPath + $"/{accountNumber}.txt";

                if (File.Exists(sFilePath))
                {
                    SaveOnDisk();
                }
                id = accountNumber;
                WriteToFile(sFilePath);
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
                streamwriter.WriteLine($"First Name|{firstName}");
                streamwriter.WriteLine($"Last Name|{lastName}");
                streamwriter.WriteLine($"Address|{address}");
                streamwriter.WriteLine($"Phone|{phone}");
                streamwriter.WriteLine($"Email|{email}");
                streamwriter.WriteLine($"Balance|{balance}");
                streamwriter.Close();
            } catch (Exception)
            {
                Console.WriteLine("Fail to write to file");
            }
        }

        public string GetMailContent()
        {
            return $"Account Statement\n\nAccountNo: {id}\nFirst Name: {firstName}\nLast Name: {lastName}\nAddress: {address}\nPhone: {phone}\nEmail: {email}\nBalance: {balance} USD\n";
        }
    }
}
