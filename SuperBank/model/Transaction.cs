using System;
namespace SuperBank.model
{
    public class Transaction
    {
        public DateTime date;
        public string action;
        public int amount;
        public int remainAmount;

        public Transaction(DateTime date, string action, int amount, int remainAmount)
        {
            this.date = date;
            this.action = action;
            this.amount = amount;
            this.remainAmount = remainAmount;
        }

        public Transaction(string date, string action, string amount, string remainAmount)
        {
            this.date = Convert.ToDateTime(date);
            this.action = action;
            this.amount = Convert.ToInt32(amount);
            this.remainAmount = Convert.ToInt32(remainAmount);
        }
    }
}
