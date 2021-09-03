using System;
namespace SuperBank.screen
{
    public class CreateAccount
    {
        private MainMenu mainMenu;

        public CreateAccount(MainMenu mainMenu)
        {
            this.mainMenu = mainMenu;
        }

        public void ShowInterface()
        {
            Console.Clear();
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\t\t|               CREATE A NEW ACCOUNT             |");
            Console.WriteLine("\t\t==================================================");
        }
    }
}
