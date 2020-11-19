using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        protected override Movie AddCore ( Movie movie )
        {
            //Clone so agument can be modified without impacting our array
            var item = CloneMovie(movie);

            //Set unique ID
            item.Id = _id++;

            //Add movie to array
            _movies.Add(item);

            //Set ID on original object and return
            movie.Id = item.Id;
            return movie;

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

        protected override Movie GetByName ( string name )
        {
            foreach (var movie in _movies)
            {
                if (String.Compare(movie.Name, name, true) == 0)
                    return CloneMovie(movie);
            };

            return null;
        }

        protected override void DeleteCore ( int id )
        {
            var movie = FindById(id);

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
        protected override IEnumerable<Movie> GetAllCore ()
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

            //return items;
        }

        //public void Get()
        protected override Movie GetByIdCore ( int id )
        {
            var movie = FindById(id);

            return (movie != null) ? CloneMovie(movie) : null;
        }

        private Movie FindById ( int id )
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

        protected override void UpdateCore ( int id, Movie movie )
        {
            var existing = FindById(id);
            
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
        }

        private Movie CloneMovie ( Movie movie )
        {
            var item = new Movie();
            item.Id = movie.Id;

            CopyMovie(item, movie);

            return item;
        }

        private void CopyMovie ( Movie target, Movie source )
        {
            target.Id = source.Id;
            target.Name = source.Name;
            target.Rating = source.Rating;
            target.ReleaseYear = source.ReleaseYear;
            target.RunLength = source.RunLength;
            target.IsClassic = source.IsClassic;
            target.Description = source.Description;
        }

        //Only store closed copies of movies here!!
        //private Movie[] _movies = new Movie[100];

        private List<Movie> _movies = new List<Movie>();
        private int _id = 1;

        //Generic Types
        //  List<T> where T is any type
        //Non-Generic
        //  ArrayList - list of objects

    }
}
