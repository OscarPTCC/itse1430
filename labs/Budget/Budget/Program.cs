using System;
/*
 *Oscar Peinado-Rojo
 *ITSE 1430
 *Lab 1
 */


namespace Budget
{
    class Program
    {
        static int Main ( string[] args )
        {
            Console.WriteLine("Budget program developed by Oscar Peinado. ");

            Console.WriteLine("Please input account nickname: ");

            AccountName = ReadString(true);

            Console.WriteLine("Please input account number: ");

            AccountNumber = ParseString(true);

            Console.WriteLine("Please input starting balance: ");

            AccountBalance = ReadInt32(0);
            do
            {
                switch (DisplayMenu())
                {
                    case 'A': AccountInformation(); break;

                    case 'Q': QuitApp(); break;

                    case 'D': DepositIncome(); break;

                    case 'W': WithdrawAccount(); break;
                }
            } while (true);
        }
        static string AccountName = "";
        static string AccountNumber = "";
        static decimal AccountBalance = 0;

        private static void WithdrawAccount ()
        {
            Console.WriteLine("Input withdrawal amount: ");

            do
            {
                string value = ReadString(true);

                if (Decimal.TryParse(value, out decimal amount))
                {
                    while (amount < 1 || amount > AccountBalance)
                    {
                        DisplayError("Amount must not exceed balance or be less than 1!");

                        amount = ReadInt32(0);
                    }

                    AccountBalance = AccountBalance - amount;

                    Console.WriteLine("Description for withdrawn value.");

                    string description = ReadString(true);

                    Console.WriteLine("Category of withrawn value.");

                    string category = ReadString(false);

                    Console.WriteLine("Date deposited: " + DateTime.Today);

                    Console.WriteLine("Value successfully withdrawn from your account!");

                    return;
                } else
                    DisplayError("Please input a numeric value.");
            } while (true);
        }

        private static string ParseString ( bool required )
        {
            do
            {
                string AccountNumber = Console.ReadLine();

                if (!required || AccountNumber != "")
                    if (Int32.TryParse(AccountNumber, out int result))
                        return AccountNumber;

                DisplayError("Value is required and it must be a numeric value.");
            } while (true);
        }

        private static void DepositIncome ()
        {
            Console.WriteLine("Input deposit amount: ");

            do
            {
                string value = ReadString(true);

                if (Decimal.TryParse(value, out decimal amount))
                {
                    while (amount < 1)
                    {
                        DisplayError("Value must be more than 0!");

                        amount = ReadInt32(0);
                    }

                    AccountBalance = AccountBalance + amount;

                    Console.WriteLine("Description for deposited value.");

                    string description = ReadString(true);

                    Console.WriteLine("Category of deposited value.");

                    string category = ReadString(false);

                    Console.WriteLine("Date deposited: " + DateTime.Today);

                    Console.WriteLine("Value successfully added to your account!");

                    return;
                } else
                    DisplayError("Please input a numeric value.");

            } while (true);
        }

        private static void QuitApp ()
        {
            do
            {
                Console.WriteLine("Are you sure? (Y/N)");

                string option = Console.ReadLine();

                if (String.Compare(option, "Y", true) == 0)
                    Environment.Exit(0);
                else if (String.Compare(option, "N", true) == 0)
                    return;
                else if (option != "Y" && option != "N" && option != "y" && option != "n")
                    DisplayError("Invalid Option");
            } while (true);
        }

        private static void AccountInformation ()
        {
            Console.WriteLine("");

            Console.WriteLine("Name\t\tAccount Number\t\tBalance");

            Console.WriteLine("".PadLeft(60, '-'));

            var message = $"{AccountName}\t\t{AccountNumber}\t\t\t{AccountBalance}";

            Console.WriteLine(message);
        }

        static char DisplayMenu ()
        {
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Main Menu");
                Console.WriteLine("".PadLeft(40, '-'));

                Console.WriteLine("A)ccount Information");
                Console.WriteLine("D)eposit");
                Console.WriteLine("W)ithdraw");
                Console.WriteLine("Q)uit");


                string value = Console.ReadLine();

                if (String.Compare(value, "Q", true) == 0)
                    return 'Q';
                else if (String.Compare(value, "A", true) == 0)
                    return 'A';
                else if (String.Compare(value, "D", true) == 0)
                    return 'D';
                else if (String.Compare(value, "W", true) == 0)
                    return 'W';
                else
                    DisplayError("Invalid option");
            } while (true);
        }

        static decimal ReadInt32 ()
        {
            return ReadInt32(Int32.MinValue);
        }

        static decimal ReadInt32 ( decimal minimumValue )
        {
            do
            {
                string value = Console.ReadLine();

                if (Decimal.TryParse(value, out decimal result) && result > minimumValue)
                    return result;

                if (minimumValue != Int32.MinValue)
                    DisplayError("Value is required and must be greater than " + minimumValue);
                else
                    DisplayError("Must be integral value");
            } while (true);
        }

        static string ReadString ( bool required )
        {
            do
            {
                string value = Console.ReadLine();

                if (!required || value != "")
                    return value;

                DisplayError("Value is required");
            } while (true);
        }

        private static void DisplayError ( string message )
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(message);

            Console.ResetColor();
        }
    }
}
