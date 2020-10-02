using System; //DO NOT DELETE
using System.Windows.Forms;

namespace MovieLibrary.WinformsHost
{
    public partial class MainForm : Form
    {
        public MainForm()
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
        }

        private void OnMovieAdd( object sender, EventArgs e)
        {
            var form = new MovieForm();

            form.ShowDialog();
        }
    }
}

//namespace OtherNamespace
//{
//  public class Mainform
//  {
//  }
//}
