using System;

namespace MovieLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            //FunWithTypes();
            //FunWithVariables();

            string title = "";
            string description = "";
            string rating = "";
            int duration;
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
        static void FunWithTypes()
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
