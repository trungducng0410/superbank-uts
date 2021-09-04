using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
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
                List<Transaction> history = new List<Transaction>();

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
                        default:
                            string[] transArray = line.Split('|');
                            string date = transArray[0];
                            string action = transArray[1];
                            string amount = transArray[2];
                            string remainAmount = transArray[3];
                            history.Add(new Transaction(date, action, amount, remainAmount));
                            break;
                    }
                }

                return new Account(id, firstName, lastName, address, phone, email, balance, history);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
