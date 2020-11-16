/*
 * ITSE 1430
 * Classwork
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MovieLibrary.IO
{
    /// <summary>Provides an implementation of <see cref="IMovieDatabase"/> using a file.</summary>
    public class FileMovieDatabase : MovieDatabase
    {
        public FileMovieDatabase ( string filename )
        {
            _filename = filename;
        }

        private readonly string _filename;

        /// <inheritdoc/>
        protected override Movie AddCore ( Movie movie )
        {
            //Find highest ID
            var movies = GetAllCore();
            //HACK: TO list
            var items = new List<Movie>(movies);
            var lastId = 0;

            foreach (var item in items)
            {
                if (item.Id > lastId)
                    lastId = item.Id;
            };

            //Set unique ID
            movie.Id = lastId++;
            items.Add(movie);

            SaveMovies(movies);
            return movie;
        }

        protected override Movie GetByName ( string name )
        {
            var movies = GetAllCore();
            foreach (var movie in movies)
            {
                if (String.Compare(movie.Name, name, true) == 0)
                    return movie;
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
            if (File.Exists(_filename))
            {
                // Read file buffered as an array
                var lines = File.ReadAllLines(_filename);

                foreach (var line in lines)
                {
                    var movie = LoadMovie(line);
                    if (movie != null)
                        yield return movie;
                };

               
            };
        }

        private Movie LoadMovie ( string line )
        {
            //NOTE: No commas in string calues
            //Id, "Name", "Description", "Rating", RunLength, ReleaseYear, IsClassic

            string[] tokens = line.Split(',');
            if (tokens.Length != 7)
                return null;

            var movie = new Movie() {
                Id = Int32.Parse(tokens[0]),
                Name = RemoveQuotes(tokens[1]),
                Description = RemoveQuotes(tokens[2]),
                Rating = RemoveQuotes(tokens[3]),
                RunLength = Int32.Parse(tokens[4]),
                ReleaseYear = Int32.Parse(tokens[5]),
                IsClassic = Int32.Parse(tokens[6]) != 0
            };

            return movie;
        }

        private string RemoveQuotes ( string value )
        {
            return value.Trim('"');
        }

        //public void Get()
        protected override Movie GetByIdCore ( int id )
        {
            var movie = FindById(id);

            return (movie != null) ? CloneMovie(movie) : null;
        }

        private Movie FindById ( int id )
        {
            //TODO: Make efficient
            var movies = GetAllCore();

            foreach (var movie in movies)
            {
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

        //File class - used to manage files
        // Copy
        // Move
        // Exists
        // Open for reading and writing
    }
}
