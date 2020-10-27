using System;
using System.Collections.Generic;

namespace MovieLibrary
{
    //Interface
    //  interface declaration ::= [access] interface identifier { interface-member* }
    //  interface-member ::= property | method | event
    //      1. No access modifiers (always public)
    //      2. No implementation of anything
    //  Cannot instantiate an interface

    //Common Interfaces
    //  IEnumerable<T>, IEnumerator<T>
    //  IList<T>, IReadOnlyList<T>
    //  ICompare<T> - relational comparison, StringCompare
    //  ICloneable - clone objects, but doesn't actually work
    //  IValidatableObject - validates objects
    public interface IMovieDatabase
    {
        Movie Add ( Movie movie, out string error );
        void Delete ( int id );
        Movie Get ( int id );
        IEnumerable<Movie> GetAll ();
        string Update ( int id, Movie movie );
    }
}