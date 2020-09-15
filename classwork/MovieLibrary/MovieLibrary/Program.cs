using System;
using System.Text;

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
                //char choice = DisplayMenu();
                //if (choice == 'Q')
                //    return;
                //else if (choice == 'A')
                //    AddMovie();
                switch (DisplayMenu())
                {
                    case 'Q': return;

                    case 'A': AddMovie(); break;

                    case 'V': ViewMovie(); break;
                };
            };
        }

        static string title = "";
        static string description = "";
        static string rating = "";
        static int duration;
        static bool isClassic;

        static void AddMovie ()
        {
            //Get title
            Console.WriteLine("Movie title: ");
            //string title = Console.ReadLine();
            //var title = ReadString(true); same as below
            //Only works with local variables and must be initialized
            // 3. (Sort of) Cannot figure out type or it is wrong
            //string title = ReadString(true);
            //int title2 = "";
            title = ReadString(true);

            //Get description
            Console.WriteLine("Description: ");
            //string description = Console.ReadLine();
            description = ReadString(false);

            //Get rating
            Console.WriteLine("Rating: ");
            //string rating = Console.ReadLine();
            rating = ReadString(false);

            //Get duration
            Console.WriteLine("Duration: ");
            //string duration = Console.ReadLine();
            duration = ReadInt32(0);

            //Get is classic
            Console.WriteLine("Is Classic(Y/N)? ");
            //string isClassic = Console.ReadLine();
            isClassic = ReadBoolean();
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
                Console.WriteLine("V)iew Movie");
                Console.WriteLine("Q)uit");

                //Get input from user
                string value = Console.ReadLine();

                //C++: if (x = 10) ; //Not valid in C#
                // if (E) S;
                //if (E) S else S;
                if (String.Compare(value, "Q", true) == 0) //2 equal signs => equality
                    return 'Q';
                else if (String.Compare(value, "A", StringComparison.CurrentCultureIgnoreCase) == 0)
                    return 'A';
                else if (String.Compare(value, "V", true) == 0)
                    return 'V';

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

        static bool ReadBoolean ()
        {
            do
            {
                // Read as string
                string value = Console.ReadLine();

                //Not useful because of how it is parse
                //Boolean.TryParse(value, out bool result)

                //switch - replace for if-else-if WHEN
                //each condition is against same variable
                // switch (E)
                // {
                //  case*
                //  [default]
                // }
                //case    ::= case E : S*; return/break;
                //default ::= default : S*; break;
                //C++ DIFFERENCES
                // No fallthrough
                // Any expression type is allowed
                // Case labels mudt be unique and compile time constants
                // Use block statements for more than 1 statement
                //if (value == "Y" || value == "y")
                //    return true;
                //else if (value == "N" || value == "n")
                //    return false;

                switch (value.ToLower())
                {
                    case "X": Console.WriteLine("Wrong value"); break;

                    //case "Y": //If case statement empty (including semicolon) then fallthrough
                    case "y": return true;

                    //case "N":
                    case "n": return false;

                    //case "A":
                    case "a":
                    {
                        //Use block statement for more than 1 statement
                        Console.WriteLine("Wrong value");
                        Console.WriteLine("Wrong value again");
                        break;
                    };

                    default: break;
                };

                DisplayError("Invlaid option");
            } while (true);
        }

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

                //Inline variable declaration - out parameters only
                //int result;
                if (Int32.TryParse(value, out int result) && result >= minimumValue)
                    return result;

                if (minimumValue != Int32.MinValue) //Int32.MaxValue
                    DisplayError("Value must be at least " + minimumValue); //String concatenation
                else
                    DisplayError("Must be integral value");
            } while (true);
        }

        static void ViewMovie ()
        {
            Console.WriteLine("Title\t\tRating\tDuration\tIsClassic");
            //Console.WriteLine("-----------------");
            Console.WriteLine("".PadLeft(60, '-'));

            //1. Format arguments
            // Format string - consists of string characters with arguments specified in curly braces as zero-based ordinals
            // 1. Readable but not great
            // 2. No compile time checking, runtime error
            //Console.WriteLine("{0}\t{1}\t{2}\t{3}", title, rating, duration, isClassic);

            //2. String Format
            //var message = String.Format("{0}\t{1}\t{2}\t{3}", title, rating, duration, isClassic);
            //Console.WriteLine(message);

            //3. String concateneation
            //   A: Programmatically build it
            //   A: Somewhat readable
            //   D: Harder to read as it gets longer and bad performance
            //var message = title + "\t" + rating + "\t" + duration + "\t" + isClassic;
            //var message = title + "\t" + rating + "\t" + duration.ToString + "\t" + isClassic.ToString;
            //Console.WriteLine(message);

            //4. String builder
            //   A: Efficient on memory
            //   A: Conditional formatting
            //   D: Longer
            //   D: Harder to read
            // var builder = new StringBuilder();
            //builder.Append(title);
            //builder.Append("\t");
            //builder.Append(rating);
            //builder.Append("\t");
            //builder.Append(duration);
            //builder.Append("\t");
            //builder.Append("isClassic");
            //builder.Append("\t");
            //message = builder.ToString();
            //Console.WriteLine(message);

            //5. String Joining
            //message = String.Join("\t", title, rating, duration, isClassic);

            //Conditional operator      C ? T : F
            //if (C) return T else return F

            //6. String interpolation - $
            //   A. Use expressions instead of ordinals
            //   A. More readable
            //   A. Compile time checked
            //   D. Compile time only and against literals
            var classicIndicator = isClassic ? "Yes" : "No";
            //if (isClassic)
            //    classicIndicator = "Yes";
            //else
            //    classicIndicator = "No";

            var message = $"{title}\t\t{rating}\t{duration}\t\t{classicIndicator}";
            Console.WriteLine(message);

            //Write description if available
            if (!String.IsNullOrEmpty(description))
                Console.WriteLine(description);

            Console.WriteLine();

            Console.WriteLine("");

            //TODO: Description if available
            //Console.WriteLine(" " + description);

            //TODO If available
            //Console.WriteLine(" " + rating);

            //Console.WriteLine(duration);

            //Console.WriteLine(isClassic);
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

        static void FunWithStrings ()
        {
            //5 characters in it, takes up 10 bytes
            // C++ difference: no NULL
            // Escape sequence begins with \ and is followed by generally 1 character, only works in literals
            //   \n - newline
            //   \t - tab
            //   \" - "
            //   \' - ' (char literal)
            //   \\ - \
            //   \xHH - hex equivalent \x0A
            //var name = "Bob\c"; // compiler warning - Bobc
            var message = "Hello \"Bob\"\nWorld";

            //File paths - always escape sequences
            var filepath = "C:\\Temp\\test.pdf"; //C:\Temp\test.pdf
            var filepath2 = @"C:\Temp\test.pdf"; //Verbatim string

            var emptyString = "";
            var spaceString = " ";

            var emptyString2 = String.Empty;  // ""
            var areEqual = emptyString == emptyString2;  //True

            //Checking for empty string
            // 1. comparison
            var isEmpty1 = emptyString == "";
            var isEmpty1_Part2 = emptyString == String.Empty;

            // 2. Length
            var isEmpty2 = emptyString.Length == 0;

            // 3. String.Compare => int
            //      < 0     left < right
            //      == 0    left == right
            //      > 0     left > right
            var isEmpty3 = String.Compare(emptyString, "") == 0;

            // 4. Preferred IsNullOrEmpty => boolean
            var isEmpty4 = String.IsNullOrEmpty(emptyString);

            // Can be null
            string nullString = null;
            var areEqual3 = emptyString == nullString;  //false
            //var willCrash = nullString.Length == 0;     //Will crash
            var willNotBeEqual = String.Compare(emptyString, null) == 0;

            //var isEmpty5 = nullString != null && nullString != "";  //Inefficient

            //Converting to string E.ToString()
            var asString = emptyString.ToString();
            asString = 10.ToString();  // "10"
            asString = (50 * 3).ToString(); // "150"

            //Common Functions -> E.func()

            //Comparison
            // 1. Relational operator == != ::= case sensitive
            // 2. String.Compare
            var relationalCompare = String.Compare("Hello", "hello") == 0; //Case Sensitive, culture aware
            var caseInsensitiveCompare = String.Compare("Hello", "hello", true) == 0;  //Case insensitive, culture aware

            //locale - Windows cultural settings
            var ordinalCompare = String.Compare("Hello", "hello", StringComparison.OrdinalIgnoreCase) == 0; //Case insensitive, ordinal (keys, paths)

            // trim and padding
            var areSpacesEqual = "" == " ";
            var name = "   Bob   ";

            name = name.Trim();  //Removes leading and trailing whitespace - "Bob"
                                 //TrimStart, TrimEnd         }

            //var filePath2 = filePath2.TrimEnd('\\');

            //PadLeft(#) PadRight(#) - pads to width, never truncates
            var paddedName = name.PadLeft(10);  // "       Bob"

            // String formatting
            // 1. Format argument overloads WriteLine(string, [args])
            // 2. String.Format 
            // 4. String building
            // 5. Joining strings
            // 6. String interpolation

            // Contains ( string ) => boolean
            // Index/IndexOfAny ( string ) => index
            // StartsWith / EndsWith

            var leftPath = @"C:\temp";
            var rightPath = @"\folderA\file.txt";

            var endsWithSlash = leftPath.EndsWith(@"\");
            var startsWithSlash = rightPath.StartsWith(@"\");

            var path = leftPath;
            if (endsWithSlash && !startsWithSlash)
                path += rightPath;
            else if (endsWithSlash && startsWithSlash)
                path += rightPath.Substring(1);  //"folderA\file.txt"
            else //!endsWithslash && StartsWithSlash
                path += rightPath;
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
