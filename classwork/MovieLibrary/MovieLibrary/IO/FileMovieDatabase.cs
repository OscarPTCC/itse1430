﻿/*
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
            movie.Id = ++lastId;
            items.Add(movie);

            SaveMovies(items);
            return movie;
        }

        protected override Movie GetByName ( string name )
        {
            var movies = GetAllCore();
            foreach (var movie in movies)
            {
                //Static method
                if (String.Compare(movie.Name, name, true) == 0)
                    return movie;
            };

            return null;
        }

        protected override void DeleteCore ( int id )
        {
            //Streaming approach
            //Stream stream = File.OpenRead(_filename);
            //StreamWriter writer = null;
            var tempFilename = _filename + ".bak";

            //Using statment not declaration
            // using (E) S
            // E => IDisposable
            // IDisposable is the interface that identifies a type as needing explicit cleanup
            // void Dispose()

            using (Stream stream = File.OpenRead(_filename))
            using (var reader = new StreamReader(stream))
            {
                //stream.Dispose();

                //Open temp file for writing - overwrite any existing file
                using (var writer = new StreamWriter(tempFilename, false))
                {
                    //Keep reading until end of stream
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        var movie = LoadMovie(line);

                        //If not the movie, write out line to temp file
                        if (movie?.Id != id)
                            writer.WriteLine(line);
                    };
                };
            };//stream.Close();
              ////} finally
              ////{
              ////    writer?.Close();

            ////    //Guaranteed to be called whether code completes or not
            ////    stream.Close();
            ////};

            //Stream original file to temp file, excluding deleted movie
            //    try
            //{
            //    //Open original file for reading
            //    StreamReader reader = new StreamReader(stream);

            //    //Open temp file for writing
            //    writer = new StreamWriter(tempFilename, false);

            //    //Keep reading until end of stream
            //    while (!reader.EndOfStream)
            //    {
            //        var line = reader.ReadLine();

            //        var movie = LoadMovie(line);

            //        //If not the movie, write out line to temp file
            //        if (movie?.Id != id)
            //            writer.WriteLine(line);
            //    };
            //} finally
            //{
            //    writer?.Close();

            //    //Guaranteed to be called whether code completes or not
            //    stream.Close();
            //};

            //Swap temp file with original file
            File.Copy(tempFilename, _filename, true);
            File.Delete(tempFilename);

            //Buffered Apporach
            //var movies = new List<Movie>(GetAllCore());
            //foreach (var movie in movies)
            //{
            //    if (movie.Id == id)
            //    {
            //        movies.Remove(movie);
            //        break;
            //    };
            //};

            //SaveMovies(movies);
        }


        protected override IEnumerable<Movie> GetAllCore ()
        {
            if (File.Exists(_filename))
            {
                // Read file buffered as an array
                string[] lines = File.ReadAllLines(_filename);
                //string rawText = File.ReadAllText(_filename)

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

        private string EncloseQuotes ( string value )
        {
            return "\"" + value + "\"";
        }

        private string SaveMovie ( Movie movie )
        {
            //NOTE: No commas in string calues
            //Id, "Name", "Description", "Rating", RunLength, ReleaseYear, IsClassic
            var builder = new System.Text.StringBuilder();

            builder.AppendFormat($"{movie.Id},");
            builder.AppendFormat($"{EncloseQuotes(movie.Name)},");
            builder.AppendFormat($"{EncloseQuotes(movie.Description)},");
            builder.AppendFormat($"{EncloseQuotes(movie.Rating)},");
            builder.AppendFormat($"{movie.RunLength},");
            builder.AppendFormat($"{movie.ReleaseYear},");
            builder.AppendFormat($"{(movie.IsClassic ? 1 : 0)}");

            return builder.ToString();
        }

        private void SaveMovies ( IEnumerable<Movie> movies )
        {
            //Buffered writing
            var lines = new List<string>();
            foreach (var movie in movies)
                lines.Add(SaveMovie(movie));

            File.WriteAllLines(_filename, lines);
        }

        private string RemoveQuotes ( string value )
        {
            return value.Trim('"');
        }

        //public void Get()
        protected override Movie GetByIdCore ( int id )
        {
            return FindById(id);
        }

        private Movie FindById ( int id )
        {
            //Streaming approach
            Stream stream = File.OpenRead(_filename);
            try
            {

                //OpenWrite(filename) //Opens a file for writing
                //OpenText(filename) //Opens a text file for reading

                //Stream = series of data (binary = byte, text = character)
                // May be read, write, or seek (CanRead, CanWrite, CanSeek)
                //stream.Read() Low Level

                //Use reader/writer for working with streams, provides a cleaner API
                StreamReader reader = new StreamReader(stream); //Reads text stream
                                                                //BinaryReader reader; //For binary files

                //Keep reading until end of stream or find movie
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var movie = LoadMovie(line);
                    if (movie?.Id == id)
                        return movie;
                };

                //Not exception safe
                //stream.close();

                return null;
            } //catch blocks here 
            finally
            {
                //Exception safe
                //Guaranteed to be called whether code completes or not
                stream.Close();
            };

            //Buffered Approach
            //var movies = GetAllCore();

            //foreach (var movie in movies)
            //{
            //    if (movie?.Id == id)
            //        return movie;
            //};

            //return null;
        }

        protected override void UpdateCore ( int id, Movie movie )
        {
            //Remove old movie
            var items = new List<Movie>(GetAllCore());
            foreach (var item in items)
            {
                //use items not movie
                if (item.Id == id)
                {
                    //Must use item not movie
                    items.Remove(item);
                    break;
                };
            };

            //Add new movie
            movie.Id = id;
            items.Add(movie);

            SaveMovies(items);
        }
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
