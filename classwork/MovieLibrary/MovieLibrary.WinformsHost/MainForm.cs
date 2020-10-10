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
            toolStripMenuItem5.Click += OnMovieAdd;
            toolStripMenuItem6.Click += OnMovieEdit;
            toolStripMenuItem7.Click += OnMovieDelete;
        }

        //Event - a notification to interested parties that something has something has happened
        private Movie _movie;

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var form = new MovieForm();

            // ShowDialog - modal ::= user must interact with child form, cannot access parent
            // Show - modeless ::= multiple windows open and accessible at the same time
            var result = form.ShowDialog(this); // Blocks until form is dismissed
            if (result == DialogResult.Cancel)
                return;

            //After form is gone
            //TODO: Save movie
            _movie = form.Movie;

            MessageBox.Show("Save successful");
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            //TODO: Verify movie exists
            if (_movie == null)
                return;

            //DialogResult
            switch (MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            { 
                case DialogResult.Yes : break;
                case DialogResult.No : return;
            };

            //TODO: Delete movie
            _movie = null;
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            if (_movie == null)
                return;

            //Object creation
            // 1. Allocate memory
            // 2. Initialize fields
            // 3. Constructor (finish initialization)
            // 4. Return new instnace
            var form = new MovieForm(_movie, "Edit Movie");
            form.Movie = _movie;

            var result = form.ShowDialog(this); 
            if (result == DialogResult.Cancel)
                return;

            //TODO: Update movie
            _movie = form.Movie;

            MessageBox.Show("Save successful");
        }
    }
}

//namespace OtherNamespace
//{
//  public class Mainform
//  {
//  }
//}
