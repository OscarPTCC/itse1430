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
            };

            ValidateChildren();
        }

        private void OnCancel ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnSave ( object sender, EventArgs e )
        {
            if (!ValidateChildren())
            {
                DialogResult = DialogResult.None;
                return;
            }

            var character = new Character();
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

            var validationResults = new ObjectValidator().TryValidateFullObject(character);
            if (validationResults.Count() > 0)
            {
                var builder = new System.Text.StringBuilder();
                foreach (var result in validationResults)
                {
                    builder.AppendLine(result.ErrorMessage);
                };

                MessageBox.Show(this, builder.ToString(), "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void OnValidateName ( object sender, CancelEventArgs e )
        {
            TextBox control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _error.SetError(control, "Name is required");
                e.Cancel = true;
            } else
                _error.SetError(control, "");
        }

        private void OnValidateProfession ( object sender, CancelEventArgs e )
        {
            ComboBox control = sender as ComboBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _error.SetError(control, "Profession is required");
                e.Cancel = true;
            } else
                _error.SetError(control, "");
        }

        private void OnValidateRace ( object sender, CancelEventArgs e )
        {
            ComboBox control = sender as ComboBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _error.SetError(control, "Race is required");
                e.Cancel = true;
            } else
                _error.SetError(control, "");
        }

        private void OnValidateHP ( object sender, CancelEventArgs e )
        {
            TextBox control = sender as TextBox;

            int value = ReadInt32(control);

            if (value < 0 || value > 52)
            {
                _error.SetError(control, "HP must be between 0 and 52");
                e.Cancel = true;
            } else
                _error.SetError(control, "");
        }

        private void OnValidateStrength ( object sender, CancelEventArgs e )
        {
            TextBox control = sender as TextBox;

            int value = ReadInt32(control);

            if (value < 0 || value > 40)
            {
                _error.SetError(control, "Strength must be between 0 and 40");
                e.Cancel = true;
            } else
                _error.SetError(control, "");
        }

        private void OnValidateMagic ( object sender, CancelEventArgs e )
        {
            TextBox control = sender as TextBox;

            int value = ReadInt32(control);

            if (value < 0 || value > 40)
            {
                _error.SetError(control, "Magic must be between 0 and 40");
                e.Cancel = true;
            } else
                _error.SetError(control, "");
        }

        private void OnValidateSkill ( object sender, CancelEventArgs e )
        {
            TextBox control = sender as TextBox;

            int value = ReadInt32(control);

            if (value < 0 || value > 40)
            {
                _error.SetError(control, "Skill must be between 0 and 40");
                e.Cancel = true;
            } else
                _error.SetError(control, "");
        }

        private void OnValidateSpeed ( object sender, CancelEventArgs e )
        {
            TextBox control = sender as TextBox;

            int value = ReadInt32(control);

            if (value < 0 || value > 40)
            {
                _error.SetError(control, "Speed must be between 0 and 40");
                e.Cancel = true;
            } else
                _error.SetError(control, "");
        }

        private void OnValidateLuck ( object sender, CancelEventArgs e )
        {
            TextBox control = sender as TextBox;

            int value = ReadInt32(control);

            if (value < 0 || value > 40)
            {
                _error.SetError(control, "Luck must be between 0 and 40");
                e.Cancel = true;
            } else
                _error.SetError(control, "");
        }

        private void OnValidateDefense ( object sender, CancelEventArgs e )
        {
            TextBox control = sender as TextBox;

            int value = ReadInt32(control);

            if (value < 0 || value > 40)
            {
                _error.SetError(control, "Defense must be between 0 and 40");
                e.Cancel = true;
            } else
                _error.SetError(control, "");
        }
    }
}
