using System;
using System.IO;
using System.Collections;
using SuperBank.model;
namespace SuperBank.utils
{
    public class AccountService
    {
        public static Account SearchAccountByAccountNumber(string accountNumber)
        {
            try
            {
                string path = FileHelpers.GetAccountFilePath(accountNumber);
                string[] accountInfo = File.ReadAllLines(path);

                string id = "";
                string firstName = "";
                string lastName = "";
                string address = "";
                string phone = "";
                string email = "";
                string balance = "";

                foreach (string line in accountInfo)
                {
                    string key = line.Split('|')[0];
                    string value = line.Split('|')[1];

                    switch (key)
                    {
                        case "AccountNo":
                            id = value;
                            break;
                        case "FirstName":
                            firstName = value;
                            break;
                        case "LastName":
                            lastName = value;
                            break;
                        case "Address":
                            address = value;
                            break;
                        case "Phone":
                            phone = value;
                            break;
                        case "Email":
                            email = value;
                            break;
                        case "Balance":
                            balance = value;
                            break;
                    }
                }

                return new Account(id, firstName, lastName, address, phone, email, balance);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
