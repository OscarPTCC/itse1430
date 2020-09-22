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
        static void Main ( string[] args )
        {
            Console.WriteLine("Budget program developed by Oscar Peinado. ");

            Console.WriteLine("Please input account nickname: ");

            accountName = ReadString(true);

            Console.WriteLine("Please input account number: ");

            accountNumber = ReadString(true);

            Console.WriteLine("Please input starting balance: ");

            accountBalance = ReadInt32(0);

            DisplayMenu();
        }

        static void QuitApp ()
        {
            
            do
            {
                Console.WriteLine("Are you sure? (Y/N)");

                string option = Console.ReadLine();

                if (String.Compare(option, "Y", true) == 0)
                    return;
                else if (String.Compare(option, "Y", true) == 0)
                    DisplayMenu();
                else
                    DisplayError("Invalid Option");
            } while (true);
        }

        private static void AccountInformation ()
        {
            Console.WriteLine("");

            Console.WriteLine("Name\t\tAccount Number\t\tBalance");

            Console.WriteLine("".PadLeft(60, '-'));

            var message = $"{accountName}\t\t{accountNumber}\t\t\t{accountBalance}";

            Console.WriteLine(message);

            DisplayMenu();
        }

        static char DisplayMenu ()
        {
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Main Menu");
                Console.WriteLine("".PadLeft(40, '-'));

                Console.WriteLine("A)ccount Information");
                Console.WriteLine("Q)uit");

                string value = Console.ReadLine();

                if (String.Compare(value, "Q", true) == 0)
                    QuitApp();
                else if (String.Compare(value, "A", true) == 0)
                    AccountInformation();

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
                    DisplayError("Value must be greater than " + minimumValue);
                else
                    DisplayError("Must be integral value");
            } while (true);
        }

        static string accountName = "";
        static string accountNumber = "";
        static decimal accountBalance = 0;

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
