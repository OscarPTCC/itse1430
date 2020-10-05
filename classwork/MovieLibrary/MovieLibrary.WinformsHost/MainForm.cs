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

            toolStripMenuItem5.Click += OnMovieAdd;
            toolStripMenuItem7.Click += OnMovieDelete;
        }

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
            MessageBox.Show("Save successful");
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            //TODO: Verify movie exists

            //DialogResult
            switch (MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            { 
                case DialogResult.Yes : break;
                case DialogResult.No : return;
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
