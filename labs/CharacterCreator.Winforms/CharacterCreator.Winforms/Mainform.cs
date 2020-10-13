﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();

            _miFileExit.Click += OnExit;
            _miHelpAbout.Click += OnHelpAbout;
            _miCharacterNew.Click += OnCharacterNew;
        }

        Character _character;
        private void OnCharacterNew ( object sender, EventArgs e )
        {
            var form = new Characterform();

            var result = form.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            MessageBox.Show("Save successful!");
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }

        private void OnExit (object sender, EventArgs e )
        {
            Close();
        }
    }
}
