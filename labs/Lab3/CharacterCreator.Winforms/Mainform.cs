/*
 * ITSE 1430
 * Oscar Peinado-Rojo
 * Lab 3
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreator.Memory;

namespace CharacterCreator.Winforms
{
    public partial class Mainform : Form
    {
        public Mainform ()
        {
            InitializeComponent();

            _miFileExit.Click += OnExit;
            _miHelpAbout.Click += OnHelpAbout;
            _miCharacterNew.Click += OnCharacterNew;
            _miCharacterDelete.Click += OnCharacterDelete;
            _miCharacterEdit.Click += OnCharacterEdit;
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            RefreshRoster();
        }

        private ICharacterRoster _character = new MemoryCharacterRoster();

        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            Character character = GetSelectedCharacter();
            if (character == null)
                return;

            Characterform form = new Characterform(character, "Edit Character");

            DialogResult result = form.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            EditCharacter(character.Id, form.Character);

            RefreshRoster();
        }

        private void EditCharacter ( int id, Character character)
        {
            string error = _character.Update(id, character);

            if (String.IsNullOrEmpty(error))
            {
                RefreshRoster();
                return;
            };

            MessageBox.Show(this, error, "Edit Character", MessageBoxButtons.OK);
        }

        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();

            if (character == null)
                return;

            switch (MessageBox.Show(this, $"Are you sure you want to delete '{character.Name}'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes: break;
                case DialogResult.No: return;
            };

            DeleteCharacter(character.Id);

            RefreshRoster();
        }

        private void DeleteCharacter ( int id )
        {
            _character.Delete(id);
        }

        private void OnCharacterNew ( object sender, EventArgs e )
        {
            var form = new Characterform();

            var result = form.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            AddCharacter(form.Character);

            RefreshRoster();
        }

        private void AddCharacter ( Character character )
        {
            var newCharacter = _character.Add(character, out string message);

            if (newCharacter == null)
            {
                MessageBox.Show(this, message, "Add Failed", MessageBoxButtons.OK);
                return;
            };

            return;
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }

        private void OnExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void RefreshRoster ()
        {
            _lstRoster.DataSource = _character.GetAll().ToArray();
        }

        private Character GetSelectedCharacter ()
        {
            return _lstRoster.SelectedItem as Character;
        }
    }
}
