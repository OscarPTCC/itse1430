using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
    public static class SeedMovieDatabase
    {
        //Make static because it does not reference any instance data
        public static void Seed ( IMovieDatabase database )
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

            //TODO: Fix error handling
            foreach (var item in items)
                database.Add(item);
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
    }
}
