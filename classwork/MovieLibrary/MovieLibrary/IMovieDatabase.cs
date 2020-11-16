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
    /// <summary>Provides an interaface for storing and retrieving movies.</summary>
    public interface IMovieDatabase
    {
        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The new movie.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="movie"/> is null.</exception>
        /// <exception cref="ValidationException"><paramref name="movie"/> is not valid.</exception>
        /// <exception cref="InvalidOperationException">A movie with the same name already exists.</exception>
        Movie Add ( Movie movie );

        /// <summary>Deletes a movie from the database.</summary>
        /// <param name="id">The movie to be deleted.</param>
        void Delete ( int id );

        /// <summary>Gets a movie from the database.</summary>
        /// <param name="id"></param>
        Movie Get ( int id );

        /// <summary>Gets all of the movies</summary>
        /// <returns>The movies</returns>
        IEnumerable<Movie> GetAll ();

        /// <summary>Updates an existing movie in the database.</summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        void Update ( int id, Movie movie );
    }
}