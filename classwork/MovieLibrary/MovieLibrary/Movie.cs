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
        // should always be private
        // Named using camel casing and start with underscore
        //Named as nouns, no abbreviation and no generic names

        //Only time public fields allowed - read only data
        // [access] const T identifier = E;
        //  1. Must be a primitive type
        //  2. Must have an initializer expression
        //  3. Must recompile all code if value changed
        //  Type name, not instance ex: var nameLength = Movie.MaximumNameLength;
        //public const int MaximumNameLength = 50;

        //Read-only
        // [access] readonly T identifier;
        //  1. Any type
        //  2. Must be initialized once either in initializer expression or at instance creation
        //  3. Allowed to have different "readonly" values for each instance
        //  4. Is not baked into source code
        //public readonly int MaximumDescriptionLength = 200;

        private string _name = "";
        private string _description = "";
        private string _rating = "";
        //private int _runLength; // = 0;
        //private bool _isClassic; // = false;
        //private int _releaseYear = 1900;

        //Not a field, because:
        // 1. Can not write 
        // 2. Calculated
        //public int Age;

        //Not a method either, because:
        // 1. Not functionality
        // 2. Complex syntax compared to fields 
        // 3. Get/Set is in name
        //public int GetAge () { }

        public int Age
        {
            //Read only property
            //Calculated property
            get { return DateTime.Now.Year - ReleaseYear; }
            //set { }
        }

        //Mixed accessibility - using a different access either on getter or setter
        //public int Id { get; private set; } // Public read, private write
        // 1. only 1 method can have access modifier
        // 2. Always more restrictive
        //Properties - Methods that have field-like syntax
        // [access] T identifier { getter setter }
        // getter ::= get { S* }
        // setter ::= set { S* }
        // auto-property ::= [access] T identifier (get; set;)
        // Properties returning arrays or strings should not return null

        public string Name
        {
            //getter - T get_Name ()
            get 
            {
                //Coalesce - scanning a series of expressions looking for non-NULL
                //  E ?? E
                //      if E1 is not null then return E1
                //      else return E2

                //if (_name == null)
                //  return "";

                // return_name;
       
                return _name ?? "";
            }

            //setter void set_Name ( T value )
            set 
            {
                _name = value;
            }
        }

        /// <summary>Gets or sets the movie description.</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }

        public string Rating
        {
            get { return _rating ?? ""; }
            set { _rating = value; }
        }

        /// <summary>Gets or sets the run length in minutes.</summary>
        public int RunLength { get; set; }
        //{
        //get {return _runLength; }
        //set {_runLength = value; }
        //}

        /// <summary>Gets or sets the release year.</summary>
        /// <value>Default value is 1900.</value>
        public int ReleaseYear { get; set; } = 1900;
       //{
       //  get { return _releaseYear; }
       //  set { _releaseYear = value; }
       //}
       //private int _releaseYear = 1900;

        public bool IsClassic { get; set; }

        public int Id { get; set; }

        //{
        //    get { return _isClassic; }
        //   set { _isClassic = value; }
        //}
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

        public override string ToString ()
        {
            return Name;
        }
    }

    //Accessibility - the visibility of an identifier to other code, compile time only, determines who can see what at compilation
    // public - everyone
    // private - only the owning type
}
