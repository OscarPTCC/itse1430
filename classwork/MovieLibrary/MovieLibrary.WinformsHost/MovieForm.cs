﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MovieLibrary.WinformsHost
{
    public partial class MovieForm : Form
    {
        public MovieForm ()
        {
            InitializeComponent();
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

            //TODO: Return movie
            Close();
        }
        private int ReadInt32 ( Control control )
        {
            var text = control.Text;

            if (Int32.TryParse(text, out var result))
                return result;

            return -1;
        }
    }
}
