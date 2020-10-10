using System;
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

            _menuExit.Click += OnExit;
        }

        private void OnExit (object sender, EventArgs e )
        {
            Close();
        }
    }
}
