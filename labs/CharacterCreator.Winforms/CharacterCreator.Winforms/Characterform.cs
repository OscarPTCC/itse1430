using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class Characterform : Form
    {
        public Characterform ()
        {
            InitializeComponent();
        }

        public Character Character { get; set; }

        private void OnCancel ( object sender, EventArgs e )
        {
            Close();
        }
    }
}
