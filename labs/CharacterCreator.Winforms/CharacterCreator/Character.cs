/*
 * ITSE 1430
 * Oscar Peinado-Rojo
 * Lab 2 "Character Creator"
*/
using System;

namespace CharacterCreator
{
    ///<summary>Represents a character</summary>
    public class Character
    {
        private string _name = "";
        private string _description = "";
        private string _profession = "";
        private string _race = "";

        /// <summary>The name of the character</summary>
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value; }
        }

        /// <summary>Gets or sets the character description</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }

        /// <summary>Gets or sets the character profession</summary>
        public string Profession
        {
            get { return _profession ?? ""; }
            set { _profession = value; }
        }

        /// <summary>Gets or sets the character race</summary>
        public string Race
        {
            get { return _race ?? ""; }
            set { _race = value; }
        }

        /// <summary>The character's Strength stat</summary>
        /// <value>The maximum value is 40</value>
        public int Strength { get; set; }

        /// <summary>The character's Magic stat</summary>
        ///  <value>The maximum value is 40</value>
        public int Magic { get; set; }

        /// <summary>The character's Skill stat</summary>
        /// <value>The maximum value is 40</value>
        public int Skill { get; set; }

        /// <summary>The character's Speed stat</summary>
        /// <value>The maximum value is 40</value>
        public int Speed { get; set; }

        /// <summary>The character's Luck stat</summary>
        /// <value>The maximum value is 40</value>
        public int Luck { get; set; }

        /// <summary>The character's Defense stat</summary>
        /// <value>The maximum value is 40</value>
        public int Defense { get; set; }

        /// <summary>The character's HP or Hit Points stat</summary>
        /// <value>The maximum value is 52</value>
        public int HP { get; set; }

        public string Validate ()
        {
            if (String.IsNullOrEmpty(Name))
                return "Name is required";

            if (String.IsNullOrEmpty(Profession))
                return "Profession is required";

            if (String.IsNullOrEmpty(Race))
                return "Race is required";

            if (Strength < 0 || Strength > 40)
                return "Strength value must be between 0 and 40";

            if (Magic < 0 || Magic > 40)
                return "Magic value must be between 0 and 40";

            if (Skill < 0 || Skill > 40)
                return "Skill value must be between 0 and 40";

            if (Speed < 0 || Speed > 40)
                return "Speed value must be between 0 and 40";

            if (Luck < 0 || Luck > 40)
                return "Luck value must be between 0 and 40";

            if (Defense < 0 || Defense > 40)
                return "Defense value must be between 0 and 40";

            if (HP < 0 || HP > 52)
                return "HP value must be between 0 and 52";

            return null;
        }
    }
}
