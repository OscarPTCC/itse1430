using System; //DO NOT DELETE
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MovieLibrary.Memory;

namespace MovieLibrary.WinformsHost
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();

            //Type = Movie
            //Variable = movie
            //Value = Instance (or an object)
            //Movie movie;
            //movie = new Movie();

            //var movie2 = new Movie();

            //member access operator ::= E . M
            //movie.Name = "Jaws";
            //var str = movie.Description;

            //hooks up an event handler to an event
            // Event += method
            //Event -= method
            _miMovieAdd.Click += OnMovieAdd;
            _miMovieEdit.Click += OnMovieEdit;
            _miMovieDelete.Click += OnMovieDelete;
            _miHelpAbout.Click += OnHelpAbout;
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            int count = RefreshUI();
            if (count == 0)
            {
                if (MessageBox.Show(this, "No movies found. DO you want to add some example movies?", "Database Empty", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var seed = new SeedMovieDatabase();
                    seed.Seed(_movies);

                    RefreshUI();
                };
            };
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }

        //Event - a notification to interested parties that something has something has happened

        //Array - T[] Array of movies
        //  Instance ::= new T[Ei]
        //  Index : 0 to size -1
        private IMovieDatabase _movies = new IO.FileMovieDatabase("movies.csv"); //0..99
        //private Movie[] _emptyMovies = new Movie[0]; //empty array and nulls equivalent, so always use empty array instead of null

        private void AddMovie ( Movie movie )
        {
            _movies.Add(movie);
            RefreshUI();
            return;
            //var newMovie = _movies.Add(movie, out var message);
            //if (newMovie == null)
            //{
            //    MessageBox.Show(this, message, "Add Failed", MessageBoxButtons.OK);
            //    return;
            //};
            //Find first empty spot in array
            //  for ( EI; EC; EU )
            //      EI - initializer expression (runs once before loop executes)
            //      EC - conditional expression => boolean (executes before loop statement is run, aboorts if condition is false)
            //      EU - update expression (runs at end of current iteration)
            //  Length -> int (# of rows in the array)
            //for (var index = 0; index < _movies.Length; ++index)
            //{
            //Array element access - V[int]
            //    if (_movies[index] == null)
            //    {
            //  Add movie to array
            //        _movies[index] = movie; //Movie is a ref type thus movie _movies[index] reference the same instance
            //    };
            //};

            //MessageBox.Show(this, "No more room for movies", "Add Movie", MessageBoxButtons.Ok);
        }

        private void DeleteMovie ( int id )
        {
            _movies.Delete(id);
            RefreshUI();
            //for (var index = 0; index < _movies.Length; ++index)
            //{
            //    //Array element access - V[int]
            //    //if (_movies[index] != null && _movies[index].Id == id)
            //    if (_movies[index]?.Id == id) // null conditional ?. if instance != null access the member
            //    {
            //        _movies[index] = null;
            //        return;
            //    };
            //};
        }

        private void EditMovie ( int id, Movie movie )
        {
            _movies.Update(id, movie);
            RefreshUI();
            //var error = _movies.Update(id, movie);
            //if (String.IsNullOrEmpty(error))
            //{
            //    RefreshUI();
            //    return;
            //}
            //for (var index = 0; index < _movies.Length; ++index)
            //{
            //    if (_movies[index]?.Id == id) 
            //    {
            //        //Just because we are doing this in memory
            //        movie.Id = id;
            //        _movies[index] = movie;
            //        return;
            //    };
            //};

            //MessageBox.Show(this, error, "Edit Movie", MessageBoxButtons.OK);
        }

        private int RefreshUI ()
        {
            var items = _movies.GetAll().ToArray();

            _lstMovies.DataSource = items;
            //_lstMovies.DisplayMember = nameof(Movie.Name); //"Name"

            //_lstMovies.DataSource = null;
            //_lstMovies.DataSource = _movies.GetAll();

            return items.Length;
        }

        private Movie GetSelectedMovie ()
        {
            return _lstMovies.SelectedItem as Movie;
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var form = new MovieForm();

            do
            {
                // ShowDialog - modal ::= user must interact with child form, cannot access parent
                // Show - modeless ::= multiple windows open and accessible at the same time
                var result = form.ShowDialog(this); // Blocks until form is dismissed
                if (result == DialogResult.Cancel)
                    return;

                //Handle errors
                //  try-catch ::= try-block catch-block
                //                try S     catch S  
                // catch statement ::= catch conditional- block* [catch-block)
                // catch-conditional- block ::= catch (T id) S

                //Save movie
                try
                {
                    AddMovie(form.Movie);
                    //AddMovie(null);
                    return;
                } catch (InvalidOperationException ex)
                {
                    MessageBox.Show(this, ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (ArgumentException ex)
                {
                    MessageBox.Show(this, ex.Message, "Bad Argmument", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (Exception ex) //Equivalent to catch
                {
                    //handle errors
                    MessageBox.Show(this, ex.Message, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                };
            } while (true);
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            //DialogResult
            switch (MessageBox.Show(this, $"Are you sure you want to delete '{movie.Name}'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes: break;
                case DialogResult.No: return;
            };

            try
            {
                DeleteMovie(movie.Id);
            } catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;
            //Object creation
            // 1. Allocate memory
            // 2. Initialize fields
            // 3. Constructor (finish initialization)
            // 4. Return new instnace
            var form = new MovieForm(movie, "Edit Movie");
            //form.Movie = _movie;

            var result = form.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;
            try
            {
                EditMovie(movie.Id, form.Movie);
            } catch (InvalidOperationException ex)
            {
                MessageBox.Show(this, ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Bad Argmument", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Edit Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Rethrow exception
                throw;
            };
        }
    }
}

//namespace OtherNamespace
//{
//  public class Mainform
//  {
//  }
//}
