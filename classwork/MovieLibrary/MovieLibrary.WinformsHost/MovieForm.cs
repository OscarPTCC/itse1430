using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MovieLibrary.WinformsHost
{
    // class-decalaration ::= [access] [modifiers] class identifier [ : T ]
    public partial class MovieForm : Form
    {
        //Access: 
        // Public - accessible in derived type
        // Protected - accessible in owning type and derived types
        // Private - only the owning type

        //Methods : properties, methods
        // Virtual - Base type provides the base implementation but a derived type may override it
        // Abstract - Base type defines it but does not implement, derived types must override it

        // Syntax for constructors
        // ctor-decalration ::= [access] T () { S* }
        public MovieForm ()
        {
            //DO NOT CALL virtual members inside of constructors
            InitializeComponent();
        }

        public MovieForm (Movie movie) : this(movie, null)
        {
            //Movie = movie;
        }

        //Constructor chaining - calling one constructor from another
        public MovieForm (Movie movie, string title) : this()
        {
            //InitializeComponent();

            Movie = movie;
            Text = title ?? "Add Movie";
        }

        public Movie Movie { get; set; }

        //Override indicates to compiler that you are overriding a virtual method
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (Movie != null)
            {
                _txtName.Text = Movie.Name;
                _txtDescription.Text = Movie.Description;
                _comboRating.SelectedText = Movie.Rating;
                _chkClassic.Checked = Movie.IsClassic;
                _txtRunLength.Text = Movie.RunLength.ToString();
                _txtReleaseYear.Text = Movie.ReleaseYear.ToString();
            };
        }

        private void textBox3_TextChanged ( object sender, EventArgs e )
        {

        }

        private void label2_Click ( object sender, EventArgs e )
        {

        }

        //Method - functions inside a class
        private void OnCancel ( object sender, EventArgs e )
        {
            Close();
        }

        //Event handler - handles an event
        // This method handles the save button clicking event
        //   void identifier ( object sender, EvenArgs e )
        private void OnSave ( object sender, EventArgs e )
        {
            // I want the button that was clicked
            //Type Casting
            // WRONG: var button = (button)sender; // C-style cast - crashes if wrong
            // CORRECT: var button = sender as Button; // as operator - always safe returns typed version or null
            //if (button == null)
            //  return;

            var movie = new Movie();
            movie.Name = _txtName.Text;
            movie.Description = _txtDescription.Text;
            movie.Rating = _comboRating.SelectedText;
            movie.IsClassic = _chkClassic.Checked;

            movie.RunLength = ReadInt32(_txtRunLength);
            movie.ReleaseYear = ReadInt32(_txtReleaseYear);

            //TODO: Fix validation
            var error = movie.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                //Show error message - use for standard messages
                MessageBox.Show(this, error, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            };

            // Return movie
            Movie = movie;
            Close();
        }

        private int ReadInt32 ( Control control )
        {
            var text = control.Text;

            if (Int32.TryParse(text, out var result))
                return result;

            return -1;
        }

        private void _txtReleaseYear_TextChanged ( object sender, EventArgs e )
        {

        }

        private void OnValidateName ( object sender, CancelEventArgs e )
        {
            TextBox control = sender as TextBox;

            //Name is required
            if (String.IsNullOrEmpty(control.Text))
            {
                MessageBox.Show("Name is required");
                e.Cancel = true; //Not valid
            }
        }

        private void OnValidateRunLength ( object sender, CancelEventArgs e )
        {

        }

        private void OnValidateReleaseYear ( object sender, CancelEventArgs e )
        {

        }
    }
}
