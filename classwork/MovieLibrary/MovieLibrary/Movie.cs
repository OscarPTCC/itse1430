/*
 * ITSE 1430
 * Oscar Peinado-Rojo
 * Classwork
 */
using System;

//StringBuilder, Regular expression, Encoding
//using System.Text;

namespace MovieLibrary
{
    //Type 
    //  PascalCased
    //  Noun
    //  Singular unless they represent a collection of things
    // [access] - class identifier { }

    //doctags
    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// A paragraph of information.
    /// Another set of information
    /// </remarks>
    public class Movie
    {
        //Data - data to store
        //fields - where the data is stored, identical to variables
        //Named as nouns, no abbreviation and no generic names

        public string Name = "";
        public string Description = "";
        public string Rating = "";
        public int RunLength; // = 0;
        public bool IsClassic; // = false;

        //Functionality - functions you want to expose
    }

    //Accessibility - the visibility of an identifier to other code, compile time only, determines who can see what at compilation
    // public - everyone
    // private - only the owning type
}
