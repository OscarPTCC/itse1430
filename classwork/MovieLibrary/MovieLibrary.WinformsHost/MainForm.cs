using System; //DO NOT DELETE
using System.Windows.Forms;

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
            Movie movie;
            movie = new Movie();

            //var movie2 = new Movie();

            //member access operator ::= E . M
            movie.Name = "Jaws";
            //var str = movie.Description;

            //hooks up an event handler to an event
            // Event += method
            //Event -= method
            _miMovieAdd.Click += OnMovieAdd;
            _miMovieEdit.Click += OnMovieEdit;
            _miMovieDelete.Click += OnMovieDelete;
            _miHelpAbout.Click += OnHelpAbout;
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }

        //Event - a notification to interested parties that something has something has happened
        private Movie[] _movies;

        private void AddMovie ( Movie movie )
        {
            MessageBox.Show("Not implemented yet");
        }

        private void DeleteMovie ( Movie movie )
        {
            MessageBox.Show("Not implemented yet");
        }

        private void EditMovie ( Movie movie )
        {
            MessageBox.Show("Not implemented yet");
        }

        private void RefreshUI ()
        {
            _lstMovies.DisplayMember = nameof(Movie.Name); //"Name"

            _lstMovies.DataSource = null;
            _lstMovies.DataSource = _movies;
        }

        private Movie GetSelectedMovie ()
        {
            return null;
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var form = new MovieForm();

            // ShowDialog - modal ::= user must interact with child form, cannot access parent
            // Show - modeless ::= multiple windows open and accessible at the same time
            var result = form.ShowDialog(this); // Blocks until form is dismissed
            if (result == DialogResult.Cancel)
                return;

            //Save movie
            AddMovie(form.Movie);
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            //DialogResult
            switch (MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            { 
                case DialogResult.Yes : break;
                case DialogResult.No : return;
            };

            DeleteMovie(movie);
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

            EditMovie(form.Movie);
        }
    }
}

//namespace OtherNamespace
//{
//  public class Mainform
//  {
//  }
//}
