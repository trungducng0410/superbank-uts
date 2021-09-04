using System;
using SuperBank.model;
using SuperBank.utils;
namespace SuperBank.screen
{
    public class Statement : SearchAccount
    {
        public Statement(MainMenu mainMenu) : base(mainMenu)
        {
            this.mainMenu = mainMenu;
        }

        public override void ShowInterface()
        {
            Console.Clear();
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\t\t|                    STATEMENT                   |");
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\t\t|                ENTER THE DETAILS               |");
            Console.WriteLine("\t\t|                                                |");
            Console.Write("\t\t|    Account number: ");
            inputCuror = new Cursor();
            Console.WriteLine("\t\t\t\t |");
            Console.WriteLine("\t\t==================================================\n\n");
            errorCursor = new Cursor();

            GetInput();
        }

        protected override void Search(string accountNumber)
        {
            try
            {
                Account account = AccountService.SearchAccountByAccountNumber(accountNumber);
                Console.WriteLine("\n\nAccount found! The statement is displayed below...");
                account.PrintHistoryToConsole();
                Console.Write("Email statement (y/n - default) ");
                string choice = Console.ReadLine();
                if (choice.Equals("y"))
                {
                    MailService.SendMail(account.GetEmail(), "Account Statement", account.GetHistoryContent());
                    Console.WriteLine("Email sent successfully!... Press enter to go back");
                }
                ContinueToSearch();
            }
            catch (Exception)
            {
                Console.SetCursorPosition(errorCursor.x, errorCursor.y);
                Console.WriteLine("Account not found!");
                ContinueToSearch();
            }
        }
    }
}
