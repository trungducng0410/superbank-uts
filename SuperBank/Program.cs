using System;
using SuperBank.screen;

namespace SuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Login loginMenu = new Login();
            Console.Clear();
            loginMenu.ShowLoginScreen();
        }
    }
}
