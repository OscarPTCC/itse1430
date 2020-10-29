using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
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
                _comboRating.Text = Movie.Rating;
                _chkClassic.Checked = Movie.IsClassic;
                _txtRunLength.Text = Movie.RunLength.ToString();
                _txtReleaseYear.Text = Movie.ReleaseYear.ToString();
            };

            // Go ahead and show validation errors
            ValidateChildren();
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
            //Forces validation of all controls
            if (!ValidateChildren())
            {
                DialogResult = DialogResult.None;
                return;
            }
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

            //Validate
            //TODO: Fix type validate
            var validationResults = new ObjectValidator().TryValidateFullObject(movie);
            if (validationResults.Count() > 0)
            {
                //TODO: Fix this later using String.Join
                var builder = new System.Text.StringBuilder();
                foreach (var result in validationResults)
                {
                    builder.AppendLine(result.ErrorMessage);
                };

                //Show error message
                MessageBox.Show(this, builder.ToString(), "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _errors.SetError(control, "Name is required");
                e.Cancel = true; //Not valid
            }
            else
            {
                //Clear error from provider
                _errors.SetError(control, "");
            };
        }

        private void OnValidateRunLength ( object sender, CancelEventArgs e )
        {
            TextBox control = sender as TextBox;


            var value = ReadInt32(control);

            //Name is required
            if (value < 0)
            {
                _errors.SetError(control, "Run Length must be >= 0");
                e.Cancel = true; //Not valid
            } else
            {
                //Clear error from provider
                _errors.SetError(control, "");
            };
        }

        private void OnValidateReleaseYear ( object sender, CancelEventArgs e )
        {
            TextBox control = sender as TextBox;

            var value = ReadInt32(control);

            //Name is required
            if (value < 1900)
            {
                _errors.SetError(control, "Release Year must be >= 1900");
                e.Cancel = true; //Not valid
            } else
            {
                //Clear error from provider
                _errors.SetError(control, "");
            };
        }

        private void PlayWithObjects( object value )
        {
            //Common type System (CTS) - ther is 1 base type from which all other types derive
            //  System.Object => object
            //      string ToString () ::= Converts a value to a string
            //      bool Equals ( object ) ::= Determines if the curent instance equals another value
            //      in GetHashCode () ::= Returns an integral value representing the object
            var str = 10.ToString(); //"10"
            var form = new Form();
            form.ToString(); // System.Windows.Forms.form

            //Type checking or casting
            // 1. C-Style cast ::= (T)E
            //      Runtime attempts to convert value to T and if successful returns value as T else crashes
            //      Must be compile time validated
            string stringValue = (string)value;

            // 2. as-operator ::= E as T
            //      Runtime attempts to convert value to T and if succcessful returns value as T else returns null
            stringValue = value as string;
            if (stringValue != null)
            { /*dealing with string */ }

            // 3. is-operator ::= E is T
            //      Runtime verifies value is of given T and returns true if successful or false otherwise
            var isString = value is string;
            if (isString)
            {
                stringValue = (string)value;
            }

            // 4. pattern-matching ::= E is T identifier
            //      Runtime attempts to convert E to T and if successful stores in identifier else stores default(T)
            if (value is string sValue)
            {
                //string sValue = value as string
                //if (sValue != null)
            }

            //Dealing with null
            // 1. Let it fail - instance.ToString() //errors if null
            // 2. null-coalesce-operator ::= E1 ?? E2
            //      If E1 is not null, return E1, else returns E2
            stringValue = stringValue ?? "";

            // 3. null-conditional-operator ::= E?.M
            //      E is an instance, M is any member, if E is not null then call M else skip it
            //      .ToString() => string
            //      ?.ToString() => string | null
            stringValue = stringValue?.ToString() ?? "";
            // if (stringValue != null)
            //      var temp = stringValue.ToString();
            //      if (temp != null) return "";
            // return ""

            // 4. null reference types
        }
    }
}
