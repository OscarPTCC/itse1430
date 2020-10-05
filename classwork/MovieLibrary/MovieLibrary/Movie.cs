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
        public int ReleaseYear = 1900;
        
        //Functionality - functions you want to expose

        /// <summary>Validates the movie instance.</summary>
        /// <returns>The error message, if any.</returns>
        public string Validate ( /*Movie this*/ )
        {
            //this is reference to current instance
            //rarely needed
            //var name = this.Name;

            //Only 2 cases where "this" is needed
            // 1. Scoping issues => fix the issue
            // fields are _id
            // locals are id
            // ex:
            //  var Name = "";
            //  Name = Name; //Wrong
            //this.Name = Name; //Correct
            //2. passing the entire object to another method (only really valid case)

            //Name is required
            if (String.IsNullOrEmpty(Name))
                return "Name is required";

            //Run Length must be >= 0
            if (RunLength < 0)
                return "Run Length must be greater than or equal to 0";

            //Release Year must be >= 1900
            if (ReleaseYear < 1900)
                return "Release Year must be at least 1900";

            return null;
        }
    }

    //Accessibility - the visibility of an identifier to other code, compile time only, determines who can see what at compilation
    // public - everyone
    // private - only the owning type
}
