using System;

namespace MovieLibrary
{
    class Program
    {
        static void Main ( string[] args )
        {
            //FunWithTypes();
            //FunWithVariables();

            //while => while (E) S;
            //0+ iterations, pre-test condition
            while (true)
            {
                //Scope - lifetime of a variable: starts at decalaration and continues until end of current scope
                char choice = DisplayMenu();
                if (choice == 'Q')
                    return;
                else if (choice == 'A')
                    AddMovie();
            };
            string title = "";
            string description = "";
            string rating = "";
            int duration;
        }

        static void AddMovie ()
        {
            //Get title
            Console.WriteLine("Movie title: ");
            //string title = Console.ReadLine();
            string title = ReadString(true);

            //Get description
            Console.WriteLine("Description: ");
            //string description = Console.ReadLine();
            string description = ReadString(false);

            //Get rating
            Console.WriteLine("Rating: ");
            //string rating = Console.ReadLine();
            string rating = ReadString(false);

            //Get duration
            Console.WriteLine("Duration: ");
            //string duration = Console.ReadLine();
            int duration = ReadInt32(0);

            //Get is classic
            Console.WriteLine("Is Classic(Y/N)? ");
            string isClassic = Console.ReadLine();
        }

        private static char DisplayMenu ()
        {
            //1+ iteration, post test
            //do S while (E);
            //block statment => { S* }
            do
            {
                Console.WriteLine("Movie Library");
                Console.WriteLine("-----------------");

                Console.WriteLine("A)dd Movie");
                Console.WriteLine("Q)uit");

                //Get input from user
                string value = Console.ReadLine();

                //C++: if (x = 10) ; //Not valid in C#
                // if (E) S;
                //if (E) S else S;
                if (value == "Q") //2 equal signs => equality
                    return 'Q';
                else if (value == "A")
                    return 'A';

                DisplayError("Invlaid option");
            } while (true);
        }

        private static void DisplayError ( string message )
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(message);

            Console.ResetColor();
        }

        //Logical operators
        // NOT -> !E : boolean
        // AND -> E && E : boolean
        // OR E || E : boolean

        //Relational operators (primitives + a few extra)
        // equality  -> E == E
        // inequality -> E != E
        // greater than -> E > E
        // greater than or equal to : E => E

        static int ReadInt32 ()
        {
            return ReadInt32(Int32.MinValue);
        }

        static int ReadInt32 ( int minimumValue )
        {
            do
            {
                string value = Console.ReadLine();

                //Parse to int int Int32.Parse ( string ) - not safe
                //int result = Int32.Parse(value);
                //int result = Int32.Parse(value);

                //Parameter kinds
                // Input parameter ("pass by value") - a copy of the argument is placed into parameter inside function definition
                // Input/Output parameter -("pass by reference") - a reference to the argument is passed to the function and 
                // both original argument and parameter reference same value ( C++: int& )
                // and both original argument and parameter reference same value ( C++: int& )
                //   Output paramter - function caller does not provide input, function always provides output (C++: return type)
                //bool Int32.TryParse ( string, out int result )
                // Double.Parse/TryParse
                // Single.Parse/TryParse
                // Boolean.Parse/TryParse 
                // Int16.Parse/TryParse
                int result;
                if (Int32.TryParse(value, out result) && result >= minimumValue)
                    return result;

                if (minimumValue != Int32.MinValue) //Int32.MaxValue
                    DisplayError("Value must be at least " + minimumValue); //String concatenation
                else
                    DisplayError("Must be integral value");
            } while (true);
        }
        static string ReadString ( bool required )
        {
            do
            {
                string value = Console.ReadLine();

                //If not required or not empty return
                if (!required || value != "")
                    return value;

                DisplayError("Value is required");
            } while (true);
        }
        private static void FunWithVariables ()
        {
            //Declares hours of type int with initial value 10 (initializer expression)
            int hours = 10;
            int value = 0;
            int calculatedValue = value * 10;

            //Identifiers rule
            //  Must start with underscore, digits or a letter
            //  Must consist of letters, digits or underscore
            // Must be unique within scope

            //Variable names
            //  camelCased - local variables and parameters
            //  nouns
            //  descriptive and no abbreviations or acronyms

            //Block declarations
            // A: Easy to find
            // A: Easy to see what is being used
            // D: Cannot see usage
            // D: Hard to tell what is actually still used
            //int x, y, z;

            //When needed
            //int x = 10;
            //int y = 20;
            //int z = x * y;
        }

        //Function declaration - declaration + implementation
        // [modifiers] T id (parameters) { s }
        //Function Signatures -[return type] name, parameter types 
        static void FunWithTypes ()
        {
            //Variable - named memory location where you can read and write value; name, type , value
            //
            //Literal - value that can be read, fixed at compilation; type and value

            //Body

            //Primitive - type known by the language

            //Integral - whole numbers
            // Signed
            //  sbyte - 1 byte, -128 to 127
            //  short - 2 bytes, +-32K
            //  int - 4 bytes, +-2 billion [Default]
            //  long - 8 bytes, really big
            // Unsigned
            //  byte - 1 byte, 0 to 255
            //  ushort - 2 bytes, 0 to 64K
            //  uint - 4 bytes, 0 to 4 billion
            //  ulong - 8 bytes, 0 to really big

            //Floating point types - real numbers
            //  float - 4 bytes, +-E38, 7 to 9 precision (digits)
            //  double - 8 bytes, +-308, 15 to 19 precision [Default]
            //  decimal - 16 bytes, precision => currency
            // Literals
            //  123.45F; => Float
            //  123.45M => decimal

            //bool - 1 byte, true or false
            bool isPassing = true;

            //Textual
            //  char - 2 bytes, '\0' to '\uFFFF'
            //  string - 0+ bytes
            //  'X' => char
        }
    }
}
