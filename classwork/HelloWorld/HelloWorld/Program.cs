/* 
 *Oscar Peinado-Rojo
 *ITSE 1430
 *Lab 1
 */
using System;

namespace HelloWorld
{
    //Pascal casing - capitalize based on word boundaries including first word
    //Camel casing - same as Pascal but first word lower case
    class Program
    {
        //Function declaration - declaration to compiler that a function exists with a given signature
        //Function signature - function name and the parameter type (sometime includes return type)
        //Function definition - declaration plus implementation
        static void Main(string[] args)
        {
            //Display given string to output
            //Arguments - data passed to function 
            Console.WriteLine("Hello World!");

            //Variable declaration:
            //T id; Type Identifiers
            // int hours;

            //hours = 10; //Assignment operator id = E

            // Identifier Rules
            //1. Unique with scope
            //2. Must start with underscore or variable
            //3. Consist of letters, digits and underscores
            //Always camel case local variables, noun
            //Preferred: T id = E
            int hours = 10;

            //int pay;
            //pay = hours * 9;
            int totalPay = hours * 9;

            //Function overloading - multiple functions with same name but different parameters
            Console.WriteLine(totalPay);
        }
    }
}
