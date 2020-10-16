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

        private void OnSave ( object sender, EventArgs e )
        {
            Character character = new Character();
            character.Name = _txtName.Text;
            character.Profession = _comboProfession.Text;
            character.Race = _comboBoxRace.Text;
            character.Description = _txtDescription.Text;

            character.HP = ReadInt32(_txtHP);
            character.Strength = ReadInt32(_txtStrength);
            character.Magic = ReadInt32(_txtMagic);
            character.Skill = ReadInt32(_txtSkill);
            character.Speed = ReadInt32(_txtSpeed);
            character.Luck = ReadInt32(_txtLuck);
            character.Defense = ReadInt32(_txtDefense);

            string error = character.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                MessageBox.Show(this, error, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            };

            Character = character;
            Close();
        }

        private int ReadInt32 ( Control control)
        {
            string text = control.Text;

            if (Int32.TryParse(text, out int result))
                return result;

            return -1;
        }
    }
}
