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
        //Not on interface
        //public void foo () { }

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
            var existing = GetByName(movie.Name);
            if (existing != null)
            {
                error = "Movie must be unique";
                return null;
            };

            error = null;
            return AddCore(movie);
        }

        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The added movie.</returns>
        protected abstract Movie AddCore ( Movie movie );

        protected abstract void DeleteCore ( int id );

        protected abstract IEnumerable<Movie> GetAllCore ();

        protected abstract Movie GetByIdCore ( int id );

        protected abstract void UpdateCore ( int id, Movie movie );

        protected virtual Movie GetByName ( string name )
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
            //TODO: Validate Id >= 0
            DeleteCore(id);

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
            return GetAllCore();
        }

        public Movie Get ( int id )
        {
            //TODO: id >= 0

            return GetByIdCore(id);
        }

        public string Update ( int id, Movie movie )
        {
            //TODO: movie is not null
            //TODO: id >= 0

            //Movie is valid
            var results = new ObjectValidator().TryValidateFullObject(movie);
            if (results.Count() > 0)
            {
                foreach (var result in results)
                {
                    return result.ErrorMessage;
                };
            };

            // Movie name is unique
            var existing = GetByName(movie.Name);
            if (existing != null && existing.Id != id)
                return "Movie must be unique";

            UpdateCore(id, movie);
            
            return "";
        }
    }
}
