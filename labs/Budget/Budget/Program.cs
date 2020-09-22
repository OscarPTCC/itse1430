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

            accountNumber = isDigitOnly(true);

            Console.WriteLine("Please input starting balance: ");

            accountBalance = ReadInt32(0);


        }

        static string isDigitOnly ( bool required )
        {
            do
            {
                string value = Console.ReadLine();

              // if (int)
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
