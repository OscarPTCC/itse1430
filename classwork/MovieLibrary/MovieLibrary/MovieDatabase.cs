using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieLibrary
{
    //Abstract class required if any member is abstract
    // 1. Cannot be instantiated
    // 2. Must be derived
    // 3. Must implement all abstract members
    public abstract class MovieDatabase : IMovieDatabase
    {
        //Default constructor to seed database
        protected MovieDatabase ()
        {
            //Not needed here
            //_movies.Clear();

            //Collections initializer syntax
            var items = new[] { //Movie[] {
                new Movie() {
                    Name = "Jaws",
                    ReleaseYear = 1977,
                    RunLength = 190,
                    Description = "Shark movie",
                    IsClassic = true,
                    Rating = "PG",
                },
                new Movie() {
                    Name = "Shrek",
                    ReleaseYear = 1999,
                    RunLength = 150,
                    Description = "Ogre movie",
                    IsClassic = true,
                    Rating = "PG",
                }
            };

            foreach (var item in items)
                Add(item, out var error);
            #region seed database
            //Seed database
            // Object initialize - only usable on new operator
            //  1. Can only set properties with setters
            //  2. Can set properties that are themselves new'ed up but cannot set child properties
            //      Position = new Position() (Name = "Boss" ); //Allowed
            //      Position.Title = "Boss"; //Not allowed
            //  3. Properties cannot rely on other properties
            //      Description = "blah"; Not allowed
            //      FullDescription = Description;
            //var movie = new Movie();
            //movie.Name = "Jaws";
            //movie.ReleaseYear = 1977;
            //movie.RunLength = 190;
            //movie.Description = "Shark movie";
            //movie.IsClassic = true;
            //movie.Rating = "PG";
            //Add(movie, out var error);
            //var movie = new Movie() {
            //    Name = "Jaws",
            //    ReleaseYear = 1977,
            //    RunLength = 190,
            //    Description = "Shark movie",
            //    IsClassic = true,
            //    Rating = "PG",
            //};

            //Add(movie, out var error);

            //movie = new Movie() {
            //    Name = "Shrek",
            //    ReleaseYear = 1999,
            //    RunLength = 150,
            //    Description = "Ogre movie",
            //    IsClassic = true,
            //    Rating = "PG",
            //};

            //Add(movie, out error);
            #endregion 
        }

        //Not on interface
        public void foo () { }

        public Movie Add ( Movie movie, out string error )
        {
            var results = new ObjectValidator().TryValidateFullObject(movie);
            if (results.Count() > 0)
            {
                foreach (var result in results)
                { 
                    error = result.ErrorMessage;
                    return null;
                };
            };

            //TODO: Movie is valid
            // Movie name is unique
            var existing = FindByName(movie.Name);
            if (existing != null)
            {
                error = "Movie must be unique";
                return null;
            };

            error = null;
            return AddCore(movie);
            #region Array Code
            //Find first empty spot in array
            //  for ( EI; EC; EU )
            //      EI - initializer expression (runs once before loop executes)
            //      EC - conditional expression => boolean (executes before loop statement is run, aboorts if condition is false)
            //      EU - update expression (runs at end of current iteration)
            //  Length -> int (# of rows in the array)
            //for (var index = 0; index < _movies.Count; ++index)
            //{
            //Array element access - V[int]
            //    if (_movies[index] == null)
            //    {
            //Clone so agument can be modified without impacting our array
            //        var item = CloneMovie(movie);

            //Set unique ID
            //        item.Id = _id++;

            //Add movie to array
            //        _movies[index] = movie; //Movie is a ref type thus movie _movies[index] reference the same instance

            //        Set ID on original object and return
            //        movie.Id = item.Id;
            //        return movie;
            //    };
            //};

            //error = "No more room";
            //return null;
            #endregion
        }

        protected abstract Movie AddCore ( Movie movie );

        protected virtual Movie FindByName ( string name )
        {
            foreach (var movie in GetAll())
            {
                if (String.Compare(movie.Name, name, true) == 0)
                    return movie;
            };

            return null;
        }

        public void Delete ( int id )
        {
            var movie = GetById(id);

            if (movie != null)
            {
                //Must use same instance that is stored in the list so ref equality works
                _movies.Remove(movie);

            };

            #region For Array
            //for (var index = 0; index < _movies.Count; ++index)
            //{
            //Array element access - V[int]
            //if (_movies[index] != null && _movies[index].Id == id)
            //    if (_movies[index]?.Id == id) // null conditional ?. if instance != null access the member
            //    {
            //        _movies[index] = null;
            //        return;
            //    };
            //};
            #endregion
        }

        //Use IEnumerable<T> for readonly lists of items
        //public Movie[] GetAll ()
        public IEnumerable<Movie> GetAll ()
        {
            //Don't do this
            //  1. Expose underlying movie items
            //  2. Callers add/remove movies
            //return _movies;
            //var clone = new Movie[_movies.Length];

            #region Array
            //TODO: Determine how many movies we're storing
            //For each one create a cloned copy
            //return _movies;
            #endregion

            //var items = new Movie[_movies.Count];
            //var index = 0;

            //Foreach equivalent
            // var enumerator = _movies.GetEnumerator();
            // while (enumerator.MoveNext())
            // { 
            //  var movie = enumerator.Current;
            // S* 
            // }

            //iterator
            foreach (var movie in _movies) //relies on IEnumeration<T>
                //    items[index++] = CloneMovie(movie);
                yield return CloneMovie(movie);
                ; 

            //return items;
        }

        public Movie Get ( int id )
        {
            var movie = GetById(id);

            return (movie != null) ? CloneMovie(movie) : null;
        }

        private Movie GetById ( int id )
        {
            foreach (var movie in _movies)
            {
                //movie == _movies[index]
                // Restrictions
                //   1. movie is readonly //movie = new Movie();
                //   2. _movies cannot change, immutable
                if (movie?.Id == id)
                    return movie;
            };

            return null;
        }

        public string Update ( int id, Movie movie )
        {
            //TODO: Validate ID
            //MOvie exists
            var existing = GetById(id);
            if (existing == null)
                return "Movie not found";

            //updated movie is valid
            //updated movie name is unique
            CopyMovie(existing, movie);

            //for (var index = 0; index < _movies.Count; ++index)
            //{
            //    if (_movies[index]?.Id == id)
            //    {
            //        //Clone it so we separate our value from argument
            //        var item = CloneMovie(movie);

            //        movie.Id = id;
            //        _movies[index] = movie;
            //        return "";
            //    };
            //};

            return "";
        }

        //Only store closed copies of movies here!!
        //private Movie[] _movies = new Movie[100];

       

        //Generic Types
        //  List<T> where T is any type
        //Non-Generic
        //  ArrayList - list of objects

    }
}
