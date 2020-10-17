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

        public Characterform ( Character character ) : this(character, null)
        {

        }

        public Characterform ( Character character, string title ) : this()
        {
            Character = character;
            Text = title ?? "Add New Character";
        }

        public Character Character { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (Character != null)
            {
                _txtName.Text = Character.Name;
                _comboProfession.Text = Character.Profession;
                _comboBoxRace.Text = Character.Race;
                _txtDescription.Text = Character.Description;

                _txtHP.Text = Character.HP.ToString();
                _txtStrength.Text = Character.Strength.ToString();
                _txtMagic.Text = Character.Magic.ToString();
                _txtSkill.Text = Character.Skill.ToString();
                _txtSpeed.Text = Character.Speed.ToString();
                _txtLuck.Text = Character.Luck.ToString();
                _txtDefense.Text = Character.Defense.ToString();
            }
        }

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

        private int ReadInt32 ( Control control )
        {
            string text = control.Text;

            if (Int32.TryParse(text, out int result))
                return result;

            return -1;
        }
    }
}
