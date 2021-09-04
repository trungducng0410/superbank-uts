using System;
using SuperBank.model;
using SuperBank.utils;
namespace SuperBank.screen
{
    public class CreateAccount
    {
        private MainMenu mainMenu;

        private Account account;

        private string firstNameInput;
        private string lastNameInput;
        private string addressInput;
        private string phoneInput;
        private string emailInput;

        private Cursor firstNameCursor;
        private Cursor lastNameCursor;
        private Cursor addressCursor;
        private Cursor phoneCursor;
        private Cursor emailCursor;
        private Cursor errorCursor;

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
            Console.WriteLine("\t\t|                ENTER THE DETAILS               |");
            Console.WriteLine("\t\t|                                                |");

            Console.Write("\t\t|    First Name: ");
            firstNameCursor = new Cursor();
            if (firstNameInput != null)
            {
                Console.Write(firstNameInput);
                
            }
            UIHelpers.PrintRemainSpace(new Cursor());

            Console.Write("\t\t|    Last Name: ");
            lastNameCursor = new Cursor();
            if (lastNameInput != null)
            {
                Console.Write(lastNameInput);
                
            }
            UIHelpers.PrintRemainSpace(new Cursor());

            Console.Write("\t\t|    Address : ");
            addressCursor = new Cursor();
            if (addressInput != null)
            {
                Console.Write(addressInput);
                
            }
            UIHelpers.PrintRemainSpace(new Cursor());

            Console.Write("\t\t|    Phone : ");
            phoneCursor = new Cursor();
            if (phoneInput != null)
            {
                Console.Write(phoneInput);
            }
            UIHelpers.PrintRemainSpace(new Cursor());

            Console.Write("\t\t|    Email : ");
            emailCursor = new Cursor();
            if (emailInput != null)
            {
                Console.Write(emailInput);
            }
            UIHelpers.PrintRemainSpace(new Cursor());

            Console.WriteLine("\t\t==================================================\n\n");

            errorCursor = new Cursor();

            GetInput();
        }

        private void GetInput()
        {
            if (firstNameInput == null)
            {
                Console.SetCursorPosition(firstNameCursor.x, firstNameCursor.y);
                firstNameInput = Console.ReadLine();
                if (firstNameInput.Length < 1)
                {
                    ShowErrorAndResetField("First name cannot be empty", ref firstNameInput);
                }
            }

            if (lastNameInput == null)
            {
                Console.SetCursorPosition(lastNameCursor.x, lastNameCursor.y);
                lastNameInput = Console.ReadLine();
                if (lastNameInput.Length < 1)
                {
                    ShowErrorAndResetField("Last name cannot be empty", ref lastNameInput);
                }
            }

            if (addressInput == null)
            {
                Console.SetCursorPosition(addressCursor.x, addressCursor.y);
                addressInput = Console.ReadLine();
                if (addressInput.Length < 1)
                {
                    ShowErrorAndResetField("Address cannot be empty", ref addressInput);
                }
            }

            if (phoneInput == null)
            {
                Console.SetCursorPosition(phoneCursor.x, phoneCursor.y);
                phoneInput = Console.ReadLine();
                if (phoneInput.Length < 1 || phoneInput.Length > 10 || !int.TryParse(phoneInput, out _))
                {
                    ShowErrorAndResetField("Phone number should not be more than 10 characters or must be number", ref phoneInput);
                };
            }

            if (emailInput == null)
            {
                Console.SetCursorPosition(emailCursor.x, emailCursor.y);
                emailInput = Console.ReadLine();
                if (!RegexHelplers.IsValidEmail(emailInput))
                {
                    ShowErrorAndResetField("Invalid email", ref emailInput);
                }
            }

            Console.SetCursorPosition(errorCursor.x, errorCursor.y);
            Console.Write("Is the information correct (y/n)? ");
            ConfirmInput();
        }

        private void ConfirmInput()
        {

            string choice = Console.ReadLine();
            if (choice.Equals("y"))
            {
                SaveAccountToFile();
                ResetAll();
            }
            else if (choice.Equals("n"))
            {
                ResetAll();
                ShowInterface();
            }
            else
            {
                Console.WriteLine("\nInvalid input, try again... Press enter");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    ShowInterface();
                }
            }

        }

        private void SaveAccountToFile()
        {
            account = new Account(firstNameInput, lastNameInput, addressInput, phoneInput, emailInput);
            int accountNumber = account.SaveNewAccount();
            if (accountNumber != -1)
            {
                Console.WriteLine("\nAccount Created! Details will be provided via email.\n");
                Console.WriteLine($"Account number is: {accountNumber}\n");
                MailService.SendMail(emailInput, "Account Information", account.GetMailContent());
                Console.Write("Email sent\nPress enter to go back to main menu... ");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    mainMenu.ShowMainMenu();
                }
            }
        }

        private void ShowErrorAndResetField(string message, ref string field)
        {
            Console.SetCursorPosition(errorCursor.x, errorCursor.y);
            Console.WriteLine($"{message}... Press enter ");
            field = null;
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                ShowInterface();
            }
        }

        private void ResetAll()
        {
            firstNameInput = null;
            lastNameInput = null;
            addressInput = null;
            phoneInput = null;
            emailInput = null;
        }
    }
}
