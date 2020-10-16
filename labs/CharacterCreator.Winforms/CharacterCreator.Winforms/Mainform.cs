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
        private Character _character;

        public Mainform()
        {
            InitializeComponent();

            Character character;
            character = new Character();

            _miFileExit.Click += OnExit;
            _miHelpAbout.Click += OnHelpAbout;
            _miCharacterNew.Click += OnCharacterNew;
            _miCharacterDelete.Click += OnCharacterDelete;
            _miCharacterEdit.Click += OnCharacterEdit;
        }

        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            if (_character == null)
                return;

            var form = new Characterform();
            form.Character = _character;

            var result = form.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            _character = form.Character;

            MessageBox.Show("Save successful!");
        }

        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            if (_character == null)
                return;

            switch (MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes: break;
                    case DialogResult.No: return;
                };

            _character = null;
        }

        private void OnCharacterNew ( object sender, EventArgs e )
        {
            var form = new Characterform();
            
            var result = form.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            _character = form.Character;

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

        public void RefreshRoster ()
        {
            var roster = new BindingList<Character>();

            roster.Add(_character);

            _lstRoster.DataSource = roster;

            _lstRoster.DisplayMember = _character.Name;
        }
    }
}
